// Partial-Author: http://lemming.life
// Language: C#
// Purpose: Challenge 1.
// Notes: The challenge descriptions are not mine, but the solutions are.
// Date: July 16, 2017

/* Challenge1 Description:
Credits: Programming Challenges by Steven S. Skiena and Miguel A. Revilla

The problem is as follows: choose a number, reverse its digits and add it to the original.
If the sum is not a palindrome (which means, it is not the same number from left to right 
and right to left), repeat this procedure. eg.
195 (initial number) + 591 (reverse of initial number) = 786
786 + 687 = 1473
1473 + 3741 = 5214
5214 + 4125 = 9339 (palindrome)
In this particular case the palindrome 9339 appeared after the 4th addition.
This method leads to palindromes in a few step for almost all of the integers.
But there are interesting exceptions. 196 is the first number for which no palindrome
has been found. It is not proven though, that there is no such a palindrome.

(lemming.life modification: I disallowed standard input for my driver)
Your program should read lines of text from standard input. Each line will contain an
integer n < 4,294,967,295. Assume each line of input will always have an answer and that
it is computable with less than 1000 iterations (additions)
Output:

For each line of input, generate a line of output which is the number of iterations (additions)
to compute the palindrome and the resulting palindrome. (they should be on one line and separated
by a single space character)
 */


using System;

namespace Challenges {
    
    class Challenge1 {





        public static void perform(int n) {
            int count = 0;
            string line;
            do {
                ++count;
                n = n + Snippets.StringOperations.Reverse.reverseInt(n);
                line = n.ToString();
            } while (!Snippets.StringOperations.Palindrome.isPalindrome(line));

            Console.WriteLine("Output: {0} {1}", count, line);
        }
        
        public static void executeDriver(bool standardIn = false) {
            Console.WriteLine("Sum n and its reverse, if result isPalindrome quit, else n is result and repeat.");
            Console.WriteLine("Output the iteration count and the resulting sum.");

            int n = 195;
            Console.WriteLine("Input: {0}", n);
            perform(n); // Expect 4 9339 (a palindrome)

            // For standard input
            if (standardIn) {
                while(Snippets.Input.requestPositiveInteger("\nInput: ", ref n) ) {
                    perform(n);
                }
            }
        }
    }

}