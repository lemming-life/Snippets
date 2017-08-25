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
        return @x  # Implicit return
    end

    def set_y(new_y)
        @y = new_y
    end

    def get_y       # No need for ()
        return @y   # explicit return
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

    # Override get_area of Shape
    def get_area
        return 3.14 * radius
    end

end


circle = Circle.new
circle.x = 1    # Uses the x setter from Shape
circle.y = -1   
circle.radius = 2
circle.get_area # 6.28