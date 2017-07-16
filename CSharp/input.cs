// Author: http://lemming.life
// Language: C#
// Purpose: Get input from standard in and output as type requested.
// Date: July 26, 2017

using System;
using System.IO;

namespace Snippet {


    // Gets value from standard in.
    class Input {

        public static string getAsString() {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))

            while (!reader.EndOfStream) {
                return reader.ReadLine();
            }

            return "";
        }

        // Will throw exception if it cannot convert to int.
        public static int getAsInt() {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))

            while (!reader.EndOfStream) {
                return int.Parse(reader.ReadLine());
            }

            return 0;
        }


        // Purpose: Ensures user enters non-negative integer (or anything not numerical) as input.
        // Notes:
        // 1. Prompts the user for input.
        // 2. Parse the input, ensure non-negative integer.
        // 3. Return true if non-negative integer, false otherwise.
        /*
            //Using it:
            int n = 0;
            while (Input.requestPositiveInteger("\nPlease, enter positive integer: ", ref n)) {
                // Do work with n;
            }
         */


        public static bool requestPositiveInteger(string prompt, ref int n) {
            Console.Write(prompt);
            if (Int32.TryParse(Console.ReadLine(), out n)) {
                if (n > -1) { return true; }
            }

            return false;
        }




    }

}