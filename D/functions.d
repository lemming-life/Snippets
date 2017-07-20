// Author: http://lemming.life
// Language: D
// Purpose: A variety of ways to manipulate functions in D.
// Testing: rdmd -unittest -main functions.d
// - Expect blank console if success. Otherwise unittest failure

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
auto combiFunc(alias funcA, alias funcB, T)(T a) {
    return funcB( funcA(a) );
}

// Construct a function from other functions, but waits for some input.
// - Evaluates from left to right.
auto combineFunctions(T)(T function(T)[] funcs) {
    import std.algorithm : reduce;
    return (T x) => reduce!( (sofar, f) => f(sofar) ) (x, funcs);
}

auto square(T)(T a) { return a * a; }

unittest { 
    alias aMul = (a, b) => a * b;
    alias aSum = (a, b) => a + b;
    alias aDiv = (a, b) => a / b;
    //alias aPrint = (a) => a.writeln;
    alias aSquare = square!(int);

    assert(aMul(2, 3) == 6);       
    assert(executeFunction!(aSum)(6, 3) == 9);
    assert(executeFunction2!(aDiv, double)(5, 2) == 2.5);
    assert(combiFunc!( aSquare, aSquare )(5) == 625);

    auto combinedFuncs = combineFunctions([ (int a) => a + a, &square!(int) ]);
    assert(combinedFuncs(3) == 36); // 36 b/c  3+3 = 6, then 6*6 = 36
}