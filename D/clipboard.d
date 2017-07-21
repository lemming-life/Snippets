// Author: http://lemming.life
// Language: D
// Description: A class with access to clipboard features.
// Testing:
// rdmd -unittest -main clipboard.d

// Info:
// Linux xclip : http://linux.softpedia.com/get/Text-Editing-Processing/Others/xclip-42705.shtml
// OSX pbcopy pbpaste : https://developer.apple.com/legacy/library/documentation/Darwin/Reference/ManPages/man1/pbpaste.1.html
// Windows Clipboard : https://msdn.microsoft.com/en-us/library/windows/desktop/ms648709(v=vs.85).aspx

module clipboard;
import std.conv : to;

// Import platform specific
version ( Windows ) {
    extern ( Windows ) {
        bool OpenClipboard(void*);
        bool EmptyClipboard();
        bool CloseClipboard();
        // todo
    }
} else {
    // Linux and OSX
    import std.algorithm : joiner, map, reduce;
    import std.array;
    import std.process : pipeProcess, ProcessPipes, Redirect, wait;
}

class Clipboard {
    static dstring readText() {
        version( Windows ) {
            if (!OpenClipboard(null)) { return ""d; } 
            scope(exit) { CloseClipboard(); }
            // todo
            
        } else {
            ProcessPipes pipes;
            scope(exit) { wait(pipes.pid); }

            version( linux ) {
                pipes = pipeProcess(["xclip", "-o", "-selection", "clipboard"], Redirect.stdout);
            } else version ( OSX ) {
                pipes = pipeProcess(["pbpaste"], Redirect.stdout);
            }

            auto message = pipes.stdout.byChunk(4096).joiner.array;
            return message.length == 0 ? ""
                    : reduce!( (soFar,b) => soFar ~= b ) (message.map!( a=> to!dstring( to!dchar(a) )));
        }
    }

    static void writeText(dstring text) {
        version( Windows ) {
            if (!OpenClipboard(null)) { return ""d; } 
            scope(exit) { CloseClipboard(); }
            // todo

        } else {
            ProcessPipes pipes;
            scope(exit) { wait(pipes.pid); }
            
            version( linux ) {
                pipes = pipeProcess(["xclip", "-i", "-selection", "clipboard"], Redirect.stdin);
            } else version( OSX ) {
                pipes = pipeProcess(["pbcopy"], Redirect.stdin);
            }

            with(pipes) {
                stdin.write(text);
                stdin.flush();
                stdin.close();
            }
        }
    }

    static void clear() {
        version( Windows ) {
            EmptyClipboard();
        } else {
            writeText(""d);
        }
    }
}


unittest {
    import std.stdio : writeln;
    auto testString = "Test String"d;
    
    Clipboard.clear();
    assert( Clipboard.readText().length == 0 );

    Clipboard.writeText(testString);
    assert( Clipboard.readText() == testString);
}