// Author: http://lemming.life
// Project: backup.d
// Date: June 20, 2017
// Requires: rdmd from http://dlang.org
// Details:
// - Prepares (removes contents of) a drive as best as it can.
// - Copies files from source drive to destination drive.

// To compile:
// rdmd --build-only backup.d

// Run on Windows:
// backup.exe D: E:

import std.file: dirEntries, SpanMode, remove, rmdirRecurse, copy, mkdir;
import std.stdio: writeln;
import std.exception;

void main(string[] args) {
    if (args.length != 3) return;
    string msg = "";

    scope(exit) { 
        if (msg.length>0) {
            "Errors:".writeln;
            msg.writeln;
        } else {
            "Done with zero errors.".writeln;
        }
    }

    string sourceDrive = args[1];
    string destinationDrive = args[2];

    // If possible, remove files from destination drive.
    writeln("Preparing destination drive: " ~ destinationDrive);
    foreach(file; dirEntries(destinationDrive, SpanMode.shallow)) {
        try {
            if (file.isFile) { remove(file); }
            if (file.isDir) { rmdirRecurse(file); }
        } catch (Exception e) {
            msg ~= "\n Failed to remove " ~ file;
        }
    }
    
    // Copy files to destination drive.
    writeln("Copying files to " ~ destinationDrive);
    foreach (sourceFile; dirEntries(sourceDrive, SpanMode.breadth)) {
        string destinationFile = destinationDrive ~ sourceFile[destinationDrive.length .. $];
        try {
            if ( sourceFile.isDir ) { destinationFile.mkdir; }
            if ( sourceFile.isFile ) { copy(sourceFile, destinationFile); }
        } catch (Exception e) {
            msg ~= "\n Cannot copy from " ~ sourceFile ~ " to " ~ destinationFile;
        }
    }
}