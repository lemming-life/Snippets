// Author: http://lemming.life
// Language: C++
// Description: Collection of misc functions.

#ifndef MISC_FUNCTIONS
#define MISC_FUNCTIONS

#include <string>

//#include <iostream>
//#include <string>
//using namespace std;

namespace misc {
    template<typename T>
    void swap(T* a, T* b) {
        T temp;
        temp = *a;
        *a = *b;
        *b = temp;
    }

    int determineLength(char* aPtr) {
        // For null terminated strings only.
        int n = 0;
        while(*aPtr != '\0') {
            ++aPtr;
            ++n;
        }
        return n;
    }

    template<typename T>
    void reverser(T* aPtr, int n) {
        if (n == 0 || n == 1) { return; }

        T* left = aPtr;
        T* right = aPtr + (n-1);
        
        while (left < right) {
            swap(left, right);
            ++left; --right;
        }
    }

    template<typename T>
    std::string toString(T* array, int n, string spacer) {
        std::string s = "";
        for (int i=0; i<n; ++i) {
            s = s + to_string(array[i]) + spacer;
        }
        return s;
    }

    template<typename T>
    int countItemInArray(T item, T* array, int n) {
        int count = 0;
        for (int i=0; i<n; ++i) {
            if (array[i] == item) { ++count; }
        }
        return count;
    }
}

#endif