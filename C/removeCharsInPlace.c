// Author: http://lemming.life
// Language: C
// Purpose: Given an input string, and an exclude string of characters,
//  remove characters of input string if they appear in the exclude string.

// Compile: gcc removeCharsInPlace.c
// Run: ./a.out

#include <stdio.h>
#include <stdbool.h>

// Forward declarator
void removeCharactersInPlace(char*, char*);

// Entry point
int main() {
    char mySentence[] = "Hello, world!";
    char excludeCharacters[] = "aeiou";

    printf("%s \n", mySentence);
    removeCharactersInPlace(mySentence, excludeCharacters);
    printf("%s \n", mySentence);
    return 0;
}

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

    // Ensure the string has null terminator.
    *address = '\0';
}