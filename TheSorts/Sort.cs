/**
 * contains all the sorts for The Sorts project
 * @braydenhanna
 * @11/15/22
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace TheSorts
{
    class Sort
    {
        Stopwatch sw = new Stopwatch();

        #region INTS
        public int Bubble(int[] oldArr)
        {
            int[] arr = copyArray(oldArr);

            
            sw.Reset();
            sw.Start();
            for (int j = 0; j <= arr.Length - 1; j++)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        Swap(ref arr[i], ref arr[i + 1]);
                    }
                }
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            return (int)(ts.Ticks  );
        }
        public int Insertion(int[] oldArr)
        {
            int[] arr = copyArray(oldArr);

            sw.Reset();
            sw.Start();

            for (int i = 1; i < arr.Length; i++)
            {
                for (int k = 0; k < i; k++)
                {
                    if (arr[k] > arr[i])
                    {
                        Swap(ref arr[k], ref arr[i]);
                    }
                }
            }

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            return (int)(ts.Ticks);
        }
        public int Selection(int[] oldArr)
        {
            int[] arr = copyArray(oldArr);

            sw.Reset();
            sw.Start();
            for (int k = 0; k < arr.Length; k++)
            {
                int lowest = Int32.MaxValue;
                int posLowest = 0;
                for (int i = k; i < arr.Length; i++)
                {
                    if (arr[i] < lowest)
                    {
                        posLowest = i;
                        lowest = arr[i];
                    }
                }
                Swap(ref arr[k], ref arr[posLowest]);
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            return (int)(ts.Ticks);
        }
        public int QuickTimed(int[] oldArr, int left, int right)
        {
            int[] arr = copyArray(oldArr);
            sw.Reset();
            sw.Start();
            Quick(arr, left, right);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            return (int)(ts.Ticks);
        }
        public int[] Quick(int[] arr, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = arr[(left+right)/2];
            while (i<= j)
            {
                while (arr[i] < pivot) i++;
                while (arr[j] > pivot) j--;
                if (i <= j)
                {
                    Swap(ref arr[i], ref arr[j]);
                    i++;
                    j--;
                }
            }
            if (left < j) Quick(arr, left, j);
            if (i < right) Quick(arr, i, right);

            return arr;
        }
        public int MergeTimed(int[] oldArr, int left, int right)
        {
            int[] arr = copyArray(oldArr);
            sw.Reset();
            sw.Start();
            MergeSort(arr, left, right);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            return (int)(ts.Ticks);
        }
        private void MergeSort(int[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);
                Merge(arr, l, m, r);
            }
        }
        private void Merge(int[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1; 
            int n2 = r - m;       
            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            //Split
            for (int i = 0; i < n1; i++) leftArray[i] = arr[l + i];
            for (int i = 0; i < n2; i++) rightArray[i] = arr[m + i + 1];

            int x = 0, y = 0, pos = l;
            while (x < n1 && y < n2)
            {
                if (leftArray[x] < rightArray[y])
                {
                    arr[pos] = leftArray[x];
                    x++;
                }
                else
                {
                    arr[pos] = rightArray[y];
                    y++;
                }
                pos++;
            }

            //Merge back together
            while (x < n1)
            {
                arr[pos] = leftArray[x];
                x++;
                pos++;
            }

            while (y < n2)
            {
                arr[pos] = rightArray[y];
                y++;
                pos++;
            }
        }
        #endregion INTS

        #region STRINGS
        public int Bubble(string[] oldArr)
        {
            string[] arr = copyArray(oldArr);
            sw.Reset();
            sw.Start();
            for (int j = 0; j <= arr.Length - 1; j++)
            {
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i].CompareTo(arr[i + 1]) > 0)
                    {
                        Swap(ref arr[i], ref arr[i + 1]);
                    }
                }
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            return (int)(ts.Ticks);
        }
        public int Insertion(string[] oldArr)
        {
            string[] arr = copyArray(oldArr);
            sw.Reset();
            sw.Start();

            for (int i = 1; i < arr.Length; i++)
            {
                for (int k = 0; k < i; k++)
                {
                    if (arr[k].CompareTo(arr[i]) > 0)
                    {
                        Swap(ref arr[k], ref arr[i]);
                    }
                }
            }

            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            return (int)(ts.Ticks);
        }
        public int Selection(string[] oldArr)
        {
            string[] arr = copyArray(oldArr);
            sw.Reset();
            sw.Start();
            for (int k = 0; k < arr.Length; k++)
            {
                String lowest = "zzzzzzzzzzzzzzz";
                for (int i = k; i < arr.Length; i++)
                {
                    if (arr[i].CompareTo(lowest) > 0)
                    {
                        lowest = arr[i];
                    }
                }
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            return (int)(ts.Ticks);
        }
        public int QuickTimed(string[] oldArr, int left, int right)
        {
            string[] arr = copyArray(oldArr);
            sw.Reset();
            sw.Start();
            Quick(arr, left, right);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            return (int)(ts.Ticks);
        }
        public void Quick(string[] arr, int left, int right)
        {
            int i = left;
            int j = right;
            string pivot = arr[(left + right) / 2];
            while (i <= j)
            {
                while (arr[i].CompareTo(pivot) < 0) i++;
                while (arr[j].CompareTo(pivot) > 0) j--;

                if (i <= j)
                {
                    Swap(ref arr[i], ref arr[j]);
                    i++;
                    j--;
                }
            }

            if (left < j) Quick(arr, left, j);
            if (i < right) Quick(arr, i, right);
        }
        public int MergeTimed(string[] oldArr, int left, int right)
        {
            string[] arr = copyArray(oldArr);
            sw.Reset();
            sw.Start();
            MergeSort(arr, left, right);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;

            return (int)(ts.Ticks);
        }
        private string[] MergeSort(string[] arr, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;
                MergeSort(arr, l, m);
                MergeSort(arr, m + 1, r);
                Merge(arr, l, m, r);
            }
            return arr;
        }
        private void Merge(string[] arr, int l, int m, int r)
        {
            int n1 = m - l + 1;
            int n2 = r - m;
            string[] leftArray = new string[n1];
            string[] rightArray = new string[n2];

            //Split
            for (int i = 0; i < n1; i++) leftArray[i] = arr[l + i];
            for (int i = 0; i < n2; i++) rightArray[i] = arr[m + i + 1];

            int x = 0, y = 0, pos = l;
            while (x < n1 && y < n2)
            {
                if (leftArray[x].CompareTo(rightArray[y]) < 0)
                {
                    arr[pos] = leftArray[x];
                    x++;
                }
                else
                {
                    arr[pos] = rightArray[y];
                    y++;
                }
                pos++;
            }

            //Merge back together
            while (x < n1)
            {
                arr[pos] = leftArray[x];
                x++;
                pos++;
            }

            while (y < n2)
            {
                arr[pos] = rightArray[y];
                y++;
                pos++;
            }
        }
        #endregion STRINGS

        #region OTHER STUFF
        private void Swap(ref int x, ref int y)
        {
            int temp1 = y;
            int temp2 = x;
            x = temp1;
            y = temp2;
        }
        private void Swap(ref string x, ref string y)
        {
            string temp1 = y;
            string temp2 = x;
            x = temp1;
            y = temp2;
        }
        public int[] copyArray(int[] arr)
        {
            int[] arr2 = new int[arr.Length];
            for (int e = 0; e < arr.Length; e++)
            {
                arr2[e] = arr[e];
            }
            return arr2;
        }
        private string[] copyArray(string[] arr)
        {
            string[] arr2 = new string[arr.Length];
            for (int e = 0; e < arr.Length; e++)
            {
                arr2[e] = arr[e];
            }
            return arr2;
        }
        public void printArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        public void printArray(string[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
        #endregion OTHER STUFF

    }
}
