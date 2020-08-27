using System;
using System.Collections;
using System.Collections.Generic;
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
            int[] arr = { 1, 2, 3, 1, 2,3,6,2,2 };
            for(int i=0; i<arr.Length; i++)
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

        //Kadanes algorithm | Longest sum contiguous subarray
        public void Longest_Sum_Subarray()
        {
            //int[] arr = { -2, -3, 4, -1, -2, 1, 5, -3 };
            int[] arr = { 1, 2, 3, -2, 5 };
            int max_end_here = 0;
            int max_so_far = int.MinValue;

            for(int i=0; i<arr.Length; i++)
            {
                max_end_here = max_end_here + arr[i];
                if(max_end_here < arr[i])
                {
                    max_end_here = arr[i];
                }
                if(max_so_far < max_end_here)
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
            int[] arr = { 3, 4, 7, 2, -3, 1, 4, 2 };
            int sum = 7;
            int n = arr.Length;

            // HashMap to store number of subarrays 
            // starting from index zero having 
            // particular value of sum. 
            Dictionary<int, int> prevSum = new Dictionary<int, int>();
            int count = 0;
            //Sum so far
            int curSum = 0;
            for(int i=0;i<n; i++)
            {
                curSum += arr[i];
                if(curSum == sum)
                {
                    count++;
                }
                if(prevSum.ContainsKey(curSum - sum))
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
            //Right pointer mve first
            //if non zero element found the swap with left
            //Increment left and right
            //if zero found - increment right
            int[] arr = { 0, 1, 0, 3, 30, 0, 6,12,0 };
            int right = 0, left = 0;
            int n = arr.Length;
            while(right <n)
            {
                if(arr[right] == 0)
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
            foreach(var a in arr)
            {
                Console.Write("{0}   ", a);
            }
        }

        //Best time to Buy and Sell
        public void MaxProfit()
        {
            //int[] arr = { 0, 1, 0, 3, 30, 0, 6, 12, 0 };
            int[] arr = { 7, 1, 5, 3, 6, 4 };
            int prof = 0;

            for(int i=1; i < arr.Length; i++)
            {
                if(arr[i] > arr[i - 1])
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
            foreach(var a in alph)
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
            foreach(var k in h)
            {
                for(int i=0; i<k.Value; i++)
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
                    if(cnt - 1 < 0)
                    {
                        Console.WriteLine("NOT Anagrams");
                        return;
                    }
                    h[st2[i]] = cnt - 1;
                }
                
            }
            int c = 0;
            foreach(var k in h)
            {
                if(k.Value != 0)
                {
                    Console.WriteLine("NOT Anagrams");
                    return;
                }
                else
                {
                    c++;
                }
            }
            if(c == h.Count)
            {
                Console.WriteLine("Anagrams");
            }
        }

        //Grouping Anagrams
        public void GroupingAnagrams()
        {
            string[] arr = { "eat", "tea", "tan", "ate", "nat", "bat" };
            Dictionary<string, ArrayList> h = new Dictionary<string, ArrayList>();

            foreach(var a in arr)
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
    }
}
