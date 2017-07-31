using System;
using System.Text;

namespace Snippets {
    class Time {

        public static void executeDriver() {
            Console.WriteLine("\nSubTest: isLeapYear");
                Console.WriteLine("Is {0} leap? {1}", 4, isLeapYear(4));
                Console.WriteLine("Is {0} leap? {1}", 100, isLeapYear(100));
                Console.WriteLine("Is {0} leap? {1}", 400, isLeapYear(400));
                int year = 2000;
                Console.WriteLine("Is {0} leap? {1}", year, isLeapYear(year++));
                Console.WriteLine("Is {0} leap? {1}", year, isLeapYear(year++));
                Console.WriteLine("Is {0} leap? {1}", year, isLeapYear(year++));
                Console.WriteLine("Is {0} leap? {1}", year, isLeapYear(year++));
                Console.WriteLine("Is {0} leap? {1}", year, isLeapYear(year++));
                Console.WriteLine("Is {0} leap? {1}", year, isLeapYear(year++));
        }

        public static bool isLeapYear(int year) {
            if (year < 1582) { return false;} // https://en.wikipedia.org/wiki/Leap_year
            if (year % 4 != 0) { return false; }
            if (year % 100 != 0) { return true; }
            if (year % 400 != 0) {return false; }
            return true;
        }

    } // End class Time

}