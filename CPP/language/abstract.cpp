// Author: http://lemming.life
// Language: C++
// Description: Shows how to deal with abstract class in c++

/* At terminal do:
    g++ abstract.cpp
    ./a.out
*/

#include <iostream>
// Abstract class
// - One cannot instantiate an object of class abstract
class Abstract {
public:
    // This is a pure virtual function,
    // it makes this class to be abstract
    virtual int getMe() = 0;
};

class Specific : public Abstract {
public:
    int getMe() { return 2; }
};

int main() {
    Abstract* myAbstract = new Specific(); // ok
    Specific* mySpecific = new Specific(); // ok
    //Abstract* myAbstract2 = new Abstract(); // NO!!!

    std::cout << myAbstract->getMe() << "\n"; // 2
    std::cout << mySpecific->getMe() << "\n"; // 2
    return 0;
}