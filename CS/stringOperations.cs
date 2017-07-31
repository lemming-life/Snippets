// Author: http://lemming.life
// Language: C#
// Description: Collection of classes related to string operations.


using System;
using System.Text;

namespace Snippets {
    class StringOperations {
        public static void executeDriver() {
            Console.WriteLine("\nSubTest: Reverse");
            Reverse.executeDriver();

            Console.WriteLine("\nSubTest: Palindrome");
            Palindrome.executeDriver();

            Console.WriteLine("\nSubTest: UrlParser");
            UrlParser.executeDriver();
        }

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


        public class UrlParser {
            // Description : Given a url extract the protocol, domain, and query string. 
            
            static string getProtocol(string url) {
                string lookFor = "://";
                int indexOf = url.IndexOf(lookFor);
                return url.Substring(0, indexOf);
            }

            static string getDomain(string url) {
                string lookFor1 = "://";
                string lookFor2 = "/";
                int indexOf1 = url.IndexOf(lookFor1) + lookFor1.Length;
                url = url.Substring(indexOf1, url.Length - indexOf1);
                int indexOf2 = url.IndexOf(lookFor2);
                return url.Substring(0, indexOf2);
            }

            static string getQuery(string url, bool path = false) {
                string lookFor = path ? getDomain(url) + "/" : "/";
                int indexOf = lookFor.Length + (path ? url.IndexOf(lookFor) : url.LastIndexOf(lookFor));
                return url.Substring(indexOf, url.Length - indexOf);
            }

            public static void executeDriver() {
                string url = "http://google.com/theQuery123";
                Console.WriteLine("Url1 is: " + url);
                Console.WriteLine("Protocol: " + getProtocol(url));
                Console.WriteLine("Domain: " + getDomain(url));
                Console.WriteLine("Query no path: " + getQuery(url, false));
                Console.WriteLine("Query with path: " + getQuery(url, true));

                url = "http://google.com/some/stuff/in/between/theQuery123";
                Console.WriteLine("\nUrl2 is: " + url);
                Console.WriteLine("Protocol: " + getProtocol(url));
                Console.WriteLine("Domain: " + getDomain(url));
                Console.WriteLine("Query no path: " + getQuery(url, false));
                Console.WriteLine("Query with path: " + getQuery(url, true));
            }

        } // End class UrlParser


    } // End class StringOperations

}