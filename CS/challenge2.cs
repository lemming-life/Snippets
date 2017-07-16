// Partial-Author: http://lemming.life
// Language: C#
// Purpose: Challenge 2
// Notes: The challenge descriptions are not mine, but the solutions are.
// Date: July 16, 2017

/* Challenge2 Description:
Write a program that, given an integer, sums all the numbers from 1 through that integer (both inclusive).
Do not include in your sum any of the intermediate numbers (1 and n inclusive) that are divisible by 5 or 7.

(Note by lemming.life: I disallowed standard input and have modified the output required).
Input:
Your program should read lines from standard input. Each line contains a positive integer.
Output:
For each line of input, print to standard output the sum of the numbers from 1 through n, 
disregarding those divisible by 5 and 7. Print out each result on a new line.
 */

using System;

 namespace Challenges {

    class Challenge2 {
        static int doSum(int n, int[] excludeDivisibleBy) {
            int sum = 0;

            for (int i=0; i<n; ++i) {
                int eval = i + 1;

                bool isDivisible = false;
                for (int j=0; j<excludeDivisibleBy.Length; ++j) {
                    if (eval % excludeDivisibleBy[j] == 0) {
                        isDivisible = true;
                        break;
                    }
                }

                if (!isDivisible) {
                    sum += eval;
                }
            }

            return sum;
        }
        
        public static void executeDriver() {
            Console.WriteLine("Do the inclusive sum of numbers from 1 to n, excluding numbers divisible by 5 and 7");
            int n;
            int[] excludeDivisibleBy = {5, 7};

            n = 5;
            Console.WriteLine("Input: {0}, Output: {1}", n, doSum(n, excludeDivisibleBy)); // 10

            n = 6;
            Console.WriteLine("Input: {0}, Output: {1}", n, doSum(n, excludeDivisibleBy)); // 16

            n = 7;
            Console.WriteLine("Input: {0}, Output: {1}", n, doSum(n, excludeDivisibleBy)); // 16

            n = 8;
            Console.WriteLine("Input: {0}, Output: {1}", n, doSum(n, excludeDivisibleBy)); // 24
        }
    }

 }
