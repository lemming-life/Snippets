// Author: http://lemming.life
// Language: C++
// Description: Example of creating and using an object.

/* At terminal do:
    g++ pointers.cpp
    ./a.out
*/

#include <iostream>

class Shape {
private:
    int id;
public:
    Shape(int id) {
        this->id = id;
    }
    int getId() { return id; }

    ~Shape() {
        std::cout << "Destroying shape" << id << "\n";
    }
};


// Pass a Shape* 
void PrintShape(Shape* shape) {
    std::cout << "Shape ID: " << shape->getId() << "\n"; 
}

int main() {
    int id = 0;

    {   // Deepen the scope
        
        // Create shape1
        Shape shape1(++id);
        PrintShape(&shape1); // Pass the address of shape

        Shape* shapePtr; // A pointer holds the address of an object type specified (in this case Shape)
        // The pointer itself is in the stack section of a program

        {
            Shape shape2(++id); // Create shape2 on the stack.
            PrintShape(&shape2);
            shapePtr = &shape2;

            // Ways to use the pointer
            std::cout << "Via pointer, arrow operator. ID: " << shapePtr->getId() << "\n";
            std::cout << "Via pointer, derefencing. ID: " << (*shapePtr).getId() << "\n";

        } // Destroying shape2 because the object goes out of scope

        // the shapePtr still has the address of the shape2 object
        PrintShape(shapePtr); // Expect: Shape ID: 2

        shapePtr = new Shape(++id);  // Creates an object on the heap portion of a program.
        PrintShape(shapePtr); // Shape ID: 3
        delete shapePtr; // Deletes the object pointed by the shapePtr 

        shapePtr = new Shape(++id); // This is Shape with id 4

    } // Destroying shape1 automatically because the object goes out of scope

    // Note that shape with id 4 was never deleted. This is a memory leak!
    // Other languages have garbage collection -- cleans memory automatically.
    // C++ 11 has shared pointers that can be used for automatically doing clean up.

    return 0;
}


// Expected Output:
/*
Shape ID: 1
Shape ID: 2
Via pointer, arrow operator. ID: 2
Via pointer, derefencing. ID: 2
Destroying shape2
Shape ID: 2
Shape ID: 3
Destroying shape3
Destroying shape1
*/