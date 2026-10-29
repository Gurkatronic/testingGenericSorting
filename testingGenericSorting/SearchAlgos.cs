using System;
using System.Collections.Generic;
using System.Text;

namespace testingGenericSorting {
    internal class SearchAlgos {

        public static int LinearSearch(int[] array, int search) {
            for (int i = 0; i < array.Length; i++) {
                if (array[i] == search) {
                    return i;
                }
            }

            return -1;
        }

        public static int BinarySearch(int[] array, int search) {

            int left = 0;
            
            int right = array.Length - 1;

            while(left <= right) {
                int middle = left + (right - left) / 2;

                if (array[middle] == search) //linear search from this point to find the actual start.
                    return middle;

                if (array[middle] < search) {
                    left = middle + 1;
                }
                else { 
                    right = middle - 1;
                }
            }

            return -1;
        }

        public class BinaryRange {
            public int low = -1;
            public int middle = -1;
            public int high = -1;
            int[] array;
            int[]? results;

            public BinaryRange(int[] array) {
                this.array = array;
            }

            public bool PerformSearch(int searchLow, int searchHigh) {
                (low, middle, high) = BinaryRangeSearch(array, searchLow, searchHigh);
                SaveResults();

                if (low < 0 && middle < 0 && high < 0)
                    return false;

                return true;
            }

            void SaveResults() {
                //Save the results of the search so its easy to access
                if (low < 0 && middle < 0 && high < 0)
                    results = null;
                else if (middle > -1)
                    results = new[] { array[middle] };
                else if (low < 0)
                    results = array[0..array[high+1]];
                else if (high < 0)
                    results = array[array[low]..array[array.Length]];
            }

            //public int[]? GetResults() {
            //    return results;
            //}
            public int[] GetResults() {
                int[] output = null;

                if (low < 0 && middle < 0 && high < 0)
                    return null;
                if (middle != -1)
                    output = new[] { array[middle] };
                else
                    output = array[low..high];

                return output;
            }
        }

        public static (int, int, int) BinaryRangeSearch(int[] array, int searchLow, int searchHigh) {
            if(searchLow > searchHigh) {
                (searchLow, searchHigh) = (searchHigh, searchLow);
            }

            int low = BinarySearch(array, searchLow);
            int high = BinarySearch(array, searchHigh);
            int middle =  -1;

            if (low < 0)
                middle = high;
            else if (high < 0)
                middle = low;


            return (low, middle, high);
        }
    }
}
