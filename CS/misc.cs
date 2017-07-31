// Author: http://lemming.life
// Language: C#
// Description: Miscelaneous methods.

using System;

namespace Snippets {
    class Misc {
        public static void executeDriver(bool standardIn = false) {
            Console.WriteLine("\nSubTest generic Swap");
                int anIntA = 3;
                int anIntB = 5;
                Console.WriteLine("Before: {0} and {1}", anIntA, anIntB);
                Swap(ref anIntA, ref anIntB);
                Console.WriteLine("After: {0} and {1}", anIntA, anIntB);
                
                string colorA = "red";
                string colorB = "green";
                Console.WriteLine("Before: {0} and {1}", colorA, colorB);
                Swap(ref colorA, ref colorB);
                Console.WriteLine("After: {0} and {1}", colorA, colorB);
        }


        static void Swap<T>(ref T left, ref T right) {
            // Generic swap via reference.
            T temp;
            temp = left;
            left = right;
            right = temp;
        }
    } // End class Misc
}