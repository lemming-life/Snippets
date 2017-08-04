// Author: http://lemming.life
// Language: C#
// Note: The challenge descriptions are not mine, but the solutions are.


using System;

namespace Challenges {

    class AllChallenges{
        public static void executeDriver(bool standardIn = false) {
            Challenge1.executeDriver(standardIn);
            Challenge2.executeDriver(standardIn);
            Challenge3.executeDriver(standardIn);
            Challenge4.executeDriver(standardIn);

        }
    } // End class AllChallenges


    class Challenge1 {
        /* Challenge Description:
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

        public static void executeDriver(bool standardIn = false) {
            Console.WriteLine("\nTEST: Challenge1");
            
            Console.WriteLine("Sum n and its reverse, if result isPalindrome quit, else n is result and repeat.");
            Console.WriteLine("Output the iteration count and the resulting sum.");

            int n = 195;
            Console.WriteLine("Input: {0}", n);
            performChallenge(n); // Expect 4 9339 (a palindrome)

            // For standard input
            if (standardIn) {
                while(Snippets.Input.requestPositiveInteger("\nInput: ", ref n) ) {
                    performChallenge(n);
                }
            }
        }

        public static void performChallenge(int n) {
            int count = 0;
            string line;
            do {
                ++count;
                n = n + Snippets.StringOperations.Reverse.reverseInt(n);
                line = n.ToString();
            } while (!Snippets.StringOperations.Palindrome.isPalindrome(line));

            Console.WriteLine("Output: {0} {1}", count, line);
        }

    } // End class Challenge1


    class Challenge2 {
        /* Challenge Description:
        Write a program that, given an integer, sums all the numbers from 1 through that integer (both inclusive).
        Do not include in your sum any of the intermediate numbers (1 and n inclusive) that are divisible by 5 or 7.

        (Note by lemming.life: I disallowed standard input and have modified the output required).
        Input:
        Your program should read lines from standard input. Each line contains a positive integer.
        Output:
        For each line of input, print to standard output the sum of the numbers from 1 through n, 
        disregarding those divisible by 5 and 7. Print out each result on a new line.

        EXAMPLE 1
        Input: n = 4
        Evaluation: 1 + 2 + 3 + 4 = 10
        Output: 10

        EXAMPLE 2:
        Input: n = 8
        Evaluation: 1 + 2 + 3 + 4 + 6 + 8 = 24
        Output: 24
        */

        public static void executeDriver(bool standardIn = false) {
            Console.WriteLine("\nTEST: Challenge2");
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
        } // End doSum()
        
    } // End class Challenge2


    class Challenge3 {
        /* Challenge Description:
        Given an initial departure and arrival time, determine the new arrival time with
        consideration of a percent delay. Use a HH:MM, and 24 hour, format.
        */
        public static void executeDriver(bool standardIn = false) {
            Console.WriteLine("\nTEST: Challenge3");

            string departureTime, arrivalTime, delayPercent;
            Console.WriteLine("Subtest1");
                departureTime = "01:00";
                arrivalTime = "02:00";
                delayPercent = "10";
                performTripCalculation(departureTime, arrivalTime, delayPercent);
            Console.WriteLine("\nSubtest2");
                departureTime = "23:30";
                arrivalTime = "24:00";
                delayPercent = "50";
                performTripCalculation(departureTime, arrivalTime, delayPercent);
            Console.WriteLine("\nSubtest3");
                departureTime = "23:30";
                arrivalTime = "00:00";
                delayPercent = "50";
                performTripCalculation(departureTime, arrivalTime, delayPercent);
            Console.WriteLine("\nSubtest4");
                departureTime = "23:30";
                arrivalTime = "01:00";
                delayPercent = "50";
                performTripCalculation(departureTime, arrivalTime, delayPercent);
        } // End executeDriver()

        public static void performTripCalculation(string departureTime, string arrivalTime, string delayPercent) {
            string newArrivalTime = calculateNewArrivalTime(departureTime, arrivalTime, delayPercent);
                Console.WriteLine("Trip departs at {0}, expected to arrive at {1}, but has {2}% delay", departureTime, arrivalTime, delayPercent);
                Console.WriteLine("The new arrival time is {0}", newArrivalTime);
        }

        public static string calculateNewArrivalTime(string initialDepatureTime, string usualArrivalTime, string delayPercent) {
            // Input:
            // HH:MM format for initialDepatureTime and usualArrivalTime
            // delayPercent from 0 to 100 to mean 0% to 100%

            // Output:
            // A string in HH:MM format indicating the new arrival time.

            const int HOURS_IN_DAY = 24;
            const int MINUTES_IN_HOUR = 60;

            // Conversion
            int initialDepartureTimeAsMinutes = Snippets.Time.timeAsMinutes(initialDepatureTime);
            int usualArrivalTimeAsMinutes = Snippets.Time.timeAsMinutes(usualArrivalTime);
            double delayPercentAsDouble = double.Parse(delayPercent) / 100.0;

            // Consideration for when arrival time is next day.
            if (usualArrivalTimeAsMinutes < initialDepartureTimeAsMinutes) {
                usualArrivalTimeAsMinutes += HOURS_IN_DAY * MINUTES_IN_HOUR;
            }

            // Determine the trip time
            double tripTimeAsMinutes = usualArrivalTimeAsMinutes - initialDepartureTimeAsMinutes;

            // Add the delay
            tripTimeAsMinutes += tripTimeAsMinutes * delayPercentAsDouble;

            // Add the time to the initialDepartureTime
            int newArrivalTimeAsMinutes = initialDepartureTimeAsMinutes + (int)tripTimeAsMinutes;

            // Determine the new HHMM
            int hours = Snippets.Maths.breakByDenomination(ref newArrivalTimeAsMinutes, MINUTES_IN_HOUR); // 60 minutes in an hour.
            int minutes = newArrivalTimeAsMinutes; // Whatever is left are the minutes

            // 24 hr correction
            if (hours >= 24) { hours -= 24; }

            return hours.ToString("00") + ":" + minutes.ToString("00");
        } // End calculateNewArrivalTime()

    } // End class Challenge3


    class Challenge4 {
        /*
        Challenge Description:
        You are given two strings A and B.
        Print the number 1 if string B occurs at the end of string A.
        Otherwise, print the number 0.
        Strings A and B are separated by a comma.

        Input:
        Your program should read lines of text from standard input.
        Each line will contain two strings, A and B, separated by a comma.
         */
        
        public static void executeDriver(bool standardIn = false) {
            Console.WriteLine("\nTest: Challenge4");

            string line = "Hello World, World";
            Console.WriteLine("Line is " + line);
            performChallenge(line);

            line = "Tomato is potato,potato";
            Console.WriteLine("Line is " + line);
            performChallenge("Line is " + line);

            line = "Tomato is potato,Tomato";
            Console.WriteLine("Line is " + line);
            performChallenge("Line is " + line);

            line = "Tomato is potato,Blabla";
            Console.WriteLine("Line is " + line);
            performChallenge("Line is " + line);
        }

        static void performChallenge(string line) {
            string[] words = line.Split(',');
            if (words[1][0] == ' ') {
                words[1] = words[1].Substring(1, words[1].Length-1);
            }
            
            int secondWordIndex = words[0].LastIndexOf(words[1]);

            if (secondWordIndex == -1) {
                Console.WriteLine("0");
            } else {
                if (words[0].Length - secondWordIndex == words[1].Length) {
                    Console.WriteLine("1");
                } else {
                    Console.WriteLine("0");
                }
            }
        } // End performChallenge


    } // End class Challenge4

}