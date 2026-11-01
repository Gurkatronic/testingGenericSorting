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
        public static void QuickSort<T>(T[] array) where T : IComparable<T>{
            QuickSortInternal(array, 0, array.Length - 1);
        }
        public static void QuickSortInternal<T>(T[] array, int low, int high) where T : IComparable<T>{
            if (low >= high) return;

            int pivot = PartionSort(array, low, high);

            QuickSortInternal(array, low, pivot - 1);
            QuickSortInternal(array, pivot + 1, high);
        }

        public static int PartionSort<T>(T[] array, int low, int high) where T : IComparable<T>{

            T pivot = array[high];

            int pointer = low - 1;

            for(int i = low; i < high; i++) {
                if (array[i].CompareTo(pivot) < 0) {
                    pointer++;
                    TupleSwap(array, i, pointer);
                }
            }

            pointer++;

            TupleSwap(array, pointer, high);

            return pointer;

        }

        public static void TupleSwap<T>(T[] array, int pos, int swap) {
            (array[pos], array[swap]) = (array[swap], array[pos]);
        }
    }
}
