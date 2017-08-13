// Author: http://lemming.life
// Language: C++
// Description: Shows how to implement an interface in C++

/* At terminal do:
    g++ interface.cpp
    ./a.out
*/

#include <iostream>
using namespace std;

// An interface
// - A promise that function(s) must be implemented.
class Interface {
public:
    virtual int getMe() { return 0; } 
};

class Implementation : public Interface {
public:
    int getMe() { return 2; }
};

int main() {
    // Principle: Program to an interface
    Interface* myInterface = new Implementation();
    cout << "Calling getMe(). Expecting 2 got " << myInterface->getMe() << ".\n";
    return 0;
}