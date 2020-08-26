using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    class MyHeap
    {
        public static void BuildHead()
        {
            int[] arr = { 2, 3, 4, 7,10, 2,30, 3, 5 };

            //Non leaf node index 
            int n = arr.Length;
            int startIdx = (n / 2) - 1;

            for (int i = startIdx; i >= 0; i--)
            {
                Heapify(arr, n, i);
            }

            Console.WriteLine("Heapifed array");
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            HeapSort(arr);

            Console.WriteLine();

            Console.WriteLine("Sorted array");
            for (int i = 0; i < n; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        /// <summary>
        /// Send Heapifed array
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="n"></param>
        /// <param name="i"></param>
        public static void HeapSort(int[] arr)
        {
            for(int i=arr.Length-1; i >=0; i--)
            {
                int temp = arr[0];
                arr[0] = arr[i];
                arr[i] = temp;

                Heapify(arr, i, 0);
            }
        }
        public static void Heapify(int[] arr, int n, int i)
        {

            int largest = i; // Initialize largest as root  
            int l = 2 * i + 1; // left = 2*i + 1  
            int r = 2 * i + 2; // right = 2*i + 2  

            // If left child is larger than root  
            if (l < n && arr[l] > arr[largest])
                largest = l;

            // If right child is larger than largest so far  
            if (r < n && arr[r] > arr[largest])
                largest = r;

            // If largest is not root  
            if (largest != i)
            {
                int swap = arr[i];
                arr[i] = arr[largest];
                arr[largest] = swap;

                // Recursively heapify the affected sub-tree  
                Heapify(arr, n, largest);
            }

        }
    }
}
