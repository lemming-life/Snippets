
using System;


namespace Snippets {
    class CsLanguage {

        public static void executeDriver(bool standardInput = false) {
            Console.WriteLine("TEST: Simple Input and Output");
            ConsoleInputOutput cio = new ConsoleInputOutput();
            cio.output();
            if (standardInput) { cio.input(); }

            Console.WriteLine("\n");

            
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