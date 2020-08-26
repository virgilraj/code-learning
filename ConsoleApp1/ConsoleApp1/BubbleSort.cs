using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Interview
{
    class BubbleSort
    {
        public static int[] GetSorted(int[] arr)
        {
            for(int i=0; i< arr.Length; i++)
            {
                for(int j=i+1; j<arr.Length; j++)
                {
                    if(arr[i] > arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            return arr;
        }
    }
}
