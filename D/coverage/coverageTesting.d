// Author: http://lemming.life
// Language: D
// Description: an example of D's coverage analysis


/* At terminal do:
    dmd -cov coverageTesting
    ./coverageTesting
*/

// Now open coverageTesting.lst

import std.stdio;

void main() {
    int i = 0;
    while(i < 10) {
        i = i + 1;
    }
}

// The .lst file
// (number of times ran) | (line details)

// coverageTesting.lst file
/*
       |import std.stdio;
       |
       |void main() {
      1|    int i = 0;
     11|    while(i < 10) {
     10|        i = i + 1;
       |    }
       |}
coverageTesting.d is 100% covered
*/