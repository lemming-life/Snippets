// Author: http://lemming.life
// Language: D
// Purpose: Get members of Enum E and convert them to items of an array of type T
// Date: July 17, 2017
// Test: rdmd -unittest -main enumToArray.d
// - Expected: Passed

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


auto printArray(T)(T[] array) {
    import std.stdio : writeln;
    foreach (item ; array) { item.writeln; }
}

unittest {
    assert( enumToArray!(Colors, string) == ["Red", "Green", "Blue"] ); // a string[]
    assert(enumToArray!(Numbers, dstring) == ["One"d, "Two"d, "Three"d] ); // a dstring[]
    assert( enumToArray!(Numbers, int) == [1, 2, 3] ); // a int[]
    import std.stdio : writeln;
    "Passed".writeln;
}