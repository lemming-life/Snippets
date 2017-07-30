// Author: http://lemming.life
// Language: D
// Description: Shows how to utilize std.datetime's StopWatch

// Test: rdmd -unittest -main stopWatchExample.d


unittest {
    import std.datetime;
    import std.stdio : writeln;
    import std.conv;
    StopWatch sw;

    sw.start();
    int x;
    int.max.writeln;
    while(x < int.max) { ++x; }
    sw.peek().to!("seconds", real)().writeln;
    sw.stop();
    sw.reset();

    sw.running.writeln;
    sw.peek().to!("seconds", real)().writeln;

    sw.start();
    uint ux;
    uint.max.writeln;
    while(ux < uint.max) { ++ux; }
    sw.peek().to!("seconds", real)().writeln;
    sw.stop();
    sw.reset();
}