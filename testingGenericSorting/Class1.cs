using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace testingGenericSorting {
    public class Node<T> {
        public T data;
        public Node<T>? left;
        public Node<T>? right;

        public Node(T data) {
            this.data = data;
            left = null;
            right = null;
        }
    }

    public class BinaryTree<T> where T : IComparable<T> {
        Node<T>? root;

        public BinaryTree() {
            
        }

        public bool FindValue(T data) {
            if (root == null)
                return false;
            Node<T> node = root;
            int steps = 0;

            while(true) {
                if (node.data.CompareTo(data) == 0) {
                    Console.WriteLine("Found data after: " + steps + " steps");
                    return true;
                }
                else if(node.data.CompareTo(data) > 0 && node.left != null) {
                    node = node.left;
                }
                else if(node.data.CompareTo(data) < 0 && node.right != null) {
                    node = node.right;
                }
                else {
                    Console.WriteLine("Data could not be found. Steps taken: " + steps);
                    return false;
                }

                steps++;
            }
        }

        public void PrintVisually() {
            if (root == null) {
                Console.WriteLine("Empty tree");
                return;
            }
            PrintRecursive(root, "", true, true);
            Console.WriteLine();
        }

        private void PrintRecursive(Node<T>? node, string indentString, bool isLeftBranch, bool isRootNode) {
            if (node == null) return;

            // Gå hela vägen till höger (ritas högst upp)
            PrintRecursive(node.right, indentString + (isRootNode ? "" : (isLeftBranch ? "│   " : "    ")), false, false);

            // Rita ut linjer baserat på om det är rot, vänster- eller högergren
            string branchShape = isRootNode ? "──> " : (isLeftBranch ? "└── " : "┌── ");
            Console.WriteLine(indentString + branchShape + node.data);

            // Gå sedan till vänster (ritas längst ner)
            PrintRecursive(node.left, indentString + (isRootNode ? "" : (isLeftBranch ? "    " : "│   ")), true, false);
        }

        public void TakeRoot(T[] array, int start, int end) {
            if (start > end) return;

            int mid = (start + end) / 2;

            AddInfo(array[mid]);

            TakeRoot(array, start, mid-1);
            TakeRoot(array, mid + 1, end);
        }

        public void AddInfo(T data) {
            if (root == null) {
                root = new Node<T>(data);
                return;
            }

            Node<T>? currentNode = root;
            while(true) {
                if(currentNode == null) {
                    currentNode = new Node<T>(data);
                    return;
                }

                int compareValue = data.CompareTo(currentNode.data);

                if(compareValue < 0) {
                    if (currentNode.left != null)
                        currentNode = currentNode.left;

                    else {
                        currentNode.left = new Node<T>(data);
                        return;
                    }
                }
                else {
                    if (currentNode.right != null) 
                        currentNode = currentNode.right;
                    
                    else {
                        currentNode.right = new Node<T>(data);
                        return;
                    }
                }
            }

        }

    }

    
}
