// 


int main() {

    return 0;
}



// A simple class
class Circle {
    public:
        Circle() {}
        Circle(int aRadius) {
            radius = aRadius;
        }

        int getRadius() { return radius; }
        void setRadius(int aRadius) { radius = aRadius; }
    private:
        int radius;
}; // 