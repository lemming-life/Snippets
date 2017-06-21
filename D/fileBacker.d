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

import std.algorithm: each;
import std.file: append, copy, DirEntry, dirEntries, exists, isFile, isDir, mkdir, rename, remove, rmdirRecurse, SpanMode;
import std.datetime;
import std.conv: to;
import std.stdio: writeln, File;
import std.exception; 

void main(string[] args) {
    if (args.length != 3) return;

    string[] messages;
    int copyCount, removedFileCount, removedFolderCount;
    const int MAX_MESSAGES = 99;

    // Begin writing the log.
    auto backupLogName = "backupLogTemp.txt";
    append(backupLogName, "BACKUP START: " ~ (to!DateTime(Clock.currTime)).toSimpleString);
    append(backupLogName, "\nMessages:");

    // Functions for saving log
    void logMessages() { messages.each!(message => append(backupLogName, message)); }
    void logOffloadMessages() { if (messages.length > MAX_MESSAGES) { logMessages; } }

    // Finish writing the log
    scope(exit) {
        // Save remaining messages
        logMessages;
        append(backupLogName, "\n - Files/folders copied: " ~ to!string(copyCount));
        append(backupLogName, "\n - Removed files count: " ~ to!string(removedFileCount));
        append(backupLogName, "\n - Removed folders count: " ~ to!string(removedFolderCount));
        append(backupLogName, "\nBACKUP COMPLETED: " ~ (to!DateTime(Clock.currTime)).toSimpleString);
        
        // Begin saving the final log
        string backupLogFinalName = "backupLogFinal.txt";
        auto backupLogFinal = File(backupLogFinalName, "w");

        // Save this run's log
        auto backupLog = File(backupLogName);
        foreach(line; backupLog.byLine()) { backupLogFinal.writeln(line); }
        backupLog.close;

        // Save the previous log
        string backupLogExistingName = "backupLog.txt";
        if (backupLogExistingName.exists) {
            auto backupLogExisting = File(backupLogExistingName);
            foreach( line; backupLogExisting.byLine()) {
                backupLogFinal.writeln(line);
            }
            backupLogExisting.close;
        }

        // Close the final log
        backupLogFinal.close;

        // Cleanup
        remove(backupLogName);
        remove(backupLogExistingName);
        rename(backupLogFinalName, backupLogName);
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
            logOffloadMessages;
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
            logOffloadMessages;
            messages ~= "\n - Failed to remove: " ~ sourceFile;
        }
    }
}