<html>
<head>
    <title>PHP Language</title>
</head>

<body>

<?php
    $br = "<br/>";
    $myStr1 = "Hello";              // Declare and initialize
    $myStr2 = $myStr1 . ", World2!" . $br; // Concatenate
    $myNumber1 = 1;                 // Number
    $myNumber2 = $myNumber1 + 2;    // Addition

    echo "Hello, World!" . $br;     // Print to html
    echo $myStr2;                   

    $myBool0 = true; // Can be true or false
    $myBool1 = $myNumber == $myNumber;  // Check for true
    $myBool2 = $myNumber !== $myNumber; // Check for false
    $myBool3 = true and true;   // if left and right true, then true otherwise false
    $myBool4 = false or true;   // if either left or right true, then true, else if both false then false

    // If else
    if ($myBool3) {
        echo "true" . $br;
    } else {
        echo "false" . $br;
    }

    // Arrays
    $myNumberArray = [1, 2, 3, 4];              // Declare and init
    $myStringArray = ["Zero", "One", "Two"];    // Declare and init
    echo "Number array: " . $myStringArray[0] . $br;  // Get value at index 0
    $myStringArray[0] = "Negative One";         // Change value

    echo doSum(2, 5) . $br;                     // 7

    printStringArray($myStringArray);           // Calling a function with argument


    // Objects
    $myObj = (object) array('x' => '0', 'y' => '1'); // An anonymous object
    echo $myObj->x; // 0
    echo $myObj->y; // 1

    echo $br;

    $myShape = new Shape;
    $myShape->x = 5;
    $myShape->{'setY'}(6);   // Calling a function and passing it a parameter
    echo $myShape->x;           // Getting the value from member x
    echo $myShape->{'getY'}();  // Calling a function and getting the value.



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
        public $x = 0;  // public member variable
        private $y = 0; // private member variable

        // Method to set private member variable
        function setY($aY) {
            $this->$y = $aY;
        }

        // Method to return the value of a member variable
        function getY() {
            return $this->$y;
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