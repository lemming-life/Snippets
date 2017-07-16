// Author: http://lemming.life
// Language: C#
// Purpose: Compute the nth fibonacci number.
// Date: July 16, 2017


using System;

namespace Snippets {
    public class Fibonacci {

        // Purpose: Computes the nth fibonacci number.
        // Conditions: non-negative integer as input.
        // Details: Uses iteration to ensure fast evaluation and to conserve stack space.
        public static int fib(int n) {
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

        public static void executeDriver() {
            for (int n = 0; n < 7; ++n) {
                Console.WriteLine("Fibonacci({0}) = {1}", n, fib(n));
            }
        }
    }
}