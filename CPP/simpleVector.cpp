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
        Vector() {
            initData();
        }
        ~Vector() {
            clearData();
        }

        void clear() {
            clearData();
            initData();
        }

        int capacity() const {
            return _capacity;
        }

        int size() const {
            return _size;
        }

        T at(int index) {
            if ( index < 0 || index > _size-1 ) {
                throw index;
            } else {
            return _data[index];
                
            }
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
};

int main() {
    Vector<int> myIntVector;
    for(int i=0; i<6; ++i) { myIntVector.push(i); }
    for (int i=0; i<myIntVector.size(); ++i) { cout << myIntVector.at(i) << " "; }
    cout << '\n';
    cout << myIntVector.toString() << "\n";
    cout << "Clearing vector.\n";
    myIntVector.clear();
    cout << myIntVector.toString() << "\n";

    Vector<char> myCharVector;
    for (int i=0; i<5; ++i) { myCharVector.push(65+i); }
    for (int i=0; i<myCharVector.size(); ++i) { cout << myCharVector.at(i) << " "; }
    cout << '\n';
    cout << myCharVector.toString() << "\n";

    return 0;
}