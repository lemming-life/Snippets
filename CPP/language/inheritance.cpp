// Author: http://lemming.life
// Language: C++
// Purpose: Shows inheritance in C++

/* At terminal do:
    g++ inheritance.cpp
    ./a.out
*/

#include <iostream>
using namespace std;

class Shape {
private:
    int id;
public:
    Shape(int id) { this->id = id; }
    ~Shape() { std::cout << "Shape destructor.\n"; }
    int getId() { return id; }
    int getRadius() { return 0; }
};

// Inheritance
class Circle : public Shape {
private:
    int radius;
public:
    // Calling the base constructor
    Circle(int id, int radius) : Shape(id) { this->radius = radius; } 

    // Destructors go from specific to base
    ~Circle() { std::cout << "Circle destructor\n"; }

    int getRadius() { return radius; }    
};


int main() {
    int id = 0;
    Shape shape(++id);
    std::cout << "id is " << shape.getId() << ". Radius is " << shape.getRadius() << "\n";

    Circle circle(++id, 100);
    std::cout << "Id is " << circle.getId() << ". Radius is " << circle.getRadius() << "\n";

    Shape* someShape = new Circle(++id, 200);
    std::cout << "Id is " << someShape->getId() << ". Radius is " << someShape->getRadius() << "\n"; // Calls Shape class getRadius()

    // Check the interface.cpp to see how to change the method behavior.
    return 0;
}