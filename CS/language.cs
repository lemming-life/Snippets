// Author: http://lemming.life
// Language: C#
// Description: Collection of C# language bits.


using System;
using System.IO;
using System.Collections.Generic;

namespace Snippets {
    class Language {

        public static void executeDriver(bool standardInput = false) {
            Console.WriteLine("\nSubTest: ManyDetails");
                ManyDetails.executeDriver();

            Console.WriteLine("\nSubTest: ConsoleOutputInput");
            ConsoleOutputInput coi = new ConsoleOutputInput();
                coi.output();
                if (standardInput) { coi.input(); }

            Console.WriteLine("\nSubTest: ChangeConsole");
                ChangeConsole.executeDriver();

            Console.WriteLine("\nSubTest: WriteRead");
                WriteRead wr = new WriteRead();
                wr.write();
                wr.read();
                wr.remove();
        }

        class ManyDetails {
            public static void executeDriver() {
                // Single line comment

                /*
                    Multi
                    Line
                    Comment
                 */

                // Console output
                Console.WriteLine("A way to output to console.");
                Console.WriteLine("Writing with some value: " + 33);
                Console.WriteLine("Writing with some value: {0}", 33); // Identical to above
                Console.WriteLine("Writing with value: {0} and a second value {1}", 33, 66);

                // Basic Data Types
                int aInt;           // integers are negative, zero, and positive numbers with no decimals.
                uint aUint;         // an unsigned integer does not allow negative numbers.
                Int32 aInt32;       // an integer with room for 4 bytes (32 bits), same as int
                long aLong;         
                Int64 aInt64;       // same as a long
                float aFloat;       // has decimal places
                double aDouble;     // allows more numbers and has decimal places
                byte aByte;         // has space for 8 bits
                char aChar;         // has space for 16 bits
                string aString;     
                bool aBoolean;
                // There are many more!

                // Multiple declaration
                int someX, someY, someZ;


                // Initializing and assigning
                // left of = is called a variable, the right of = is a literal in this case.
                aInt = -1234; 
                aUint = 1234; 
                aLong = 333;
                aFloat = 12.34F;
                aDouble = 12.34;
                aByte = 5; // should store as 0000 0101
                aChar = 'a';
                aString = "hello"; 
                aBoolean = true; // can also be false

                // Assign from variable to variable.
                aInt = aInt;    // ok

                // Multiple assignment
                someX = someY = someZ = 5; // The 5 is assigned to someZ, then value of someZ is assigned to someY, etc.
                
                // Coersion: changes the right side type to match the left side type.
                aDouble = aInt;     // ok because aDouble has enough space for the integer
                //aInt = aDouble;   // error because the double is much bigger than the double.

                // Casting: converting how something is managed
                aInt = (int)aUint;  // ok because aInt supports both signed and unsigned
                aUint = (uint)aInt; // this is only ok if the aInt is zero or positive, otherwise it's an error,
                                    // because an unsigned integer cannot have a negative number.
                                    // Note that casting can remove data if not done properly.

                // Conversion via Parse:
                aString = "123"; // This is validly numeric.
                aInt = int.Parse(aString); // Now aInt has 123

                // Conversion via TryParse
                // TryParse returns true if it can, otherwise false.
                aBoolean = int.TryParse("123", out aInt); // true
                aBoolean = int.TryParse("123Hello", out aInt); // false
                

                // Constants: they cannot be changed
                const int A_CONSTANT = 33; // Generally an all caps name is suitable for constants
                // A_CONSTANT = 44; // If line uncommented, error because we cannot change an already defined constant.

                // var
                // var is a type defined when assigned
                var anotherInt = 1234;

                // Binary Math operations
                aInt = 2 + 3; // Sum
                aInt = 2 - 3; // Subtraction
                aInt = 2 * 3; // Multiplication
                aInt = 4 / 2; // Division;
                aInt = 4 % 2; // Modulus (the remainder of a division), result is 0 because 4 is divisible by 2.
                
                // Integer division, when a division is performed by integers
                // such that the result is not the natural mathematical expected result.
                aInt = 5 / 2;       // result is 2
                aDouble = 5 / 2;    // result is 2

                // Not integer division because at least one of the literals has decimal.
                aDouble = 5.0 / 2;  // result is 2.5
                aDouble = 5 / 2.0;  // result is 2.5

                // Binary boolean operations (conditions that evalute to true or false)
                aBoolean = 5 == 5;  // is 5 equal to 5, and the answer is true.
                aBoolean = 2 != 3;  // is 2 not equal to 3, and the answer is true.
                aBoolean = 4 != 4;  // is 4 not equal to 4, and the answer is false.
                aBoolean = 2 < 3;   // is 2 less than 3, and the answer is true.
                aBoolean = 4 > 2;   // is 4 greater than 2, and the answer is true. 
                aBoolean = 4 > 4;   // is 4 greater than 4, and the answer is false.
                aBoolean = 4 >= 4;  // is 4 greater than or equal to 4, and the answer is true
                aBoolean = 4 <= 4;  // is 4 less than or equal to 4, and the answer is true


                // Increment/decrement post
                aInt++; // give me the value of aInt, then increment the value by one
                aInt--; // give me the value of aInt, then decrement the value by one

                // pre increment and pre decrement
                ++aInt; // increment the value of aInt by one, then give me the value.
                    // equivalent of doing a = a + 1;
                --aInt; // decrement the value of aInt by one, then give me the value.

                // Adding/subtracting shortcut
                // You can do aInt = aInt + 5 to add 5 to aInt, or you can do the following:
                aInt += 5;

                // The equivalent of aInt = aInt - 5 is:
                aInt -= 5;


                // ENVIRONMENT
                //string theMyDocumentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + @"\";

                // STRINGS
                string aStringWithTab = "\t"; // the \ is an escape character, in this case \t means insert a tab when printing the string
                string aStringWithNewLine = "\n";   // Insert a new line
                string aStringEscapingSlash = "\\"; // Will have a \ in the string.
                string aStringPath = "C:\\Program Files\\";          // This looks ugly for a path name right?
                string aStringEscapeVerbatim = @"C:\Program Files\"; // Using @ can be useful.

                aChar = aStringPath[0]; // Gets the character first character from aStringPath, which is C


                // USING If, else, else if
                if (true) {
                    // comes here
                }

                if (false) {
                    // skips this
                }
                // comes here

                if(false) {
                    // skips this
                } else {
                    // comes here
                }

                if (false) {
                    // skips this
                } else if(true) {
                    // comes here
                }

                if (1 == 1) {
                    // above evaluates as true
                    // comes here
                }

                if (false) {
                    // above is not true, so skips
                } else if(1 == 2) {
                    // above is not true, so skips
                } else {
                    // comes here
                }

                // And is written as &&
                // Or is written as ||

                // And only evaluates if needed.

                if (true && true) {
                    // comes here because both sides are true
                }

                if (true && false) {
                    // skips this because right side is false
                }
                // comes here

                if (false && true) {
                    // skips this because left side is false, 
                    // do note that the right side of && is not evaluates in this case
                    // as it is not necessary.
                }
                // comes here

                // Or always evaluates left and right sides.
                if (true || true) {
                    // comes here because 
                }

                if (true || false) {
                    // comes here
                }

                if (false || true) {
                    // comes here
                }

                // NESTED if
                if (true) {
                    if (true) {
                        if (true) {
                            // Wnat more?  This is completely valid code. :)
                        }
                    }
                }
                

                // TERNARY OPERATOR
                // Similar to if else
                // Evaluates a condition if so return left of : otherwise return right
                aString = ( 1 == 1 ? "James" : "Jane"); 

                // The equivalent using if/else
                if (1 == 1) {
                    aString = "James";
                } else {
                    aString = "Jane";
                }

                Console.WriteLine("do while loop");
                // Notice the semi-colon at the end of while()
                aInt = 0;
                do {
                    // Execute this at least once, and do again if condition is met.
                    Console.WriteLine(aInt);
                    ++aInt;
                } while(aInt < 3);
                // Value of aInt is 3

                Console.WriteLine("while loop");
                // Notice how the while loop condition may skip if the condition is not true
                aInt = 0;
                while(aInt < 3) {
                    // Execute this if the condition is met.
                    Console.WriteLine(aInt);
                    ++aInt;
                }
                // Value of aInt is 3

                Console.WriteLine("for loop");
                // Similar to the while loop above
                // initiate; evaluate; perform
                for (int i=0; i<3; ++i ) {
                    Console.WriteLine(i);
                }

                Console.WriteLine("Nested for loops");
                for (int i=0; i<3; ++i) {
                    for (int j=0; j<3; ++j) {
                        Console.WriteLine("i: {0} j: {1}", i, j);
                    }
                }
                /*
                Output
                    i: 0 j: 0
                    i: 0 j: 1
                    i: 0 j: 2
                    i: 1 j: 0
                    i: 1 j: 1
                    i: 1 j: 2
                    i: 2 j: 0
                    i: 2 j: 1
                    i: 2 j: 2
                */

                // USING continue AND break

                // continue
                // A way to change the control flow of the program.
                // In this case the second for loop skips and goes to the second for loop evaluation
                Console.WriteLine("Using continue");
                for (int i=0; i<3; ++i) {
                    for (int j=0; j<3; ++j) {
                        if (j == 1) { continue; }
                        Console.WriteLine("i: {0} j: {1}", i, j); // this line does not output when j is 1
                    }
                }
                /*
                Output:
                    i: 0 j: 0
                    i: 0 j: 2
                    i: 1 j: 0
                    i: 1 j: 2
                    i: 2 j: 0
                    i: 2 j: 2
                 */

                // break
                // A way to change the control flow of the program.
                // In this case the second for loop is skipped, and control is given to the first for loop evaluation
                Console.WriteLine("Using break");
                for (int i=0; i<3; ++i) {
                    for (int j=0; j<3; ++j) {
                        if (j == 1) { break; }
                        Console.WriteLine("i: {0} j: {1}", i, j); // Line may be skipped
                    }
                }
                /*
                Output:
                    i: 0 j: 0
                    i: 1 j: 0
                    i: 2 j: 0
                */

                // THE switch STATEMENT

                // switch statement 1
                // - When value is found.
                aInt = 1;
                switch(aInt) {
                    case 0:
                        // not this one
                        break; 
                        
                    case 1:
                        // this one
                        break;
                }

                // switch statement 2
                // - When the value is not found
                aInt = 1;
                switch(aInt) {
                    case 0:
                        // not this one
                        break;

                    default:            // default is somewhat similar to the else of an if statement
                        // this one
                        break;
                }

                // switch statement 3
                // - Removing the break;
                aInt = 0;
                switch(aInt) {
                    case 0:
                        // this one
                    case 1:
                        // this line runs too because no break above.
                        break;
                    default:
                        // this line does not run
                        break;
                }

                // switch statemetn 4
                // - Using a goto
                aInt = 0;
                switch(aInt) {
                    case 0:
                        // this one
                        goto case 2; // changes the control flow to case 2
                    case 1:
                        // not this one
                        break;
                    case 2:
                        // this one runs.
                        goto default; // and now change the flow to the default case
                    default:
                        // this one runs.
                        break;
                }


                // ARRAYS
                // A variable that is treated as if it holds several elements of the same type

                // Declaration, and separate initialization
                int[] anArrayOfInts;                // Declaration
                anArrayOfInts = new int[3]{1, 2, 3}; // Initialization

                // Declaration and initialization
                string[] anArrayOfStrings = new string[]{"red", "green", "blue"};

                // Also, another way to declare and initialize:
                int[] anotherArrayOfInts = {4, 5, 6};
                
                // To access an element of an array we can use the index of the element.
                // The first element of an array is at index zero
                string redColor = anArrayOfStrings[0]; // red

                // Change the second element, index is one
                anArrayOfStrings[1] = "orange";

                // Change the last element, index would be 2 in this case, or the same as anArrayOfStrings.Length - 1
                anArrayOfStrings[2] = "yellow";
                anArrayOfStrings[anArrayOfStrings.Length - 1] = "yellow";

                Console.WriteLine("Printing the values of the elements of anArrayOfStrings via index");
                for(int index=0; index<anArrayOfStrings.Length; ++index) {
                    Console.WriteLine( anArrayOfStrings[index] );
                }

                Console.WriteLine("Printing the values of the elements of anArrayOfStrings via foreach");
                foreach(var color in anArrayOfStrings) {
                    Console.WriteLine( color );
                }

                // MULTI DIMENSIONAL ARRAY
                
                // Dimensions determined automatically
                int[,] multiDimensionalAuto = new int[,] { {1,2,3}, {4, 5, 6} };
                // The above reads as an array that holds two arrays of which each can hold 3 elements.
                // So we have a 2 x 3 array
                // Doing the above also assigns values at the specified locations.
                
                
                int[,] multiDimensionalSpecified = new int[2,3]; // We could also assign values via { {1,2,3}, {4, 5, 6} };
                
                // No values have been specified for multiDimsionalSpecified, so let's assign them via two for loops
                int valueForArray = 0;
                for (int row=0; row<multiDimensionalSpecified.GetLength(0); ++row) {
                    for(int col=0; col<multiDimensionalSpecified.GetLength(1); ++col) {
                        multiDimensionalSpecified[row, col] = valueForArray;
                        ++valueForArray;
                    }
                }

                Console.WriteLine("Printing values from multiDimensionalSpecified");
                for (int row=0; row<multiDimensionalSpecified.GetLength(0); ++row) {
                    for(int col=0; col<multiDimensionalSpecified.GetLength(1); ++col) {
                        Console.WriteLine("Row {0} Col {1} Value {2}", row, col, multiDimensionalSpecified[row, col]);
                    }
                }
                /*
                Output is:
                    Row 0 Col 0 Value 0
                    Row 0 Col 1 Value 1
                    Row 0 Col 2 Value 2
                    Row 1 Col 0 Value 3
                    Row 1 Col 1 Value 4
                    Row 1 Col 2 Value 5
                */

                // 3 Dimensions
                int [, ,] array3D = new int[1, 2, 3]; // this can be complicated :)


                // STRING STUFF
                string nameOfPerson = "Isaac Newton";
                string nameInAllLower = nameOfPerson.ToLower(); // isaac newton


                // RANDOM NUMBERS and OBJECTS
                // - This also shows how an object is created, and how to call a method of the object.
                Random randomDiceNumber = new Random();
                // Note that randomDiceNumber is a variable that holds the address to the object.
                // The randomDiceNumber variable is in stack memory
                // The object is in heap memory.

                // An object is an "instance" of a class.
                // A class is "template" of how an object is.
                // - This includes member variables and methods.

                // Memory management.
                // - Objects are created and destroyed via C# garbage collection, therefore no memory leaks.
                // - In other many other languages one has to manually free the memory.
                
                Console.WriteLine("\nA random dice number: {0}", randomDiceNumber.Next(1, 7) );   // This is a call to Next( <included>, <one less than this one>)
                // Methods are functions that can be accessed via the object.
                // Functions are procedures, which have blocks of instructions.
                // - The term function is usually given to non-object attached.



                // SCOPE
                int intOfDriver = 5; // This exists in the executeDriver method scope.

                {
                    // This is a scope inside of the executeDriver method
                    // We'll call this scopeA

                    // From here we can access the anything from an outer scope, like this:
                    int varInScopeA = intOfDriver; // ok
                    
                    {
                        // We'll call this scopeB

                        int varInScopeB = varInScopeA; // We can still access stuff from an outer scope.
                        varInScopeB = intOfDriver; // an even more outer scope
                    } // End scopeB

                    //intOfDriver = varInScopeB; // If line uncommented: Error, cannot access varInScopeB, it belongs to an inner scope (scopeB)
                } // End scopeA

                // Struct, is similar to a 
                SimpleStruct aStruct;
                aStruct.a = 5;  // a is a member of aStruct

                // OBJECTS
                Simple simple = new Simple(); // Notice the new keyword.
                //simple.a = 1; // Can't do it because it's private.
                //simple.b = 2; // Can't do it because it's private.
                //simple.c = 3; // Can't do it because it's protected.
                simple.d = 4;   // ok, because it's public
                Simple.e = 5;   // Notice that it is capital S on Simple.

                // ARRAY of OBJECTS
                Simple[] simpleObjects = { new Simple(), new Simple() }; // two simple objects in array.

                // Calling a member method
                int theSum = Sum.doTheSum(5, 7); // doTheSum is a static member of the Sum class


                // LISTS
                // - Lists allow you to store items, and the numbers of them can grow.
                List<int> myList = new List<int>(); // A list of ints.
                myList.Add(1);  // One way to add items to the list.
                myList.Add(4);
                myList.Add(2);
                myList.Add(3);
                myList.Add(2);

                int myIntFromList = myList[0]; // Get the first element from myList

                myList.Sort();  // A neat sorting method, default is ascending
                Console.WriteLine("\nNumbers of the list sorted.");
                foreach(var item in myList) {
                    Console.Write(item + " ");
                }

                int[] myIntsFromList = myList.ToArray(); // A method to convert to array.

                myList.Remove(2);
                Console.WriteLine("\nRemoved a 2 from myList, here are the results.");
                foreach(var item in myList) { Console.Write(item + " "); }


                myList.RemoveAt(0); // Remove the first element from myList
                Console.WriteLine("\nRemoved element at 0 index from myList, here are the results.");
                foreach(var item in myList) { Console.Write(item + " "); }

                myList.Clear(); // Remove all elements from myList

                
                Console.WriteLine("\n\n\n");
            } // End executeDriver()

