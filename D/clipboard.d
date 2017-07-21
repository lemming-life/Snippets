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
    import core.sys.windows.windows;
    import core.stdc.wchar_ : wcslen;
    import std.utf : toUTF16z;

    extern ( Windows ) {
        bool OpenClipboard(void*);
        bool CloseClipboard();
        
        // For Reading
        void* GetClipboardData(uint);

        // For Writing
        bool EmptyClipboard();
        void* SetClipboardData(uint, void*);
        void* GlobalLock(void*);
        bool GlobalUnlock(void*);
        void* GlobalAlloc(uint, size_t);
    }

    const int CF_UNICODETEXT = 13;
    const uint GMEM_FIXED = 0;      // Fixed memory

} else {
    // Linux and OSX
    import std.algorithm : joiner, map;
    import std.array;
    import std.process : pipeProcess, ProcessPipes, Redirect, wait;
}

class Clipboard {
    static wstring readText() {
        version( Windows ) {
            if (!OpenClipboard(null)) { return ""w; } 
            scope(exit) { CloseClipboard(); }
            
            wchar* data = cast(wchar*) GetClipboardData(CF_UNICODETEXT);
            if (data) {
                return to!wstring(data[0 .. wcslen(data)]);
            }
        } else {
            ProcessPipes pipes;
            scope(exit) { wait(pipes.pid); }

            version( linux ) {
                pipes = pipeProcess(["xclip", "-o", "-selection", "clipboard"], Redirect.stdout);
            } else version ( OSX ) {
                pipes = pipeProcess(["pbpaste"], Redirect.stdout);
            }

            auto data = pipes.stdout.byChunk(4096).joiner.array;

            if (data.length > 0) {
                //return reduce!( (soFar,b) => soFar ~= b ) (data.map!( a=> to!dstring( to!dchar(a) )));
                auto wdata = data.map!( a=> to!wchar(a));
                return to!wstring( wdata[0 .. $] );
            }
        }

        return ""w;
    }

    static void writeText(wstring text) {
        version( Windows ) {
            if (!OpenClipboard(null)) { return ""w; } 
            scope(exit) { CloseClipboard(); }
            EmptyClipboard();

            //const wchar* data = toUTF16z(text);

            // Allocate global memory
            const int dataLength = (text.length + 1) * wstring.sizeof;
            void* handleGlobal = GlobalAlloc(GMEM_FIXED, dataLength);
            void* memPtr = GlobalLock(handleGlobal);

            // Copy the text to the buffer
            memcpy(memPtr, toUTF16z(text), dataSize);

            // Unlock
            GlobalUnlock(handleGlobal);

            // Place the handle on the clipboard
            SetClipboardData(CF_UNICODETEXT, handleGlobal);  
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
            writeText(""w);
        }
    }
}


unittest {
    import std.stdio : writeln;
    auto testString = "Test String"w;
    
    Clipboard.clear();
    assert( Clipboard.readText().length == 0 );

    Clipboard.writeText(testString);
    assert( Clipboard.readText() == testString);
}