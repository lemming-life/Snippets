// Author: http://lemming.life
// Language: D
// Title: enumStrings.d
// Description: Example of the name of the enum and value from enum.

import std.stdio : writeln;
import std.traits : EnumMembers;

void main(string[] args) {
    enum Color {Red = "Red", Green = "Green", Blue = "Blue", RedVelvet = "Red Velvet"}

    "Name of enum: ".writeln;
    foreach(color; EnumMembers!Color) {
        color.writeln;
    }

    "\nValue from enum: ".writeln;
    foreach (color; EnumMembers!Color) {
        string valueFromEnum = color; // left hand must be defined as string
        valueFromEnum.writeln;
    }
    "\nLast one should be 'Red Velvet' with a space.".writeln;
}