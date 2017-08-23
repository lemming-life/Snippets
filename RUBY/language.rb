# Author: http://lemming.life
# Language: D

# This is a comment

# Output to console
print "Hello, World\n"  # print does not add a \n
puts "Hello, World"     # puts always adds a \n


# Get from console example
print "Enter an integer: "
number = gets.to_i                  # Get from console, convert to integer
puts "You entered " + number.to_s   # Output to console the concatenation of the literal and the converted number to string

# Arithmetic: +, -, *, /, %, +=, -=

# Everything is an object in Ruby
# - The type is determined by Ruby
# - note the lower case for variable name
number = 1      # Fixnum 
float = 0.123   # Floats must have zero prior to the decimal.  Recall that there are limits on float (14 digits)
string = "This is a string"

# Get the class name by doing .class
number.class    # Fixnum
float.class     # Float
string.class    # String

# Constant
# - First letter in upper case
MATH_PI = 3.14
#MATH_PI = 5.3   # Gives us warning that MATH_PI was previously initialized

# Write File
file_out = File.new("test.txt", "w")
file.out.puts("Some text inside.").to_s
file_out.close

# Read File
text_from_file = File.read("test.txt") # Contains the text that we previously wrote