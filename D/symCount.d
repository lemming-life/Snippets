// Author: http://lemming.life
// Language: dlang
// Purpose: Determines the symbol count of a given file.
// Secondary: "Sorts" an associative array that has a numerical value. Returns a sorted list of tuples.

import std.stdio; 
import std.string; 
import std.typecons;

void main(string[] args) {
  if (args.length != 2) return;

  // Populate
  int[char] symbols;
  populateMap(symbols, args[1]);

  // Sort
  auto sorted = sortMap(symbols);
  
  // Print results
  foreach (kv; sorted){
    kv[0].write;
    ":".write;
    kv[1].writeln;
  }
}

void populateMap(K, V)(ref V[K] aMap, string fileName) {
  auto file = File(fileName);
  string line;

  while ((line = file.readln) !is null) {
    line = line.strip;
    while (line.length>0) {
      if (line[0] in aMap) {
        ++aMap[line[0]];
      } else {
        aMap[line[0]] = 1;
      }
      line = line[1 .. $];
    }
  }
}

auto sortMap(K, V)(ref V[K] aMap){
  import std.typecons;
  Tuple!(K,V)[] sorted = [];
  
  foreach(k,v; aMap) {
    int i = 0;
    while (i<sorted.length) {
      if (sorted[i][1] > v) break;
      ++i;
    }

    if (i == 0) {
      sorted = [tuple(k,v)] ~ sorted;
    } else if (i<sorted.length) {
      auto leftSide = sorted[0 .. i];
      auto rightSide = sorted[i .. $];
      sorted = leftSide ~ [tuple(k,v)] ~ rightSide;  
    } else {
      sorted ~= [tuple(k,v)];
    }
  }

  return sorted;
}