// Author: http://lemming.life
// Language: D
// Description: Reads from file a list of names and scores and outputs
//  those names and scores which have a score of 90 or greater.
// Data looks like: Thomas Edison, 55

// Running it:
// rdmd readNameScores.d nameScores.txt

import std.stdio : writeln, File;
import std.conv : to, parse;
import std.string : indexOf;

void main(string[] args) {
    auto file = File(args[1]);
    const int A_SCORE = 90;
  
    string line;
    while( (line = file.readln) !is null) {
        int index = to!int(line.indexOf(","));
        string name = line[0 .. index];

        string scoreString = line[index+2 .. line.length];
        int score = parse!int(scoreString); // the parsing does not allow a range

        if (score >= A_SCORE) {
            writeln(name ~ " - " ~ to!string(score));
        }
    }
}

/* If Input is:
Leo, 55
Einstein, 99
Newton, 95
Obama, 70
Edison, 33

Expect output as:
Einstein - 99
Newton - 95
*/