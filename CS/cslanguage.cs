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
            }

            public void input() {
                Console.WriteLine("Reading input.");
                string input = Console.ReadLine();
                Console.WriteLine("Your typed: " + input);
            }
        } // End class ConsoleOutputInput


    } // End class CsLanguages
}