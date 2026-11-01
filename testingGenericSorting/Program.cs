using System.Collections;
using System.Reflection;
using testingGenericSorting;
using static Fieldpackaging.FieldUtility;
using static testingGenericSorting.InsertionSorting;
using static testingGenericSorting.SortingAlgos;
using static testingGenericSorting.SearchAlgos;
using static testingGenericSorting.IndexSorting;

namespace testingGenericSorting {
    internal class Program {



        static NumberClass[] RandomNumberClass(int arraySize, int randomSeed) {
            NumberClass[] outputArray = new NumberClass[arraySize];
            string[] randomString = new string[] { "abc", "aaw", "wauda", "aspdo", "odpq", "pwapd", "o1oiiadk", "ppqea", "xscaft", "lasdp", "wwarp", "short" };
            //String, number, float
            Random random = new Random(randomSeed);

            for (int i = 0; i < outputArray.Length; i++) {
                outputArray[i] = new(randomString[random.Next(0, randomString.Length)], random.Next(0, 100), random.NextSingle());
            }

            return outputArray;
        }

        static DateClass[] RandomDateClass(int arraySize, int randomSeed) {
            DateClass[] outputArray = new DateClass[arraySize];
            string[] randomString = new string[] { "abc", "aaw", "wauda", "aspdo", "odpq", "pwapd", "o1oiiadk", "ppqea", "xscaft", "lasdp", "wwarp", "short" };
            char[] randomChars = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'w', 'z', 'c', 'd', 's' };
            //Date, string, char
            Random random = new Random(randomSeed);

            for (int i = 0; i < arraySize; i++) {
                DateTime newDate = new DateTime();

                newDate = newDate.AddYears(random.Next(1450, 2000));
                newDate = newDate.AddDays(random.Next(1, 20));
                newDate = newDate.AddMonths(random.Next(1, 13));
                outputArray[i] = new DateClass(newDate.ToString(), randomString[random.Next(randomString.Length)], randomChars[random.Next(randomChars.Length)]);
            }



            return outputArray;
        }

        public static int[] CreateNumberArray(int arraySize, int seed) {
            int low = 0;
            int high = 100;
            int[] output = new int[arraySize];
            Random random = new(seed);

            for (int i = 0; i < arraySize; i++) {
                output[i] = random.Next(low, high);
            }

            return output;
        }
        static void Main(string[] args) {

            int[] testArray = CreateNumberArray(10000, 10);
            
            int[] sortedIndex = GetSortedIndex(testArray);
            int[] treeTestArray = new int[] { 5, 2, 3, 4, 2, 0 };

            BinaryTree<int> binTree = new BinaryTree<int>();
            Console.WriteLine(string.Join(", ", testArray));

            QuickSort(testArray);
            Console.WriteLine(string.Join(", ", testArray));
            binTree.TakeRoot(testArray, 0, testArray.Length-1);

            var timer = System.Diagnostics.Stopwatch.StartNew();
            int searchValue = 14;

            timer.Start();
            binTree.FindValue(searchValue);
            timer.Stop();
            Console.WriteLine("Tree searching took: " + timer.ElapsedTicks);

            testArray = CreateNumberArray(999999999, 10);

            timer = System.Diagnostics.Stopwatch.StartNew();
            timer.Start();
            BinarySearch(testArray, searchValue);
            timer.Stop();

            Console.WriteLine("Regular binary search took: " + timer.ElapsedTicks);


            //Yggdrasil yggdrasil = new();

            //yggdrasil.TakeRoot(treeTestArray);
            //yggdrasil.PrintTree();

            //int[] bfsTravel = yggdrasil.BFSTravel();
            //int[] dfsTravel = yggdrasil.DFSTravel();

            //Console.WriteLine("BFS travel path");
            //Console.WriteLine(string.Join(", ", bfsTravel));
            //Console.WriteLine("\nDFS travel path");
            //Console.WriteLine(string.Join(", ", dfsTravel));



            //int low = 10;
            //int high = 50;

            //int middle = (low + high) / 2;
            //Console.WriteLine(middle);
            //Console.WriteLine(string.Join(", ", testArray));
            //MerginSort(testArray, 0, testArray.Length - 1);

            //for(int i = 0; i < testArray.Length; i++) {
            //    Console.Write(" " + testArray[sortedIndex[i]]);
            //}

            //Console.WriteLine("\n\n\n Actual array pos\n");

            //for(int i = 0; i < testArray.Length; i++) {
            //    Console.Write(" " + testArray[i]);
            //}

            //int[] numArray = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //LinkedList<int> linkedInt = new LinkedList<int>(numArray);
            //InsertionSort(testArray);
            //Yggdrasil yggdrasil = new();
            //yggdrasil.TakeRoot(100);


            //Console.WriteLine(string.Join(", ", testArray));
            //BinaryRange binaryRange = new(testArray);

            //binaryRange.PerformSearch(19, 30);

            //int[]? temp = binaryRange.GetResults();

            //if (temp != null) {
            //    for (int i = 0; i < temp.Length; i++) {
            //        Console.WriteLine("found: " + temp[i]);
            //    }
            //}

        }

