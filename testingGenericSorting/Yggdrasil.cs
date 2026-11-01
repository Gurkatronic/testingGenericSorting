using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace testingGenericSorting {

    //Min tree saknar korrekt implementation ska skicka med den sorterade index arrayen och sedan spara ner detta i noderna
    //behöver även få ut informationen från trädet
    public class Rune(int index) {
        public int index = index;
        public Rune? left, right = null;

        public void Establish(int[] indexArray, int low, int high) {

            if (low <= index -1) {
                int leftMiddle = (low + (index - 1)) / 2;
                left = new(indexArray[leftMiddle]);
                left.Establish(indexArray,low, index-1);
            }

            if(high >= index+1) {
                int rightMiddle = (high + index + 1) / 2;
                right = new(indexArray[rightMiddle]);
                right.Establish(indexArray,index + 1, high);
            }
        }

        public void SearchIndex(int i) {
            if (index == i) {
                Console.WriteLine("found index: " + i);
                return;
            }
            if (left != null)
                left.SearchIndex(i);
            if (right != null)
                right.SearchIndex(i);

        }

        public void Print() {
            Console.WriteLine(index);
            if (left != null)
                left.Print();
            if (right != null)
                right.Print();
        }

        public void DFSTravel() {

        }

    }

    public class Yggdrasil {
        public Rune root;
        public int Count;
        private int[] bfsIndex;
        private int[] dfsIndex;

        public Yggdrasil() {
            root = null;
        }

        
        public void TakeRoot(int[] indexArray) {
            int end = indexArray.Length;
            if (indexArray.Length <= 0)
                return;

            int start   = 0;
            int middle  = end / 2;
            
            root = new Rune(middle);
            root.Establish(indexArray, start, end-1);
            Count = end;
        }

        public void PrintTree() {
            
            if (root != null)
                root.Print();
            Console.WriteLine("Root");
        }

        public void Search(int i) {
            if (root != null)
                root.SearchIndex(i);

        }

        public int[] BFSTravel() { //breadth first search gör nivå för nivå änvänder en que för att gå ner i trädet
            if (bfsIndex != null)
                return bfsIndex;
            else
                bfsIndex = new int[Count];

            Queue<Rune> runes = new Queue<Rune>();
            runes.Enqueue(root);

            int travelIndex = 0;
            while (runes.Count > 0) {

                Rune rune = runes.Dequeue();

                bfsIndex[travelIndex] = rune.index;
                travelIndex++;

                if(rune.left != null) {
                    runes.Enqueue(rune.left);
                }
                if(rune.right != null) {
                    runes.Enqueue(rune.right);
                }

            }

            return bfsIndex;
        }

        public int[] DFSTravel() { //Åker så djupt ner den kan sedan börjar den poppa noder för att ge platserna
            if (dfsIndex != null)
                return dfsIndex;
            else
                dfsIndex = new int[Count];

            Stack<Rune> runes = new Stack<Rune>();
            runes.Push(root);

            int travelIndex = 0;
            while(runes.Count > 0) {

                Rune rune = runes.Pop();

                dfsIndex[travelIndex] = rune.index;
                travelIndex++;

                if (rune.right != null) { //behöver ta höger in i stacken först så den hamnar sist
                    runes.Push(rune.right);
                }
                if (rune.left != null) {
                    runes.Push(rune.left);
                }
                
            }

            return dfsIndex;
        }
    }
}
