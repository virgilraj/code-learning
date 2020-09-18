using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections;
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
        public void MaximumSumSubArray()
        {
            int[] arr = { -2, -3, 4, -1, -2, 1, 5, -3 };
            //int[] arr = { -8, -3, -6, -2, -5, -4 };
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

            Console.WriteLine("\n MaximumSumSubArray  {0}", so_far);
        }

        public void MinimuSumSubArray()
        {
            int[] arr = { 5, -3, -7, 6, 1, 4 };
            //int[] arr = { -8, -3, -6, -2, -5, -4 };
            int min_here = 0;
            int so_far = int.MaxValue;
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                min_here = min_here + arr[i];
                if (min_here > arr[i])
                {
                    min_here = arr[i];
                }
                if (so_far > min_here)
                {
                    so_far = min_here;
                }
            }

            Console.WriteLine("\n MinimuSumSubArray  {0}", so_far);
        }

        //Maximum Sum circular sub array
        //Approcah 1. Sum of all element + minimum sum of sub array : edge case - if all elements are negative then return maximum value
        //Approcah 2. Create inverted array and get max sum of sub array + total sum
        public void MaximumSumCircularSubArray()
        {
            //Approach 1 
            //int[] arr = {5, -3, -2, 6, -1, 4 };
            int[] arr = { -5, -2, -4, -1 };
            int sumProd = 0;
            int maxvalue = int.MinValue;
            int cnt = 0;
            int n = arr.Length;
            int min_here = 0;
            int so_far = int.MaxValue;
            for (int i=0; i<n; i++)
            {
                sumProd += arr[i];
                maxvalue = Math.Max(arr[i], maxvalue);
                if (arr[i] < 0) cnt++;

                //Get Minimum sum of sub array
                min_here = min_here + arr[i];
                if(arr[i] < min_here)
                {
                    min_here = arr[i];
                }
                if(so_far > min_here)
                {
                    so_far = min_here;
                }
            }

            if(cnt == n)
            {
                Console.WriteLine("\n Maximum Sum circular sub array {0}", maxvalue);
            }
            else
            {
                Console.WriteLine("\n Maximum Sum circular sub array {0}", sumProd + (-1)*so_far);
            }
            
            //Alternate Approach
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
            Console.WriteLine("\nRearrangeArrayHighAndLow");
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
                    Console.WriteLine("\n equilibrium index of an array approach 1 :: {0}", i);
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
                int left = sum[i] - arr[i];
                int right = sum[n - 1] - sum[i];
                if (left == right)
                {
                    Console.WriteLine("\n equilibrium index of an array approach 2 :: {0}", i);
                }
            }
        }

        //Find majority element (Boyer–Moore Majority Vote Algorithm)
        //Given an array of integers containing duplicates, return the majority element in an array if present. 
        //A majority element appears more than n/2 times where n is the size of the array.
        //Aproach 1 . Naive solution - i loop N/2 time and j loop n times
        //arr[i]==arr[j] then count++

        //Aproach 2 - O(n) .. 1. consider 1st ele as majority ele, and counter = 1
        //2. compared 1st ele to next ele..  if it is not equal then counter--. 
        //if counter==0 then set counter=1 and majority = current val 
        //3. if equal then counter++
        //4. if we have majority element counter > 0 and majority variable has majority element

        public void FindMajorityElement()
        {
            int[] arr = { 2, 8, 7, 2 };
            int n = arr.Length;
            bool hasMaj = false;
            for(int i=0; i < n / 2; i++)
            {
                int count = 1;
                for(int j=i+1; j < n; j++)
                {
                    if(arr[i] == arr[j])
                    {
                        count++;
                    }
                }
                if (count >= n / 2)
                {
                    Console.WriteLine("\n Found majority element {0}", arr[i]);
                    hasMaj = true;
                }
            }

            
            if(!hasMaj)
            {
                Console.WriteLine("\nNOT Found majority element");
            }

            //Approach 2
            int majority = arr[0];
            int counter = 1;
            for(int i=1; i<n; i++)
            {
                if(majority == arr[i])
                {
                    counter++;
                }
                else
                {
                    counter--;
                    if (counter == 0) //Reassign important
                    {
                        majority = arr[i];
                        counter = 1;
                    }
                    
                }
            }
            Console.WriteLine("\n Found majority element :: Approach 2 :: {0}", majority);
        }

        //Move all zeros present in an array to the end
        //Simple approach O(nlogn)
        //Move all non zero to right then all end elements to zero
        //Approach 2 
        //Right and left pointer
        //Right pointer move first
        //if non zero element found the swap with left
        //Increment left and right
        //if zero found - increment right
        public void MoveAllZeroToEnd()
        {
            int[] arr = { 6, 0, 8, 2, 3, 0, 4, 0, 1 };
            int k = 0;
            int n = arr.Length;
            for(int i=0; i<n; i++)
            {
                if(arr[i] != 0)
                {
                    arr[k] = arr[i];
                    k++;
                }
            }

            for(int i =k; i<n; i++)
            {
                arr[i] = 0;
            }

            Console.WriteLine("\n MoveAllZeroToEnd approach 1");
            foreach (var a in arr)
            {
                Console.Write("{0}  ", a);
            }

            int[] arr1 = { 6, 0, 8, 2, 3, 0, 4, 0, 1 };
            int right = 0, left = 0;
            n = arr1.Length;
            while(right < n)
            {
                if (arr1[right] == 0) right++;
                else
                {
                    Swap(arr1, left, right);
                    left++;right++;
                }
            }

            Console.WriteLine("\n MoveAllZeroToEnd approach  2 (right and left pointer)");
            foreach (var a in arr1)
            {
                Console.Write("{0}  ", a);
            }
        }

        //Product of array except self (multiplication of array without self)
        public void ProductOfArrayWithotSlef()
        {
            int[] arr = { 1, 2, 3, 4 };
            int product = 0;
            int n = arr.Length;
            //divide approach
            for (int i = 0; i < n; i++)
            {
                if (i == 0) { product = arr[i]; }
                else
                {
                    product *= arr[i];
                }
            }
            for (int i = 0; i < n; i++)
            {
                arr[i] = product / arr[i];
            }

            Console.WriteLine("\n ProductOfArrayWithotSlef");
            foreach (var a in arr)
            {
                Console.Write("{0}  ", a);
            }

            //Without divide approach
            int[] arr1 = { 1, 2, 3, 4 };
            int[] left = new int[arr1.Length];
            int[] op = new int[arr1.Length];
            n = arr1.Length;
            int prod = 1;
            for (int i = 0; i < n; i++)
            {
                if (i == 0) left[i] = arr1[i];
                else
                {
                    left[i] = arr1[i] * arr1[i - 1];
                }
            }
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
            Console.WriteLine("\n ProductOfArrayWithotSlef approach 2 with extra space");
            foreach (var a in op)
            {
                Console.Write("{0}    ", a);
            }
        }

        //Bitonic Subarray in array 
        //Bitonic - accesnding order -> peek -> decending order
        //Approach 1. 1 .I[i] stores the length of the longest increasing sub-array ending at A[i]
        // 2.D[i] stores the length of the longest decreasing sub-array starting with A[i]
        // // consider each element as peak and calculate LBS

        public void BitonicSubArray()
        {
            int[] arr = { 3, 5, 8, 4, 5, 9, 10, 8, 5, 3, 4 };
            //int[] arr = { 12, 4, 78, 90, 45, 23 };
            int n = arr.Length;
            int[] Inc = new int[n];
            int[] Dec = new int[n];

            Inc[0] = 1;
            for (int i = 1; i < n; i++)
            {
                Inc[i] = 1;
                if (arr[i] > arr[i - 1])
                {
                    Inc[i] = Inc[i - 1] + 1;
                }
            }

            Dec[n - 1] = 1;
            for (int i = n - 2; i >= 0; i--)
            {
                Dec[i] = 1;
                if (arr[i] > arr[i + 1])
                {
                    Dec[i] = Dec[i + 1] + 1;
                }
            }

            // consider each element as peak and calculate LBS
            int lbs_len = 1;
            int beg = 0, end = 0;
            for (int i = 0; i < n; i++)
            { 
                if(lbs_len < Inc[i] + Dec[i] - 1)
                {
                    lbs_len = Inc[i] + Dec[i] - 1;
                    beg = i - Inc[i] + 1;
                    end = i + Dec[i] - 1;
                }
            }
            Console.WriteLine("\nBitonicSubArray Length {0}", lbs_len);
            for(int i=beg; i<end; i++)
            {
                Console.Write("{0}  ", arr[i]);
            }

            //Aproch 2 O(n) and O(1) 
            int max_len = 0, end_index = 0;
            int k = 0;
            while(k < n - 2)
            {
                int len = 1;

                // run till sequence is increasing
                while(k+1 < n && arr[k] < arr[k + 1])
                {
                    k++; len++;
                }

                // run till sequence is decreasing
                while (k + 1 < n && arr[k] > arr[k + 1])
                {
                    k++; len++;
                }

                // update Longest Bitonic Subarray if required
                if(len > max_len)
                {
                    max_len = len;
                    end_index = k;
                }
            }

            Console.WriteLine("\nBitonicSubArray Approch O(n) Length {0}", lbs_len);
            for (int i = end_index - max_len + 1; i < end_index; i++)
            {
                Console.Write("{0}  ", arr[i]);
            }
        }

        //Find maximum difference between two elements in an array by satisfying given constraints
        //(larger element appears after smaller)
        public void FindMaximumDifference()
        {
            int[] arr = { 2, 7, 9, 5, 1, 3, 5 };
            int max_so_far = int.MinValue;
            int diff = 0;
            int n = arr.Length;
            // traverse the array from right and keep track the maximum element
            for(int i = n-1; i>=0; i--)
            {
                if(arr[i] > max_so_far)
                {
                    max_so_far = arr[i];
                }
                else
                {
                    diff = Math.Max(diff, max_so_far - arr[i]);
                }
            }

            Console.WriteLine("\nFindMaximumDifference  {0}", diff);
        }

        //Find all distinct combinations of given length -- Ncr
        
        public void FindAllCombinations()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int r = 3;
            int[] data = new int[r];

            Console.WriteLine("Print Combination of r elements in an array of size n");
            combinationUtil(arr, data, 0, arr.Length - 1, 0, r);
        }

        /* arr[] ---> Input Array 
        data[] ---> Temporary array to store current combination 
        start & end ---> Staring and Ending indexes in arr[] 
        index ---> Current index in data[] 
        r ---> Size of a combination to be printed */

        public void combinationUtil(int[] arr, int[] data,
                    int start, int end,
                    int index, int r)
        {
            // Current combination is ready to be printed, print it 
            if (index == r)
            {
                for (int j = 0; j < r; j++)
                    Console.Write("{0}", data[j]);
                Console.WriteLine();
                return;
            }

            // replace index with all possible elements. 
            // The condition "end-i+1 >= r-index" 
            // makes sure that including one element 
            // at index will make a combination with 
            // remaining elements at remaining positions

            for (int i = start; i <= end && end - i + 1 >= r - index; i++)
            {
                data[index] = arr[i];
                combinationUtil(arr, data, i + 1,
                                end, index + 1, r);
            }
        }

        // Find minimum sum sub-array of given size k
        public void FindSumMimumSubArray_Given_Size()
        {
            int[] arr = { 10, 4, 2, 5, 6, 3, 8, 1 };
            int k = 3;

            // stores sum of element in current window
            int window_sum = 0;

            // stores sum of minimum sum sub-array found so far
            int min_window = int.MaxValue;

            // stores ending index of minimum sum sub-array found so far
            int last = 0;
            int n = arr.Length;
            for (int i = 0; i < n; i++) {
                //Current sum
                window_sum += arr[i];

                //If window size greater than size k
                if(i+1 > k)
                {
                    //update minimum sum window
                    if(window_sum < min_window)
                    {
                        min_window = window_sum;
                        last = i;
                    }

                    // remove leftmost element from the window
                    window_sum -= arr[i + 1 - k]; 
                }
            }

            Console.WriteLine("Find minimum sum sub-array of given size k index ::{0}  -- {1} and value {2} --> {3}", last - k + 1, last, arr[last-k+1], arr[last]);
        }

        // Function to check if sub-array with given sum exists in
        // the array or not
        public void FindSumSubArray_Given_Sum()
        {
            //This approach work for positive integer
            
            int[] arr = { 2, 6, 0, 9, 7, 3, 1, 4, 1, 10 };
            int sum = 15;
            
            int n = arr.Length;
            int window_sum = 0;
            int low = 0, high = 0;
            for (low = 0; low < n; low++)
            {
                // if current window's sum is less than the given sum,
                // then add elements to current window from right
                while (window_sum < sum && high < n)
                {
                    window_sum += arr[high];
                    high++;
                }

                // if current window's sum is equal to the given sum
                if (window_sum == sum)
                {
                    Console.WriteLine("\nSubarray Found at :: {0} --> {1}", low, high - 1);
                    //return;
                }

                // At this point the current window's sum is more than the given sum
                // remove current element (leftmost element) from the window

                window_sum -= arr[low];
            }


            //Dictionary approach
            int[] ar1 = { -3, 5, 2, -1, -4, 10 };
            sum = -4;

            Dictionary<int, int> h = new Dictionary<int, int>();
            h.Add(0, -1);
            // maintains sum of elements so far
            int sum_so_far = 0;
            for (int i=0; i < ar1.Length; i++)
            {
                // update sum_so_far
                sum_so_far += ar1[i];
                if (h.ContainsKey(sum_so_far - sum))
                {
                    Console.WriteLine("\nDict Subarray Found at :: {0} --> {1}", h[sum_so_far - sum]+1, i);
                }
                else
                {
                    if (!h.ContainsKey(sum_so_far))
                    {
                        h.Add(sum_so_far, i);
                    }
                    else
                    {
                        h[sum_so_far] = i;
                    }
                }
            }
        }

        // Function to find the length of smallest subarray whose sum
        // of elements is greater than the given number
        public void LengthOfSmallestSubarray_SumOfElements_GreaterThanNumber()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int k = 21;
            int n = arr.Length;
            int window_sum = 0;
            int len = int.MaxValue;
            int left = 0;
            // maintain a sliding window [left..right]
            for (int right = 0; right < n; right++)
            {
                // include current element in the window
                window_sum += arr[right];
                
                while(window_sum > k && left <= right)
                {
                    len = Math.Min(len, right - left + 1);

                    // remove elements from the window's left side till window
                    window_sum -= arr[left];
                    left++;
                }
            }

            if(len != int.MaxValue)
            {
                Console.WriteLine("\nSmallest sub-array length and Sum is :: {0}   {1}", len, window_sum);
            }
            else
            {
                Console.WriteLine("\n NO Smallest sub-array found ");
            }
        }

        //Find smallest window in array sorting which will make entire array sorted
        //1. Traverse array from left to right keeping track of maximum so far and note the last encountered index  which is less than the maximum so far.
        //2. Traverse array from right to left keeping track of minimum so far and note the last encountered index  which is more than the minimum so far.
        //3. 3. Finally we sort the array from index

        public void Find_Smallest_Window_Will_Make_Entire_Array_Sorted()
        {
            int[] arr = { 1, 3, 2, 7, 5, 6, 4, 8 };
            int n = arr.Length;

            int leftIndex = -1, rightIndex = -1;
            // traverse from left to right and keep track of maximum so far
            int max_so_far = int.MinValue;
            for(int i=0; i<n; i++)
            {
                if(max_so_far < arr[i])
                    max_so_far = arr[i];

                // find the last position that is less than the maximum so far
                if (arr[i] < max_so_far)
                    rightIndex = i;
            }

            // traverse from right to left and keep track of minimum so far
            int min_so_far = int.MaxValue;
            for (int i = n - 1; i >= 0; i--)
            {
                if(min_so_far > arr[i])
                {
                    min_so_far = arr[i];
                }

                // find the last position that is more than the minimum so far
                if(min_so_far < arr[i])
                {
                    leftIndex = i;
                }
            }

            Console.WriteLine("Sort array from index  {0}  to  {1}", leftIndex, rightIndex);
        }

        //Trapping Rain Water within given set of bars
        public void TrappingRainWaterwithin_given_set_bars()
        {
            int[] arr = { 1, 0, 2, 0, 3, 1 };
            //int[] arr = { 7, 0, 4, 2, 5, 0, 6, 4, 0, 5 };
            int n = arr.Length;
            int sum = 0;
            // left[i] stores the maximum height of a bar to the left
            // of current bar
            int[] left = new int[n];
            left[0] = int.MinValue;
            for (int i = 1; i < n - 1; i++)
            {
                left[i] = Math.Max(left[i - 1], arr[i - 1]);
            }

            // right stores the maximum height of a bar to the right
            // of current bar
            int right = int.MinValue;
            for (int i = n-2; i>=1; i--)
            {
                right = Math.Max(right, arr[i + 1]);

                // check if it is possible to store water in current bar
                if (Math.Min(left[i], right) > arr[i])
                {
                    int min = Math.Min(left[i], right);
                    sum += min - arr[i];
                }
            }

            Console.WriteLine("\n Trapping Rain Water within given set of bars  {0}", sum);
        }

        //Find maximum sum of subsequence with no adjacent elements
        //Formula 
        /**
        * Recursive slow solution.
        public int maxSum(int arr[], int index)
        {
            if (index == 0)
            {
                return arr[0];
            }
            else if (index == 1)
            {
                return Math.max(arr[0], arr[1]);
            }
            return Math.max(this.maxSum(arr, index - 2) + arr[index], this.maxSum(arr, index - 1));
        }*/
        public void Find_Maximum_Sum_Subsequence_With_NO_Adjacent()
        {
            int[] arr = { 1, 2, 9, 4, 5, 0, 4, 11, 6 };
            int n = arr.Length;

            //Simple fast DP: formula 
            //1. Find inclusive and exclusive sum
            //2. inclusive Max(exclusive+current, inclusive)
            //3. exclusive = old_inclusive
            //4. Sum = inclusive

            int exclusive = 0;
            int inclusive = arr[0];
            for(int i=0; i< n; i++)
            {
                int temp = inclusive;
                inclusive = Math.Max(exclusive + arr[i], inclusive);
                exclusive = temp;
            }

            Console.WriteLine("maximum sum of subsequence with no adjacent elements :: {0}", inclusive);
        }

        //Find minimum number of platforms needed in the station so to avoid any delay in arrival of any train
        public void MinimumNumber_Platform()
        {
            double[] arrival = { 2.00, 2.10, 3.00, 3.20, 3.50, 5.00 };
            double[] departure = { 2.30, 3.40, 3.20, 4.30, 4.00, 5.20 };

            Array.Sort(arrival);
            Array.Sort(departure);
            // maintains the count of trains
            int count = 0;

            // stores minimum platforms needed
            int platforms = 0;

            // take two indices for arrival and departure time
            int i = 0, j = 0;

            // run till train is scheduled to arrive
            while (i < arrival.Length)
            {
                // if train is scheduled to arrive next
                if (arrival[i] < departure[j])
                {
                    // increase the count of trains and update minimum
                    // platforms if required
                    count++;
                    platforms = Math.Max(platforms, count);

                    // move the pointer to next arrival
                    i++;
                }

                // if train is scheduled to depart next i.e.
                // (departure[j] < arrival[i]), decrease the count of trains
                // and move pointer j to next departure

                // If two trains are arriving and departing at the same time, i.e.
                // (arrival[i] == departure[j]) depart the train first
                else
                { count--; j++; }
            }


            Console.WriteLine("\nMinimum platforms needed is  {0}", platforms);
        }

        //Length of longest continuous sequence with same sum in given binary arrays
        // Given two binary arrays X and Y, find the length of longest
        // continuous sequence that starts and ends at same index in both
        // arrays and have same sum

        public void LengthOf_Continuous_Same_Sum_Two_Binary_Array()
        {
            int[] X = { 0, 0, 1, 1, 1, 1 };
            int[] Y = { 0, 1, 1, 0, 1, 0 };
            int n = X.Length;
            int sumX = 0, sumY = 0,  len = 0;

            Dictionary<int, int> h = new Dictionary<int, int>();
            
            //Important inizialize
            h.Add(0, -1);
            // traverse both lists simultaneously
            for (int i = 0; i < n; i++)
            {
                sumX += X[i];
                sumY += Y[i];
                // calculate difference between sum of elements in two lists
                int diff = Math.Abs( sumX - sumY);

                // if difference is seen for the first time, then store the
                // difference and current index in a dictionary
                if (!h.ContainsKey(diff))
                {
                    h.Add(diff, i);
                }
                else
                {
                    
                    len = Math.Max(len, i - h[diff]);
                }
            }

            Console.WriteLine("\nLength of longest sequence with same sum in given binary arrays {0}", len);
        }

        //Find number of rotations in a circularly sorted array
        //Number of rotations = Number of elements before minimum element of the array 
        public void Find_Number_Rotations()
        {
            int[] arr = { 8, 9, 10, 2, 5, 6 };
            int n = arr.Length;

            int low = 0, high = n-1;

            while(low < high )
            {
                if(arr[low] <= arr[high])
                {
                    Console.WriteLine("\nnumber of rotations {0}", low);
                    return;
                }
                else
                {
                    int mid = (low + high) / 2;
                    // find next and previous element of the mid element
                    // (in circular manner)
                    int next = (mid + 1) % n;
                    int prev = (mid - 1 + n) % n;

                    // if mid element is less than both its next and previous
                    // neighbor, then it is the minimum element of the array
                    if(arr[mid] < arr[next] && arr[mid] < arr[prev])
                    {
                        Console.WriteLine("\nnumber of rotations {0}", mid);
                        return;
                    }
                    else if(arr[mid] >= arr[low])
                    {
                        low = mid + 1;
                    }
                    else if(arr[mid] <= arr[high])
                    {
                        high = mid - 1;
                    }

                }
            }
        }
        //Rod cuting
        // Function to find best way to cut a rod of length n
        // where rod of length i has a cost price[i-1]
        public void RodCutting()
        {
            int[] length = { 1, 2, 3, 4, 5,  6,  7,  8 }; //Dummy
            int[] price = { 1, 5, 8, 9, 10, 17, 17, 20 };
            // rod length
            int n = 4;
            
            // T[i] stores maximum profit achieved from rod of length i
            int[] T = new int[n+1];

            // consider rod of length i
            for (int i = 1; i <= n; i++)
            {
                // divide the rod of length i into two rods of length j
                // and i-j each and take maximum
                for (int j = 1; j <= i; j++)
                    T[i] = Math.Max(T[i], price[j - 1] + T[i - j]);
            }


            Console.WriteLine("\n Maximun Profit {0}", T[n]);
        }
        //Find kth smallest element
        public void Find_kth_Smallest_Element()
        {
            int[] arr = { 10,3, 4, 7, 2, 3, 5 };
            int k = 6;
            QuickSort.QuickSelect_Recursive(arr,0,arr.Length-1, k-1);
            
        }
        private void Swap(int[] arr, int li, int ri)
        {
            int temp = arr[li];
            arr[li] = arr[ri];
            arr[ri] = temp;
        }

    }

}
