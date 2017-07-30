// Author: http://lemming.life
// Language: D
// Description: Given a list of strings and a string
// identify the closest matching string in the list

// Note: It supports strings, wstrings, and dstrings.

module closeststring;

class ClosestString (T) {
    private:
        class StringScore (T) {
            T value;
            int index;
            int score;

            this(T value, int index, int score = 0) {
                this.value = value;
                this.index = index;
                this.score = score;
            }
        }

        StringScore!T[int] map;

    public:
        this(T[] arrayOfStrings) {
            for(int i=0; i<arrayOfStrings.length; ++i) {
                map[i] = new StringScore!T(arrayOfStrings[i], i);
            }
        }
        
        int getByIndex(T strLookFor) {
            if (map.length == 0) { return -1; }
            auto highestStringScore = assignScores(strLookFor);
            if (highestStringScore !is null) {
                return highestStringScore.index;
            } else {
                return -1;
            }
        }
    
        T getByValue(T strLookFor) {
            if (map.length == 0) { return cast(T)""; }
            auto highestStringScore = assignScores(strLookFor);
            if (highestStringScore !is null) {
                return highestStringScore.value;
            } else {
                return cast(T)"";
            }
        }

        StringScore!T assignScores(T strLookFor) {
            // Reset the scores
            // Assume all are valid.
            foreach (k, ref v; map) {
                v.score = int.max;
            }

            // Determine the score
            // - Reduce the score by each character that doesn't match.
            foreach (k, ref v; map) {
                foreach(i, c; strLookFor) {
                    if (i < v.value.length) {
                        if (v.value[i] != strLookFor[i]) {
                            v.score -= int.max/ (8+i); // Decrease the score
                        }
                    }
                }
            }

            // Get the highest score
            int highestScore = int.min;
            StringScore!T highestStringScore = null;
            import std.algorithm : sort;

            foreach(k; sort(map.keys)) {
                auto v = map[k];
                if (v.score > highestScore) {
                    highestScore = v.score;
                    highestStringScore = v;
                }
            }

            return highestStringScore;
        } // End assignScores
        
} // End class ClosestString


unittest {
    import std.stdio : writeln;

    // Using a string
    auto list = ["red", "green", "blue", "black", "Black"];
    auto closestString = new ClosestString!string(list);

    // Test the index
    foreach(i, s; list) {
        assert(closestString.getByIndex(s) == i);
    }

    
    // Test the value
    foreach(i, s; list) {
        assert(closestString.getByValue(s) == s);
    }

    assert(closestString.getByValue("Red") == "red");
    assert(closestString.getByValue("track") == "black"); // Black would be the second one because of the index
    assert(closestString.getByValue("true") == "green"); // You might have expected blue but the r gives it a very high score.



    // Using a dstring
    auto list2 = ["red"d, "green"d, "blue"d, "black"d, "Black"d];
    auto closestString2 = new ClosestString!dstring(list2);

    // Test the index
    foreach(i, s; list2) {
        assert(closestString2.getByIndex(s) == i);
    }

    // Test the value
    foreach(i, s; list2) {
        assert(closestString2.getByValue(s) == s);
    }

    assert(closestString2.getByValue("Red"d) == "red"d);
    assert(closestString2.getByValue("track"d) == "black"d); // Black would be the second one because of the index
    assert(closestString2.getByValue("true"d) == "green"d); // You might have expected blue but the r gives it a very high score.
} // End unittest