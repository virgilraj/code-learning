using Interview;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int[] arr = { 1,2,3,3,4,5,5,8,10,10};
            //var a = BubbleSort.GetSorted(arr);
            // QuickSort.GetSorted(arr);
            MyHeap.BuildHead();
            //foreach (var x in a)
            //{
            //    Console.WriteLine(x);
            //}

            var a = removeDuplicates(arr, arr.Length);
            // Print updated array 
            for (int i = 0; i < a; i++)
                Console.Write(arr[i] + " ");

            var b = BianrySearch(arr, 225, 0, arr.Length-1);
            Console.WriteLine(b);

            BinaryTree bt = new BinaryTree();
            BinaryTree bt1 = new BinaryTree();
            var root = bt.Insert(null, 10);
            var root1 = bt1.Insert(null, 10);
            /*root = bt.Insert(root, 20);
            root = bt.Insert(root, 8);
            root = bt.Insert(root, 9);
            root = bt.Insert(root, 15);
            root = bt.Insert(root, 25);
            */
            bt.Insert(root, 20);
            bt.Insert(root, 8);
            bt.Insert(root, 9);
            bt.Insert(root, 15);
            bt.Insert(root, 25);
            bt.Insert(root, 12);
            bt.Insert(root, 5);

            bt1.Insert(root1, 20);
            bt1.Insert(root1, 8);
            bt1.Insert(root1, 9);
            bt1.Insert(root1, 15);
            bt1.Insert(root1, 25);
            //bt1.Insert(root1, 12);
            bt1.Insert(root1, 7);

            TwoNodes tn = new TwoNodes { First = bt.RootNode, Second = bt1.RootNode };

            Console.WriteLine("Is_BST_Identical_Iterative  ::{0} ", bt.Is_BST_Identical_Iterative(tn));
            Console.WriteLine("Is_BST_Identical  ::{0} ", bt.isIdentical(bt.RootNode, bt1.RootNode));
            bt1.Height_Tree_Iterative(bt1.RootNode);

            Console.WriteLine("PreOrder");
            bt.PreOrder(bt.RootNode);
            Console.WriteLine("");
            Console.WriteLine("InOrder");
            bt.InOrder(bt.RootNode);
            Console.WriteLine("");
            Console.WriteLine("PostOrder");
            bt.PostOrder(bt.RootNode);

            bt.CreateBinaryTreeFromInAndPreOrder();

            Console.WriteLine("");
            Console.WriteLine("Find");
            var f = bt.Find(115, bt.RootNode);
            Console.WriteLine(f != null ? f.data : 0);

            Console.WriteLine("");
            Console.WriteLine("MinValue");

            var m = bt.GetMinValue(bt.RootNode);
            Console.WriteLine(m);
            int pos = 6;
            bt.GetKthMinValue(bt.RootNode, ref pos);
            //bt.LevelOrder(bt.RootNode);
            //bt.Inorder_Iterative(bt.RootNode);
            //bt.Preorder_Iterative(bt.RootNode);
            //bt.Postorder_Iterative(bt.RootNode);
            //bt.Get_Inorder_Predecessor(bt.RootNode);
            //bt.Get_Inorder_Successor(bt.RootNode);

            Console.WriteLine("\nInvert binary");
            bt.InvertBinary(bt.RootNode);
            bt.LevelOrder(bt.RootNode);

            Node ln = new Node { data = 20 };
            Node rn = new Node { data = 30 };
            Node no = new Node { data = 10, Left = ln, Right = rn };

            // Console.WriteLine("isBST :: {0}", bt.isBST(no, int.MinValue) );
            Console.WriteLine("isBST :: {0}", bt.isBinarySearch(no));

            AVLTree at = new AVLTree();
            at.Avl_execute();

            int[] arr1 = { 5,6, 8, 9, 10, 12, 15, 20 };

            GetTriplets(arr1, 30);
            GetSumDobles(arr1, 15);
            GetSumDobles_Linear(arr1, 15);

            Console.WriteLine("KnapSack");
            int[] val = new int[] { 60, 120, 100 };
            int[] wt = new int[] { 10, 30, 20 };
            int Cap = 50;
            int n = val.Length;
            int[,] dp = new int[n+1, Cap+1];
            KnapSack k = new KnapSack();
            Console.WriteLine(k.KnapSack_Binary(Cap, wt, val, n, dp));
            k.KnapSack_Fraction(Cap, wt, val, n);

            Console.WriteLine("Pattern");
            Pattern.SearchPattern("AABAACAADAABAAABAACAAD", "CAAD");
            Pattern.Binary_MultipleOf3("110100000101");

            Console.WriteLine("Largest Sum Contiguous Subarray");
            int[] aa = { 1, 2, 3, - 2, 5 };
            Pattern.maxSubArraySum(aa);
            Console.WriteLine("Missing elements");

            int[] aa1 = { 1, 2, 3, 5 ,7,8,10};
            Pattern.FindMissingElements(aa1);

            int[] aa2 = { 1, 2, 3, 1, 1 };
            Pattern.FindMajorityElement(aa2);

            //Search in a Rotated Array 
            int[] aa3 = { 5,6,7,8,9,10,1, 2, 3,4 };
            Pattern.SearchRotatedArray(aa3, 10);

            //Linked List
            LinkedList lst = new LinkedList();
            lst.InsertFront(10);
            lst.InsertLast(20);
            lst.InsertFront(5);
            lst.InsertLast(25);
            lst.InsertLast(35);
            lst.PrintList(lst);

            lst.FindMiddleElement(lst);

            Problem_30 p30 = new Problem_30();
            p30.FindSingeNumber();
            p30.HappyNumber();
            p30.Longest_Sum_Subarray();
            p30.FindSubarraySum();
            p30.MoveZeroRight();
            p30.MaxProfit();
            p30.IsAnagram();
            p30.StringSorting("kgadeA");
            p30.GroupingAnagrams();
            p30.CountingElement();
            p30.BackspaceStingCompare();
            //p30.LastStoneWeight();
            p30.SubArrayWithEqualZeroAndOne();
            p30.StringShif();
            p30.ProductOfArrayExceptSlef();
            Console.WriteLine("\nValid parenthesis:: {0}", p30.ValidParenthesis());
            p30.NumberOfIsland();
            p30.LeftmostColumnWithAtleastOne();
            p30.BitwiseAnd();
            p30.JumpingProblem();
            p30.LongestcommonSubsequence();
            p30.CountPairsGivenSum();
            p30.MaximumPathSum(bt.RootNode);
            p30.ValidSequence(bt.RootNode);
            p30.MinFromSatck();
            p30.MinimumPathSum();
            p30.HistogramMaxRectangle();
            //p30.Print_Combination_R_Elements_Array();

            ///All Array Problem
            ///
            ArrayProblem ar = new ArrayProblem();
            ar.Find_And_Print_SubArraySum();
            ar.SortBinaryArray();
            ar.FindDuplicate();
            ar.LongestConsecutiveSubArray();
            ar.MaximumSumSubArray();
            ar.MinimuSumSubArray();
            ar.SubArrayWithEqualZeroAndOne();
            ar.SortArrayOnlyZeroOneTwos();
            ar.Merge2SortedArray();
            ar.MergeArray_ReplaceZeroValue();
            ar.Find_Index_MaxLength_ContinuousOnes();
            ar.ProductOfTwoIntArray();
            ar.Suffle();
            ar.RearrangeArrayHighAndLow();
            ar.EquilibriumIndex();
            ar.FindMajorityElement();
            ar.MoveAllZeroToEnd();
            ar.ProductOfArrayWithotSlef();
            ar.BitonicSubArray();
            ar.FindMaximumDifference();
            ar.MaximumSumCircularSubArray();
            ar.FindSumMimumSubArray_Given_Size();
            ar.FindSumSubArray_Given_Sum();
            ar.LengthOfSmallestSubarray_SumOfElements_GreaterThanNumber();
            ar.Find_Smallest_Window_Will_Make_Entire_Array_Sorted();
            ar.TrappingRainWaterwithin_given_set_bars();
            ar.Find_Maximum_Sum_Subsequence_With_NO_Adjacent();
            ar.MinimumNumber_Platform();
            ar.LengthOf_Continuous_Same_Sum_Two_Binary_Array();
            ar.Find_Number_Rotations();
            ar.RodCutting();
            ar.Find_kth_Smallest_Element();
            ar.FindAllCombinations();

            //Trie data structure
            Trie tr = new Trie();
            string[] words = { "abc", "abgl", "cdf", "abcd", "lmn" };
            //string[] words = { "abc"};
            foreach (string st in words)
            {
                tr.Insert(st);
            }

            Console.WriteLine("\nIs string present {0} ", tr.Search("cdf"));
            tr.AutoComplete("ab");

            // List of graph edges as per above diagram
            List<Edge> edges = new List<Edge>{
                // Notice that node 0 is unconnected node
                new Edge(1, 2), new Edge(1, 7), new Edge(1, 8),
                    new Edge(2, 3), new Edge(2, 6), new Edge(3, 4),
                    new Edge(3, 5), new Edge(8, 9), new Edge(8, 12),
                    new Edge(9, 10), new Edge(9, 11)
            };

            // Set number of vertices in the graph (0-12)
            int N = 13;

            // create a graph from edges
            Graph graph = new Graph(edges, N);

            // stores vertex is discovered or not
            bool[] discovered = new bool[N];

            // Do DFS traversal from all undiscovered nodes to
            // cover all unconnected components of graph
            for (int i = 0; i < N; i++)
            {
                if (!discovered[i])
                {
                    graph.DFS(graph, i, discovered);
                }
            }

            //Matrix
            Matrix mt = new Matrix();
            mt.Print_SpiralOrder();
            mt.Rotation_90();
            mt.FloodFill();
        }
        static int removeDuplicates(int[] arr, int n)
        {

            if (n == 0 || n == 1)
                return n;

            // To store index of next 
            // unique element 
            int j = 0;

            // Doing same as done in Method 1 
            // Just maintaining another updated 
            // index i.e. j 
            for (int i = 0; i < n - 1; i++)
                if (arr[i] != arr[i + 1])
                {
                    arr[j] = arr[i];
                    j++;
                }

            arr[j++] = arr[n - 1];

            return j;
        }

        static bool BianrySearch(int[] arr, int key, int low, int high)
        {
            if (low <= high && high < arr.Length)
            {
                int mean = (low + high) / 2;
                if (arr[mean] == key)
                {
                    return true;
                }
                if (arr[mean] > key)
                {
                    high = mean - 1;
                }
                if (arr[mean] < key)
                {
                    low = mean + 1;

                }
                return BianrySearch(arr, key, low, high);
            }
            else
            {
                return false;
            }
        }

        static int BianrySearch_Position(int[] arr, int key, int low, int high)
        {
            if (low <= high && high < arr.Length)
            {
                int mean = (low + high) / 2;
                if (arr[mean] == key)
                {
                    return mean;
                }
                if (arr[mean] > key)
                {
                    high = mean - 1;
                }
                if (arr[mean] < key)
                {
                    low = mean + 1;

                }
                return BianrySearch_Position(arr, key, low, high);
            }
            else
            {
                return -1;
            }
        }
        static void GetSumDobles(int[] arr, int sum)
        {
            int n = arr.Length;
            for (int i = 0; i < arr.Length; i++)
            {
                int k = sum - arr[i];
                int low = i + 1;
                int high = n - 1;
                int a = BianrySearch_Position(arr, k, low, high);
                if(a > 0)
                    Console.WriteLine("Double :First :: {0}, Second:: {1}", arr[i], arr[a]);
                
            }
        }

        static void GetSumDobles_Linear(int[] arr, int sum)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (sum == (arr[i] + arr[j]))
                    {
                        Console.WriteLine("Double Linear:First :: {0}, Second:: {1}", arr[i], arr[j]);
                    }
                }
            }
        }
        static void GetTriplets(int[] arr, int sum)
        {
            bool isTrip = false;
            int n = arr.Length;
            for(int i = 0; i < arr.Length; i++)
            {
                int k = sum - arr[i];
                int low = i + 1;
                int high = n - 1;

                while(low < high)
                {
                    if(arr[low] + arr[high] < k)
                    {
                        low++;
                    }
                    else if (arr[low] + arr[high] > k)
                    {
                        high--;
                    }
                    else
                    {
                        Console.WriteLine("First :: {0}, Second:: {1}, Third:: {2}", arr[i], arr[low], arr[high]);
                        isTrip = true;
                        low++;
                    }
                }
            }
            if (!isTrip)
            {
                Console.WriteLine("No Triplets Found");
            }
        }
    }


}
