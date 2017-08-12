// Author: http://lemming.life
// Language: C++
// Purpose: Example of object oriented programming using classes.
// - C++ is C with classes.
// - Classes enable "encapsulation", meaning everything needed for x is in one package/class.
// - Has clases, enum, interface, abstract class, inheritance, polymorphism, access modifiers, 

#include <iostream>
#include <string>
using namespace std;
//using std::string;

class Simple {
    public:
        int x;  // This is a public member variable
        void changeX(int newX) { x = newX; } // This is a public method
};

class Simple2 {
    private:
        int x; // Essential, a private member is one that only the class can access
    public:
        void changeX(int newX) { x = newX; } // changeX is a public method, which can access that x
};


// An enum is a type that has constant members.
enum Color { RED, GREEN, BLUE };

// A simple structure for x and y values.
struct Position {
    int x;
    int y;

    string toString() {
        return "x: " + to_string(x) + " y: " + to_string(y);
    }
};

// An interface is a constract
// - Those using the interface must implement the methods advertised.
class PositionInterface {
    virtual int getX() = 0;
    virtual int getY() = 0;
    virtual void changePosition(int, int) = 0;
};

// Shape is an abstract class
// - Abstract classes cannot be instantiated, but those inheriting from can be instantiated.
// - The setColor(Color aColor) = 0 makes this an "abstract class" in c++
class Shape : PositionInterface {
    private:
        Position position; // The shape has a position structure, it is private and thus only Shape can access
    protected:
        Color color; // Shape and child classes can access
    public:

        // This is a parameterized constructor
        Shape(int newX, int newY) {
            position.x = newX;
            position.y = newY;
        } 

        // Implementation of the PositionInterface methods
        int getX() { return position.x; }
        int getY() { return position.y; }
        void changePosition(int newX, int newY) { position.x = newX; position.y = newY; }

        // Shape by itself doesn't have a color
        // but the inherited types may. So, we must
        // ensure that inherited classes implement.
        virtual Color getColor() { return color; }   // virtual method, it can be called but must be done so explictly
        virtual void setColor(Color aColor) = 0;    // A pure virtual method == the child must implement.

        virtual string toString() {
            string colorStr;

            // The getColor() method call will be the child one (Circle)
            // - Polymorphism is magic.
            switch(getColor()) {
                case RED: colorStr = "Red"; break;
                case GREEN: colorStr = "Green"; break;
                case BLUE: colorStr = "Blue"; break;
                default: colorStr = "None"; break;
            }
            return position.toString() + " Color: " + colorStr;
        }

        // Abstract classes must have virtual destructors
        virtual ~Shape() { }
};

// Circle inherits from Shape
// - This is a is-a relationship. Circle "is-a" shape.
class Circle : public Shape {
    private:
        int radius;
    public:
        // A parameterized constructor that calls Shape constructor for the x and y positions.
        Circle(int newX, int newY, int newRadius) : Shape(newX, newY) {
            radius = newRadius;
        }

        Color getColor() {
            return Shape::getColor(); // Explicitly calling the abstract class getColor();
        }

        void setColor(Color aColor) {
            color = aColor; // Circle can access protected and public members
        }

        string toString() {
            return Shape::toString() + " Radius: " + to_string(radius);
        }

        ~Circle() {
            // This is the Circle destructor
            // then ~Shape destructor is called
        }
};

class Square : public Shape {
    private:
        int width;
        int height;
    public:

        // Repeating ourselves is tedious...
        // Seeing repetition like this means that we should reconsider
        // how we have implemented. Perhaps it is the wrong approach.
        // One fix is to delegate this to Shape as a "has-a" relationship
        // in a similar way as we have done with a "has-a" position.
        Color getColor() { return color; }
        void setColor(Color aColor) { color = aColor; }


        string toString() {
            return Shape::toString() + " Width: " + to_string(width) + " Height: " + to_string(height);
        }

        Square(int newX, int newY, int newWidth, int newHeight) : Shape(newX, newY) {
            width = newWidth;
            height = newHeight;
        }
        ~Square() { }
};



int main() {
    
    Simple simple;
    simple.x = 5;
    cout << "Simple x is " << simple.x << '\n'; // 5
    simple.changeX(10);
    cout << "Simple x is " << simple.x << '\n'; // 10

    // Create an object.
    Circle* circle = new Circle(0, 0, 5);
    cout << circle->toString() << '\n'; // Color not yet assigned. So output is x: 0 y: 0 Color: None Radius: 5
    circle->setColor(RED);
    cout << circle->toString() << '\n'; // x: 0 y: 0 Color: Red Radius: 5
    delete circle; // Order of destructor call is from specific to base.

    // Imagine having a collection of Circles, then we have a collection of Squares.
    // Then we go through each collection, and call the toString() method of each element.
    // Wouldn't it be better if we had a single collection of Squares and Circles -- a collection of Shapes.
    // We can do this because Shape* is an abstract class and both Squares and Circles inherit from it.
    Shape* shapes[] = { new Circle(1, 2, 3), new Square(4, 5, 6, 7) }; // This may also be called "program to an interface"
    int length = 2;

    for(int i=0; i<length; ++i) {
        // Polymorphism: it knows which to call Circle::toString() or Square::toString()
        cout << shapes[i]->toString() << '\n'; 
        delete shapes[i]; // Delete the object. In C++ we must free memory manually.
    }

    return 0;
}