// Author: http://lemming.life
// Language: C#
// Description: Collection of geometry classes.

using System;

namespace Snippets {

    class Geometry {

        public static void executeDriver(bool standardInput = false) {
            Console.WriteLine("\nSubTest: CircleInSquare");
                CircleInSquare circleInSquare = new CircleInSquare(5);
                circleInSquare.showResults();

            Console.WriteLine("\nSubTest: getHypothenuse");
            {
                int sideA = 2;
                int sideB = 4;
                Console.WriteLine("sideA {0} and sideB{1}, hypothenuse is {2}", sideA, sideB, getHypothenuse(sideA, sideB));
            }

            Console.WriteLine("\nSubTest: getPolarCoordinates");
                {
                    Console.WriteLine("\nTesting quadrants");

                    double x, y, angle, distance;
                    x = y = 2; getPolarCoordinates(x, y, out angle, out distance);
                    Console.WriteLine("x: {0} y: {1} | Polar coords, angle {2:f2}, distance {3:f4}", x, y, angle, distance);
                    x = -2;y = 2; getPolarCoordinates(x, y, out angle, out distance);
                    Console.WriteLine("x: {0} y: {1} | Polar coords, angle {2:f2}, distance {3:f4}", x, y, angle, distance);
                    x = y = -2; getPolarCoordinates(x, y, out angle, out distance);
                    Console.WriteLine("x: {0} y: {1} | Polar coords, angle {2:f2}, distance {3:f4}", x, y, angle, distance);
                    x = 2; y = -2; getPolarCoordinates(x, y, out angle, out distance);
                    Console.WriteLine("x: {0} y: {1} | Polar coords, angle {2:f2}, distance {3:f4}", x, y, angle, distance);

                    Console.WriteLine("\nTesting when coords have zeros.");
                    x = y = 0; getPolarCoordinates(x, y, out angle, out distance);
                    Console.WriteLine("x: {0} y: {1} | Polar coords, angle {2:f2}, distance {3:f4}", x, y, angle, distance);
                    x = 1; y = 0; getPolarCoordinates(x, y, out angle, out distance);
                    Console.WriteLine("x: {0} y: {1} | Polar coords, angle {2:f2}, distance {3:f4}", x, y, angle, distance);
                    x = -1; y = 0; getPolarCoordinates(x, y, out angle, out distance);
                    Console.WriteLine("x: {0} y: {1} | Polar coords, angle {2:f2}, distance {3:f4}", x, y, angle, distance);
                    x = 0; y = 1; getPolarCoordinates(x, y, out angle, out distance);
                    Console.WriteLine("x: {0} y: {1} | Polar coords, angle {2:f2}, distance {3:f4}", x, y, angle, distance);
                    x = 0; y = -1; getPolarCoordinates(x, y, out angle, out distance);
                    Console.WriteLine("x: {0} y: {1} | Polar coords, angle {2:f2}, distance {3:f4}", x, y, angle, distance);
                
                } // End getPolarCoordinates subtest
                
        } // End executeDriver()

        public static double getHypothenuse(double sideA, double sideB) {
            return Math.Sqrt( (sideA*sideA) + (sideB*sideB) );
        }

        public class CircleInSquare {
            private double _circleRadius;
            private double _squareLength;
            public CircleInSquare(double radius) {
                _circleRadius = radius;
                _squareLength = radius*2;
            }

            public double getCircleArea() {
                return Math.PI * Math.Pow(_circleRadius, 2);
            }

            public double getSquareArea() {
                return _squareLength * _squareLength;
            }

            public double getCornerAreaOfCorners() {
                return getSquareArea() - getCircleArea();
            }

            public void showResults() {
                Console.WriteLine("Circle In Square Details");
                Console.WriteLine("Radius of circle {0} and length of square {1}", _circleRadius, _squareLength);
                Console.WriteLine("Area of circle: {0:f4}", getCircleArea());
                Console.WriteLine("Area of square: {0:f4}", getSquareArea());
                Console.WriteLine("Sum of corners area: {0:f4}", getCornerAreaOfCorners());
            }

        } // End class CircleInSquare


        public static void getPolarCoordinates(double x, double y, out double angle, out double distance) {
            // Determines the distance and angle to the x and y location.
            // Assumes origin coordinate is 0, 0.
            // Angle goes from 0 counter-clockwise to 360.

            distance = Math.Sqrt( (x*x) + (y*y) );
            
            if ( y==0 && x>0 ) { angle = 0; return; }
            if ( y>0 && x==0 ) { angle = 90; return; }
            if ( y==0 && x<0 ) { angle = 180; return; }
            if ( y<0 && x==0 ) { angle = 270; return; }

            const double RADS_TO_DEGREE_CONVERSION_FACTOR = 180 / Math.PI;
            angle = Math.Atan(  y / x ) * RADS_TO_DEGREE_CONVERSION_FACTOR;

            if ( x<0 ) { angle = 180 + angle; return; } 
            if ( x>0 && y<0 ) { angle = 360 + angle; return; }
        } // End getPolarCoordinates

    } // End class Geometry
}