// Author: http://lemming.life
// Language: C#
// Purpose: Given a string determine if it is a palindrome.
// Date: July 15, 2017

using System;

namespace Snippets {

    class Palindrome {
        public static bool isPalindrome(string line) {
            bool palindrome = true;
            for (int i=0; i < line.Length/2; ++i) {
                if (line[i] != line[line.Length - (i+1)]) {
                    palindrome = false;
                    break;
                }
            }
            return palindrome;
        }

        public static void executeDriver() {
            string line = "hello";
            Console.WriteLine("Is {0} a palindrome? {1}", line, isPalindrome(line));
            
            line = "101";
            Console.WriteLine("Is {0} a palindrome? {1}", line, isPalindrome(line));

            line = "aabbaa";
            Console.WriteLine("Is {0} a palindrome? {1}", line, isPalindrome(line));
        } 
    }
    
}