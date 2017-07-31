
using System;


namespace Snippets {
    class CsLanguage {

        public static void executeDriver(bool standardInput = false) {
            Console.WriteLine("\n - TEST: Simple Input and Output");
            ConsoleInputOutput cio = new ConsoleInputOutput();
                cio.output();
                if (standardInput) { cio.input(); }

        }

        class ConsoleInputOutput {

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
        }

        



    }

}