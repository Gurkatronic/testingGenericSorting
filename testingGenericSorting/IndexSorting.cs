using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace testingGenericSorting {
    internal class IndexSorting {
        public static bool randomPivot = false;

        public static int[] GetSortedIndex<T>(T[] referenceArray) {
            int start = 0;
            int end = referenceArray.Length - 1;
            int[] sortedIndex = new int[end+1];

            for (int i = 0; i < sortedIndex.Length; i++)
                sortedIndex[i] = i;

            IndexQuickSort(sortedIndex, referenceArray, start, end);
            return sortedIndex;

        }
        static void IndexQuickSort<T>(int[] indexSorted, T[] referenceArray, int start, int end) {
            if (start >= end) return;

            int pivot = PartionSort(indexSorted, referenceArray, start, end);

            IndexQuickSort(indexSorted, referenceArray, start, pivot - 1);
            IndexQuickSort(indexSorted, referenceArray, pivot + 1, end);
        }

        static int PartionSort<T>(int[] indexSorted, T[] referenceArray, int start, int end) {

            T pivot = referenceArray[indexSorted[end]];
            Comparer comparer = Comparer.Default;
            int pointer = start - 1;

            for (int i = start; i < end; i++) {
                if (comparer.Compare(referenceArray[indexSorted[i]], pivot) < 0) {
                    pointer++;
                    (indexSorted[i], indexSorted[pointer]) = (indexSorted[pointer], indexSorted[i]);
                }
            }

            pointer++;
            (indexSorted[end], indexSorted[pointer]) = (indexSorted[pointer], indexSorted[end]);

            return pointer;
        }

        
    }
}
