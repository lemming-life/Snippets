// Author: http://lemming.life
// Language: C#
// Purpose: Tests my C# snippets
// Date: July 15, 2017


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
            Square.executeDriver();
            Fibonacci.executeDriver();
            
            //Fibonacci.executeDriver();
            //Square.executeDriver();
            //UrlParser.executeDriver();
            //Reverse.executeDriver();
            Palindrome.executeDriver();
        }
    }
}
