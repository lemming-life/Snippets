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

            Console.WriteLine("\nSubTest: computeMoneyChange");
                {
                    int money = 100; // between 1 and 99 inclusive.
                    const int DENOMINATION_QUARTER = 25;
                    Console.WriteLine("Initial money: {0:f0}", money);
                    Console.WriteLine("Quarters: {0}, remaining money: {1:f0}", computeMoneyChange(ref money, DENOMINATION_QUARTER), money);
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


        public static int computeMoneyChange(ref int amount, int denomination) {
            // Purpose: Determine how many coins fit into the amount based on the denomination
            // Postcondition: amount will change to reflect the value removed by possible coins returned
            int coins = amount / denomination;
            amount = amount % denomination;
            return coins;
        }

    } // End class Maths
}