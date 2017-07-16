// Author: http://lemming.life
// Language: C#
// Purpose: Returns the square of a number.
// Date: July 25, 2017

using System;
using System.IO;

namespace Snippets {

    public class Square {
        public static int square(int x) {
            return x * x;
        }

        public static void executeDriver() {
            using (StreamReader reader = new StreamReader(Console.OpenStandardInput()))
            while (!reader.EndOfStream) {
                Console.Write("Input to square: ");
                string line = reader.ReadLine();
                int n;
                if (Int32.TryParse(line, out n)) {
                    Console.WriteLine("The square of {0} is {1}", n, Square.square(n));
                }
            }
        }
    }

}