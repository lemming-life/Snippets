// Author: http://lemming.life
// Language: C#
// 

using System;
//using System.IO;
//using System.Collections.Generic;


namespace Challenges {

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

        
        public static void executeDriver() {
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


    } // End class
}