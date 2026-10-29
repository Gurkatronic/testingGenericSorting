using System;
using System.Collections.Generic;
using System.Text;

namespace testingGenericSorting {

    public class Node {
        public int index;
        public Node left, right;

        public Node(int index) {
            this.index = index;
            left = null;
            right = null;
        }

        
    }
    public class Yggdrasil {
        public Node root;

        public Yggdrasil() {
            root = null;
        }

        public void BuildBalance(int[] array) {
            root = BuildBalance(array, 0, array.Length - 1);
        }

        Node BuildBalance(int[] array, int low, int high) {
            if (low > high)
                return null;

            int middle = low + (high - low) / 2;
            Node node = new(middle);

            node.left = BuildBalance(array, low, middle - 1);
            node.right = BuildBalance(array, middle + 1, high);

            return node;
        }

        public void PrintOrder() { PrintOrder(root); }
        public void PrintOrder(Node node) {
            if (node == null)
                return;

            PrintOrder(node.left);
            PrintOrder(node.right);

            Console.WriteLine(node.index);
        }
    }
}
