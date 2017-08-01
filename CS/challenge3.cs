// Partial-Author: http://lemming.life
// Language: C#

using System;

namespace Challenges {
    class Challenge3 {
        /* Challenge Description:
        Given an initial departure and arrival time, determine the new arrival time with
        consideration of a percent delay. Use a HH:MM, and 24 hour, format.
        */

        public static void executeDriver() {
            string departureTime, arrivalTime, delayPercent;
            Console.WriteLine("\nSubtest1");
                departureTime = "01:00";
                arrivalTime = "02:00";
                delayPercent = "10";
                performTripCalculation(departureTime, arrivalTime, delayPercent);
            Console.WriteLine("\nSubtest2");
                departureTime = "23:30";
                arrivalTime = "24:00";
                delayPercent = "50";
                performTripCalculation(departureTime, arrivalTime, delayPercent);
            Console.WriteLine("\nSubtest3");
                departureTime = "23:30";
                arrivalTime = "00:00";
                delayPercent = "50";
                performTripCalculation(departureTime, arrivalTime, delayPercent);
            Console.WriteLine("\nSubtest4");
                departureTime = "23:30";
                arrivalTime = "01:00";
                delayPercent = "50";
                performTripCalculation(departureTime, arrivalTime, delayPercent);
        } // End executeDriver()

        public static void performTripCalculation(string departureTime, string arrivalTime, string delayPercent) {
            string newArrivalTime = calculateNewArrivalTime(departureTime, arrivalTime, delayPercent);
                Console.WriteLine("Trip departs at {0}, expected to arrive at {1}, but has {2}% delay", departureTime, arrivalTime, delayPercent);
                Console.WriteLine("The new arrival time is {0}", newArrivalTime);
        }

        public static string calculateNewArrivalTime(string initialDepatureTime, string usualArrivalTime, string delayPercent) {
            // Input:
            // HH:MM format for initialDepatureTime and usualArrivalTime
            // delayPercent from 0 to 100 to mean 0% to 100%

            // Output:
            // A string in HH:MM format indicating the new arrival time.

            const int HOURS_IN_DAY = 24;
            const int MINUTES_IN_HOUR = 60;

            // Conversion
            int initialDepartureTimeAsMinutes = Snippets.Time.timeAsMinutes(initialDepatureTime);
            int usualArrivalTimeAsMinutes = Snippets.Time.timeAsMinutes(usualArrivalTime);
            double delayPercentAsDouble = double.Parse(delayPercent) / 100.0;

            // Consideration for when arrival time is next day.
            if (usualArrivalTimeAsMinutes < initialDepartureTimeAsMinutes) {
                usualArrivalTimeAsMinutes += HOURS_IN_DAY * MINUTES_IN_HOUR;
            }

            // Determine the trip time
            double tripTimeAsMinutes = usualArrivalTimeAsMinutes - initialDepartureTimeAsMinutes;

            // Add the delay
            tripTimeAsMinutes += tripTimeAsMinutes * delayPercentAsDouble;

            // Add the time to the initialDepartureTime
            int newArrivalTimeAsMinutes = initialDepartureTimeAsMinutes + (int)tripTimeAsMinutes;

            // Determine the new HHMM
            int hours = Snippets.Maths.breakByDenomination(ref newArrivalTimeAsMinutes, MINUTES_IN_HOUR); // 60 minutes in an hour.
            int minutes = newArrivalTimeAsMinutes; // Whatever is left are the minutes

            // 24 hr correction
            if (hours >= 24) { hours -= 24; }

            return hours.ToString("00") + ":" + minutes.ToString("00");
        } // End calculateNewArrivalTime()

    } // End Challenge3

}