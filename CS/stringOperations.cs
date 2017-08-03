// Author: http://lemming.life
// Language: C#
// Description: Collection of classes related to string operations.


using System;
using System.Text;
using System.Collections.Generic;

namespace Snippets {
    class StringOperations {
        public static void executeDriver() {
            Console.WriteLine("\nTEST: String Operations");
            Console.WriteLine("\nSubTest: Reverse");
            Reverse.executeDriver();

            Console.WriteLine("\nSubTest: Palindrome");
            Palindrome.executeDriver();

            Console.WriteLine("\nSubTest: UrlParser");
            UrlParser.executeDriver();

            Console.WriteLine("\nSubTest: IsWellFormed1");
            IsWellFormed1.executeDriver();

            Console.WriteLine("\nSubTest: IsWellFormed2");
            IsWellFormed2.executeDriver();
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
                for (int i=0; i < line.Length/2; ++i) {
                    if (line[i] != line[line.Length - (i+1)]) {
                        return false;
                    }
                }
                return true;
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

            static string getQueryWithQuestionMark(string url) {
                string lookFor = "?";
                int indexOf = url.IndexOf(lookFor);
                if (indexOf == -1) {return "";}
                ++indexOf;
                return url.Substring(indexOf, url.Length - indexOf);
            }

            public static void executeDriver() {
                string url = "http://google.com/theQuery123";
                Console.WriteLine("Url is: " + url);
                Console.WriteLine("Protocol: " + getProtocol(url));
                Console.WriteLine("Domain: " + getDomain(url));
                Console.WriteLine("Query no path: " + getQuery(url, false));
                Console.WriteLine("Query with path: " + getQuery(url, true));

                url = "http://google.com/some/stuff/in/between/theQuery123";
                Console.WriteLine("\nUrl is: " + url);
                Console.WriteLine("Protocol: " + getProtocol(url));
                Console.WriteLine("Domain: " + getDomain(url));
                Console.WriteLine("Query no path: " + getQuery(url, false));
                Console.WriteLine("Query with path: " + getQuery(url, true));


                url = "http://www.somewebsitewithnoqueryline.com/index.html";
                Console.WriteLine("\nUrl is: " + url);
                Console.WriteLine("Protocol: " + getProtocol(url));
                Console.WriteLine("Domain: " + getDomain(url));
                Console.WriteLine("Query?: " + getQueryWithQuestionMark(url));

                url = "http://www.somewebsitewithquestionmarkquery.com/index.html?aquery=123";
                Console.WriteLine("\nUrl is: " + url);
                Console.WriteLine("Protocol: " + getProtocol(url));
                Console.WriteLine("Domain: " + getDomain(url));
                Console.WriteLine("Query?: " + getQueryWithQuestionMark(url));
            }

        } // End class UrlParser

        public class IsWellFormed1 {
            // Considers only strings that have characters: (,),{,},[,]
            // Example1: () is well formed
            // Example2: ([}) is not well formed.
            public static void executeDriver() {
                string line = "()";
                Console.WriteLine("Is {0} well formed? {1}", line, isWellFormed(line));
                line = "([)]";
                Console.WriteLine("Is {0} well formed? {1}", line, isWellFormed(line));
            }
            

            public static bool isWellFormed(string line) {
                if (line.Length % 2 != 0) { return false; } 

                for (int i=0; i<line.Length/2; ++i) {
                    if (line[i] != oppositeChar( line[line.Length - (1+i)]) ) {
                        return false;
                    }
                }
                return true;
            }

            private static char oppositeChar(char aChar) {
                if (aChar == '(') return ')';
                if (aChar == '{') return '}';
                if (aChar == '[') return ']';
                if (aChar == ')') return '(';
                if (aChar == '}') return '{';
                if (aChar == ']') return '[';
                return ' ';
            }
        } // End class IsWellFormed1


        public class IsWellFormed2 {
            // Considers strings that have (,),{,},[,]
            // but also characters in between those.
            // Example1: (hello) is well formed.
            // Example2: (he[llo]) is well formed.
            // Example3: (he[llo) is not well formed.
            // Example4: hell}o is not well formed.

            public static void executeDriver() {
                string line;
                line = "hello";
                Console.WriteLine("Is {0} well formed? {1}", line, isWellFormed(line)); // true
                line = "(hello)";
                Console.WriteLine("Is {0} well formed? {1}", line, isWellFormed(line)); // true
                line = "(he[llo])";
                Console.WriteLine("Is {0} well formed? {1}", line, isWellFormed(line)); // true
                line = "hell{}";
                Console.WriteLine("Is {0} well formed? {1}", line, isWellFormed(line)); // true
                line = "(he[llo)";
                Console.WriteLine("Is {0} well formed? {1}", line, isWellFormed(line)); // false
                line = "hell}o";
                Console.WriteLine("Is {0} well formed? {1}", line, isWellFormed(line)); // false
                line = "]hello";
                Console.WriteLine("Is {0} well formed? {1}", line, isWellFormed(line)); // false
                line = "he(ll]o";
                Console.WriteLine("Is {0} well formed? {1}", line, isWellFormed(line)); // false
            }

            public static bool isWellFormed(string line) {
                Stack<char> charStack = new Stack<char>();

                foreach (var c in line) {
                    if ( !isBracketType(c) ) { continue; }

                    if (isCharOpener(c)) {
                        charStack.Push(c);
                    } else {
                        if (charStack.Count == 0) return false;

                        if (c == oppositeChar(charStack.Peek())) {
                            charStack.Pop();
                        } else {
                            return false;
                        }
                    }
                }

                if (charStack.Count>0) { return false;}

                return true;
            }

            private static bool isBracketType(char aChar) {
                if (aChar == '(') return true;
                if (aChar == '{') return true;
                if (aChar == '[') return true;
                if (aChar == ')') return true;
                if (aChar == '}') return true;
                if (aChar == ']') return true;
                return false;
            }

            private static bool isCharOpener(char aChar) {
                if (aChar == '(') return true;
                if (aChar == '{') return true;
                if (aChar == '[') return true;
                return false;
            }

            private static char oppositeChar(char aChar) {
                if (aChar == '(') return ')';
                if (aChar == '{') return '}';
                if (aChar == '[') return ']';
                if (aChar == ')') return '(';
                if (aChar == '}') return '{';
                if (aChar == ']') return '[';
                return ' ';
            }

        }


    } // End class StringOperations

}