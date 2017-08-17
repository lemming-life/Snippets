#include <iostream> // cout, cin
#include <stdlib.h> // srand, rand

#include "simpleVector.h"
#include "miscFunctions.h"
#include "linkedList.h"
#include "sort.h"
#include "sortHelper.h"
using namespace std;
using namespace misc;



int main() {

    {
        cout << "\n\nMISC FUNCTIONS TEST\n";
        char msg[] = "Tom";
    
        cout << "Characters Normal: " << msg << '\n';                  // Tom
        reverser(msg, determineLength(msg));                
        cout << "Characters Reversed: " << msg << '\n';                // moT

        int numbers[] = { 1, 2, 7, 7, 5 };
        cout << "Numbers Normal: " << toString(numbers, 5, " ") << '\n';
        reverser(numbers, 5);
        cout << "Numbers Reversed: " << toString(numbers, 5, " ") << '\n';

        cout << "Count of " << 7 << " in Numbers is " << countItemInArray(7, numbers, 5) << '\n';

        cout << "Looking for 'world' in 'Hello, world!', expecting index 7, got " << getIndexOfSecond("Hello, world!", "world", 0) << '\n';
        cout << "Looking for 'red' in 'Hello, world!', expecting index -1, got " << getIndexOfSecond("Hello, world!", "red", 0) << '\n';
    
        cout << "fibRecursive(7) is " << fibRecursive(7) << '\n';
        cout << "fibIterative(7) is " << fibIterative(7) << '\n';
    }

    {
        cout << "\n\nVECTOR TEST\n";
        cout << "Int Vector\n";
        Vector<int> myIntVector;
        for(int i=0; i<6; ++i) { myIntVector.push(i); }
        myIntVector.print(" ");
        cout << '\n';
        cout << myIntVector.toString() << "\n";
        cout << "Clearing vector.\n";
        myIntVector.clear();
        cout << myIntVector.toString() << "\n";

        cout << "Char Vector\n";
        Vector<char> myCharVector;
        for (int i=0; i<5; ++i) { myCharVector.push(65+i); }
        myCharVector.print(" "); // A B C D E
        cout << '\n';
        myCharVector.removeAt(2);
        myCharVector.print(" "); // A B D E
        cout << "\n"; 
        myCharVector.removeAt(0);
        myCharVector.print(" "); // B D E
        cout << "\n";
        myCharVector.removeAt(2);
        myCharVector.print(" "); // B D
        cout << "\n";  
        myCharVector.removeAt(1);
        myCharVector.print(" "); // B
        cout << "\n"; 
        myCharVector.removeAt(0);
        myCharVector.print(" "); // 
        cout << "\n"; 
        cout << myCharVector.toString() << "\n";
    }

    {
        cout << "\n\nLINKED LIST TEST\n";
        List<int> intList;
        cout << "pushBack(1)\n"; 
        intList.pushBack(1);
        cout << "\tFront: " << intList.front() << '\n';   // 1
        cout << "\tBack: " << intList.back() << '\n';     // 1

        cout << "pushFront(2)\n";
        intList.pushFront(2);
        cout << "\tFront: " << intList.front() << '\n';   // 2
        cout << "\tBack: " << intList.back() << '\n';     // 1

        cout << "pushBack(3)\n"; 
        intList.pushBack(3);
        cout << "\tFront: " << intList.front() << '\n';   // 2
        cout << "\tBack: " << intList.back() << '\n';     // 3

        for (int i=0; i<intList.size(); ++i) {
            cout << "Value at(" << i << ") is " << intList.at(i) << '\n';
        }

        cout << "popBack is " << intList.popBack() <<  " expecting 3\n";    // 3
        cout << "popFront is " << intList.popFront() << " expecting 2\n";   // 2

        cout << "Is front() == back() ? " << (intList.front() == intList.back() ? "yes" : "no") << '\n'; // yes


        List<char> charList;
        for(int i=0; i<3; ++i) { charList.pushBack(65 + i); }

        cout << "charList size is " << charList.size() << '\n';
        while(charList.size() != 0) {
            cout << "charList popFront is " << charList.popFront() << '\n';
        }

        for(int i=0; i<3; ++i) { charList.pushBack(65 + i); }
        cout << "charList size is " << charList.size() << '\n';
        while(charList.size() != 0) {
            cout << "charList popBack is " << charList.popBack() << '\n';
        }

        for(int i=0; i<6; ++i) { charList.pushBack(71 + i); }
        List<char> charList2(charList); // Test the constructor that accepts lists.
        cout << "Expecting charList2 to have 6 items, it has " << charList2.size() << '\n';

        for(int i=0; i<6; ++i) { charList.pushBack(77 + i); }
        charList2 = charList; // Test assignment
        cout << "Expecting charList2 to have 12 items, it has " << charList2.size() << '\n';
    } // End Linked List test


    {
        cout << "\n\nSORT TEST\n";

        int size = 10;
        sortHelper("INSERTION SORT", size, 1, insertionSort, blankFunc2);
        sortHelper("SHELL SORT", size, 1, shellSort, blankFunc2);
        sortHelper("QUICK SORT", size, 2, blankFunc1, quickSort);
    }

    return 0;
} // End main()
