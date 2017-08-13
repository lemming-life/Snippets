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


    int getIndexOfSecond(string s, string t, int index) {
        // Given two strings, find the target string within the source string
        // Return -1 if not found, return an index >= 0 if found
        if (t.length() > s.length()) { return -1; } // The word was not found
        if (s.substr(0, t.length()) == t) {
            return index;   // Target is within the source
        } else {
            return getIndexOfSecond(s.substr(1), t, ++index); // Look further into the source
        }
    }
}

#endif