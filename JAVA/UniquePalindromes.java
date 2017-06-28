
// Author: http://lemming.life
// Language: Java
// Description: Given a string, identifies and counts the unique number of palindromes in the string's substrings.

// Build
// javac UniquePalindromes.java

// Run:
// java UniquePalindromes

// Example input: aabaa
// All strings:
// a, aa, ab, aab, aaba, aabaa
// a, ab, aba, abaa
// b, ba, baa
// a, aa
// a
// Unique palindromes: a, aa, aabaa, aba, b
// Count: 5


import java.util.Scanner;

class UniquePalindromes {

    static int UniquePalindromesInStringCount(String s) {
        int count = 0;
        final int MAX_SIZE = 10000;
        String[] uniqueStrings = new String[MAX_SIZE];
        String[] allSubstrings = new String[MAX_SIZE];
        
        // Get all possible substrings
        int subStringCount = 0;
        for (int pos = 0; pos < s.length(); ++pos) {
            for (int l = 0; l <= s.length()-pos; ++l) {
                if (pos != pos+l) {
                    allSubstrings[subStringCount++] = s.substring(pos, pos+l);
                }
            }
        }

        // Determine if each substring is a palindrome, add if unique
        for (int c = 0; c < subStringCount; ++c) {
             // isPalidrome check
            boolean isPalindrome = true;
            String s1 = allSubstrings[c];
            for (int i=0; i < s1.length()/2; ++i) {
                if (s1.charAt(i) != s1.charAt(s1.length()-(1+i))) {
                    isPalindrome = false;
                    break;
                }
            }
            
            // Add if unique
            if (isPalindrome) {
                boolean found = false;
                for (int j=0; j < count; ++j) {
                    if (s1.equals(uniqueStrings[j])) {
                        found = true;
                        break;
                    }
                }

                if (found == false) {
                    uniqueStrings[count++] = s1;
                    // System.out.println(s1);  // Comment out to see the unique palindrome.
                }
            }
        }

        return count;
    }

    public static void main(String[] args) {
        System.out.println("Unique palindrome count in substrings of string.");
        System.out.print("Please, type the string: ");
        Scanner in = new Scanner(System.in);
        String s = in.nextLine();
        in.close();
        System.out.println("Count: " + UniquePalindromesInStringCount(s));
    }
}