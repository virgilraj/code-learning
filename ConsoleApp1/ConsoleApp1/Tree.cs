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
                PostOrder(parent.Left);
                PostOrder(parent.Right);
                Console.Write(parent.data + " ");
                
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

        public int GetMaxValue(Node node)
        {
            int maxval = node.data;
            while (node.Right != null)
            {
                node = node.Right;
                maxval = node.data;
            }
            return maxval;
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

        public void GetKthMinValue(Node parent, ref int k)
        {
            if (parent != null)
            {
                GetKthMinValue(parent.Left, ref k);
                k = k - 1;
                if (k == 0)
                {
                    Console.WriteLine("Kth Min Value {0}",  parent.data );
                    return;
                }
                else
                {
                    
                    //Console.Write(parent.data + " ");
                    GetKthMinValue(parent.Right, ref k);
                }
               
            }
        }

        public void LevelOrder(Node parent)
        {
            if(parent != null)
            {
                Console.WriteLine("Print Level Order");
                Queue<Node> Q = new Queue<Node>();
                Q.Enqueue(parent);
                while(Q.Count > 0)
                {
                    var node = Q.Dequeue();
                    Console.Write("{0}   ", node.data);
                    if(node.Left != null)
                    {
                        Q.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        Q.Enqueue(node.Right);
                    }
                }
            }
            
        }

        public void Inorder_Iterative(Node node)
        {
            Console.WriteLine("Print Inorder Iterative\n");
            Stack<Node> S = new Stack<Node>();
            Node cur_node = node;
            
            while (true)
            {
                if(cur_node != null)
                {
                    S.Push(cur_node);
                    cur_node = cur_node.Left;
                }
                else if(S.Count > 0)
                {
                    cur_node = S.Pop();
                    Console.Write("{0}   -> ", cur_node.data);
                    cur_node = cur_node.Right;
                }
                else
                {
                    break;
                }
            }
        }

        public void Preorder_Iterative(Node root)
        {
            Node cur_node = root;
            Stack<Node> S = new Stack<Node>();
            S.Push(cur_node);
            Console.WriteLine("Print Preorder Iterative\n");
            while (S.Count > 0)
            {
                cur_node = S.Pop();
                Console.Write("{0}   -> ", cur_node.data);
                if (cur_node.Right   != null)
                {
                    S.Push(cur_node.Right);
                }
                if (cur_node.Left != null)
                {
                    S.Push(cur_node.Left);
                }
            }
        }

        public void Postorder_Iterative(Node root)
        {
            Node cur_node = root;
            Stack<Node> S1 = new Stack<Node>();
            Stack<Node> S2 = new Stack<Node>();
            S1.Push(cur_node);
            Console.WriteLine("Print Postorder Iterative\n");
            while (S1.Count > 0)
            {
                cur_node = S1.Pop();
                S2.Push(cur_node);
                if (cur_node.Right != null)
                {
                    S1.Push(cur_node.Right);
                }
                if (cur_node.Left != null)
                {
                    S1.Push(cur_node.Left);
                }
            }

            while(S2.Count > 0)
            {
                Console.Write("{0}   -> ", S2.Pop().data);
            }
        }

        public void Get_Inorder_Predecessor(Node root)
        {
            int val = 20;
            Node node = this.Find(20, root);
            if(node.Left != null)
            {
                Console.WriteLine("\nInorder_Predecessor {0}", this.GetMaxValue(node.Left));
            }
            else
            {
                Node predecessor = null;
                Node ancestor = root;
                while (ancestor != node)
                {
                    if(node.data > ancestor.data)
                    {
                        predecessor = ancestor;
                        ancestor = ancestor.Right;
                    }
                    else
                    {
                        ancestor = ancestor.Left;
                    }
                }

                if(predecessor != null)
                {
                    Console.WriteLine("\nInorder_Predecessor {0}", predecessor.data);
                }
            }

        }

        public void Get_Inorder_Successor(Node root)
        {
            int val = 20;
            Node node = this.Find(20, root);
            if (node.Right != null)
            {
                Console.WriteLine("\nInorder_Predecessor {0}", this.GetMinValue(node.Right));
            }
            else
            {
                Node successor = null;
                Node ancestor = root;
                while (ancestor != node)
                {
                    if (node.data < ancestor.data)
                    {
                        successor = ancestor;
                        ancestor = ancestor.Left;
                    }
                    else
                    {
                        ancestor = ancestor.Right;
                    }
                }

                if (successor != null)
                {
                    Console.WriteLine("\nInorder_Predecessor {0}", successor.data);
                }
            }

        }

        //Invert Binary tree
        //Mirror image of binary tree
        //Post order traversal 1. Left 2. Right
        //3. Sawp the left to right

        public void InvertBinary(Node parent)
        {
            if (parent != null)
            {
                InvertBinary(parent.Left);
                InvertBinary(parent.Right);
                Node t = parent.Left;
                parent.Left = parent.Right;
                parent.Right = t;
            }
        }

        public bool Is_BST_Identical_Iterative(TwoNodes twoNodes)
        {
            // if both trees are empty, return true
            if (twoNodes.First == null && twoNodes.Second == null)
                return true;

            // if first tree is empty (& second tree is non-empty), return false
            if (twoNodes.First == null)
                return false;
            if (twoNodes.Second == null)
                return false;

            // create a stack to hold Node* pairs
            Stack<TwoNodes> S = new Stack<TwoNodes>();
            S.Push(twoNodes);

            while(S.Count >0)
            {
                // pop top pair from the stack and process it
                Node x = S.Peek().First;
                Node y = S.Peek().Second;
                S.Pop();

                // if value of their root node don't match, return false
                if (x.data != y.data)
                    return false;

                // if left subtree of both x and y exists, push their addresses
                // to stack else return false if only one left child exists
                if (x.Left !=null && y.Left !=null)
                    S.Push(new TwoNodes { First = x.Left, Second = y.Left });
                else if ((x.Left == null && y.Left != null) || (x.Left != null && y.Left == null))
                    return false;

                // if right subtree of both x and y exists, push their addresses
                // to stack else return false if only one right child exists

                if (x.Right != null && y.Right != null)
                    S.Push(new TwoNodes { First = x.Right, Second = y.Right });
                else if ((x.Right == null && y.Right != null) || (x.Right != null && y.Right == null))
                    return false;

            }

            return true;
        }

        // Recursive function to check if two given binary trees are identical or not
        public bool isIdentical(Node x, Node y)
        {
            // if both trees are empty, return true
            if (x == null && y == null)
                return true;

            // if both trees are non-empty and value of their root node matches,
            // recur for their left and right sub-tree
            return (x !=null && y !=null) && (x.data == y.data) && isIdentical(x.Left, y.Left) && isIdentical(x.Right, y.Right);
        }

        // Recursive function to calculate height of given binary tree
        /*int height(Node* root)
        {
            // Base case: empty tree has height 0
            if (root == nullptr)
                return 0;

            // recur for left and right subtree and consider maximum depth
            return 1 + max(height(root->left), height(root->right));
        }*/

        // Iterative function to calculate height of given binary tree
        // by doing level order traversal of the tree
        public void Height_Tree_Iterative(Node root)
        {
            if(root == null)
            {
                Console.WriteLine("Empty tree height:: 0");
            }
            Queue<Node> Q = new Queue<Node>();
            Q.Enqueue(root);
            int height = 0;

            while(Q.Count > 0)
            {
                // calculate number of nodes in current level
                int size = Q.Count;
                // process each node of current level and enqueue their
                // non-empty left and right child to queue

                while(size > 0)
                {
                    var front = Q.Peek();
                    Q.Dequeue();

                    if(front.Left != null)
                    {
                        Q.Enqueue(front.Left);
                    }
                    if (front.Right != null)
                    {
                        Q.Enqueue(front.Right);
                    }
                    size--;
                }

                // increment height by 1 for each level
                height++;
            }

            Console.WriteLine("Height of the Tree is {0}", height);
        }
    }

    public class TwoNodes
    {
        public Node First { get; set; }
        public Node Second { get; set; }
    }
}
