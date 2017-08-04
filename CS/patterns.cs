
using System;

namespace Patterns {

    class AllPatterns {
        public static void executeDriver() {
            Console.WriteLine("\nTEST: Patterns");
            StrategyPattern.executeDriver();
            DecoratorPattern.executeDriver();

        }
    }


    public class StrategyPattern {
        // Notes: Uses composition, uses a has-a relationship.
        // Pros: Can change behavior if needed, prevents us from having a larger hierarchy (aka Car, BigCar, LittleCar, etc.)
        // Cons: Can lead to a lot of classes of the interface of the behavior.
        // Principles:
        // - Identify what varies from what stays the same.
        // - Program to an interface (or abstraction), not an implementation
        // - Favor composition over inheritance.
        // - Don't repeat yourself.

        public static void executeDriver() {
            Console.WriteLine("\nStrategy Pattern");
            Car bigCar = new Car(new LoudHorn());
            Console.WriteLine("bigCar horn is ");
            bigCar.makeSound(); // LOUD!!!

            Car smallCar = new Car(new SoftHorn());
            Console.WriteLine("smallCar horn is ");
            smallCar.makeSound(); // SOFT
        }


        class Car {
            HornBehavior horn;
            public Car(HornBehavior horn) { this.horn = horn; }

            public void makeSound() { horn.makeSound(); }
        }

        interface HornBehavior {
            void makeSound();
        }

        class LoudHorn : HornBehavior {
            public void makeSound() { Console.WriteLine("LOUD!!!"); }
        }

        public class SoftHorn : HornBehavior {
            public void makeSound() { Console.WriteLine("SOFT"); }
        }
    }


    public class DecoratorPattern {
        // Decorator pattern, with NullPattern

        // Decorator principles:
        // - Open for extension, closed for modification.
        // - Single responsibility
        // - A derived class can be used wherever an instance of the base class is used.

        // Pros:
        // - Flexible

        // Cons:
        // - Lots of objects are created.
        // - Can have quite tedious looking code.

        public static void executeDriver() {
            Console.WriteLine("\nDecorator and Null Pattern");
            var milkCreamSugar = new Milk(new Cream(new Sugar(null)));
            Console.WriteLine("A milk with cream and sugar. {0:c2}", milkCreamSugar.cost() );
            var milkSugarSugar = new Milk(new Sugar(new Sugar(null)));
            Console.WriteLine("A milk with double sugar. {0:c2}", milkSugarSugar.cost() );
        }

        interface CostInterface {
            int cost();
        }

        public class Decorator : CostInterface {
            // Base Decorator class
            protected Decorator other;
            public Decorator(Decorator other = null) {
                this.other = other;
            }
            public int cost() {
                if (other != null) {
                    return other.cost();;
                }
                return 0;
            }
        }


        class Milk : Decorator {

            public Milk(Decorator other ) : base(other) { }
            public int cost() { return (other.cost() + 1); }
        }

        class Cream : Decorator {
            public Cream(Decorator other ) : base(other) { }

            public int cost() { return (other.cost() + 2); }
        }

        class Sugar : Decorator {
            public Sugar(Decorator other ) : base(other) { }

            public int cost() { return (other.cost() + 1); }
        }
    }  // End class DecoratorAndNullPattern


} // End namespace Patterns