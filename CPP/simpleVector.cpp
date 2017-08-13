// Author: http://lemming.life
// Language: C++
// Purpose: A simple Vector class

#include <iostream>
#include <exception>
using namespace std;

// For simple types only!
template<class T>
class Vector {
    private:
        int _size;
        int _capacity;
        T* _data;

        void initData() {
            _size = 0;
            _capacity = 2;
            _data = new T[_capacity];
        }

        void clearData() {
            if (_data != NULL) {
                delete[] _data;
                _data = NULL;
            }
        }
    public:
        Vector() { initData(); }
        ~Vector() { clearData(); }

        int size() const { return _size; }
        int capacity() const { return _capacity; }

        void clear() {
            clearData();
            initData();
        }

        T at(int index) {
            if ( index < 0 || index > _size-1 ) { throw index; }
            return _data[index];
        }

        void removeAt(int index) {
            if (index < 0 || index > _size-1 ) { throw index; }

            T* newArray = new T[_size-1];

            // Grab leftOf
            for (int i=0; i<index; ++i) { newArray[i] = _data[i]; }

            // Grab rightOf
            for (int i=index+1; i<_size; ++i) { newArray[i-1] = _data[i]; }

            delete[] _data;
            _data = newArray;

            --_size;
        }

        void push(T item) {
            // Increase size if needed, copy old values to new array
            if (_size > _capacity-1) {
                _capacity = _capacity * 2;
                T* newArray = new T[_capacity];
                for (int i=0; i<_size; ++i) {
                    newArray[i] = _data[i];
                }
                delete[] _data;
                _data = newArray;
            }
            
            // Add item
            _data[_size] = item;
            ++_size;
        }

        string toString() {
            return "Size: " + to_string(_size) + ", Capacity: " + to_string(_capacity);
        }

        void print(string separator) {
            for (int i=0; i<size(); ++i) {
                cout << at(i) << separator;
            }
        }
};

int main() {
    cout << "Int Vector\n";
    Vector<int> myIntVector;
    for(int i=0; i<6; ++i) { myIntVector.push(i); }
    myIntVector.print(" ");
    cout << '\n';
    cout << myIntVector.toString() << "\n";
    cout << "Clearing vector.\n";
    myIntVector.clear();
    cout << myIntVector.toString() << "\n";

    cout << "Char Vector\n";
    Vector<char> myCharVector;
    for (int i=0; i<5; ++i) { myCharVector.push(65+i); }
    myCharVector.print(" "); // A B C D E
    cout << '\n';
    myCharVector.removeAt(2);
    myCharVector.print(" "); // A B D E
    cout << "\n"; 
    myCharVector.removeAt(0);
    myCharVector.print(" "); // B D E
    cout << "\n";
    myCharVector.removeAt(2);
    myCharVector.print(" "); // B D
    cout << "\n";  
    myCharVector.removeAt(1);
    myCharVector.print(" "); // B
    cout << "\n"; 
    myCharVector.removeAt(0);
    myCharVector.print(" "); // 
    cout << "\n"; 
    cout << myCharVector.toString() << "\n";

    return 0;
}