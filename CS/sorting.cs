// Author: http://lemming.life
// Language: C#
// Description: Some sorting methods

using System;

namespace Snippets {
    delegate bool CompareDelegate<T>(T a, T b);

    class Sorting {

        public static void executeDriver() {
            Console.WriteLine("\nTEST: Sorting");

            Console.WriteLine("\nSubTest: bubbleSortArray");
            {
                int[] intData = { 5, 2, 11, 4, 6, 5 };
                Console.WriteLine("Unsorted data: ");
                foreach(var item in intData) { Console.Write(item + " "); }
                bubbleSortArray(intData);
                Console.WriteLine("\nSorted descending data:");
                foreach(var item in intData) { Console.Write(item + " "); }
                bubbleSortArray(intData, false);
                Console.WriteLine("\nSorted ascending data:");
                foreach(var item in intData) { Console.Write(item + " "); }
                Console.WriteLine();
            }


            
        }
        
        static void bubbleSortArray<T>(T[] array, bool descending = true) where T : IComparable {
            CompareDelegate<T> compareOperator;
            
            if (descending) {
                compareOperator = new CompareDelegate<T>(lessThan);
            } else {
                compareOperator = new CompareDelegate<T>(greaterThan);
            }
            
            for (int i=0; i<array.Length; ++i) {
                for (int j=0; j<array.Length-1; ++j) {
                    if ( compareOperator(array[j], array[j+1]) ) {
                        Snippets.Misc.Swap(ref array[j], ref array[j+1]);
                    }
                }
            }
        }
        
       public static bool lessThan<T>(T a, T b) where T : IComparable {
            return a.CompareTo(b) < 0;
       }

       public static bool greaterThan<T>(T a, T b) where T : IComparable {
           return a.CompareTo(b) > 0;
       }

    } // End class sorting

}