// Author: http://lemming.life
// Language: C++
// Description: Program a complex number class, and overload operators.
// - Test the complex numbers by doing arithmetic.

#include <iostream>
using namespace std;

class ComplexNumber {
    private:
        double _real;
        double _imaginary;
    
    public:
        ComplexNumber() { _real = 0; _imaginary = 0; }
        ComplexNumber(double real, double imaginary) {
            _real = real;
            _imaginary = imaginary;
        }

        void setReal(const double real) { _real = real; }
        void setImaginary(const double imaginary) { _imaginary = imaginary; }
        double getReal() const { return _real; }
        double getImaginary() const { return _imaginary; }

        // Operator overloading examples
        ComplexNumber operator+(const ComplexNumber& rh) const {
            return ComplexNumber(
                this->getReal() + rh.getReal()
                , this->getImaginary() + rh.getImaginary()
            );
        }

        ComplexNumber operator-(const ComplexNumber& rh) const {
            return ComplexNumber(
                this->getReal() - rh.getReal()
                , this->getImaginary() - rh.getImaginary()
            );
        }

        ComplexNumber operator*(const ComplexNumber& rh) const {
            return ComplexNumber(
                (this->getReal() * rh.getReal()) - (this->getImaginary() * rh.getImaginary())
                , (this->getReal() * rh.getImaginary()) + (this->getImaginary() * rh.getReal())
            );
        }

        ComplexNumber operator/(const ComplexNumber& rh) const {
            return ComplexNumber(
                (
                    (this->getReal()*rh.getReal()) + (this->getImaginary()*rh.getImaginary())
                ) / (
                    (rh.getReal() * rh.getReal()) + (rh.getImaginary() + rh.getImaginary())
                )
                ,
                (
                    (-1*this->getReal()*rh.getImaginary()) + (this->getImaginary() * rh.getReal())
                ) / (
                    (rh.getReal() * rh.getReal()) + (rh.getImaginary() + rh.getImaginary())
                )
            );
        }

        void operator=(const ComplexNumber& rh) {
            this->setReal( rh.getReal() );
            this->setImaginary( rh.getImaginary() );
        }

        bool operator==(const ComplexNumber& rh) const {
            if (this->getReal() != rh.getReal()) { return false; }
            if (this->getImaginary() != rh.getImaginary()) { return false; }
            return true;
        }

        bool operator!=(const ComplexNumber& rh) const {
            if (this->getReal() != rh.getReal()) { return true; }
            if (this->getImaginary() != rh.getImaginary()) { return true; }
            return false;
            
        }
};

ostream& operator<<(ostream& out, const ComplexNumber& cn) {
    double r = cn.getReal();
    double i = cn.getImaginary();

    if (r == 0 && i == 0) { out << 0; }                     // 0
    if (r == 0 && i != 0) { out << i << "i"; }              // bi
    if (r != 0 && i == 0) { out << r; }                     // a
    if (r != 0 && i < 0)  { out << r << " " << i << "i"; }  // a - bi 
    if (r != 0 && i > 0)  { out << r << " +" << i << "i"; } // a + bi
    return out;
}

int main() {
    // Create complex numbers to do arithmentic with
	ComplexNumber cm1(2, -2);
	ComplexNumber cm2(2, -0);

    cout << cm1 + cm2 << '\n'; // + | 4-2i
    cout << cm1 - cm2 << '\n'; // - | -2i
    cout << cm1 * cm2 << '\n'; // * | 4-4i
    cout << cm1 / cm2 << '\n'; // / | 1-1i

    ComplexNumber cm3 = cm1; // Assignment operator

    // Comparison
    if (cm1 != cm2) { cout << "cm1 and cm2 are not equal\n"; }
    if (cm1 == cm3) { cout << "cm1 and cm3 are equal\n"; }
    return 0;
}