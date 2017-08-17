// Author: http://lemming.life
// Language: C++
// Purpose: Various sort algorithms

#ifndef SORT
#define SORT

void swapValues(int& a, int& b) {
    int temp = a;
    a = b;
    b = temp;
}

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
                swapValues(array[i+k], array[i]);

                // If the first swap takes place, then some swaps may be
                // needed towards the left (j-k), else exit j loop.
                bool quit = false;
                int j = i;
                while(j-k>-1 && !quit) {
                    if (array[j-k]>array[j]) {
                        swapValues(array[j-k], array[j]);
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


/* QUICKSORT uses quickSort, partition, getMedian functions */

int getMedianIndex(int* array, int min, int max) {
    int mid = (min+max)/2;

    if (
        (array[min]>array[max] && array[max] > array[mid])
        ||
        (array[mid]>array[max] && array[max] > array[min])
    ) return max;

    if (
        (array[max]>array[min] && array[min] > array[mid])
        ||
        (array[mid]>array[min] && array[min] > array[max])
    ) return min;

    return mid;
}

int partition(int* array, int left, int right) {
    // Purpose: partition (order) an array within the given boundaries
    int medianIndex = getMedianIndex(array, left, right);
    int pivot = array[medianIndex];
    int partitionIndex = left;
    int pick;

    // Swap last and pivot
    swapValues(array[right], array[medianIndex]);

    // Go through the elements of the group
    for (int i=left; i<right; ++i) {
        // Move items less than the pivot to the left
        if (array[i] <= pivot) {
            swapValues(array[i], array[partitionIndex]);
            ++partitionIndex;
        }
    }

    // Swap the pivot with the index less than greater than pivot number
    swapValues(array[partitionIndex], array[right]);
    return partitionIndex;
}

void quickSort(int* array, int left, int right) {
    // QuickSort
    // - Pick a pivot from the array.
    // - Partition (reorder array so that elements values less than pivot come before the pivot)
    // - Recursively apply above steps to smaller sub-arrays.
    // Worst case: O(n^2)
    // Best case: O(nlogn)
    if (right <= left) { return; }

    // Order the partition, and teh pivotIndex
    int pivotIndex = partition(array, left, right);

    // Determine the size of the two subgroups
    int aSize = (pivotIndex-1) - left;
    int bSize = right - (right+1);

    // Work on the smaller group first.
    if (aSize < bSize) {
        quickSort(array, left, pivotIndex-1);
        quickSort(array, pivotIndex+1, right);
    } else {
        quickSort(array, pivotIndex+1, right);
        quickSort(array, left, pivotIndex-1);
    }
} // End quickSort()

#endif