// Author: http://lemming.life
// Language: C#
// Description: Soime time related functions.

using System;

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
            Console.WriteLine("\nSubTest: timeAsMinutes");
                string hhmm = "00:33";
                Console.WriteLine("{0} is {1} minutes", hhmm, timeAsMinutes(hhmm));
                hhmm = "01:00";
                Console.WriteLine("{0} is {1} minutes", hhmm, timeAsMinutes(hhmm));
                hhmm = "01:33";
                Console.WriteLine("{0} is {1} minutes", hhmm, timeAsMinutes(hhmm));
                hhmm = "24:00";
                Console.WriteLine("{0} is {1} minutes", hhmm, timeAsMinutes(hhmm));

        } // End executeDriver()

        public static bool isLeapYear(int year) {
            if (year < 1582) { return false;} // https://en.wikipedia.org/wiki/Leap_year
            if (year % 4 != 0) { return false; }
            if (year % 100 != 0) { return true; }
            if (year % 400 != 0) {return false; }
            return true;
        }

        public static int timeAsMinutes(string hhmm) {
            // Input: hhmm must be in hh:mm
            const int MINUTES_IN_HOUR = 60;
            return (int.Parse(hhmm.Substring(0, 2)) * MINUTES_IN_HOUR) + int.Parse(hhmm.Substring(3, 2));
        }

    } // End class Time

}