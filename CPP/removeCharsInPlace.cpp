// Author: http://lemming.life
// Language: C++
// Purpose: Given an input string, and an exclude string of characters,
//  remove characters of input string if they appear in the exclude string.

#include <iostream>
using namespace std;

void removeCharactersInPlace(char* aString, char* excludeChars) {
    // Note: aString and exludeChars are  C-strings,
    // so they must have a null terminator.

    // Address to write to
    char* address = aString; 

    // Read all aStr until null terminator.
    while( *aString != '\0' ) {

        // Identify if the character is excluded.
        bool found = false;
        char* excludePtr = excludeChars;
        do {
            found = *aString == *excludePtr ? true : false;
            ++excludePtr;
        } while( *excludePtr != '\0' && !found );

        // The character is not excluded, so add it to the next
        // spot in the address.
        if (!found) {
            *address = *aString;
            ++address;
        }

        ++aString;
    }

    *address = '\0';
}


int main() {
    char mySentence[] = "Hello, world!";
    char excludeCharacters[] = "aeiou";

    cout << mySentence << "\n"; // Hello, world!
    removeCharactersInPlace(mySentence, excludeCharacters);
    cout << mySentence << "\n"; // Hll, wrld!
    return 0;
}