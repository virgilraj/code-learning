using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    class Tree
    {
    }

    public class Node
    {
        public int data { get; set; }
        public Node Right { get; set; }
        public Node Left { get; set; }

        public Node Next { get; set; }

    }
    class BinaryTree
    {
        public Node RootNode { get; set; }

        public Node Insert(Node root, int value)
        {
            Node newnode = new Node();
            newnode.data = value;
            if (this.RootNode == null)
            {
                this.RootNode = newnode;
            }
            if (root == null)
            {
                root = newnode;
            }
            else if(value < root.data)
            {
                root.Left = Insert(root.Left, value);
            }
            else
            {
                root.Right = Insert(root.Right, value);
            }
            return root;
        }
        public bool Add(int value)
        {
            Node current = this.RootNode;
            Node position = null;
            while(current != null)
            {
                position = current;
                if(value < current.data)
                {
                    current = current.Left;
                }
                else if (value > current.data)
                {
                    current = current.Right;
                }
                else
                {
                    return false;
                }
            }

            Node newnode = new Node();
            newnode.data = value;

            if(this.RootNode == null)
            {
                this.RootNode = newnode;
            }
            else
            {
                if(value < position.data)
                {
                    position.Left = newnode;
                }
                if (value > position.data)
                {
                    position.Right = newnode;
                }
            }
            return true;
        }

        public void PreOrder(Node parent)
        {
            if(parent != null)
            {
                Console.Write(parent.data + " ");
                PreOrder(parent.Left);
                PreOrder(parent.Right);
            }
        }

        public void InOrder(Node parent)
        {
            if (parent != null)
            {
                InOrder(parent.Left);
                Console.Write(parent.data + " ");
                InOrder(parent.Right);
            }
        }

        public int[] SortedArray(Node parent)
        {
            int[] aa = new int[7];
            int i = 0;
            if (parent != null)
            {
                InOrder(parent.Left);
                Console.Write(parent.data + " ");
                aa[i] = parent.data;
                InOrder(parent.Right);
                i++;
            }
            return aa;
        }

        public void PostOrder(Node parent)
        {
            if (parent != null)
            {
                PostOrder(parent.Right);
                Console.Write(parent.data + " ");
                PostOrder(parent.Left);
            }
        }
        
        public int GetMinValue(Node node)
        {
            int minval = node.data;
            while(node.Left != null)
            {
                node = node.Left;
                minval = node.data;
            }
            return minval;
        }

        public Node Find(int key , Node parent)
        {
            if (parent != null)
            {
                if (parent.data == key)
                {
                    return parent;
                }
                if (key < parent.data)
                {
                    return Find(key, parent.Left);
                }
                if (key > parent.data)
                {
                    return Find(key, parent.Right);
                }
            }
            return null;
        }

        public bool isBinarySearch(Node parent)
        {
            return isBSTUtil(parent, int.MinValue, int.MaxValue);
        }

        bool isBSTUtil(Node parent, int MIN, int MAX)
        {
            if(parent == null) { return true; }
            if (parent.data > MIN && parent.data < MAX
                && isBSTUtil(parent.Left, MIN, parent.data)
                && isBSTUtil(parent.Right, parent.data, MAX)){
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
