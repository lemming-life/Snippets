// Author: http://lemming.life
// Language: C++
// Purpose: Examples on how to use C++, covers functions, and structs.


#include <iostream>
using namespace std;

// Pass by value
int sum(int a, int b) {
    return a + b;
}

// Pass by reference
void sum2(int a, int b, &int c) {
    c = a + b;
}



int main() {
    int a = 2;
    int b = 3;
    int c;
    cout << "By Value, sum of " << a << " and " << b << " is " << sum(a, b);

    sum2(a, b, c);
    cout << "By Reference, "

    return 0;
}



// A simple class
class Circle {
    public:
        Circle() {}
        Circle(int aRadius) {
            radius = aRadius;
        }

        int getRadius() { return radius; }
        void setRadius(int aRadius) { radius = aRadius; }
    private:
        int radius;
}; // 