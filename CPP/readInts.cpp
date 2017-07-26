// Author: http://lemming.life
// Language: C++

// Description: Read integers from standard in into an array of size N
// , where N is the first input and the rest of the input are integer numbers.
// Stop reading if non integer input.
// Print the array of ints in reverse order to standard out.

/* At terminal do:
    g++ readInts.cpp
    ./a.out
*/

/* Input:
4
1 4 3 2
*/

/*Output:
2 3 4 1
*/

#include <iostream>
using namespace std;

// Function to read and output integers
void readInts() {
    int size, n, count;

    // Get the size
    cin >> size;
    int array[size];
    
    // Get the integers
    count = 0;
    while (cin >> n) {
        array[count] = n;
        ++count;
    }
    
    // Print the array
    while (count > 1) {
        cout << array[count-1] << ' ';
        --count;
    }
    cout << array[0];
}

// Driver
int main() {
    readInts();
    return 0;
}