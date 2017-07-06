// Author: http://lemming.life
// Language: C++
// Description: Example of creating and using an object.

/* At terminal do:
    g++ objects.cpp
    ./a.out
*/

#include <iostream>

class Shape {
private:
    int x; int y;
public:
    Shape(int x, int y) {
        this->x = x;
        this->y = y;
    }
    int getX() { return x; }
    int getY() { return y; }
};

int main() {
    Shape shape(2, 3);
    std::cout << "Shape position. x: " << shape.getX() << " y: " << shape.getY() << "\n"; 
    return 0;
}