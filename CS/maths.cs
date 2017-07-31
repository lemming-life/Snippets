// Author: http://lemming.life
// Description: Collection of Math classes and operations.


using System;

namespace Snippets {
    class Maths {
        public static void executeDriver(bool standardIn = false) {
            Console.WriteLine("TEST: Square");
            Square.executeDriver();

            Console.WriteLine("TEST: Fibonacci");
            Fibonacci.executeDriver();
        }



        public class Square {
            // Purpose: Returns the square of a number.
            public static int square(int x) {
                return x * x;
            }

            public static void executeDriver() {
                int n;

                n = 2;
                Console.WriteLine("The square of {0} is {1}", n, square(n));

                n = 6;
                Console.WriteLine("The square of {0} is {1}", n, square(n));
            }
        }


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



    
}