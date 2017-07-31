// Author: http://lemming.life
// Language: C#
// Description: Collection of Math classes and operations.

using System;

namespace Snippets {
    class Maths {
        public static void executeDriver(bool standardIn = false) {
            Console.WriteLine("\nnSubTest: fibonacciIterative");
            for (int n = 0; n < 7; ++n) {
                Console.WriteLine("fibonacciIterative({0}) = {1}", n, fibonacciIterative(n));
            }

            Console.WriteLine("\nnSubTest: fibonacciRecursive");
            for (int n = 0; n < 7; ++n) {
                Console.WriteLine("fibonacciRecursive({0}) = {1}", n, fibonacciRecursive(n));
            }
        }

        public static int fibonacciIterative(int n) {
            if (n == 0) { return n; }
            
            int fibLeft, fibRight, result;
            fibLeft = 0;
            result = 1;

            for (int i=0; i<(n-1); ++i) {
                fibRight = fibLeft;
                fibLeft = result;
                result = fibLeft + fibRight;
            }
            
            return result;
        }

        public static int fibonacciRecursive(int n) {
            if (n == 0 || n == 1) { return n; }
            return fibonacciRecursive(n - 1) + fibonacciRecursive(n - 2);
        }
    } // End class Maths
}