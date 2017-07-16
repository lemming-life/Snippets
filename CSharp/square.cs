// Author: http://lemming.life
// Language: C#
// Purpose: Returns the square of a number.
// Date: July 25, 2017

using System;
using System.IO;

namespace Snippets {

    public class Square {
        public static int square(int x) {
            return x * x;
        }

        public static void executeDriver() {
            int n;

            n = 2;
            Console.WriteLine("The square of {0} is {1}", n, Square.square(n));

            n = 6;
            Console.WriteLine("The square of {0} is {1}", n, Square.square(n));
        }
    }

}