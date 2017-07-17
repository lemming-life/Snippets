// Author: http://lemming.life
// Language: D
// Purpose: A variety of ways to manipulate functions in D.

import std.stdio : writeln;

// Auto determines the type to use.
T executeFunction(alias func, T)(T a, T b) {
    return func(a, b);
}

// Specifies the type to use.
T executeFunction2(alias func, T)(T a, T b) {
    return func!(T)(a, b);
}

// Combines functions when evaluating
void combiFunc(alias funcA, alias funcB, T)(T a) {
    funcB( funcA(a) );
}

// Construct a function from other functions, but waits for some input.
// - Evaluates from left to right.
auto combineFunctions(T)(T function(T)[] funcs) {
    import std.algorithm : reduce;
    return (T x) => reduce!( (sofar, f) => f(sofar) ) (x, funcs);
}

auto square(T)(T a) { return a * a; }

void main(string[] args) {
    alias aMul = (a, b) => a * b;
    alias aSum = (a, b) => a + b;
    alias aDiv = (a, b) => a / b;
    alias aPrint = (a) => a.writeln;
    alias aSquare = square!(int);

    aMul(2, 3).writeln;                             // 6
    executeFunction!(aSum)(6, 3).writeln;           // 9
    executeFunction2!(aDiv, double)(5, 2).writeln;  // 2.5
    combiFunc!( aSquare, aPrint )(5);               // 25

    auto combinedFuncs = combineFunctions([ (int a) => a + a, &square!(int) ]);
    combinedFuncs(3).writeln; // 36 b/c  3+3 = 6, then 6*6 = 36
}