

/*
Before doing this interview question, we recommend going through the Angular PhoneCat Tutorial (https://docs.angularjs.org/tutorial). You may or may not have heard of AngularJS, but part of this task will be how you can pick up something that you may be a bit unfamiliar with. You have been tasked to create a simple calendar event app using AngularJS. You can assume that there is only a single, 31-day month and that the first day of the month happens on the first day of the week. Your calendar app must do the following: • Display a calendar where each box has the day of the month and an optional message. • Each box is selectable by a mouse click. When a box is selected, it should be highlighted to differentiate it from the other boxes. • When a box is a selected, an input element appears outside of the calendar where the user can input a message . • As the user types in the input box, the selected calendar day’s message should be updated to reflect the inputted value. • Selecting a different box, will update the input element with the message value from the new box. All days should maintain their message. • Along with the day of the month, an AngularJS filter should be created which will convert the day into a day plus the day of the week. Attached is an image of how this might look. We have provided a JSFiddle as a starting point. http://jsfiddle.net/bbsellers/zsvd6ed8/ This fiddle already includes a few things that use may find useful (Bootstrap and some starter CSS, HTML, and JavaScript), but feel free to implement this in the way you best see fit. Please include the URL of your JSFiddle, JSBin, Dabblet, Tinkerbin, or wherever else we can view your code online.

 */






/*
Programming Challenge Description:

Credits: Programming Challenges by Steven S. Skiena and Miguel A. Revilla

The problem is as follows: choose a number, reverse its digits and add it to the original. If the sum is not a palindrome (which means, it is not the same number from left to right and right to left), repeat this procedure. eg.
195 (initial number) + 591 (reverse of initial number) = 786

786 + 687 = 1473

1473 + 3741 = 5214

5214 + 4125 = 9339 (palindrome)
In this particular case the palindrome 9339 appeared after the 4th addition. This method leads to palindromes in a few step for almost all of the integers. But there are interesting exceptions. 196 is the first number for which no palindrome has been found. It is not proven though, that there is no such a palindrome.
Input:

Your program should read lines of text from standard input. Each line will contain an integer n < 4,294,967,295. Assume each line of input will always have an answer and that it is computable with less than 1000 iterations (additions)
Output:

For each line of input, generate a line of output which is the number of iterations (additions) to compute the palindrome and the resulting palindrome. (they should be on one line and separated by a single space character)



 */


/*

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class Program {
    static void Main(string[] args) {
        using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
        while (!reader.EndOfStream) {
            string line = reader.ReadLine();

            int n1, n2, n3;
            //string line3;

            int count  = 0;
            do {
                ++count;
                Int32.TryParse(line, out n1);

                StringBuilder line2 = new StringBuilder();
                for (int i = line.Length-1; i > -1; --i) {  
                    line2.Append(line[i]);
                }

                Int32.TryParse(line2.ToString(), out n2);

                n3 = n1 + n2;
                line = n3.ToString();
            } while (isPalindrome(line) == false);


            Console.WriteLine("{0} {1}", count, line);
        }
    }

    static bool isPalindrome(string line) {
        bool palindrome = true;
        for (int i=0; i < line.Length/2; ++i) {
            if (line[i] != line[line.Length - (i+1)]) {
                palindrome = false;
                break;
            }
        }
        return palindrome;
    }
}
 */






/*
Programming Challenge Description:

Write a program that, given a URL parses out and displays it's constituent components. For the purpose of this challenge, a URL is of the form <protocol^gt;://<domain>/path?<query string>. Print out the protocol, domain and query string, separated by commas.
Input:

Your program should read lines from standard input. Each line contains a url. There is one url per line.
Output:

For each line of input, extract and print a line to standard output of the protocol, domain and query string (comma separated) of the url. In case any of the components are missing, leave it blank in the output. */


/*
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

// Parse URL
class Program {
    static void Main(string[] args) {
        using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
        while (!reader.EndOfStream) {
            string line = reader.ReadLine();

            string protocol;
            string domain;
            string query;

            int indexOfDomain = line.LastIndexOf("/");
            query = line.Substring(indexOfDomain+1, line.Length - (indexOfDomain+1));
            line = line.Substring(0, line.Length - (query.Length + 1));
            int indexOfProtocol = line.IndexOf("://");
            protocol = line.Substring(0, indexOfProtocol);
            domain = line.Substring(protocol.Length + 3, line.Length - (protocol.Length+3));
            Console.WriteLine("{0}, {1}, {2}", protocol, domain, query);
        }
    }
}
 */



/* 

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class Program {
    
    static int doSum(int n) {
        int sum = 0;
        for (int i = 0; i < n; ++i) {
            int eval = i + 1;
            if (eval % 5 != 0 && eval % 7 != 0) {
                sum += (eval);
            }
        }
        return sum;
    }
    
    static void Main(string[] args) {
        using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
        while (!reader.EndOfStream) {
            string line = reader.ReadLine();
            int n;
            if (Int32.TryParse(line, out n)) {
                Console.WriteLine("{0}", doSum( n ));
            }
        }
    }
}

*/


/*
Programming Challenge Description:

Write a program that, given an integer, sums all the numbers from 1 through that integer (both inclusive). Do not include in your sum any of the intermediate numbers (1 and n inclusive) that are divisible by 5 or 7.
Input:

Your program should read lines from standard input. Each line contains a positive integer.
Output:

For each line of input, print to standard output the sum of the numbers from 1 through n, disregarding those divisible by 5 and 7. Print out each result on a new line.

 */


/*
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

class Program {
    
    static int square(int x) {
        return x * x;
    }
    
    static void Main(string[] args) {
        using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
        while (!reader.EndOfStream) {
            string line = reader.ReadLine();
            int n;
            if (Int32.TryParse(line, out n)) {
                Console.WriteLine("{0}", square(n));
            }
            
            //Console.WriteLine(line);
        }
    }
}
 */