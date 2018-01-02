// Various ways to call a class and member methods.
#include <iostream>

class Callee {
public:
    static void staticMethod() {
        std::cout << "Callee.staticMethod()\n";   
    }

    void instanceMethod() {
        std::cout << "Callee.instanceMethod()\n";
    }
};

class Caller {
public:
    void someMethod() {
        doCallStaticMethod(Callee::staticMethod);
    
        auto memberMethod = &Callee::instanceMethod;
        doCallMember(memberMethod);
        
        auto callee1 = new Callee();
        doCallMemberOnInstance(callee1, memberMethod);
    }
    
    void doCallStaticMethod( void (*fn)() ) {
        fn();
    }
    
    void doCallMember(void (Callee::*fn)() ) {
        Callee callee; // Needs an instance
        (callee.*fn)();   
    }
    
    void doCallMemberOnInstance(Callee* instance, void (Callee::*fn)() ) {
        (instance->*fn)();   
    }
};

int main() {
    Caller caller;
    caller.someMethod();
}
