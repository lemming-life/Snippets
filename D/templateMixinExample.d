// Author: http://lemming.life
// Language: D
// Description: Demonstration of D's Template Mixin

// Test: rdmd -unittest -main templateMixinExample.d

mixin template MixinFoo(T) {
    T sum(T)(T a, T b) {
        return a + b; // This line runs 3 times on the unittest
    }

    T value;
}

class Ints {
    // Ints now has a sum method for int types, and a member value of int
    mixin MixinFoo!(int);

    this() {
        value = int.max;
    }
}

class Doubles {
    // Doubles now has a sum method for double types, and a member value of double
    mixin MixinFoo!(double); 

    this() {
        value = double.max;
    }
}

unittest {
    auto myInts = new Ints();
    auto myDoubles = new Doubles();
    mixin MixinFoo!real; // a local sum function, and a real value variable

    assert( myInts.sum(2, 3) == 5 );
    assert( myInts.value == int.max );

    assert( myDoubles.sum(2.0, 3.0) == 5.0 );
    assert( myDoubles.value == double.max );

    import std.math : isNaN;
    assert( sum(2.0, 3.0) == 5.0 );
    assert( value.isNaN == true ); // value is a real and initially is a NaN
}


// Coverage testing: (times line ran during execution)|(line details)
/*
       |// Author: http://lemming.life
       |// Language: D
       |// Description: Demonstration of D's Template Mixin
       |
       |// Test: rdmd -unittest -main templateMixinExample.d
       |
       |mixin template MixinFoo(T) {
      1|    T sum(T)(T a, T b) {
      3|        return a + b; // This line runs 3 times on the unittest
       |    }
       |
      1|    T value;
       |}
       |
       |class Ints {
       |    // Ints now has a sum method for int types, and a member value of int
       |    mixin MixinFoo!(int);
       |
      1|    this() {
      1|        value = int.max;
       |    }
       |}
       |
       |class Doubles {
       |    // Doubles now has a sum method for double types, and a member value of double
       |    mixin MixinFoo!(double); 
       |
      1|    this() {
      1|        value = double.max;
       |    }
       |}
       |
       |unittest {
      1|    auto myInts = new Ints();
      1|    auto myDoubles = new Doubles();
       |    mixin MixinFoo!real; // a local sum function, and a real value variable
       |
      1|    assert( myInts.sum(2, 3) == 5 );
      1|    assert( myInts.value == int.max );
       |
      1|    assert( myDoubles.sum(2.0, 3.0) == 5.0 );
      1|    assert( myDoubles.value == double.max );
       |
       |    import std.math : isNaN;
      1|    assert( sum(2.0, 3.0) == 5.0 );
      1|    assert( value.isNaN == true ); // value is a real and initially is a NaN
       |}
templateMixinExample.d is 100% covered
*/