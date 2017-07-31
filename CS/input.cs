// Author: http://lemming.life
// Language: C#
// Description: Get input from standard in and output as type requested.

using System;
using System.IO;

namespace Snippets {
    class Input {
        // Gets value from standard in.

        public static string getAsString() {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))

            while (!reader.EndOfStream) {
                return reader.ReadLine();
            }

            return "";
        }

        
        public static int getAsInt() {
            // Will throw exception if it cannot convert to int.
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))

            while (!reader.EndOfStream) {
                return int.Parse(reader.ReadLine());
            }

            return 0;
        }

        public static bool requestPositiveInteger(string prompt, ref int n) {
            // Purpose: Ensures user enters non-negative integer (or anything not numerical) as input.
            // Notes:
            // 1. Prompts the user for input.
            // 2. Parse the input, ensure non-negative integer.
            // 3. Return true if non-negative integer, false otherwise.
            /*
                //Example of how to use it:
                int n = 0;
                while (Input.requestPositiveInteger("\nPlease, enter positive integer: ", ref n)) {
                    // Do work with n;
                }
            */
            Console.Write(prompt);
            if (Int32.TryParse(Console.ReadLine(), out n)) {
                if (n > -1) { return true; }
            }

            return false;
        }

        public static void executeDriver() {
            int n = 0;
            string s = "";

            Console.Write("Input a string: ");
            s = getAsString();
            Console.WriteLine("Your input is: {0}", s);
        
            Console.Write("\nInput a number: ");
            try {
                n = getAsInt();
                Console.WriteLine("Your input is: {0}", n);
            } catch (Exception e) {
                Console.WriteLine("That is not a number! Exception message: \n{0}", e);
            }
            
            while(requestPositiveInteger("\nInput a positive integer: ", ref n)) {
                Console.WriteLine("Your input is {0}", n);
            }
            Console.WriteLine("Finished input of positive integers.");
        }

    } // End class Input

}