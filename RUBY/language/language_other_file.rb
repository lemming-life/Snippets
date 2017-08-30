puts "Executing language_other_file.rb"


# A class
class Shape
    def initialize
        @x = 0  # member variable
        @y = 0  # member variable
    end

    def set_x(new_x)
        @x = new_x
    end

    def get_x()
        return @x  # Explicit return
    end

    def set_y(new_y)
        @y = new_y 
    end

    def get_y       # No need for ()
        @y          # Implicit return
    end

    # Setter (can be used to verify that data compatible)
    def x=(new_x)
        @x = new_x if new_x.is_a?(Numeric)
    end

    # Getter
    def x
        @x  # implicit return
    end

    def y=(new_y)
        @y = new_y if new_y.is_a?(Numeric)
    end

    def y
        @y
    end

    def get_area
        return 0
    end
end

# Create an object
shape = Shape.new
shape.set_x(1)      # Use a method, pass a value
shape.get_x         # Use a method to get
shape.x = 5         # Use the setter
shape.x        # Use the getter


# Class using inheritance
class Circle < Shape
    #attr_reader :radius, :area # Getters
    #attr_writer :radius :area  # Setters
    attr_accessor :radius, :color # Both getter and setter

    def initialize
        radius = 1
    end

    # Override get_area of Shape
    def get_area
        return 3.14 * radius.to_f
    end
end

class Rectangle < Shape
    attr_accessor :height, :width

    def initialize
        height = 1
        width = 1
    end

    def get_area
        return width.to_f * height.to_f
    end
end

circle = Circle.new
circle.x = 1    # Uses the x setter from Shape
circle.y = -1   
circle.radius = 2
circle.get_area # 6.28


# Allows us to use the StopWatch module
require_relative "stopwatch"

module Phone
    def play_ringtone
        puts "ring, ring..."
    end

    def vibrate
        puts "brrr"
    end
end

class FancyPhone
    include Phone

    # Include StopWatch methods in the Phone
    include StopWatch
end

fancyPhone = FancyPhone.new
fancyPhone.play_ringtone
fancyPhone.start_stop_watch
fancyPhone.output_stop_watch
fancyPhone.stop_stop_watch

class NotFancyPhone
    prepend Phone

    # Note how vibrate is a method in both Phone and NotFancyPhone
    # the preprend Phone means that the Phone one will be used instead of the NotFancyPhone
    def vibrate
        puts "no vibrate"
    end
end

noFancyPhone = NotFancyPhone.new
noFancyPhone.vibrate    # brrr

# Symbols (no value given)
:a_symbol


# Enumeration
class Colors
    include Enumerable
    def each
        yield "red"
        yield "green"
        yield "blue"
    end
end

colors = Colors.new
colors.each do |color|
    aColor = color
end


colors.first # red
colors.find{ |color| color = "red" }.to_s # "red"
colors.select { |color| color.size <=4 } # ["red", "blue"]
colors.reject { |color| color.size >=4 } # ["red"]
colors.min # blue
colors.max # red
colors.sort   #["blue", "green", "red"]
colors.reverse_each { |color| aColor = color} # blue, green, red

# Open classes allow us to 
# have more class instance member additions
# even though class Colors was already defined.
# You can do this with any class, and you could
# modify some very essential classes, this is called "moneky patching"
class Colors
    def someOtherMethod

    end
end