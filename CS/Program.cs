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
            const Boolean CONSOLE_INPUT = true;
            Language.executeDriver(CONSOLE_INPUT);
            
            Maths.executeDriver();
            Geometry.executeDriver();
            StringOperations.executeDriver();
            Time.executeDriver();
            Misc.executeDriver();
            Sorting.executeDriver();

            if (CONSOLE_INPUT) Input.executeDriver();

            Challenges.AllChallenges.executeDriver(CONSOLE_INPUT);
        } // End Main()

    } // End class Program

} // End namespace ConsoleApplication
