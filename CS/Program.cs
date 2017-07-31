// Author: http://lemming.life
// Language: C#
// Description: Tests C# snippets

using System;
using Snippets;

// To setup in console do:
/*
dotnet new
dotnet restore
dotnet run
 */

namespace ConsoleApplication {
    public class Program {
        public static void Main(string[] args) {
            const Boolean CONSOLE_INPUT = false;

            Console.WriteLine("\nTEST: C# Language");
            CsLanguage.executeDriver(CONSOLE_INPUT);

            Console.WriteLine("\nTEST: Maths");
            Maths.executeDriver();

            Console.WriteLine("\nTEST: Geometry");
            Geometry.executeDriver();

            Console.WriteLine("\nTEST: String Operations");
            StringOperations.executeDriver();

            Console.WriteLine("\nTEST: Time");
            Time.executeDriver();

            Console.WriteLine("\nTEST: Misc");
            Misc.executeDriver();

            Console.WriteLine("\nTEST: Challenge1");
            Challenges.Challenge1.executeDriver();

            Console.WriteLine("\nTEST: Challenge2");
            Challenges.Challenge2.executeDriver();

            if (CONSOLE_INPUT) {
                Console.WriteLine("\nTEST: Input");
                Input.executeDriver();
            }
           
        } // End Main()

    } // End class Program

} // End namespace ConsoleApplication