        static void SpecialSort(int[] array, int low, int high) {
            
            while(low <= high) {
                if (array[low] < array[high])
                    (array[low], array[high]) = (array[high], array[low]);
                else {
                    low++;
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }

        static void NormalSort(int[] array, int low, int high) {
            for(int i = 1; i < high; i++) {
                for(int j = 0; j < i; j++) {
                    if (array[i] < array[j]) {

                        (array[j], array[i]) = (array[i], array[j]);
                    }
                        
                }
            }

            Console.WriteLine(string.Join(", ", array));
        }

        static void LetsSortIt(int[] array, int low, int high) {

            //split in the middle for as many times it can be done
            //
            int splitAmount = high/2; //it can be split 4 times on an array of size 10
            if (splitAmount <= 1) return;

            for(int i = 0; i < splitAmount*2; i++) {
                Console.WriteLine($"low {i} high {i + 2}");
                CompareSwitch(array, i, i + 2);
            }

            LetsSortIt(array, low, high-1);

            Console.WriteLine(string.Join(",",array));
            
        }

        static void MerginSort(int[] array, int low, int high) {
            int n = high/2;
            int i = low;
            if (low+1 == high) return;
            Console.WriteLine($"i: {i} n {n}");
            MerginSort(array, i, n);
            MerginSort(array, n + 1, high);
        }

        static void CompareSwitch(int[] array, int index, int indexSwap) {
            if (array[index] < array[indexSwap])
                (array[index], array[indexSwap]) = (array[indexSwap], array[index]);
        }

        static void SpiceSort(int[] array, int low, int high) {
            //Split all arrays into arrays of smaller parts then sum and do a pass to check numbers once
            int middle = (low + high) / 2;
            while(middle > 2) {
                Console.WriteLine("Middle " + middle);
                ParallelMerge(array, low, middle);
                ParallelMerge(array, middle + 1, high);
                middle = SplitMiddle(low, middle);
            }
            Console.WriteLine(string.Join(", ", array));
            for(int i = 0; i < array.Length; i++) {

            }
            

        }

        static void ParallelMerge(int[] array, int low, int high) {
            Console.WriteLine($"Low {low} >_< High {high}");
            if (low >= high) return;
            if (array[low] < array[high])
                (array[low], array[high]) = (array[high], array[low]);
            else
                ParallelMerge(array, low + 1, high - 1);
        }

        static int SplitMiddle(int low, int high) {

            int middle = (high + (low - high)) / 2;
            return middle;
        }

        static void MeasureSortingMethods()
        {
            int arraySize = 4000;
            int randomSeed = 100;

            NumberClass[] NumberClasss = RandomNumberClass(arraySize, randomSeed);
            DateClass[] DateClasss = RandomDateClass(arraySize, randomSeed);
            var timeStopOnce = System.Diagnostics.Stopwatch.StartNew();
            var timeStopLoop = System.Diagnostics.Stopwatch.StartNew();

            timeStopOnce.Start();
            InsertionSortGetOnce(NumberClasss, 1, false);
            InsertionSortGetOnce(DateClasss, 1, false);
            timeStopOnce.Stop();

            for (int i = 0; i < NumberClasss.Length; i++)
            {
                Console.WriteLine($"{NumberClasss[i].userName}\t - {NumberClasss[i].age}\t - {NumberClasss[i].power}");
            }

            for (int i = 0; i < DateClasss.Length; i++)
            {
                Console.WriteLine($"{DateClasss[i].date.ToString()}\t - {DateClasss[i].catchPhrase}");
            }

            Console.WriteLine("Time spent sorting with one get function on fields: " + timeStopOnce.ElapsedMilliseconds + " ms");
            Console.WriteLine("Press any key to test other method");

            NumberClasss = RandomNumberClass(arraySize, randomSeed);
            DateClasss = RandomDateClass(arraySize, randomSeed);

            timeStopLoop.Start();
            InsertionSortGetEveryLoop(NumberClasss, 1, false);
            InsertionSortGetEveryLoop(DateClasss, 1, false);
            timeStopLoop.Stop();

            Console.WriteLine("time spent sorting geting types every iteration: " + timeStopLoop.ElapsedMilliseconds + " ms");
            Console.WriteLine("Time spent sorting with one get function on fields: " + timeStopOnce.ElapsedMilliseconds + " ms");
            long diff = timeStopOnce.ElapsedMilliseconds - timeStopLoop.ElapsedMilliseconds;
            Console.WriteLine("Once - Loop = " + diff + " ms");
            Console.WriteLine("array size : " + arraySize);
            Console.WriteLine("Seed: " + randomSeed);
            Console.ReadKey();

            Console.ReadKey();
        }


    }
}
    

