// Author: http://lemming.life
// Description: Collection of classes related to string operations.


using System;
using System.Text;

namespace Snippets {
    class StringOperations {
        public static void executeDriver() {
            Console.WriteLine("\n - TEST: Reverse");
            Reverse.executeDriver();

            Console.WriteLine("\n - TEST: Palindrome");
            Palindrome.executeDriver();
        }


        public class Palindrome {
            // Purpose: Given a string determine if it is a palindrome.
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
        } // End class Palindrome
        

        public class Reverse {
            // Purpose: Reverses strings and integers.

            public static string reverseStr(string s) {
                StringBuilder reversed = new StringBuilder();
                for (int i = s.Length-1; i > -1; --i) {
                    reversed.Append(s[i]);
                }
                return reversed.ToString();
            }

            public static int reverseInt(int n) {
                int reversed;
                Int32.TryParse(reverseStr(n.ToString()), out reversed);
                return reversed;
            }

            public static void executeDriver() {
                string str = "Hello, World";
                Console.WriteLine("The reverse of '{0}' is '{1}'", str, reverseStr(str));

                int n = 12345;
                Console.WriteLine("The reverse of {0} is {1}", n, reverseInt(n));
            }
        } // End class Reverse


    } // End class StringOperations

}