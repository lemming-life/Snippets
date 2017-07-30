// Author: http://lemming.life
// Language: D
// Purpose: Get members of Enum E and convert the members to array of type T

// Test: rdmd -unittest -main enumToArray.d
// - Expected: Passed

module enumtoarray;

auto enumMemberToArray(E, T)() {
    import std.traits : EnumMembers;
    import std.conv : to;

    T[] tempArray;
    foreach(member; EnumMembers!E) {
        tempArray ~= to!T(member);
    }
    return tempArray;
}

auto enumValuesToArray(E, T)() {
    import std.traits : EnumMembers;
    import std.conv : to;

    T[] tempArray;
    foreach(member; EnumMembers!E) {
        T value = member;
        tempArray ~= value;
    }
    
    return tempArray;
}

unittest {
    enum Colors {Red, Green, Blue}
    enum Numbers : int { One = 1, Two, Three }
    enum Titles { Doctor = "Doctor", SupremeLeader = "Supreme Leader" }

    // Members
    assert( enumMemberToArray!(Colors, string) == ["Red", "Green", "Blue"] ); // a string[]
    assert( enumMemberToArray!(Numbers, dstring) == ["One"d, "Two"d, "Three"d] ); // a dstring[]
    assert( enumMemberToArray!(Numbers, Numbers) == [Numbers.One, Numbers.Two, Numbers.Three] ); // a Numbers[]
    assert( enumMemberToArray!(Numbers, int) == [1, 2, 3] ); // a int[]

    // Values
    assert( enumValuesToArray!(Titles, string) == ["Doctor", "Supreme Leader"] ); // a string[]
    assert( enumValuesToArray!(Numbers, int) == [1, 2, 3] ); // a int[]

    import std.stdio : writeln;
    "Passed".writeln;
}