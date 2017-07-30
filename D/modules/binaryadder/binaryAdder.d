// Author: http://lemming.life
// Language: D
// Description: a binary adder using strings.
// Test: rdmd -unittest -main binaryAdder.d

module binaryadder;

string binaryAdder(string first, string second) {
    // Make the strings equal size
    while (first.length < second.length) first = "0" ~ first;
    while (first.length > second.length) second = "0" ~ second;

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

unittest {
    assert( binaryAdder("0000", "0000") == "0000" );
    assert( binaryAdder("0000", "0001") == "0001" );
    assert( binaryAdder("0001", "0000") == "0001" );
    assert( binaryAdder("0001", "0001") == "0010" );
    assert( binaryAdder("0010", "0001") == "0011" );
    assert( binaryAdder("0011", "0001") == "0100" );
    assert( binaryAdder("0100", "0001") == "0101" );
    assert( binaryAdder("1000", "1000") == "10000" ); // Expands
    assert( binaryAdder("1111", "0100") == "10011" ); // Expands
}