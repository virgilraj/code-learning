using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    class Pattern
    {
        public static void SearchPattern(string txt, string pat)
        {
            int T = txt.Length;
            int P = pat.Length;

            for(int i=0; i < T-P; i++)
            {
                int j;
                for(j=0; j < P; j++)
                {
                    if(txt[i + j] != pat[j])
                    {
                        break;
                    }
                }

                if(j == P)
                {
                    Console.WriteLine("Pattern found at index " + i);
                }
            }
        }

       public static void Binary_MultipleOf3(string bianry)
        {
            int odd_cnt = 0;
            int even_cnt = 0;

            for(int i=1; i <= bianry.Length; i++)
            {
                if(bianry[i-1] == '1')
                {
                    if(i%2 == 0)
                    {
                        even_cnt++;
                    }
                    else
                    {
                        odd_cnt++;
                    }
                }
            }

            if(even_cnt - odd_cnt == 0)
            {
                Console.WriteLine("Binary divisible By 3");
            }
            else
            {
                Console.WriteLine("Binary NOT divisible By 3");
            }
        }

     public static void maxSubArraySum(int[] arr)
        {
            int so_far = int.MinValue;
            int max_end_here = 0;
            for(int i=0; i < arr.Length; i++)
            {
                max_end_here = max_end_here + arr[i];

                if(so_far < max_end_here)
                {
                    so_far = max_end_here;
                }

                if(max_end_here < 0)
                {
                    max_end_here = 0;
                }
            }

            Console.Write("Maximum contiguous sum is " + so_far);
        }

        public static void FindMissingElements(int[] arr)
        {
            //Normal formula is ::  n*(n+1)/2 -sum(all elements) --- this will give only missing item 
            if (arr.Length > 0)
            {
                int start = arr[0];
                int cnt = 1;
                int n = arr.Length;
                for (int i = start; i <=n ; i++)
                {
                    if (i != arr[i-cnt])
                    {
                        Console.WriteLine("Missing elements {0} at Index {1}", i, i - cnt);
                        cnt++;
                        n++;
                    }
                }
            }
        }
        //N/2 Majority Element
        public static void FindMajorityElement(int[] arr)
        {
            int majority = 0;
            int count = 1;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] == majority)
                {
                    count++;
                }
                else
                {
                    count = count - 1;
                    if (count == 0)
                    {
                        majority = arr[i];
                        count = 1;
                    }
                }
            }

            Console.WriteLine("N/2 Majority Element {0}", majority);
        }
    }
}
