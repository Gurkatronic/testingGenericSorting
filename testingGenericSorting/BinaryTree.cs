using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace testingGenericSorting {

    //Min tree saknar korrekt implementation ska skicka med den sorterade index arrayen och sedan spara ner detta i noderna
    public class Rune(int index) {
        public int index = index;
        public Rune? left, right = null;

        public void Establish(int low, int high) {

            if (low <= index -1) {
                int leftMiddle = (low + (index - 1)) / 2;
                left = new(leftMiddle);
                left.Establish(low, index-1);
            }

            if(high >= index+1) {
                int rightMiddle = (high + index + 1) / 2;
                right = new(rightMiddle);
                right.Establish(index+1, high);
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

        public void BFSTravel(Queue<Rune> runes) {
            while(runes.Count > 0) {
                Console.WriteLine(runes.Dequeue().index);
            }
            if(left != null) {
                runes.Enqueue(left);
                left.BFSTravel(runes);
            }
            if(right != null) {
                runes.Enqueue(right);
                right.BFSTravel(runes);
            }
            
        }

    }

    public class Yggdrasil {
        public Rune root;

        public Yggdrasil() {
            root = null;
        }

        
        public void TakeRoot(int size) {
            if (size <= 0)
                return;

            int start   = 0;
            int middle  = size / 2;

            root = new Rune(middle);
            root.Establish(start, size);
        }

        public void PrintTree() {
            Console.WriteLine("Root");
            if (root != null)
                root.Print();
        }

        public void Search(int i) {
            if (root != null)
                root.SearchIndex(i);

        }

        public void BFS() {
            Queue<Rune> runes = new Queue<Rune>();
            runes.Enqueue(root);
            root.BFSTravel(runes);
        }

        public void DFS() {

        }
    }
}
