// Author: http://lemming.life
// Purpose: Compute the nth fibonacci number.
// Language: C#
// Date: June 26, 2017

// To setup in console do:
// dotnet run
// dotnet restore
// (now paste the code onto the Program.cs file)
// dotnet run

using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Let's determine the nth Fibonacci number.");
            Console.WriteLine("To quit, type anything other than a non-negative integer.");

            int n = 0;
            while (UserInput("\nPlease, enter value: ", ref n)) {
                Console.WriteLine("Fibonacci({0}) = {1}", n, Fibonacci(n));
            }
            Console.WriteLine("Bye!");
        } // End Main()

        // Purpose: Ensures user enters non-negative integer as input.
        // Notes:
        // 1. Prompts the user for input.
        // 2. Parse the input, ensure non-negative integer.
        // 3. Return true if non-negative integer, false otherwise.
        public static bool UserInput(string prompt, ref int n) {
            Console.Write(prompt);

            if (Int32.TryParse(Console.ReadLine(), out n)) {
                if (n > -1) { return true; }
            }

            return false;
        } // End UserInput()

        // Purpose: Computes the nth fibonacci number.
        // Conditions: non-negative integer as input.
        // Details: Uses iteration to ensure fast evaluation and to conserve stack space.
        public static int Fibonacci(int n) {
            if (n == 0) { return n; }
            
            int fibLeft, fibRight, result;
            fibLeft = 0;
            result = 1;

            for (int i=0; i<(n-1); ++i) {
                fibRight = fibLeft;
                fibLeft = result;
                result = fibLeft + fibRight;
            }
            
            return result;
        } // End Fibonacci()

    } // End class Program
}
