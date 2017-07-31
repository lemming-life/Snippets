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

    } // End class Geometry
}