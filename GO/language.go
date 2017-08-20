package main

// A comment

/* Multi
  line
  comment
*/

// To run type at terminal: go run language.go

import "fmt" // Input and output

// Program entry point
func main() {
	fmt.Println("Hello, World!"); // At terminal you can godoc fmt Println for more info

	// Data Types:
	// Integers: uint, uint8, uint16, uint32, uint64, int, int8, int16, int32, int64
	// String: string
	// Booelan: bool

	// Variables (statically typed: defined and cannot be changed)

	// uint8 is 2^8 possible values, so 0 to 255

	// Declare, then initialize
	var aUint8 uint8
	aUint8 = 0

	// Declare and initialize
	var anInt int = 1

	// Type defined implicitly
	someNumber := 33
	someFloat := 100.01

	// String
	var someString string = "My String"  // We can use 

	// Constant
	const HOURS_PER_DAY int = 24

	// Multiple variable declaration
	var (
		fingers = 5
		hands = 2
		lengthOfSomeString = len(someString)
	)

	// Math: +, -, *, /, %
	// Also: +=, -= for  a = a + x
	fingers = fingers + 5 - 5 / 1
	hands = (4 % hands) + 2

	// Printing to console
	fmt.Println(aUint8, " ", anInt, " ", someNumber, " ", someFloat, " ", someString, " ", lengthOfSomeString)
	// Output: 0 1 33 100.01 My String 9

	fmt.Println("Concatenating this string " + "and this other string.")

	fmt.Printf("Humans have %d fingers, %d hands, and %.2f average IQ\n", fingers, hands, someFloat)
	// Output: Humans have 5 fingers, 2 hands, and 100.01 average IQ

	// Output the data type
	fmt.Printf("aUint8 is of type %T\n", aUint8)

	// Output as binary
	fmt.Printf("someNumber in binary is %b \n", someNumber) // 100001
	fmt.Printf("The code 64 code is character %c \n", 64) // @
	
	// Arrays
	var cards[2] int
	cards[0] = 1
	cards[1] = 2

	cards2 := [2]int {1, 2} // Same as above

	// Going through the array, considering index
	for index, value := range cards {
		fmt.Println(value, index)
	}
	/* Output:
		1 0
		2 1
	*/

	for _, value := range cards2 {
		fmt.Println(value)
	}


	// Logical operators:
	// - And: &&
	// - Or: ||
	// - Not: !

	

	// Relational operators:
	// - Equality: ==
	// - Not Equal: !=
	// - Less Than: <
	// ... : >, <=, >=

	// For loops
	i:=0
	for i < 10 {
		i++
	}

	for j:=0; j<10; j++ {
		// Stuff to do
	}

	// If else
	if 5 >= 2 {
		// This line runs
	} else {
		// Does not run
	}

	// if else if 
	if 4 > 4 {
		// This line doesn't run
	} else if ( 2 < 4) {
		// This line runs
	} else {
		// This line doesn't run
	}

	// switch
	switch(5) {
		case 1: // does not run
		case 5: // this line runs
		default: // does not run
	}

	
	// Slices: like an array, but no size specified
	slice := []int {0, 1, 2, 3, 4, 5}
	firstSlice := slice[0:3] // 0 up to but not including 3rd index, so length is 3 and has {0, 1, 2}
	fmt.Println(firstSlice[0], " ", firstSlice[2]) // 0 2
	fmt.Println(slice[:3]) // From 0 to but not including 3rd index.  Output: [0, 1, 2]
	fmt.Println(slice[2:]) // From 2 index to end. Output: [2, 3, 4, 5]

	zeroForFirst := 3
	size := 9
	notDefinedValuesSlice := make([]int, zeroForFirst, size)
	fmt.Println(notDefinedValuesSlice[0:]) // [0 0 0]

	copy(notDefinedValuesSlice, slice) // Copy values from slice to notDefinedValuesSlice
	fmt.Println(notDefinedValuesSlice[0:]) // [0 1 2]

	notDefinedValuesSlice = append(notDefinedValuesSlice, 4, 5, 6)
	fmt.Println(notDefinedValuesSlice[0:]) // [0 1 2 4 5 6]

	// Maps
	kidAges := make(map[string] int) // map[keyType] valueType
	kidAges["Tom"] = 12
	kidAges["Tim"] = 13
	fmt.Println(kidAges) // map[Tom:12 Tim:13]
	delete(kidAges, "Tom")
	fmt.Println(kidAges) // map[Tim:13]
	fmt.Println(len(kidAges)) // 1

	// Function calls
	fmt.Println( sum(2, 3) ) // 5

	{
		num1, num2 := returnTwoValues()
		fmt.Println(num1, " ", num2) // 2 3
	}

	fmt.Println( sumTheArguments(1, 2, 3, 4, 5, 6) ) // 21
	
	// Functions with closure
	{
		num:= 2
		checkForDivisible := func(n int) bool {
			return n % num == 0 // Note that num doesn't exist in this scope, but it's one level outside
		}

		fmt.Printf("Is 5 divisible by %d? %t \n", num, checkForDivisible(5)) // false

	}


}

// Declare a function
// func nameOfFunction(variableName variableType) returnType
func sum(a int, b int) int {
	return a + b
}

// Function with multiple return
// func nameOfFunction(arguments) (returnType1, returnType2, returnType...)
func returnTwoValues() (int, int) {
	return 2, 3 
}
// Function with n arguments
func sumTheArguments(arguments ... int) int {
	theSum := 0
	for _, value := range arguments  {
		theSum += value
	}
	return theSum
}

// 