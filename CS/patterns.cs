
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

        class SoftHorn : HornBehavior {
            public void makeSound() { Console.WriteLine("SOFT"); }
        }
    } // End class StrategyPattern


    public class DecoratorPattern {
        // Description: A fairly bland component that is then decorated with other components.

        // Decorator principles:
        // - Open for extension, closed for modification.
        // - Single responsibility
        // - Separate what varies from what stays the same.

        // Pros:
        // - Flexible, and should be easy to debug.

        // Cons:
        // - Lots of objects are created.
        // - Can have quite tedious looking code when instantiating.

        public static void executeDriver() {
            Console.WriteLine("\nDecorator Pattern");
            Console.WriteLine("Milk $1, Cream $2, Sugar $3");

            var milkSugar = new Sugar(new Milk());
            Console.WriteLine("Milk sugar. {0:c2}", milkSugar.cost()); // $4

            var milkCreamSugar = new Cream(new Sugar(new Milk()));
            Console.WriteLine("Milk with cream and sugar. {0:c2}", milkCreamSugar.cost()); // $6

            var milkCreamCreamSugar = new Cream(new Cream(new Sugar(new Milk())));
            Console.WriteLine("Milk with double cream and sugar. {0:c2}", milkCreamCreamSugar.cost()); // $8
        }

        // Component (abstraction)
        interface MilkComponent {
            int cost();
        }

        // Concrete Component
        class Milk : MilkComponent {
            public int cost() { return 1; }
        }

        // Decorator (abstraction)
        abstract class Decorator : MilkComponent {
            // Base Decorator class
            protected MilkComponent _other = null;
            public Decorator(MilkComponent other) { _other = other; }
            public abstract int cost();
        }

        // Concrete Decorator
        class Cream : Decorator {
            public Cream(MilkComponent other) : base(other) { }
            public override int cost() { return 2 + _other.cost(); }
        }

        // Concrete Decorator
        class Sugar : Decorator {
            public Sugar(MilkComponent other) : base(other) { }
            public override int cost() { return 3 + _other.cost(); }
        }
    }  // End class DecoratorAndNullPattern


    class AdapterPattern {
        public static void executeDriver() {
            Console.WriteLine("\nAdapter Pattern");
            var obj1 = new TargetAlready();  // obj1.request() returns int
            var obj2 = new Adaptee();   // obj2.request() returns string
            var obj3 = new AdapteeToTarget(); // obj3.request() returns int
            // But obj3 is really an Adaptee that makes methods compatible with new interface.
            
            //if ( obj1.request() == obj2.request() ) {} // Incompatible
            if ( obj1.request() == obj3.request() ) {} // Compatible
        }

        interface CurrentTargetSpecification {
            int request();
        }

        class TargetAlready : CurrentTargetSpecification {
            public int request() { return 33; }
        }

        class AdapteeToTarget : CurrentTargetSpecification {
            // This s the Adapter
            // In C++ we have public inheritance of CurrentTargetSpecification
            // and private inheritance of Adaptee
            // But in C# we don't have that, so we'll use an object in the method.
            public int request() {
                Adaptee adaptee = new Adaptee();
                return int.Parse( adaptee.request() );  // Adapting from string to an int
            }
        }

        class Adaptee {
            // The adaptee is the version that is incompatible
            // but the code is good for use, if adapted by the adapter. 
            public string request() {return "33";}
        }
    }


} // End namespace Patterns