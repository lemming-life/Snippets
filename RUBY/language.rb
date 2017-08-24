# Author: http://lemming.life
# Language: D

# This is a comment

=begin
    This is a 
    multi-line
    comment
=end

# Output to console
print "Hello, World1\n"  # print does not add a \n
puts "Hello, World2"     # puts always adds a \n
string = "Hello, World"
puts "#{string + 3.to_s}"   # Conducts operations inside #{ }
puts '#{string + 3.to_s'    # Yields #{string + 3.to_s}

# Arithmetic: +, -, *, /, %, +=, -=

# Everything is an object in Ruby
# - The type is determined by Ruby
# - note the lower case for variable name
number = 1       
float = 0.123   # Floats must have zero prior to the decimal.  Recall that there are limits on float (14 digits)
string = "This " + " is a string"  # concatenating strings
bool = true     

# Get the class name by doing .class
number.class       # Integer
float.class        # Float
string.class       # String
bool.class         #TrueClass

# Constant
# - First letter in upper case
MATH_PI = 3.14
#MATH_PI = 5.3   # Gives us warning that MATH_PI was previously initialized

KEYBOARD_INPUT_EXAMPLES = false

# Multi line string
# - Begins with <<EOM
# - Ends with EOM
# - Keeps the \n at end of each line
multi_line_string = <<EOM
This is the story of Ruby,
 a language that is dynamic and strong
EOM


# Boolean operators: >, >=, <, <=, ==, != 
# Logical operators: and, &&, or, ||, not, !
# Comparison with <=> will yield -1, 0, or 1 depending on left and right hand variables
# 1 <=> 2   # -1
# 3 <=> 3   # 0
# 3 <=> 2   # 1

# Conditional: if, elsif, els
if (2 > 3 && 5 < 3)
    # This will not run
elsif ( 2 >= 3  || 3 <= 2)
    # This will not run
else
    # This will run
end

# Conditional: unless
unless 2 < 4
    # This will not run
else
    # This will run
end

# Evaluate if condition is true
number = 2
number = 5 if 3 > 2     # number is now equal to 5
# puts number.to_s      # 5

# The case example
case number
when 2
    # this doesn't run
when 3, 4
    # this doesn't run
else
    # this runs
end

# Ternary operator ? :
number = true == true ? 1 : 2   # picks 1 in this case
number = true == false ? 1 : 2  # picks 2 in this case

# loop do
i = 0
loop do
    i += 1
    break if i > 5
end
# i is 6

# loop do
i = 0
loop do
    i += 1
    next if i < 5
    break
end
# i is 5

# while
i = 0
while i < 5
    i += 1
end

#until
i = 0
until i > 5
    i += 1
end 

# Arrays
numbers = [1, 2, 3]

# Go through each element in the array
for n in numbers
    # runs again, and again
end

# Iterating through with a holding cell |n|
numbers.each do |n|
    # runs again, and again
end

# Range
# - (fromInclusive .. toInclusive)
(0..3).each do |n|
    # runs again, and again, until
end


# Function declaration 1
# - arguments passed by value
def sum1(a, b)
    a + b   # implicit return is last line
end

# Call the function
sum1(2, 3) # 5

# Function declaration 2
def divideBy(a, b)
    return a / b    # explicit return
end

# Exceptions
begin
    result = divideBy(2, 0)
rescue
    # This line runs this time
    puts "Can't divide by zero"
    #exit #if we want to stop execution below
end

# User Exceptions
def willThrow(n)
    raise ArgumentError, "Argument is zero, need anything but zero" if n == 0
    puts "This line only runs if n is less than or greater than zero"
end

begin
    willThrow(0)
rescue ArgumentError
    # This line runs if willThrow(0)
    puts "Argument is zero at willThrow(0)"
end


# Write File
file_out = File.new("test.txt", "w")
file_out.puts("Some text inside.").to_s
file_out.close

# Read File
text_from_file = File.read("test.txt") # Contains the text that we previously wrote

# Remove/delete File
File.delete("test.txt")

# Load and execute from other file
load "language_other_file.rb" # Executing language_other_file.rb


# Get number from console example
if KEYBOARD_INPUT_EXAMPLES == true
    print "Enter an integer: "
    number = gets.to_i                  # Get from console, convert to integer
    puts "You entered " + number.to_s   # Output to console the concatenation of the literal and the converted number to string
end

# Get string from console example
if KEYBOARD_INPUT_EXAMPLES == true
    print "Enter your name: "
    name = gets.chomp  # chomp removes the \n
    puts "You entered " + name
end