            struct SimpleStruct {
                // Structs are similar to a Class
                // I would use the philosophy of the D programming language with these.
                // - Structs should be used as a collection of values.
                // - But this is not the definition in C#
                public int a;
                public int b;

                public int c, d; // multiple in a single line.
            } // End struct SimpleStruct

            
            class Simple {
                // Shows access modifiers, static member, and default constructor

                int a;              // Access in C# is private by default.
                private int b;      // Access in the same class.
                protected int c;    // Access in the same class and derived

                public int d;       // Allows access from anywhere
                
                public static int e;       // static member means only one per all instances of Simple

                // Note that Simple has a default constructor
            } // End class Simple

            class Properties {
                // Shows C# properties

                // Automatic properties
                public int AutoSetGet { get; set; }

                // using a member variable and public properties
                private int _x;
                public int X {
                    get{ return _x; }
                    set{ _x = value; }
                }

                // Having a public getter, but an internal to class only setter
                public int Y { get; internal set; }

                // Having a private getter, and a public setter
                public int Z { private get; set;}

                public Properties() {
                    // It's wise to initialize anything with private/internal setters.
                    // Otherwise a call to the getter will try to return but instead we'll have an error.
                    this.Y = 0;
                }
            } // End class Properties

            class Sum {
                public static int doTheSum(int a, int b) {
                    return a + b;
                }
            }

