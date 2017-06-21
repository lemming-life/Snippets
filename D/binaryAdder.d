// Author: http://lemming.life
// Language: D
// Description: a binary adder using strings.

import std.stdio;

void main() {
    "First string: ".write;
    string s1 = readln;

    "Second string: ".write;
    string s2 = readln;

    "Result: ".write;
    AddStrings(s1, s2).writeln;
}

string AddStrings(string first, string second) {
    makeEqualSize(first, second);
    string result = "";
    char carry = '0';

    while (first.length>0) {
        char a = first[$-1];
        char b = second[$-1];

        if (a == b && a == '0') {
            result = carry ~ result;
            carry = '0';
        } else if (a == b && a == '1') {
            result = (carry == '0' ? '0' : '1') ~ result;
            carry = '1';
        } else {
            result = (carry == '0' ? '1' : '0') ~ result;
        }

        first = first[0 .. $-1];
        second = second[0 ..$-1];
    }

    if (carry == '1') result = carry ~ result;
    return result;
}

void makeEqualSize(ref string first, ref string second) {
    while (first.length < second.length) first = "0" ~ first;
    while (first.length > second.length) second = "0" ~ second;
}