// Author: http://lemming.life
// Language: D
// Description: an example of D's coverage analysis and unittesting

/* At terminal do:
    rdmd -unittest -cov -main test.d
*/

// Now open test.lst to view results. Format: (times ran)|(line details)

class Test {
    string getString() {
        return "meow";
    }   

    unittest {
        auto test = new Test();
        assert(test.getString() == "meow");

        for(int i=0; i<10; ++i) {
            // nothing
        }

        int x = 0;
        while (x<10) {
            ++x;
        }
    } 
}

// More unit testing
unittest {
    auto test = new Test();
    assert(test.getString() == "meow");
}