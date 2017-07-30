// Author: http://lemming.life
// Language: D
// Description: Spawn threads, make each wait for some time, then execute a function.

// Test: rdmd -unittest -main timing.d

import std.concurrency : spawn;
import std.datetime; // StopWatch and to

void worker(int seconds, ref StopWatch sw) {
    sw.start();
    while(sw.peek().to!("seconds", int)() < seconds) { }
    sw.stop();
    sw.reset();
    someFunction(seconds);
}

void someFunction(int seconds) {
    import std.stdio : writeln;
    import std.conv : to;
    writeln("Hello, World! Seconds: " ~ to!string(seconds));
}

unittest {
    import std.stdio : writeln;
    "Starting workers".writeln;
    StopWatch sw1, sw2;
    spawn(&worker, 4, sw1);  // worker will call someFunction in 4 seconds.
    spawn(&worker, 2, sw2);  // worker will call someFunction in 2 seconds.
    "Workers are still running ...".writeln;
}