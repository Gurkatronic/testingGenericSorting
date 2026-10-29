using System;
using System.Collections.Generic;
using System.Text;

namespace testingGenericSorting {
    internal class SortingAlgos {

        public static void InsertionSort(int[] array) {
            for(int i = 1; i < array.Length; i++) {
                int key = array[i];
                int j = i - 1;

                while(j >= 0 && array[j] > key) {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
                
            }
        }
    }
}
