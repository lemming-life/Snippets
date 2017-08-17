// Author: http://lemming.life
// Language: C++
// Purpose: Various sort algorithms

#ifndef SORT
#define SORT

void insertionSort(int* array, const int size) {
    // Insertion Sort:
    // - Break the array into two sides. The left one is sorted, the right one is sorted.
    // - Pick the next element from the unsorted side and compare it with the sorted side.
    // - If the element is greater than a particular spot in the sorted side, then that is its position.
    // - Insertion sort in this implementation is in-place.
    // Worst case: if we insert always at the beginning. Order is O(N^2)
    // Best case: If list is already sorted. Order is N
    
    if (size < 2) return; // Nothing to sort

    int value;                  // The value of the element from the unsorted side.
    int i;                      // Position of the unsorted element.
    int j;                      // Position that will be used from unsorted element through sorted side.

    // Go through each element of the unsorted side
    // and place the 
    i = 1;                      // No need for the first element
    while(i < size) {
        j = i;
        value = array[i];     // Get the element value from the unsorted side.

        // Shift elements to the right if the left one is greater than the element value.
        while (j>0 && array[j-1]>value) {
            array[j] = array[j-1];  //Shift element to the right
            --j;
        }

        array[j] = value; // The value is between elements or is left most
        ++i;
    }
} // End insertionSort()

void shellSort(int* array, const int size) {
    // Shellsort:
    // - Sort pairs of elements far apart, then reduce the gap between elements compared.
    // - Implementation is in-place.
    // Worst case: O(n^2)
    // Best case: O(nlogn)

    int value;
    int k = size / 2;

    while (k>0) {
        int i = 0;
        // Loop while i+k is not outside the array rightmost bound
        while (i+k < size) {
            // Swap elements if left (array[i]) is greater than array[i+k]
            if (array[i]>array[i+k]) {
                int temp = array[i+k];
                array[i+k] = array[i];
                array[i] = temp;

                // If the first swap takes place, then some swaps may be
                // needed towards the left (j-k), else exit j loop.
                bool quit = false;
                int j = i;
                while(j-k>-1 && !quit) {
                    if (array[j-k]>array[j]) {
                        temp = array[j-k];
                        array[j-k] = array[j];
                        array[j] = temp;
                    } else {
                        quit = true;
                    }
                    j -= k;
                } // End while
            } // End if
            ++i;

        } // End while
        k = k / 2; // Reduce k by halfing
    } // End while
} // End shellSort()



#endif