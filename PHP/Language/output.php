<html>
<head>
    <title>Output</title>
</head>

<body>

<?php
    $color = $_POST["color"];       // Get from the value from the element named "color"
    if ($color !== null) {          // Check if variable is not null
        echo "The color is " . $color;
    }
?>

</body>
</html>