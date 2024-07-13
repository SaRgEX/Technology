using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technology.Service.Sorts
{
    public static class QuickSort
    {
        public static string Sort(string data)
        {
            char[] array = data.ToCharArray();
            Array.Copy(data.ToCharArray(), array, data.Length - 1);
            return QSort(array, 0, data.Length - 1);
        }
        public static string QSort(char[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return new string(array);
            }

            int pivotIndex = GetPivotIndex(array, minIndex, maxIndex);

            QSort(array, minIndex, pivotIndex - 1);

            QSort(array, pivotIndex + 1, maxIndex);

            return new string(array);
        }

        private static int GetPivotIndex(char[] array, int minIndex, int maxIndex)
        {
            int pivot = minIndex - 1;

            for (int i = minIndex; i <= maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);

            return pivot;
        }

        private static void Swap(ref char leftItem, ref char rightItem)
        {
            char temp = leftItem;

            leftItem = rightItem;

            rightItem = temp;
        }
    }
}
