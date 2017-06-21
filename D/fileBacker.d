/*
Author: http://lemming.life
Project: fileBacker.d
Date: June 21, 2017
Language: D
Compile tool: rdmd from http://dlang.org
Details:
 - Copy files from source drive to destination drive.
 - If source and destination file modified-times are different then override.
 - Remove files found in destination that are not in source.
 - Keeps log as backupLog.txt

Note:
 - Recommend using some kind of scheduler (in Windows use Task Scheduler)

To compile:
rdmd --build-only fileBacker.d

To run (on Windows), where D: and E: are the source and destination drives, respectively.
fileBacker.exe D: E:
*/

import std.file: append, copy, DirEntry, dirEntries, exists, isDir, mkdir, remove, rmdirRecurse, SpanMode;
import std.datetime;
import std.conv: to;
import std.stdio: writeln;
import std.exception; 

void main(string[] args) {
    if (args.length != 3) return;
    string[] messages;
    int copyCount, removedFileCount, removedFolderCount;
    const int MAX_MESSAGES = 99;

    // Write the log
    auto backupLog = "backupLog.txt";
    append(backupLog, "\n\nBACKUP START: " ~ (to!DateTime(Clock.currTime)).toSimpleString);
    append(backupLog, "\nMessages:");

    // Finish writing the log
    scope(exit) {
        logMessages(backupLog, messages);
        append(backupLog, "\n - Files/folders copied: " ~ to!string(copyCount));
        append(backupLog, "\n - Removed files count: " ~ to!string(removedFileCount));
        append(backupLog, "\n - Removed folders count: " ~ to!string(removedFolderCount));
        append(backupLog, "\nBACKUP COMPLETED: " ~ (to!DateTime(Clock.currTime)).toSimpleString);
    }

    // For readability
    string sourceDrive = args[1];
    string destinationDrive = args[2];

    // Copy files from source drive to destination drive.
    // If source and destination file modified-times are different then override.
    foreach(sourceFile; dirEntries(sourceDrive, SpanMode.breadth)) {
        string destinationFile = destinationDrive ~ sourceFile[destinationDrive.length .. $];
        try {
            if ( sourceFile.isDir && !destinationFile.exists ) { destinationFile.mkdir; ++copyCount; }

            if ( sourceFile.isFile ) {
                if ( destinationFile.exists )  {
                    auto sourceTime = sourceFile.timeLastModified;
                    auto destinationTime = (new DirEntry(destinationFile)).timeLastModified;

                    if ( sourceTime != destinationTime ) {
                        remove(destinationFile);
                        copy(sourceFile, destinationFile);
                        ++copyCount;
                    }
                } else {
                    copy(sourceFile, destinationFile);
                    ++copyCount;
                }
            }
        } catch (Exception e) {
            if (messages.length > MAX_MESSAGES) { logMessages(backupLog, messages); }
            messages ~= "\n - Failed to copy: " ~ sourceFile;
            
        }
    }

    // Remove files found in destination that are not in source.
    foreach(destinationFile; dirEntries(sourceDrive, SpanMode.breadth)) {
        string sourceFile = destinationDrive ~ destinationFile[sourceDrive.length .. $];
        try {
            if ( !sourceFile.exists ) {
                if ( destinationFile.isFile ) { remove(destinationFile); ++removedFileCount; }
                if ( destinationFile.isDir ) { rmdirRecurse(destinationFile); ++removedFolderCount; }
            }
        } catch (Exception e) {
            if (messages.length > MAX_MESSAGES) { logMessages(backupLog, messages); }
            messages ~= "\n - Failed to remove: " ~ sourceFile;
        }
    }
}

void logMessages(string backupLog, ref string[] messages) {
    if (messages.length>0) {
        foreach(message; messages) {
            append(backupLog, message);
        }
    }
    messages.length = 0;
}