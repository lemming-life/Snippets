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
            Language.executeDriver(CONSOLE_INPUT);
            Maths.executeDriver();
            Geometry.executeDriver();
            StringOperations.executeDriver();
            Time.executeDriver();
            Misc.executeDriver();
            Sorting.executeDriver();

            if (CONSOLE_INPUT) Input.executeDriver();

            Challenges.Challenge1.executeDriver();
            Challenges.Challenge2.executeDriver();
            Challenges.Challenge3.executeDriver();
            Challenges.Challenge4.executeDriver();

        } // End Main()

    } // End class Program

} // End namespace ConsoleApplication
