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

    }

}