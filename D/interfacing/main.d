// Author: http://lemming.life
// Language: D
// Description: Small example on how D interfaces with C++ and C.
// - There is also a small description on how to compile the files.

/* At terminal do:
    g++ -c foo.cpp
    gcc -c bar.c
    dmd -c main.d
    dmd main.o foo.o bar.o
*/

// Run the final product: ./main

extern(C++) int foo(int a, int b);
extern(C) char bar(char c);

void main() {
    import std.stdio : writeln;
    foo(3, 5).writeln;
    bar('a').writeln;
}

/* Expected output:
8
Input character is a. Output is b
*/