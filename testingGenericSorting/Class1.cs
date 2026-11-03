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

        public bool DeleteValue(T data) {
            Node<T> node = root;
            int steps = 0;

            while(node != null) {
                if(node.data.CompareTo(data) == 0 ) {
                    //Console.WriteLine("Found the object. after " + steps + " steps");
                    HandleDelete(node, data);
                }
                else if (node.data.CompareTo(data) > 0) {
                    node = node.left;
                }
                else if (node.data.CompareTo(data) < 0) {
                    node = node.right;
                }
            }
            return false;
        }


        //delete operation
        //No child just delete
        //1 child promote up
        //2 child spooky stuff
        void HandleDelete(Node<T> node, T data) {

            Console.WriteLine("Stefany tänker smyga hem");
            while(node != null) {
                if(node.left == null && node.right == null) {
                    Console.WriteLine("tar bort data: " + node.data.ToString());
                    node = null;
                    Console.WriteLine("TAR BORT ELEMENT");
                    return;
                }
                else if(node.left != null && node.right == null) {
                    node = node.left;
                    return;
                }
                else if(node.right != null && node.left == null) {
                    node = node.right;
                    return;
                }
                else if(node.right != null && node.left != null) {
                    //node.data = node.left.data;
                    Console.WriteLine("Spännande vägen");
                    node = node.left;
                }
            }
        }


        public bool FindValue(T data) {
            if (root == null)
                return false;
            Node<T> node = root;
            int steps = 0;

            while(node != null) {
                if (node.data.CompareTo(data) == 0) {
                    Console.WriteLine("Found data after: " + steps + " steps");
                    return true;
                }
                else if(node.data.CompareTo(data) > 0 ) {
                    node = node.left;
                }
                else if(node.data.CompareTo(data) < 0 ) {
                    node = node.right;
                }
                steps++;
            }
            Console.WriteLine("Data could not be found. Steps taken: " + steps);
            return false;
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