            class HasConstructor {
                public HasConstructor(int a, int b) {
                    // This is a parametized constructor
                    // Notice that it does not have an explicit return type.
                    // - The return type is implicit and it is of HasConstructor.
                }

                public HasConstructor(int a, char b, string c) {
                    // Overloading: The same method name with a different signature.
                    // The signature is the argument types: int, char , string
                }
            }



        } // End class ManyDetails




        class ConsoleOutputInput {

            public void output() {
                string name = "Jack";
                Console.WriteLine("My name is " + name);
                Console.WriteLine("{0} is my name.", name);

                double someNumber = 1234.5678;
                Console.WriteLine("Format {0} with 4 decimal places: {1:f4}", someNumber, someNumber);
                Console.WriteLine("Format {0} as number with 3 decimal places: {0:n3}", someNumber);
                Console.WriteLine("Format {0} as currency with two decimal places: {0:c2}", someNumber);
                Console.WriteLine("Format {0} as exponential: {0:e}", someNumber);
                Console.WriteLine("Format {0} with leading zeros: {0:d4}", 12);
                Console.WriteLine("Format {0} as percent: {0:p}", 0.33);
                Console.WriteLine("Format {0} with 4 leading digits a period and 2 decimal places {0:0000.00}", 12.3);
            }

            public void input() {
                Console.WriteLine("Reading input.");
                string input = Console.ReadLine();
                Console.WriteLine("Your typed: " + input);
            }
        } // End class ConsoleOutputInput

