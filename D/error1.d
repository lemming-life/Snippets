// Author: http://lemming.life
// Language: D
// Purpose: Demonstrates what could be an error in the D language.
// - It looks as it is reusing the same spot in memory without initializing the x member.
// - At the moment it seems that if we have an object in class we got to initialize it at the constructor.

import std.stdio : write, writeln;
import std.conv : to;

class A {
    int x;
}

// Error one.
class B {
    A a = new A();
    this() {
        a.x += 2;
    }
}

// Behaves as expected.
class C {
    A a;
    this() {
        a = new A();
        a.x += 2;
    }
}

void main(string[] args) {
    const int ITERATIONS = 4;

    writeln("Outputs: 2 4 6 8");
    for (int i=0; i<ITERATIONS; ++i) {
        auto b = new B();
        write(to!string(b.a.x) ~ " ");
    }

    writeln("\nOutputs: 2 2 2 2");
    for (int i=0; i<ITERATIONS; ++i) {
        auto c = new C();
        write(to!string(c.a.x) ~ " ");
    }

}