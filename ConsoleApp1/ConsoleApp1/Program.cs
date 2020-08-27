using Interview;
using System;
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
            var root = bt.Insert(null, 10);
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

            Console.WriteLine("PreOrder");
            bt.PreOrder(bt.RootNode);
            Console.WriteLine("");
            Console.WriteLine("InOrder");
            bt.InOrder(bt.RootNode);
            Console.WriteLine("");
            Console.WriteLine("PostOrder");
            bt.PostOrder(bt.RootNode);

            Console.WriteLine("");
            Console.WriteLine("Find");
            var f = bt.Find(115, bt.RootNode);
            Console.WriteLine(f != null ? f.data : 0);

            Console.WriteLine("");
            Console.WriteLine("MinValue");

            var m = bt.GetMinValue(bt.RootNode);
            Console.WriteLine(m);

            Node ln = new Node { data = 20 };
            Node rn = new Node { data = 30 };
            Node no = new Node { data = 10, Left = ln, Right = rn };

            // Console.WriteLine("isBST :: {0}", bt.isBST(no, int.MinValue) );
            Console.WriteLine("isBST :: {0}", bt.isBinarySearch(no));
            int[] arr1 = { 5,6, 8, 9, 10, 12, 15, 20 };

            GetTriplets(arr1, 30);
            GetSumDobles(arr1, 15);
            GetSumDobles_Linear(arr1, 15);

            Console.WriteLine("KnapSack");
            int[] val = new int[] { 60, 120, 100 };
            int[] wt = new int[] { 10, 30, 20 };
            int Cap = 50;
            int n = val.Length;
            KnapSack k = new KnapSack();
            Console.WriteLine(k.KnapSack_Binary(Cap, wt, val, n));
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
