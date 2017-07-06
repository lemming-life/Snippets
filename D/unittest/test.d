// Author: http://lemming.life
// Language: D
// Description: Shows how to use unit testing in D for a Test class.
// - also has coverage anlysis test
// More info: https://wiki.dlang.org/Unittest

// The commands below doe the following:
// -unittest : Runs all the unittest blocks
// -cov : Performs a coverage analysis test
// -main : inserts an empty main function.

/* At terminal do:
    dmd -unittest -cov -main test.d
    ./test
*/


class Test {
    string getString() { return "meow"; }   

    unittest {
        auto test = new Test();
        assert(test.getString() == "meow");
    } 
}

// The .lst file
// (number of times ran) | (line details)

// test.lst file contents
/*
       |class Test {
      1|    string getString() { return "meow"; }   
       |
       |    unittest {
      1|        auto test = new Test();
      1|        assert(test.getString() == "meow");
       |    } 
       |}
*/