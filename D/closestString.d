// Author: http://lemming.life
// Language: D
// Description: Given a list of strings and a string
// identify the closest matching string in the list

/// Hll
class ClosestString {
    private:
        class StringScore {
            dstring value;
            int index;
            int score;

            this(dstring value, int index, int score = 0) {
                this.value = value;
                this.index = index;
                this.score = score;
            }
        }

        StringScore[int] map;
        StringScore highestStringScore = null;

    public:
        this(dstring[] arrayOfStrings) {
            foreach(int index; 0 .. cast(int)arrayOfStrings.length) {
                map[index] = new StringScore(arrayOfStrings[index], index);
            }
        }

        int getByIndex(dstring strLookFor) {
            if (map.length == 0) { return -1; }
            assignScores(strLookFor);

            if (highestStringScore !is null) {
                return highestStringScore.index;
            } else {
                return -1;
            }
        }

        dstring getByValue(dstring strLookFor) {
            if (map.length == 0) { return ""d; }
            assignScores(strLookFor);

            if (highestStringScore !is null) {
                return highestStringScore.value;
            } else {
                //return cast(T)"";
                return ""d;
            }
        }

        void assignScores(dstring strLookFor) {
            // Reset the scores
            // Assume all are valid.
            foreach (k, ref v; map) {
                v.score = int.max;
            }

            // Determine the score
            // - Reduce the score by each one wrong.
            foreach (k, ref v; map) {
                foreach(i, c; strLookFor) {
                    if (i < v.value.length) {
                        if (v.value[i] != strLookFor[i]) {
                            v.score -= int.max/ (8+i); // int.max / (8+i); // Use the 
                        }
                    }
                }
            }

            // Get the highest score
            int highestScore = int.min;
            highestStringScore = null;
            import std.algorithm : sort;

            foreach(k; sort(map.keys)) {
                auto v = map[k];
                if (v.score > highestScore) {
                    highestScore = v.score;
                    highestStringScore = v;
                }
            }
        } // End assignScores
}


unittest {
    import std.stdio : writeln;

    auto list = ["red"d, "green"d, "blue"d, "black"d, "Black"d];
    auto closestString = new ClosestString(list);

    // Test the index
    foreach(i, s; list) {
        assert(closestString.getByIndex(s) == i);
    }

    // Test the value
    foreach(i, s; list) {
        assert(closestString.getByValue(s) == s);
    }

    assert(closestString.getByValue("Red"d) == "red"d);
    assert(closestString.getByValue("track"d) == "black"d); // Black would be the second one because of the index
    assert(closestString.getByValue("true"d) == "green"d); // You might have expected blue but the r gives it a very high score.
}