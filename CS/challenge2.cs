// Partial-Author: http://lemming.life
// Language: C#
// Purpose: Collection of code challenges.
// Notes: The challenge descriptions are not mine, but the solutions are.
// Date: July 16, 2017

/* Challenge2 Description:

Write a program that, given an integer, sums all the numbers from 1 through that integer (both inclusive).
Do not include in your sum any of the intermediate numbers (1 and n inclusive) that are divisible by 5 or 7.

Input:
Your program should read lines from standard input. Each line contains a positive integer.
Output:
For each line of input, print to standard output the sum of the numbers from 1 through n, 
disregarding those divisible by 5 and 7. Print out each result on a new line.
 */

 namespace Challenges {

    class Challenge2 {
         public static void perform(int n) {
            int count = 0;
            string line;
            do {
                ++count;
                n = n + Snippets.Reverse.reverseInt(n);
                line = n.ToString();
            } while (!Snippets.Palindrome.isPalindrome(line));

            Console.WriteLine("{0} {1}", count, line);
        }
        
        public static void executeDriver() {
            perform(195); // Expect 9339 a palindrome.

            // For standard input
            /*
            int n = 0;
            while(Snippets.Input.requestPositiveInteger("\nInput: ", ref n) ) {
                perform(n);
            }
            */
        }
    }


 }