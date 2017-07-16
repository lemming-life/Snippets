// Author: http://lemming.life
// Language: C#
// Purpose: Tests my C# snippets
// Date: July 16, 2017


using System;
using Snippets;

// To setup in console do:
// dotnet new
// dotnet restore
// (You can paste the code on this file onto Program.cs)
// dotnet run

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nTEST: Square");
            Square.executeDriver();

            Console.WriteLine("\nTEST: Fibonacci");
            Fibonacci.executeDriver();

            Console.WriteLine("\nTEST: Palindrome");
            Palindrome.executeDriver();

            Console.WriteLine("\nTEST: UrlParser");
            UrlParser.executeDriver();

            Console.WriteLine("\nTEST: Reverse");
            Reverse.executeDriver();

            // Since user input is required,
            // it is best to keep commented for now.
            //Console.WriteLine("\nTEST: Input");
            //Input.executeDriver();
        }
    }
}
