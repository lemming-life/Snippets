// Author: http://lemming.life
// Language: D
// Purpose: Get members of Enum E and convert them to items of an array of type T
// Date: July 17, 2017

enum Colors {Red, Green, Blue}
enum Numbers : int { One = 1, Two, Three }

auto enumToArray(E, T)() {
    import std.traits : EnumMembers;
    import std.conv : to;

    T[] tempArray;
    foreach(member; EnumMembers!E) {
        tempArray ~= to!T(member);
    }
    return tempArray;
}


void main(string[] args) {
    string[] colorsAsString = enumToArray!(Colors, string);
    colorsAsString.printArray;

    dstring[] numbersAsDString = enumToArray!(Numbers, dstring);
    numbersAsDString.printArray;

    int[] numbersAsInt = enumToArray!(Numbers, int);
    numbersAsInt.printArray;
}

auto printArray(T)(T[] array) {
    import std.stdio : writeln;
    foreach (item ; array) { item.writeln; }
}

// Output:
/*
Red
Green
Blue
One
Two
Three
1
2
3
*/