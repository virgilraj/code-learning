using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Interview
{
    public class Problem_30
    {
        //Find Single number from array
        // XOR of two differrnt numbers = 1
        // XOR same number is = 0
        // XOR 0 = number
        public void FindSingeNumber()
        {
            int result = 0;
            int[] arr = { 1, 2, 3, 1, 2, 3, 6, 2, 2 };
            for (int i = 0; i < arr.Length; i++)
            {
                result ^= arr[i];
            }

            Console.WriteLine("Single number from array {0}", result);
        }

        //Happy number
        //A number is called happy if it leads to 1 after a sequence of 
        //steps wherein each step number is replaced by the sum of squares of its digit that is
        //if we start with Happy Number and keep replacing it with digits square sum, we reach 1.
        //Input: n = 19
        //Output: True
        //19 is Happy Number,
        //1^2 + 9^2 = 82
        //8^2 + 2^2 = 68
        //6^2 + 8^2 = 100
        //1^2 + 0^2 + 0^2 = 1
        //As we reached to 1, 19 is a Happy Number.

        public void HappyNumber()
        {
            int number = 29;
            int val;
            int index;
            HashSet<int> h = new HashSet<int>();
            h.Add(number);
            while (true)
            {
                val = 0;
                while (number > 0)
                {
                    index = number % 10;
                    val += index * index;
                    number = number / 10;
                }
                if (val == 1)
                {
                    Console.WriteLine("Happy number");
                    return;
                }
                else if (h.Contains(val))
                {
                    Console.WriteLine("NOT Happy number");
                    return;
                }

                h.Add(val);
                number = val;
            }
        }

        //Kadanes algorithm | Longest sum contiguous (it should be adjusent) subarray
        //Brute-force - find all possible sub aaray O(n2) . then find the maximun O(n2)
        //Kadanes -- Single traversal -> max_end_here
        //2.same time find the max_so_far
        //Means - 
        public void Longest_Sum_Subarray()
        {
            int[] arr = { -2, -3, 4, -1, -2, 1, 5, -3 };
            //int[] arr = { 1, 2, 3, -2, 5 };
            int max_end_here = 0;
            int max_so_far = int.MinValue;

            for (int i = 0; i < arr.Length; i++)
            {
                max_end_here = max_end_here + arr[i];
                if (max_end_here < arr[i])
                {
                    max_end_here = arr[i];
                }
                if (max_so_far < max_end_here)
                {
                    max_so_far = max_end_here;
                }
            }

            Console.WriteLine("Longest sum contiguous subarray {0}", max_so_far);
        }

        //Number of subarrays having sum exactly equal to k
        public void FindSubarraySum()
        {
            // int[] arr = { 10, 2, -2, -20, 10 };
            //int[] arr = { 3, 4, 7, 2, -3, 1, 4, 2 };
            int[] arr = { 3, 4, -7, 3, 1, 3, 1, -4, -2, -2 };
            int sum = 0;
            int n = arr.Length;

            // HashMap to store number of subarrays 
            // starting from index zero having 
            // particular value of sum. 
            Dictionary<int, int> prevSum = new Dictionary<int, int>();
            int count = 0;
            //Sum so far
            int curSum = 0;
            for (int i = 0; i < n; i++)
            {
                curSum += arr[i];
                if (curSum == sum)
                {
                    count++;
                }
                if (prevSum.ContainsKey(curSum - sum))
                {
                    count += prevSum[curSum - sum];
                }

                if (!prevSum.ContainsKey(curSum))
                {
                    prevSum.Add(curSum, 1);
                }
                else
                {
                    int cnt = prevSum[curSum];
                    prevSum[curSum] = cnt + 1;
                }
            }

            Console.WriteLine("Number of subarrays having sum exactly equal to {0} is {1}", sum, count);

        }

        //Move zeroes to right -- Don't change the order of non zero value
        public void MoveZeroRight()
        {
            //Right and left pointer
            //Right pointer move first
            //if non zero element found the swap with left
            //Increment left and right
            //if zero found - increment right
            int[] arr = { 0, 1, 0, 3, 30, 0, 6, 12, 0 };
            int right = 0, left = 0;
            int n = arr.Length;
            while (right < n)
            {
                if (arr[right] == 0)
                {
                    right++;
                }
                else
                {
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                    right++;
                    left++;
                }
            }

            Console.WriteLine("Move Zero Right array");
            foreach (var a in arr)
            {
                Console.Write("{0}   ", a);
            }
        }

        //Best time to Buy and Sell
        //Condition - Buy it before sell
        //Cannot buy and sell on the same day
        //1st day - we can do buy only ... Last day we can sell only
        //Formula --> if(a[i] > a[i-1]) then buy - > profit = profit + (arr[i] - arr[i - 1])
        public void MaxProfit()
        {
            //int[] arr = { 0, 1, 0, 3, 30, 0, 6, 12, 0 };
            int[] arr = { 7, 1, 5, 3, 6, 4 };
            int prof = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[i - 1])
                {
                    prof += (arr[i] - arr[i - 1]);
                }
            }

            Console.WriteLine("\nMax Profit is {0}", prof);
        }

        public string StringSorting(string st)
        {
            //string st = "kgadeA";
            char[] alph = { 'a', 'A', 'b', 'B', 'c', 'C', 'd', 'D', 'e', 'E', 'f', 'F', 'g', 'G', 'h',
                'H', 'i', 'I', 'j', 'J', 'k', 'K','l','L','m','M','n','N','o','O','p','P','q','Q','r','R',
                's','S','t','T','u','U','v','V','w','W','x','X','y','Y','z','Z'};
            Dictionary<int, int> h = new Dictionary<int, int>();
            foreach (var a in alph)
            {
                h.Add((int)a, 0);
            }
            for (int i = 0; i < st.Length; i++)
            {
                int stInt = (int)st[i];
                if (!h.ContainsKey(stInt))
                {
                    h.Add(stInt, 1);
                }
                else
                {
                    int cnt = h[stInt];
                    h[stInt] = cnt + 1;
                }
            }
            string nstr = "";
            foreach (var k in h)
            {
                for (int i = 0; i < k.Value; i++)
                {
                    nstr += (char)k.Key;
                }
            }

            Console.WriteLine("Sorted String   {0}", nstr);
            return nstr;
        }

        //Is Anagrams
        public void IsAnagram()
        {
            string st1 = "abac";
            string st2 = "abcb";
            //Sort both string and compare .. if equals then its anagrams 
            //but the time complexity of sorting is n(logn)
            //Other approach - useing hashmap

            Dictionary<char, int> h = new Dictionary<char, int>();
            for (int i = 0; i < st1.Length; i++)
            {
                if (!h.ContainsKey(st1[i]))
                {
                    h.Add(st1[i], 1);
                }
                else
                {
                    int cnt = h[st1[i]];
                    h[st1[i]] = cnt + 1;
                }
            }
            Console.WriteLine("asdasdas {0}", (char)65);
            //Checking 2 string with Hash
            for (int i = 0; i < st2.Length; i++)
            {
                if (h.ContainsKey(st2[i]))
                {
                    int cnt = h[st2[i]];
                    if (cnt - 1 < 0)
                    {
                        Console.WriteLine("NOT Anagrams");
                        return;
                    }
                    h[st2[i]] = cnt - 1;
                }

            }
            int c = 0;
            foreach (var k in h)
            {
                if (k.Value != 0)
                {
                    Console.WriteLine("NOT Anagrams");
                    return;
                }
                else
                {
                    c++;
                }
            }
            if (c == h.Count)
            {
                Console.WriteLine("Anagrams");
            }
        }

        //Grouping Anagrams
        public void GroupingAnagrams()
        {
            string[] arr = { "eat", "tea", "tan", "ate", "nat", "bat" };
            Dictionary<string, ArrayList> h = new Dictionary<string, ArrayList>();

            foreach (var a in arr)
            {
                string sortedStr = this.StringSorting(a);
                if (!h.ContainsKey(sortedStr))
                {
                    ArrayList aa = new ArrayList();
                    aa.Add(a);
                    h.Add(sortedStr, aa);
                }
                else
                {
                    var aa = h[sortedStr];
                    aa.Add(a);
                }
            }
        }

        //Counting element - increamet by 1
        //1.Brute force -- need to go each 
        //2.Single window slide - right and left pointer
        //3.Hashmap
        public void CountingElement()
        {
            int[] arr = { 1, 1, 1, 1, 1, 2 };
            Array.Sort(arr);
            int right = 1;
            int left = 0;
            int n = arr.Length;
            int count = 0;
            while (right < n)
            {
                if (arr[left] + 1 == arr[right])
                {
                    count += (right - left);
                    left = right;
                    right++;
                } else if (arr[left] == arr[right])
                {
                    right++;
                }
                else
                {
                    left = right;
                    right++;
                }
            }

            Console.WriteLine("Counting element - increamet by 1 is ::{0}", count);
        }

        //Backspace string compare if #
        public void BackspaceStingCompare()
        {
            string str1 = "ab#cd#";
            string str2 = "ac#d#c";
            int n1 = str1.Length;

            if (RemoveBackSpace(str1) == RemoveBackSpace(str2))
            {
                Console.WriteLine("Strings {0} and {1} are equal", str1, str2);
            }
            else
            {
                Console.WriteLine("Strings {0} and {1} are NOT equal", str1, str2);
            }


        }

        public string RemoveBackSpace(string str1)
        {
            int n1 = str1.Length;
            for (int i = 0; i < n1; i++)
            {
                if (str1[i] == '#')
                {
                    int startIndex = i - 1;
                    int removePos = 2;
                    if (i == 0)
                    {
                        startIndex = 0;
                        removePos = 1;
                    }
                    str1 = str1.Remove(startIndex, removePos);
                    n1 = str1.Length;
                    i = i - removePos;
                }
            }
            Console.WriteLine(str1);
            return str1;
        }

        public int[] RemoveElementFromArray(int[] arr, int ele)
        {
            int[] narr = new int[arr.Length - 1];
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != ele)
                {
                    narr[j] = arr[i];
                    j++;
                }
            }
            return narr;
        }

        //In order to get
        //Need to take 2 Stack..
        //One will track the current array
        //second will track of Minimum

        public void MinFromSatck()
        {
            MinStack s = new MinStack();
            s.push(20);
            s.push(10);
            Console.WriteLine("Top and Min {0} - {1}", s.top(), s.getMin());
            s.push(30);
            s.push(7);
            s.pop();
            Console.WriteLine("Top and Min {0} - {1}", s.top(), s.getMin());

        }

        //Last stone weight
        //Need to use the Heap data structure
        //TO DO
        public void LastStoneWeight()
        {
            int[] arr = { 7, 1, 5, 3, 6, 4 };

            int n = arr.Length;
            int startIdx = (n / 2) - 1;

            for (int i = startIdx; i >= 0; i--)
            {
                MyHeap.Heapify(arr, n, i);
            }

            MyHeap.HeapSort(arr);
            //arr.
            for (int i = n - 1; i > 0; i--)
            {
                var a = this.RemoveElementFromArray(arr, 5);
                //if(arr[i] == arr[i - 1]) { 
                //    arr.
                //}
                Console.WriteLine("{0}   {1}", arr[i], arr[i - 1]);
            }

        }

        //Contiguous array 
        //find the count of all contiguous array will equal number of zeroes and 
        //If consider 0 to -1 then sum of the sub array always 0 
        //Use dictionary -> key = sum , value = index
        public void SubArrayWithEqualZeroAndOne()
        {
            int[] arr = { 1, 1, 0, 0, 1, 1, 0, 1, 1 };
            int count = 0, sum = 0;
            Dictionary<int, int> h = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                int temp = arr[i] == 0 ? -1 : arr[i];
                sum += temp;
                //If sum 0 then sub array starts from 0th index
                if (sum == 0)
                {
                    if (count < i + 1)
                    {
                        count = i + 1;
                    }
                }
                else if (!h.ContainsKey(sum))
                {
                    h.Add(sum, i);
                }
                else
                {
                    if (count < (i - h[sum]))
                    {
                        count = (i - h[sum]);
                    }
                }
            }

            Console.WriteLine("Longest sub array {0}", count);
        }

        //Perform string shifts
        //We are given an array of queries and 
        //we are required to shift a string in the same order of query and return the string. 
        //Rotation of string can be both left rotation and rotation and can be present in any sequence
        public void StringShif()
        {
            string s = "abcdefg";
            Dictionary<int, int> rotation = new Dictionary<int, int>();
            rotation.Add(3, 0);
            rotation.Add(10, 1);
            rotation.Add(50, 0);
            rotation.Add(70, 1);

            //0 - Left rotation
            //1 - Right rotation
            //Formula (left rotation means -x, right rotation menas x)
            //Formula from number rotation is ::   (-3+10-50+70)%length of string ::: 27%7 = 6 
            //if the result is + then Right - then Left
            int ER = 0;
            foreach (var rot in rotation)
            {
                if (rot.Value == 0)
                {
                    ER += (-1) * rot.Key;
                }
                else
                {
                    ER += rot.Key;
                }
            }
            ER = ER % s.Length;
            if (ER == 0)
            {
                Console.WriteLine("NO ROTATION ");
            }
            if (ER > 0)
            {
                Console.WriteLine("Shifted string with rotation {0} is :: {1} ", ER, s.Substring(ER, s.Length - ER) + s.Substring(0, ER));
            }
            else
            {
                Console.WriteLine("Shifted string with rotation {0} is :: {1} ", ER, s.Substring(0, ER) + s.Substring(ER, s.Length - ER));
            }

        }

        //Product of array except self
        public void ProductOfArrayExceptSlef()
        {
            //Approch -- with divide
            int[] arr = { 1, 2, 3, 4 };
            int product = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                {
                    product = arr[i];
                }
                else
                {
                    product *= arr[i];
                }
            }
            //Form product of array
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = product / arr[i];
            }

            //2. left and right array Approach
            //Left array will store cumulative multiply + sum from left to right
            //Right array will store cumulative multiply + sum from right to left
            int[] arr1 = { 1, 2, 3, 4 };
            int[] left = new int[arr1.Length];
            int[] right = new int[arr1.Length];
            int[] op = new int[arr1.Length];
            int n = arr1.Length;
            int prod = 1;
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    left[i] = arr1[i];
                }
                else
                {
                    left[i] = arr1[i] * left[i - 1];
                }
            }

            for (int i = n - 1; i >= 0; i--)
            {
                if (i == n - 1)
                {
                    right[i] = arr1[i];
                }
                else
                {
                    right[i] = arr1[i] * right[i + 1];
                }
            }
            //Two array approach
            /* for (int i = 0; i < n; i++)
             {
                 if(i== 0)
                 {
                     arr1[i] = right[1];
                 }else if(i == n - 1)
                 {
                     arr1[i] = left[i-1];
                 }
                 else
                 {
                     arr1[i] = left[i - 1] * right[i + 1];
                 }
             }*/

            //Optimized approach - In place
            //Traverse from last element
            for (int i = n - 1; i >= 0; i--)
            {
                if (i == n - 1)
                {
                    op[i] = left[i - 1];
                    prod = arr1[i];
                }
                else if (i == 0)
                {
                    op[i] = prod;
                }
                else
                {
                    op[i] = left[i - 1] * prod;
                    prod = prod * arr1[i];
                }
            }
            foreach (var a in op)
            {
                Console.Write("{0}    ", a);
            }
        }

        //Valid parenthesis string
        //very important stack interview coding problem which is to find if a 
        //given string is valid or invalid in terms of parenthesis. 
        //This question is slightly twisted because it has stars 
        //in it as well which can be converted to ( or ) or and empty string

        public bool ValidParenthesis()
        {
            string str = ")(*(**))";
            Stack<int> open = new Stack<int>();
            Stack<int> star = new Stack<int>();
            int n = str.Length;

            //Open bracket
            for(int i=0; i<n; i++)
            {
                if(str[i] == '(')
                {
                    open.Push(i);
                }
                else if (str[i] == '*')
                {
                    star.Push(i);
                }
                else
                {
                    if(open.Count > 0)
                    {
                        open.Pop();
                    }
                    else if (star.Count > 0)
                    {
                        star.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            //close bracket

            while(open.Count > 0)
            {
                if (star.Count == 0) return false;
                if(star.Peek() > open.Peek())
                {
                    open.Pop();
                    star.Pop();
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public void NumberOfIsland()
        {
            int[,] arr = { { 1,1,1,1},
                           { 1,1,1,1},
                           { 1,1,1,1},
                           { 1,1,1,1}
                        };
            // Get all bounds before looping.
            int rows = arr.GetUpperBound(0);
            if(rows == 0)
            {
                Console.WriteLine("NO Island found");
                return;
            }

            int cols = arr.GetUpperBound(1);
            int number_islands = 0;

            for (int i = 0; i <= rows; i++)
            {
                for (int j = 0; j <= cols; j++)
                {
                    if(arr[i,j] == 1)
                    {
                        Mark_CurrentIland(arr, i, j, rows, cols);
                        number_islands++;
                    }
                }
            }

            Console.WriteLine("Island found :: {0}", number_islands);
        }

        public void Mark_CurrentIland(int[,] arr, int i, int j, int rows, int cols)
        {
            if (i < 0 || i > rows || j < 0 || j > cols || arr[i, j] != 1) return;

            arr[i, j] = 2;

            //Process 4 direction
            Mark_CurrentIland(arr, i + 1, j, rows, cols);  //Right
            Mark_CurrentIland(arr, i - 1, j, rows, cols);  //Left
            Mark_CurrentIland(arr, i, j + 1, rows, cols);  //Down
            Mark_CurrentIland(arr, i, j - 1, rows, cols);  //UP
        }

        //Minimum path sum
        //Recursive method O(n2*m2)
        public void MinimumPathSum()
        {
            int[,] arr = { { 1,3,5},
                           { 2,1,2},
                           { 4,3,1}
                        };
            int rows = arr.GetUpperBound(0);
            int cols = arr.GetUpperBound(1);
            int res = minpathSum(arr, 0, 0, rows, cols);
            Console.WriteLine("MinimumPathSum Recursive method :: {0}", res);

            ///Optimized approach
            ///Filled with minimum cost of each cell
            ///then return the last cell
            ///
            for (int x = 0; x <= rows; x++)
            {
                for (int y = 0; y <= cols; y++)
                {
                    if(x==0 && y == 0)
                    {
                        arr[x, y] = arr[x, y];
                    }else if(x==0 && y > 0)
                    {
                        arr[x, y] = arr[x, y] + arr[x, y - 1];
                    }
                    else if (x > 0 && y == 0)
                    {
                        arr[x, y] = arr[x, y] + arr[x-1, y];
                    }
                    else
                    {
                        arr[x, y] = arr[x, y] + Math.Min(arr[x, y - 1], arr[x - 1, y]);
                    }
                }
            }

            Console.WriteLine("MinimumPathSum Optimized method :: {0}", arr[rows,cols]);
        }

        public int minpathSum(int[,] arr, int x, int y, int rows, int cols)
        {
            if (x < 0 || x > rows || y < 0 || y > cols) return 0;
            int xmin = minpathSum(arr, x, y + 1, rows, cols);
            int ymin = minpathSum(arr, x + 1, y, rows, cols);
            return arr[x, y] + Math.Min(xmin, ymin);
        }



        //Leftmost column with atleast a one | Ladder approach | Leetcode
        //Alternate approach - Binary search from each row
        //Alternate approach - Binary search from each row - from the last row and column
        //Best apprach O(R+C) - Lader -> start from bottom right to left-> if found 1 then (mark the index)
        //then move top -> move left upto out of bound condition 

        public void LeftmostColumnWithAtleastOne() {
            int[,] arr = { { 0,0,1,1},
                           { 0,1,1,1},
                           { 0,0,0,1}
                        };
            int result = -1;
            int x = arr.GetUpperBound(0);
            int y =  arr.GetUpperBound(1);
            while(x >=0 && y >= 0)
            {
                if(arr[x,y] == 1)
                {
                    result = y;
                    y--;
                }
                else
                {
                    x--;
                }
            }

            Console.WriteLine("Leftmost column with atleast a one position is {0},{1}", result, x);
        }

        //Bitwise AND of numbers range | Range AND query
        // find Bitwise AND of numbers in a given range
        public void BitwiseAnd()
        {
            int n = 16, m = 19;
            int count = 0;
            while(m != n)
            {
                m = m >> 1;
                n = n >> 1;
                count++;
            }
            m <<= count;

            Console.WriteLine("Bitwise AND of numbers range {0}  ", m);
        }

        //Jumping problem
        public void JumpingProblem()
        {
            int[] arr = { 1, 1, 2, 5, 2, 1, 0, 0, 1, 3 };

            int reach = 0;
            for(int i=0; i<arr.Length; i++)
            {
                if (reach < i)
                {
                    Console.WriteLine("NOT jump to END");
                    return;
                }
                else
                {
                    reach = Math.Max(reach, i + arr[i]);
                }

            }

            Console.WriteLine("Can jump to END");
        }

        ///Longest common Subsequence (LCS)
        ///Recursive Method
        public void LongestcommonSubsequence()
        {
            string A = "stone";
            string B = "longest";
            int i = LCS_Recursive(A, B, 0, 0);
            Console.WriteLine("Longest common Subsequence {0}", i);
            LCS_Dyanmic();
        }

        public void LCS_Dyanmic()
        {
            /// If A[i] == B[j] then
            /// LCS[i,j] = 1+ LCS[i-1,j-1];
            /// ELSE LCS[i,j] = max(LCS[i-1], LCS[i,j-1]);
            /// 
            string A = "stone";
            string B = "longest";

            int row = A.Length;
            int col = B.Length;
            int[,] LCS = new int[row+1, col+1];
            //filling LCS

            for(int i=0; i<=row; i++)
            {
                for(int j=0; j<=col; j++)
                {
                    if(i == 0 || j == 0)
                    {
                        LCS[i, j] = 0;
                    }
                    else if(A[i-1] == B[j-1])
                    {
                        LCS[i, j] = 1 + LCS[i - 1, j - 1];
                    }
                    else
                    {
                        LCS[i, j] = Math.Max(LCS[i - 1, j], LCS[i, j - 1]);
                    }
                }
            }

            string lcs = "";
            int l = row;
            int k = col;
            while (k > 0 && l > 0)
            {
                if (LCS[l, k] != LCS[l, k - 1])
                {
                    lcs = B[k - 1].ToString() + lcs;
                    l--;
                    k--;
                }
                else
                {
                    k--;
                }
            }
            
            Console.WriteLine("Longest common Subsequence :: Dyanmic {0},{1}", LCS[row,col], lcs);
        }

        public int LCS_Recursive(string A, string B, int i, int j)
        {
            if (i >= A.Length || j >= B.Length) return 0;
            if(A[i] == B[j])
            {
                return 1 + LCS_Recursive(A, B, i + 1, j + 1);
            }
            else
            {
                return Math.Max(LCS_Recursive(A, B, i + 1, j), LCS_Recursive(A, B, i, j + 1));
            }

        }

        //Count pairs with given sum
        public void CountPairsGivenSum()
        {
            //Sorted array
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int left = 0;
            int sum = 5;
            int right = arr.Length-1;

            while (left < right)
            {
                if(arr[left] + arr[right] == sum)
                {
                    Console.WriteLine("Sum  pair Sorted single array {0} + {1} ={2}", left, right, sum);
                    left++;
                    right--;
                }
                else if(arr[left] + arr[right] < sum)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            //Unsorted array with dictonary
            int[] arr1 = { 3, 4, 1, 2, 8, 6, 7 };
            Dictionary<int,int> h = new Dictionary<int,int>();
            for(int i=0; i<arr1.Length; i++)
            {
                if(h.ContainsKey(arr1[i]))
                {
                    Console.WriteLine("Sum  pair unsorted single array {0} + {1} ={2}", h[arr1[i]], i, sum);
                }else
                {
                    h.Add(sum - arr1[i], 1);
                }
            }

            //Sum pair from 2 sorted array
            int[] a1 = { 1, 2, 3, 4, 22 };
            int[] a2 = { 3, 5, 6, 7, 8, 9, 20, 16 };
            int sum1 = 10;
            int l = 0;
            int n = a1.Length;
            int r = a2.Length - 1;
            
            while (l <n && r >=0 )
            {
                if (a1[l] + a2[r] == sum1)
                {
                    Console.WriteLine("Sum  pair Sorted 2 array {0} + {1} = {2}", l, r, sum1);
                    l++;
                    r--;
                }
                else if (a1[l] + a2[r] < sum1)
                {
                    l++;
                }
                else { r--; }
            }

            //Sum pair from 2 unsorted array
            int[] a11 = { 4, 6, 5, 7, 2, 1 };
            int[] a22 = { 8, 5, 7, 11,4 };
            int sum11 = 10;
            Dictionary<int, int> h1 = new Dictionary<int, int>();
            bool isf = a11.Length >= a22.Length;
            int n1 = isf ? a11.Length : a22.Length;
            for (int i = 0; i < (isf ? a22.Length : a11.Length); i++)
            {
                int temp = sum11 - (isf ? a22[i] : a11[i]);
                if (!h1.ContainsKey(temp))
                {
                    h1.Add(temp, 1);
                }
                
            }

            for (int i = 0; i < n1; i++)
            {
                int temp = (isf ? a11[i] : a22[i]);
                if (h1.ContainsKey(temp))
                {
                    Console.WriteLine("Sum  pair unsorted single array {0} + {1} ={2}", h1[temp], i, sum11);
                }
                
            }

        }

        //Maximum Path sum from Binary tree
        //Case 1 :: Current node is in the path of sum
        //Case 2 :: Current node is the root of max sum path
        //Case 3 :: Current node is not in path of Max sum

        //Case 1 :: ms = max(max(left,right)+root.val, root.val)
        //Case 2 :: m21 = max(ms, left + right + root.val)
        //Case 3 :: result = max(m21, result)

        public void MaximumPathSum(Node root)
        {
            int result = int.MinValue;
            MaxPathSum_Util(root, ref result);

            Console.WriteLine("Maximum Path sum from Binary tree :: {0}", result);
        }

        public int MaxPathSum_Util(Node root, ref int result)
        {
            if (root == null) return 0;

            int left = MaxPathSum_Util(root.Left, ref result);
            int right = MaxPathSum_Util(root.Right, ref result);

            int ms = Math.Max(Math.Max(left, right) + root.data, root.data);
            int m21 = Math.Max(ms, left + right + root.data);
            result = Math.Max(m21, result);

            return ms;
        }

        //Valid sequence from the root to leaf in a binary tree
        public void ValidSequence(Node root)
        {
            int[] arr = { 10, 8, 5 };
            int n = arr.Length;
            int pos = 0;

            Console.WriteLine("Valid sequence from the root to leaf:: {0} ", isValidSequence(root, n, pos, arr));
        }

        public bool isValidSequence(Node root, int n, int pos, int[] arr)
        {
            if (root == null) return false;
            else if (pos == null) return false;
            else if (root.data != arr[pos]) return false;
            else if (root.Left == null && root.Right == null && pos == n-1) return true;

            return isValidSequence(root.Left, n, pos + 1, arr) || isValidSequence(root.Right, n, pos + 1, arr);
            
        }

        public void HistogramMaxRectangle()
        {
            //int[] arr = { 2, 1, 2, 3, 1 };
            int[] arr = { 1, 2, 4 };
            int max = 0;
            Stack<int> S = new Stack<int>();
            int area = 0;
            int i = 0;
            while(i < arr.Length)
            {
                //If stack is empty or stack peak value less than next value then add index to stack
                if(S.Count == 0 || arr[S.Peek()] <= arr[i])
                {
                    S.Push(i);
                    i++;
                }
                else
                {
                    int top = S.Pop();
                    if(S.Count == 0)
                    {
                        area = arr[top] * i;
                    }
                    else
                    {
                        area = arr[top] * (i - S.Peek()-1);
                    }
                    if(area > max)
                    {
                        max = area;
                    }
                }
                
            }

            while(S.Count > 0)
            { 
                int top = S.Pop();
                if (S.Count == 0)
                {
                    area = arr[top] * i;
                }
                else
                {
                    area = arr[top] * (i - S.Peek() - 1);
                }
                if (area > max)
                {
                    max = area;
                }
            }

            Console.WriteLine("\nHistogram Max Rectangle {0}", max);
        }
    }

}
