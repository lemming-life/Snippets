// Author: http://lemming.life
// Title: mainCall Fibonacci
// Notes: This has to be one of the worst Fibonacci calls ever.
//        But its emphasis is  in that you can call main from main. :)
// Run: rdmd mainCallFib.d 12
// Expected output: 144

import std.stdio : writeln, write;
import std.conv: to;

int main(string[] args) {
    if (args.length == 2) { args ~= args[1]; }  // Append the initial number to args (marks the initial number)
    int result;
    scope(exit) (args[2] == args[1] ? result.writeln : "".write); // When the first main frame exits print the result.

    int n = to!int(args[1]);    // Convert to number
    if (n == 0) { return 0; }   // Base case
    if (n == 1) { return 1; }   // Base case
    result = main(["", to!string(n-1), args[2]]) + main(["", to!string(n-2), args[2]]); // Call main twice, store the result
    return result;
}