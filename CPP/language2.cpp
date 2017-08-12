// Author: http://lemming.life
// Language: C++
// Purpose: Examples on how to use C++, covers functions, function template, structs, void*

#include <iostream>
using namespace std;

// Pass by value
int sum(const int a, const int b) { // note that const indicates that such will not be modified
    return a + b;
}

// Pass by reference
void sum2(const int a, const int b, int& c) {
    c = a + b;
}

// Forward declaration of a function
void sum3(int*, int*, int*);


// TEMPLATE function
template <typename T>
T sum4(const T a, const T b) {
    return a + b;
}


// A structure holds values
struct Circle {
    int x;
    int y ;
    int radius;

    // A constructor
    // - It can be used to assign values or call methods.
    // - Usually it is the first thing to run regarding an object.
    Circle() { x = 0; y = 0; radius = 1; }

    // A destructor
    // - Called when deleting an object
    ~Circle() { }

}; // Note the semi-colon at end

// This function must be below the struct Circle declaration.
void PrintCircle(Circle& aCircle) {
    cout << aCircle.x << ", " << aCircle.y << ", " << aCircle.radius << "\n";
}

// A function that takes a void*
void PrintCircle2(void* unknown) {
    Circle* circle = (Circle*) unknown; // We must cast the void* to be something, then work with it.
    PrintCircle(*circle);
}

int main() {
    int a = 2;
    int b = 3;
    int c;
    cout << "By Value, sum of " << a << " and " << b << " is " << sum(a, b) << '\n'; // 2, 3, 5

    sum2(a, b, c);
    cout << "By Reference, " << a << " and " << b << " is " << c << '\n'; // 2, 3, 5

    a = 2; b = 3; c = 3;
    int* aPtr = &a;
    int* bPtr = &b;
    int* cPtr = &c;
    sum3(aPtr, bPtr, cPtr);
    cout << "By Pointers, " << a << " and " << b << " is " << c << '\n'; // 2, 3, 5
    cout << "By Pointers, " << *aPtr << " and " << *bPtr << " is " << *cPtr << '\n'; // 2, 3, 5

    a = 2; b = 3; c = 7;
    c = sum4(a, b);
    cout << "By Template, " << a << " and " << b << " is " << c << '\n'; // 2, 3, 5
    
    // STRUCTS
    cout << "CIRCLES\n";
    // In this case memory is all in stack.
    Circle circle1;
    PrintCircle(circle1); // 0, 0, 1

    circle1.x = 33;
    circle1.y = -33;
    circle1.radius = 99;
    PrintCircle(circle1); // 33, -33, 99

    // OBJECTS
    Circle* circlePtr = new Circle(); // Using new allocates memory for the object, the memory resides in the heap
    circlePtr->x = 10;  // Arrow operator to access members
    circlePtr->y = -10;
    circlePtr->radius = 33;
    PrintCircle(*circlePtr); // 10, -10, 33
    

    // Another way of accessing members
    (*circlePtr).x = 20;
    (*circlePtr).y = -20;
    (*circlePtr).radius = 40;
    PrintCircle(*circlePtr); // 20, -20, 40

    // A voif* can point to anything
    void* ptr = circlePtr;
    PrintCircle2(ptr); 

    delete circlePtr; // Note that I am freeing memory allocated in heap.

    return 0;
}

// Function declaration here.
void sum3(int* a, int* b, int* c) {
    *c = *a + *b;
}