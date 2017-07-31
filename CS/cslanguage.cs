// Author: http://lemming.life
// Language: C#
// Description: Collection of C# language bits.


using System;

namespace Snippets {
    class CsLanguage {

        public static void executeDriver(bool standardInput = false) {
            Console.WriteLine("\nSubTest: Simple Output and Input");
            ConsoleOutputInput coi = new ConsoleOutputInput();
                coi.output();
                if (standardInput) { coi.input(); }

        }

        class ConsoleOutputInput {

            public void output() {
                string name = "Jack";
                Console.WriteLine("My name is " + name);
                Console.WriteLine("{0} is my name.", name);

                double someNumber = 1234.5678;
                Console.WriteLine("Format {0} with 4 decimal places: {1:f4}", someNumber, someNumber);
                Console.WriteLine("Format {0} as number with 3 decimal places: {0:n3}", someNumber);
                Console.WriteLine("Format {0} as currency with two decimal places: {0:c2}", someNumber);
                Console.WriteLine("Format {0} as exponential: {0:e}", someNumber);
                Console.WriteLine("Format {0} with leading zeros: {0:d4}", 12);
                Console.WriteLine("Format {0} as percent: {0:p}", 0.33);
                Console.WriteLine("Format {0} with 4 leading digits a period and 2 decimal places {0:0000.00}", 12.3);
            }

            public void input() {
                Console.WriteLine("Reading input.");
                string input = Console.ReadLine();
                Console.WriteLine("Your typed: " + input);
            }
        } // End class ConsoleOutputInput


    } // End class CsLanguages
}