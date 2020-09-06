using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    public class ArrayProblem
    {
        //Schedule the given 2N candidates among two cities such that each city has exactly N candidates.
        //We are given a cost matrix for travel of each candidate.
        //We are required to find such a configuration of travel for candidates such that the cost of travel is minimized.
        //There are many approaches to solve this problem like sorting,recursion,dynamic programming  etc. 
        //I have explained the  easiest and most efficient method using sorting and also using heap.
        
        public void TwoCityTravelProfit()
        {
            int[,] arr = { { 30, 300 },
                           { 40, 200 },
                           { 20, 60 },
                           { 10, 50 }
                        };
        }

        //Print Find the sum of sub array by given value K
        //Steps 1. add cumlative sum and index to dictionary
        //2. if cursum == sum the add the counter and print the index form 0 to current index
        //3. if cursum-sum exist in the dictionary then add counter and print 
        //  dictionary index+1 and current index 
        //4.if currentSum not in the dictionary then add cursum and index
        //5 else update the index to currentSum
        public void Find_And_Print_SubArraySum()
        {
            int[] arr = { 3, 4, 7, 2, -3, 1, 4, 2 };
            //int[] arr = { 3, 4, -7, 3, 1, 3, 1, -4, -2, -2 };
            int sum = 0;
            int n = arr.Length;

            
            Dictionary<int, int> prevSum = new Dictionary<int, int>();
            int curSum = 0;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                curSum += arr[i];
                if (curSum == sum)
                {
                    count++;
                    Console.WriteLine("Sub array start index {0}  ...  {1}", 0, i);
                }
                
                if (prevSum.ContainsKey(curSum - sum))
                {
                    count++;
                    int preIndex = prevSum[curSum - sum];
                    Console.WriteLine("Sub array start index {0}  ...  {1}", preIndex+1, i);
                }

                if (!prevSum.ContainsKey(curSum))
                {
                    prevSum.Add(curSum, i);
                    //prevSum.Add(curSum, 1);
                }
                else
                {
                    prevSum[curSum] = i;
                    //int cnt = prevSum[curSum];
                    //prevSum[curSum] = cnt + 1;
                }
            }

            Console.WriteLine("Number of subarrays having sum exactly equal to {0} is {1}", sum, count);
        }

        /// <summary>
        /// 1. If sorted array - use left and right pointer ==>applicable for two sorted array
        ///     a.loop left less than right
        ///     b. if both sum equal to given value then print then left++ , right--
        ///     c.if both sum less than given value then left++
        ///     d.if both sum greater than given value then right++
        /// 2.Unsorted array use dictionary
        ///  a. add given vlaue - array into dictionary 
        ///  b. if dictionary has array value then print
        /// </summary>
        public void FinPairsGivenSum()
        {
            //Sorted array
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int left = 0;
            int sum = 5;
            int right = arr.Length - 1;

            while (left < right)
            {
                if (arr[left] + arr[right] == sum)
                {
                    Console.WriteLine("Sum  pair Sorted single array {0} + {1} ={2}", left, right, sum);
                    left++;
                    right--;
                }
                else if (arr[left] + arr[right] < sum)
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
            Dictionary<int, int> h = new Dictionary<int, int>();
            for (int i = 0; i < arr1.Length; i++)
            {
                if (h.ContainsKey(arr1[i]))
                {
                    Console.WriteLine("Sum  pair unsorted single array {0} + {1} ={2}", h[arr1[i]], i, sum);
                }
                else
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

            while (l < n && r >= 0)
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
            int[] a22 = { 8, 5, 7, 11, 4 };
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

        //Sort binary array in linear time O(n)
        //1.Right and left pointer to == 0
        //2.Loop right < array length
        //2.Right pointer move first
        //3.if  zero element found the swap with left
        //4.Increment left and right
        //5 if non zero found - increment right
        public void SortBinaryArray()
        {
            int[] arr = { 1, 0, 1, 1, 0, 1, 0, 1 };
            int left = 0;
            int right = 0;
            while (right < arr.Length)
            {
                if(arr[right] == 1)
                {
                    right++;
                }
                else
                {
                    //Swap 
                    int temp = arr[right];
                    arr[right] = arr[left];
                    arr[left] = temp;
                    left++;
                    right++;
                    
                }
            }
            Console.WriteLine("\nSorted binary sub array");

            for(int i=0; i<arr.Length; i++)
            {
                Console.Write("{0}   ", arr[i]);
            }
        }

        //Find a duplicate element in a limited range array
        public void FindDuplicate()
        {
            int[] arr = { 0, 4, 5, 6, 7, 1, 3, 2, 4, 6, 0 };
            Dictionary<int, int> h = new Dictionary<int, int>();

            for(int i=0; i<arr.Length; i++)
            {
                if (h.ContainsKey(arr[i]))
                {
                    h[arr[i]] = h[arr[i]] + 1;
                    Console.WriteLine("\nDuplicate element for at position {0} --> {1}", i, arr[i]);
                }
                else
                {
                    h.Add(arr[i], 1);
                }
            }
        }

        //Find largest sub-array formed by consecutive integers
        //Condition -- no duplicate elements
        //So far O(n2)
        //Formaula :: difference between Max and Min value equal to last and first index difference
        public void LongestConsecutiveSubArray()
        {
            int[] arr = { 4, 6, 0, 2, 1, 3, 10, 8, 11 };
            //Array.Sort(arr);
            //int[] arr = { 10, 12,11 };
            int max_len = 1;
            int n = arr.Length;
            for(int i=0; i < n-1; i++)
            {
                int mn = arr[i];
                int mx = arr[i];
                
                for(int j=i+1; j <n; j++)
                {
                    mn = Math.Min(mn, arr[j]);
                    mx = Math.Max(mx, arr[j]);

                    if((mx-mn) == (j-i))
                    {
                        max_len = Math.Max(max_len, (mx - mn + 1));
                        
                        Console.WriteLine("\nConsecutiveSub array {0},{1} -> {0}",j, i, (j-i));
                        //int h = (j - i) + 1;
                        for (int k = i; k <= j; k++)
                            Console.Write("{0}  ", arr[k]);
                    }
                }
            }

            Console.WriteLine("\nLongest Consecutive Sub Array  {0}", max_len);
        }

        //Find Sum of longest sub array
        //Kadanes -- Single traversal -> max_end_here --> max so far
        public void SumLongestSubArray()
        {
            int[] arr = { -2, -3, 4, -1, -2, 1, 5, -3 };
            int max_here = 0;
            int so_far = int.MinValue;
            int n = arr.Length;
            for (int i = 0; i < n ; i++)
            {
                max_here = max_here + arr[i];
                if(max_here < arr[i])
                {
                    max_here = arr[i];
                }
                if(so_far < max_here)
                {
                    so_far = max_here;
                }
            }

            Console.WriteLine("\n SumLongestSubArray  {0}", so_far);
        }

        //Contiguous array 
        //find the count of all contiguous array will equal number of zeroes and 
        //If consider 0 to -1 then sum of the sub array always 0 
        //Use dictionary -> key = sum , value = index
        public void SubArrayWithEqualZeroAndOne()
        {
            int[] arr = { 1, 1, 0, 0, 1, 1, 0, 1, 1 };
            int max_len = 0, sum = 0;
            Dictionary<int, int> h = new Dictionary<int, int>();
            for(int i=0; i < arr.Length; i++)
            {
                int temp = arr[i] == 0 ? -1 : arr[i];
                sum += temp;

                //If sum 0 then sub array starts from 0th index
                if (sum == 0)
                {
                    max_len = max_len < i+1 ? i +1 : max_len;
                }else if (!h.ContainsKey(sum))
                {
                    h.Add(sum, i);
                }
                else
                {
                    max_len = max_len < (i -h[sum]) ? (i - h[sum]) : max_len;
                }
            }

            Console.WriteLine("Count of all contiguous array will equal number of zeroes {0}", max_len);
        }

        //Sorting the array only contains 0, 1,2
        //Approach 1 - Any sorting algorithm will work
        //Approcah 2 - maintain 3 pointers low, medium and high
        // 1. low and medium will start from index 0
        // 2. high will start from last index-1
        // 3. Move the medium pointer 
        // 4. If medium = 0 then swap low and medium and low++, medium++
        // 5. if medium = 1 then medium++
        // 6  if medium = 2 then swap medium and high and high--

        public void SortArrayOnlyZeroOneTwos()
        {
            int[] arr = {1, 2, 1, 0, 2, 1, 2, 1, 2,0 };
            int low = 0, medium = 0, high = arr.Length -1;
            while(medium < high)
            {
                if(arr[medium] == 0)
                {
                    Swap(arr, low, medium);
                    low++;
                    medium++;
                }
                if(arr[medium] == 1)
                {
                    medium++;
                }
                if(arr[medium] ==2)
                {
                    Swap(arr, medium, high);
                    high--;
                }
            }

            Console.WriteLine("\nSorted array");
            foreach(int k in arr)
            {
                Console.Write("{0}  ", k);
            }
        }

        //In palce merge for to sorted array
        // Step 1. Iterate through all elements of ar2[] starting from the last element
        // 2. Find the smallest element greater than ar2[i]. 
        // 3. Move all elements one position ahead till the smallest greater element is not found

        public void Merge2SortedArray()
        {
            int[] arr1 = { 3, 7, 9, 10, 12 };
            int[] arr2 = { 2, 4, 15 };

            int m = arr1.Length, n = arr2.Length;
            //1. Iterate through all elements of ar2[] starting from the last element
            for (int i = n - 1; i >= 0; i--)
            {
                int last = arr1[m - 1];
                int j;

                // 2. Find the smallest element greater than ar2[i]. 
                // 3. Move all elements one position ahead till the smallest greater element is not found
                for (j = m - 2; j >= 0 && arr1[j] > arr2[i]; j--)
                    arr1[j + 1] = arr1[j];

                // If there was a greater element 
                if (j != m-2 || last > arr2[i])
                {
                    arr1[j + 1] = arr2[i];
                    arr2[i] = last;
                }
            }
            

            Console.WriteLine("Merged Sorted Array");
            foreach(var i in arr1)
            {
                Console.Write(" {0} ->", i);
            }
            foreach (var i in arr2)
            {
                Console.Write("=> {0} ->", i);
            }

        }

        //Merge two arrays by satisfying given constraints
        //Step 1 . curPos and J =0 
        //2. X[curPos] is zero and next element of X greater than Y element then replace zero with y element
        //3. curPos++ and j++
        //4. curpos element is zero and next element greater than zero and next element less than Y
        //5. Swap curpos to next element and curPos++
        //6. curpos element > 0 then curPos++
        //7. replace last zero with Y array 
        public void MergeArray_ReplaceZeroValue()
        {
            int[] X = { 0, 2, 0, 3, 0, 5, 6, 0, 0 };
            int[] Y = { 1, 8, 9, 10, 15 };

            int j = 0, curPos = 0;
            for (int i = 0; i < X.Length - 1; i++)
            {
                if (X[curPos] == 0 && X[i + 1] > Y[j])
                {
                    X[curPos] = Y[j];
                    curPos++;
                    j++;
                }
                else if (X[curPos] == 0 && X[i + 1] > 0 && X[i + 1] < Y[j])
                {
                    Swap(X, curPos, i + 1);
                    curPos++;
                }else if(X[curPos] > 0)
                {
                    curPos++;
                }
                
            }

            //Replace Last zero elements
            while(curPos < X.Length && j < Y.Length)
            {
                X[curPos] = Y[j];
                curPos++;
                j++;
            }

            Console.WriteLine("\nMergeArray_ReplaceZeroValue");
            foreach(var i in X)
            {
                Console.Write("{0}  ", i); 
            }
        }

        //Find index of 0 to be replaced to get maximum length sequence of continuous ones
        public void Find_Index_MaxLength_ContinuousOnes()
        {
            int[] arr = { 0, 0, 1, 0, 1, 1, 1, 0, 1, 1 };
            int max_count = 0;      // stores maximum number of 1's (including zero)
            int max_index = -1;     // stores index of 0 to be replaced

            int prev_zero_index = -1;   // stores index of previous zero
            int count = 0;  			// store current count of zeros

            for (int i=0; i< arr.Length; i++)
            {
                // if current element is 1
                if (arr[i] == 1)
                {
                    count++;
                }
                else
                // if current element is 0
                {
                    // reset count to 1 + number of ones to the left of current 0
                    count = i - prev_zero_index;

                    // update prev_zero_index to current index
                    prev_zero_index = i;
                }

                // update maximum count and index of 0 to be replaced if required
                if (count > max_count)
                {
                    max_count = count;
                    max_index = prev_zero_index;
                }
            }

            Console.WriteLine("\nFind_Index_MaxLength_ContinuousOnes  {0}  --> {1}", max_index , count);
        }

        //Product of two integer array
        //Approach 1 . two i and j loop and get the each multiplication from i*j
        //Approach 2. Sort the array max(multiply first 2 numbs,multiply last 2 numbs)
        //Approach 3. We can solve this problem in linear time as we need 
        //only maximum, second maximum, minimum and second minimum element to solve this problem.
        //We can compute all these in only single traversal of the array which accounts for 

        public void ProductOfTwoIntArray()
        {
            int[] arr = { -10, -3, 5, 6, -2 };
            //Approach 1 = 
            int max_prod = 0;
            int n = arr.Length;
            for(int i=0; i<arr.Length; i++)
            {
                for (int j = i+1; j < arr.Length; j++)
                {
                    if(arr[i]*arr[j] > max_prod)
                    {
                        max_prod = arr[i] * arr[j];
                    }
                }
            }

            Console.WriteLine("Product of two integer array :: {0}", max_prod);

            //Approach 2 : Sort
            int[] ar1 = { -40, -3, 5, 6, -2 };
            Array.Sort(arr);
            int max_prod1 = 0;
            if (ar1[0] * ar1[1] > ar1[n-1] * ar1[n - 2])
            {
                max_prod1 = ar1[0] * ar1[1];
            }
            else
            {
                max_prod1 = ar1[n - 1] * ar1[n - 2];
            }
            Console.WriteLine("Product of two integer array Sort:: {0}", max_prod1);

            //Aproach 3 - O(n) -- get 2 min and max
            int[] ar2 = { -40, -3, 5, 6, -2 };
            int max1 = ar2[0], max2=int.MinValue;
            int min1 = ar2[0], min2 = int.MaxValue;

            for(int i =0; i< ar2.Length; i++)
            {
                //Update max1 and max2
                if(ar2[i] > max1)
                {
                    max2 = max1;
                    max1 = ar2[i];
                    
                }
                //if the current element is less than max1 and greater than max2 then update the max2
                if (ar2[i] < max1 && ar2[i] > max2)
                {
                    max2 = ar2[i];
                }

                //Update min
                //Update max1 and max2
                if (ar2[i] < min1)
                {
                    min2 = min1;
                    min1 = ar2[i];
                }
                //if the current element is greater than min1 and less than min2 then update the min2
                if (ar2[i] > min1 && ar2[i] < min2)
                {
                    min2 = ar2[i];
                }

            }
            if (min1 * min2 > max1 * max2)
            {
                Console.WriteLine("Product of two integer array Min Max approach:: {0}", min1 * min2);
            }
            else if (min1 * min2 < max1 * max2)
            {
                Console.WriteLine("Product of two integer array Min Max approach:: {0}", max1 * max2);
            }
        }

        //Suffle the given array
        public void Suffle()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            int n = arr.Length;
            for(int i = n-1; i>=0; i--)
            {
                Random r = new Random();
                
                //generate the random number such that 0<=j<=i
                int j = r.Next() % (i + 1);
                Swap(arr, i, j);
            }

            Console.WriteLine("\nSuffled Array\n");
            foreach(var a in arr)
            {
                Console.Write("{0}  ", a);
            }
        }

        //Rearrange an array with alternate high and low elements
        //Approach 1 = Move 2 element at a time
        //Check left element greater than current then swap 
        //Check right element less than current then swap
        public void RearrangeArrayHighAndLow()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };
            //int[] arr = { 6, 9, 2, 5, 1, 4 };
            //int[] arr = { 9, 6, 8, 3, 7 };
            int n = arr.Length;

            for (int i = 1; i < n-1; i = i + 2)
            {
                if(arr[i] < arr[i - 1])
                {
                    Swap(arr, i, i - 1);
                }
                if (arr[i] < arr[i + 1])
                {
                    Swap(arr, i, i + 1);
                }
            }
            Console.WriteLine("\nRearrangeArrayHighAndLow\n");
            foreach (var a in arr)
            {
                Console.Write("{0}  ", a);
            }
        }

        //Find the equilibrium index of an array 
        //equilibrium :: sum of left elements == sum of right elements
        //Approach 1. two loop (i & j) j O(n*n)
        //1. Strat from first index then get sum left array 
        //2. get the sum of right arry 3. if both equal the its equilibrium index
        //Approach 2:1. Create another sum array for each index
        //2. Start from 1 element 
        //3. leftsum = sum[i] - arr[i]
        //4. Rightsum = toatl(sum[n-1]) - arr[i]
        //5 . check both leftsum == rightsum
        public void EquilibriumIndex()
        {
            //Edge conditon --> array should be greater than 2

            int[] arr = { 1, 2, 6, 4, 0, -1 };
            int n = arr.Length;

            //int l = 0, r = 0;

            for (int i = 1; i < n - 1; i++)
            {
                int left = 0, right = 0;
                int l = i - 1;
                int r = i + 1;
                //left sum
                while (l >= 0)
                {
                    left += arr[l];
                    l--;
                }
                while (r < n)
                {
                    right += arr[r];
                    r++;
                }

                if (left == right)
                {
                    Console.WriteLine("\n equilibrium index of an array approach 1 :: {0}\n", i);
                }
            }

            //Approach 2
            int[] sum = new int[n];
            int s = 0;
            for (int i = 0; i < n; i++)
            {
                s += arr[i];
                sum[i] = s;
            }

            for (int i = 0; i < n; i++)
            {
                s += arr[i];
                int left = sum[i] - arr[i];
                int right = sum[n - 1] - sum[i];
                if (left == right)
                {
                    Console.WriteLine("\n equilibrium index of an array approach 2 :: {0}\n", i);
                }
            }
        }

        private void Swap(int[] arr, int li, int ri)
        {
            int temp = arr[li];
            arr[li] = arr[ri];
            arr[ri] = temp;
        }
    }

}
