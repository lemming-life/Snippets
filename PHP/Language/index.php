<html>
<head>
    <title>PHP Language</title>
</head>

<body>

<?php
    // Setup stuff
    $br = "<br/>";
    $countAsserts = 0;

    // If doAssert fails print a message
    function doAssert($boolean) {
        $countAsserts++;
        if ($boolean !== true) {
            echo "Assert " . $countAsserts . " failed. <br />";
        } 
    }

    echo "Hello, World!" . $br;     // Print to html

    // Variables    
    $myStr1 = "Hello";              // Declare and initialize
    $myStr2 = $myStr1 . ", World2!"; // Concatenate
    doAssert($myStr2 == "Hello, World2!");

    $myNumber1 = 1;                 // Number
    $myNumber2 = $myNumber1 + 2;    // Addition
    $varFloat = 1.2345;             // Float
    doAssert( $varFloat == 1.2345 );

    $myBool0 = true; // Can be true or false
    doAssert($myBool0 == true);    
    $myBool1 = $myNumber == $myNumber;  // Check for true
    $myBool2 = $myNumber !== $myNumber; // Check for false
    $myBool3 = true and true;   // if left and right true, then true otherwise false
    $myBool4 = false or true;   // if either left or right true, then true, else if both false then false


    // If else
    if ($myBool3) {
        echo "Condition evaluated to true." . $br;
    } else {
        echo "Condition evaluated to false." . $br;
    }

    // Arrays
    $myNumberArray = [1, 2, 3, 4];              // Declare and init
    $myStringArray = ["Zero", "One", "Two"];    // Declare and init
    $myStringArray[0] = "Nero";                 // Change value
    doAssert($myStringArray[0] == "Nero");

    doAssert( doSum(2, 5) == 7 );                   // Function call with arguments.
    printStringArray($myStringArray);           // Function call with aguments.

    // Objects
    $myObj = (object) array('x' => '0', 'y' => '1'); // An anonymous object
    doAssert($myObj->x == 0);   // Access to member variable
    doAssert($myObj->y == 1);   // Access to member variable

    $myShape = new Shape;       // Object is an instance of a class.
    $myShape->x = 5;            // Setting member variable
    doAssert( $myShape->x == 5 );   // Get value from public member
    
    $myShape->setY(7);          // Calling a function and passing it a parameter
    doAssert( $myShape->getY() == 7 ); // Get value via member method

    $myShape->{'setY'}(6);      // Calling a function and passing it a parameter
    doAssert( $myShape->{'getY'}() == 6 );  // Get value via member method

    for( $i=0; $i<5; $i++ ) {
        echo $i . " ";
    }

    echo $br;
    $varCircle = new Circle();
    $varCircle->$radius = 2.0;

    doAssert( $varCircle->getArea() == 12.56 ); 

    // Function with two arguments, and return
    function doSum($a, $b) {
        return $a + $b;
    }

    // Function with array as argument
    function printStringArray($array) {
        // Iterating through the array, and outputing
        echo "<ul>";
        foreach($array as $item) {
            echo "<li>" . $item . "</li>";
        }
        echo "</ul>";
    };


    // Classes
    class Shape {
        public $x;  // public member variable
        private $y; // private member variable

        // Method to set private member variable
        public function setY($aY) {
            $this->$y = $aY;
        }

        // Method to return the value of a member variable
        public function getY() {
            return $this->$y;
        }
    } // End class Shape

    class Circle extends Shape {
        public $radius;

        public function getArea() {
            return (($this->$radius * $this->$radius) * 3.14);
        }
    }

?>

<!-- A form that will call output.php post-->
<form action="output.php" method="post">
    Color <input type="text" name="color">
    <input type="submit">
</form>

</body>
</html>