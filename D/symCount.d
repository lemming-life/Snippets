// Author: http://lemming.life
// Language: dlang
// Purpose: Determines the symbol count of a given file.
// Secondary: "Sorts" an associative array that has a numerical value. Returns a sorted list of tuples.

import std.stdio; 
import std.string;
import std.typecons;

void main(string[] args) {
  if (args.length != 2) return;
  int[char] symbols;
  auto file = File(args[1]);
  string line;
  while( (line = file.readln) !is null) {
    line = line.strip;
    while( line.length > 0) {
      if (line[0] in symbols) {
        ++symbols[line[0]];
      } else {
        symbols[line[0]] = 1;
      }
      line = line[1 .. $];
    }
  }

  auto sorted = sortMap(symbols);
  foreach(kv; sorted){
    kv[0].write;
    ":".write;
    kv[1].writeln;
  }

}

auto sortMap(K, V)(ref V[K] aMap){
  import std.typecons;
  //import std.algorithm;

  Tuple!(K,V)[] sorted = [];
  
  foreach(k,v; aMap) {
    int i = 0;
    while(i<sorted.length){
      if (sorted[i][1] <= v){
        ++i;
      } else {
        break;
      }
    }

    if (i == 0) {
      sorted = [tuple(k,v)] ~ sorted;
    } else if (i>=sorted.length){
      sorted = sorted ~ [tuple(k,v)];
    } else {
      auto leftSide = sorted[0 .. i];
      auto rightSide = sorted[i .. $];
      sorted = leftSide ~ [tuple(k,v)] ~ rightSide;
    }
  }

  return sorted;
}