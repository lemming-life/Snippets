// Author: http://lemming.life
// Language: C#
// Description: Collection of Math classes and operations.

using System;

namespace Snippets {
    class Maths {
        public static void executeDriver(bool standardIn = false) {
            Console.WriteLine("\nTEST: Maths");
            
            Console.WriteLine("\nnSubTest: fibonacciIterative");
            for (int n = 0; n < 7; ++n) {
                Console.WriteLine("fibonacciIterative({0}) = {1}", n, fibonacciIterative(n));
            }

            Console.WriteLine("\nnSubTest: fibonacciRecursive");
            for (int n = 0; n < 7; ++n) {
                Console.WriteLine("fibonacciRecursive({0}) = {1}", n, fibonacciRecursive(n));
            }

            Console.WriteLine("\nSubTest: breakByDenomination");
            {
                int money = 99; // Think of it as $99!
                const int DENOMINATION_FIFTY = 50;
                const int DENOMINATION_TWENTY = 20;
                const int DENOMINATION_TEN = 10;
                const int DENOMINATION_FIVE = 5;
                const int DENOMINATION_ONE = 1;
                Console.WriteLine("Initial money: {0:c0}", money);
                Console.WriteLine("How many {0:c}? {1}, remaining money: {2:f0}", DENOMINATION_FIFTY, breakByDenomination(ref money, DENOMINATION_FIFTY), money);
                Console.WriteLine("How many {0:c}? {1}, remaining money: {2:f0}", DENOMINATION_TWENTY, breakByDenomination(ref money, DENOMINATION_TWENTY), money);
                Console.WriteLine("How many {0:c}? {1}, remaining money: {2:f0}", DENOMINATION_TEN, breakByDenomination(ref money, DENOMINATION_TEN), money);
                Console.WriteLine("How many {0:c}? {1}, remaining money: {2:f0}", DENOMINATION_FIVE, breakByDenomination(ref money, DENOMINATION_FIVE), money);
                Console.WriteLine("How many {0:c}? {1}, remaining money: {2:f0}", DENOMINATION_ONE, breakByDenomination(ref money, DENOMINATION_ONE), money);
            }

            Console.WriteLine("\nSubTest: getAverage");
            {
                double[] numbers = new double[] {1, 2, 3, 5.5, 6.6, 7.7 };
                Console.Write("The average of ");
                foreach(var number in numbers) { Console.Write(number + " "); }
                Console.WriteLine(" is {0}", getAverage(numbers));
            }

            Console.WriteLine("\nSubTest: getHighest / getLowest / getHighestByIndex / getLowestByIndex ");
            {
                double[] numbers = new double[] {1, 2, 3, 5.5, 6.6, 7.7, 1.5, 4, 99, 64 };
                Console.Write("Given ");
                foreach(var number in numbers) { Console.Write(number + " "); }
                Console.WriteLine("\nHighest is {0} and lowest is {1}", getHighest(numbers), getLowest(numbers));
                Console.WriteLine("Index of highest is {0}, index of lowest is {1}", getHighestByIndex(numbers), getLowestByIndex(numbers));
            }

            

        } // End executeDriver()

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

        public static int breakByDenomination(ref int amount, int denomination) {
            // Purpose: Determine how many denominations fit into the amount based on the denomination
            // Postcondition: amount will change to reflect the value removed by possible denominations returned
            int numberOfDenominations = amount / denomination;
            amount = amount % denomination;
            return numberOfDenominations;
        }

        public static double getAverage(double[] array) {
            if (array.Length == 0) { return 0; }
            double sum = 0;
            for (int i=0; i<array.Length; ++i) {
                sum += (double) array[i];
            }
            return sum / array.Length;
        }

        public static T getHighest<T>(T[] array) where T : IComparable  {
            T highest = array[0];
            
            for (int i=1; i<array.Length; ++i) {
                if (array[i].CompareTo(highest)>0 ) {
                    highest = array[i];
                }
            }
            return highest;
        }

        public static T getLowest<T>(T[] array) where T : IComparable  {
            T lowest = array[0];
            
            for (int i=1; i<array.Length; ++i) {
                if (array[i].CompareTo(lowest) < 0 ) {
                    lowest = array[i];
                }
            }
            return lowest;
        }

        public static int getHighestByIndex<T>(T[] array) where T : IComparable  {
            T highest = array[0];
            int index = 0;

            for (int i=1; i<array.Length; ++i) {
                if (array[i].CompareTo(highest)>0 ) {
                    highest = array[i];
                    index = i;
                }
            }
            return index;
        }

        public static int getLowestByIndex<T>(T[] array) where T : IComparable  {
            T lowest = array[0];
            int index = 0;
            
            for (int i=1; i<array.Length; ++i) {
                if (array[i].CompareTo(lowest) < 0 ) {
                    lowest = array[i];
                    index = 0;
                }
            }
            return index;
        }



        


    } // End class Maths
}