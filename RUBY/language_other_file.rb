puts "Executing language_other_file.rb"


# A class
class Shape
    def initialize
        @x = 0
        @y = 0
    end

    def set_x(new_x)
        @x = new_x
    end

    def get_x()
        return @x  # Implicit return
    end

    def set_y(new_y)
        @y = new_y
    end

    def get_y       # No need for ()
        return @y   # explicit return
    end

    # setter (can be used to verify that data compatible)
    def x=(new_x)
        @x = new_x if new_x.is_a?(Numeric)
    end

    # a getter
    def x
        @x  # implicit return
    end

end

# Create an object
shape = Shape.new
shape.x = 5
puts shape.get_x