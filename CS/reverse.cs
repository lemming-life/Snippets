// Author: http://lemming.life
// Language: C#
// Purpose: Reverse an integer.
// Date: July 25, 2017

using System;
using System.Text;

namespace Snippets {

    class Reverse {
        public static string reverseStr(string s) {
            StringBuilder reversed = new StringBuilder();
            for (int i = s.Length-1; i > -1; --i) {
                reversed.Append(s[i]);
            }
            return reversed.ToString();
        }

        public static int reverseInt(int n) {
            int reversed;
            Int32.TryParse(reverseStr(n.ToString()), out reversed);
            return reversed;
        }

        public static void executeDriver() {
            string str = "Hello, World";
            Console.WriteLine("The reverse of '{0}' is '{1}'", str, reverseStr(str));

            int n = 12345;
            Console.WriteLine("The reverse of {0} is {1}", n, reverseInt(n));
        }
    }

}