        class ChangeConsole {
            public static void executeDriver() {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        class WriteRead {
            // Demonstrates how to to write and read from file.
            // It utilizes: using System.IO;

            private static string fileName = "tempFile.txt";
            public void write() {
                Console.WriteLine("Writing file " + fileName);
                using (StreamWriter writer = File.CreateText(fileName) ) {
                    for (int i=0; i<5; ++i) {
                        writer.WriteLine("\tLine " + i);
                    }
                } // calls writer.Dispose()
                Console.WriteLine("Finished writing file.");
            }

            public void read() {
                Console.WriteLine("Reading file " + fileName);
                if (!File.Exists(fileName)) { Console.WriteLine("File {0} doesn't exist.", fileName); return; }
                using (StreamReader reader = File.OpenText(fileName)) {
                    string line;
                    while ( (line = reader.ReadLine()) != null) {
                        Console.WriteLine(line);
                    }
                } // calls reader.Dispose()
                Console.WriteLine("Finished reading file.");
            }

            public void remove() {
                if ( File.Exists(fileName) ) {
                    File.Delete(fileName);
                    if (File.Exists(fileName)) {
                        Console.WriteLine("Could not remove {0}", fileName);
                    } else {
                        Console.WriteLine("Removed file {0}", fileName);
                    }
                } else {
                    Console.WriteLine("File {0} doesn't exist.", fileName);
                }
            }
        } // End class WriteRead

        


    } // End class CsLanguage
}