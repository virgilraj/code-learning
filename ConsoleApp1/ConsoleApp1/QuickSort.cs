using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Interview
{
    class QuickSort
    {
        public static void GetSorted(int[] arr1)
        {
            int[] arr = { 10, 3, 4, 7, 2, 3, 5 };
            QuickSort_Recursive(arr, 0, arr.Length - 1);
            foreach (var x in arr)
            {
                Console.WriteLine(x);
            }
        }

        public static void QuickSort_Recursive(int[] arr, int start, int end)
        {
            if(start < end)
            {
                int p = Partition(arr, start, end);

                //Left side
                QuickSort_Recursive(arr, start, p - 1);

                //Right
                QuickSort_Recursive(arr, p+1, end);
            }
        }

        public static int Partition(int[] arr, int start, int end)
        {
            int pivot = arr[end];  //Take last element as Pivot
            int pIndex = start;   //Take start point as pivot index
            for(int i=start; i < end; i++)
            {
                if (arr[i] <= pivot)
                {
                    Swap(arr, i, pIndex);
                    pIndex++;
                }
            }

            Swap(arr, pIndex, end); //Pivot position swap
            return pIndex;
        }

        public static void Swap(int[] arr, int start, int end)
        {
            int temp = arr[start];
            arr[start] = arr[end];
            arr[end] = temp;
        }

    }
}

