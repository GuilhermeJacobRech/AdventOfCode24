using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode24
{
    internal class Helpers
    {
        public static void QuickSort(int[] arr, int start, int end)
        {
            int pivotPos;
            if (start < end)
            {
                pivotPos = Partition(arr, start, end);

                QuickSort(arr, start, pivotPos - 1);
                QuickSort(arr, pivotPos + 1, end);
            }
        }

        private static int Partition(int[] arr, int start, int end)
        {
            int temp;
            int p = arr[end];
            int i = start - 1;

            for (int j = start; j <= end - 1; j++)
            {
                if (arr[j] <= p)
                {
                    i++;
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            temp = arr[i + 1];
            arr[i + 1] = arr[end];
            arr[end] = temp;
            return i + 1;
        }
    }
}
