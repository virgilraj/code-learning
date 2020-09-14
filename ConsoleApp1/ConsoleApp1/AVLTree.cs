using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    /*AVL tree is self balancing binary tree.Difference of height of left or right subtree
 * cannot be greater than one.
 * 
 * There are four different use cases to insert into AVL tree
 * left left - needs ones right rotation
 * left right - needs one left and one right rotation
 * right left - needs one right and one left rotation
 * right right - needs one left rotation
 * 
 * Follow rotation rules to keep tree balanced.
 *
 * At every node we will also keep height of the tree so that we don't
 * have to recalculate values again.
 *
 * Runtime complexity to insert into AVL tree is O(logn).
 */
    public class AVLNode
    {
        public int data { get; set; }
        public AVLNode left { get; set; }
        public AVLNode right { get; set; }
        public int height { get; set; }
        public int size { get; set; }

        public static AVLNode newNode(int data)
        {
            return new AVLNode() { data = data };
        }
    }
    public class AVLTree
    {

        public AVLNode insert(AVLNode root, int data)
        {
            if(root == null)
            {
                return AVLNode.newNode(data);
            }

            if(root.data >= data)
            {
                root.left = insert(root.left, data);
            }
            else
            {
                root.right = insert(root.right, data);
            }

            int bal = balance(root.left, root.right);

            if(bal > 1)
            {
                if(height(root.left.left) >= height(root.left.right))
                {
                    root = rightRotate(root);
                }
                else
                {
                    root.left = leftRotate(root.left);
                    root = rightRotate(root);
                }
            }else if(bal < -1)
            {
                if(height(root.right.right) >= height(root.right.left))
                {
                    root = leftRotate(root);
                }
                else
                {
                    root.right = rightRotate(root.right);
                    root = leftRotate(root);
                }
            }
            else
            {
                setHeight(root);
                setSize(root);
            }

            return root;
        }

        private AVLNode leftRotate(AVLNode root)
        {
            AVLNode newRoot = root.right;
            newRoot.left = root;
            root.right = root.right.left; // setting null

            root.height = setHeight(root);
            root.size = setHeight(root);

            newRoot.height = setHeight(newRoot);
            newRoot.size = setSize(newRoot);

            return newRoot;
        }

        private AVLNode rightRotate(AVLNode root)
        {
            AVLNode newRoot = root.left;
            newRoot.right = root;
            root.left = root.left.right; // setting null

            root.height = setHeight(root);
            root.size = setHeight(root);

            newRoot.height = setHeight(newRoot);
            newRoot.size = setSize(newRoot);

            return newRoot;
        }
        private int height(AVLNode root)
        {
            if (root == null) return 0;
            else return root.height;
        }
        private int setHeight(AVLNode root)
        {
            if (root == null) return 0;
            else return 1 + Math.Max(root.left == null ? 0 : root.left.height, root.right == null ? 0 : root.right.height) ;
        }

        private int setSize(AVLNode root)
        {
            if (root == null) return 0;
            else return 1 + Math.Max(root.left == null ? 0 : root.left.size, root.right == null ? 0 : root.right.size);
        }

        public void AVL_Inorder(AVLNode root)
        {
            if(root != null)
            {
                AVL_Inorder(root.left);
                Console.Write("{0} - > ", root.data);
                AVL_Inorder(root.right);
            }
        }

        public void AVL_Preorder(AVLNode root)
        {
            if (root != null)
            {
                Console.Write("{0} - > ", root.data);
                AVL_Preorder(root.left);
                AVL_Preorder(root.right);
            }
        }

        private int balance(AVLNode rootLeft, AVLNode rootRight)
        {
            return height(rootLeft) - height(rootRight);
        }

        public void Avl_execute()
        {
            AVLTree avlTree = new AVLTree();
            AVLNode root = null;
            root = avlTree.insert(root, -10);
            root = avlTree.insert(root, 2);
            root = avlTree.insert(root, 13);
            root = avlTree.insert(root, -13);
            root = avlTree.insert(root, -15);
            root = avlTree.insert(root, 15);
            root = avlTree.insert(root, 17);
            root = avlTree.insert(root, 20);

            Console.WriteLine("AVL - > In order");
            AVL_Inorder(root);
            Console.WriteLine("AVL - > Pre order");
            AVL_Preorder(root);
        }
    }
}
