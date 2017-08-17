
#ifndef SORT_HELPER
#define SORT_HELPER

#include <iostream>
#include <string>
#include "miscFunctions.h"
using namespace std;


void blankFunc1(int* array, int size) { }
void blankFunc2(int* array, int size, int size2) {}

void sortHelper(string title, int size, int funcToUse, void (*func)(int*, int), void (*func2)(int*, int, int)) {
    cout << '\n' << title << '\n';
    int array[size];
    for(int i=0; i<size; ++i) { array[i] = rand() % 101; }
    cout << "Unsorted: " << misc::toString(array, size, " ") << '\n';
    if (funcToUse == 1) {
        (*func)(array, size);
    } else if (funcToUse == 2) {
        (*func2)(array, 0, size-1);
    }

    cout << "  Sorted: " << misc::toString(array, size, " ") << '\n';
}

#endif