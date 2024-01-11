using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics; // stopwatch


namespace SelectionSortTest
{
    class Program
    {
        static void InsertionSort(int[] array)
        {
            int size = array.Length;

            for (int step = 1; step < size; step++)
            {
                int key = array[step];
                int j = step - 1;

                // Compare key with each element on the left of it until an element smaller than
                // it is found.
                // For descending order, change key<array[j] to key>array[j].
                while (j >= 0 && key < array[j])
                {
                    array[j + 1] = array[j];
                    --j;
                }

                // Place key at after the element just smaller than it.
                array[j + 1] = key;
            }
        }

        static void SelectionSort(int[] num)
        {
            int i, j, first, tempc;
            for (i = num.Length - 1; i > 0; i-- )
            {
                first = 0;   //initialize to subscript of first element
                for (j = 1; j <= i; j++)   //locate smallest element between positions 1 and i.
                {
                    if (num[j] > num[first])
                        first = j;
                }
                tempc = num[first];   //swap smallest found with element in position i.
                num[first] = num[i];
                num[i] = tempc;
            }
        }

        // perform the bubble sort
        static void BubbleSort(int[] array)
        {
            int size = array.Length;

            // loop to access each array element
            for (int i = 0; i < size - 1; i++)

                // loop to compare array elements
                for (int j = 0; j < size - i - 1; j++)

                    // compare two adjacent elements
                    // change > to < to sort in descending order
                    if (array[j] > array[j + 1])
                    {

                        // swapping occurs if elements
                        // are not in the intended order
                        int tempb = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tempb;
                    }
        }

        // Rearrange elements at each n/2, n/4, n/8, ... intervals
        static void ShellSort(int[] array, int N)
        {
            for (int interval = N / 2; interval > 0; interval /= 2)
            {
                for (int i = interval; i < N; i += 1)
                {
                    int tempa = array[i];
                    int j;
                    for (j = i; j >= interval && array[j - interval] > tempa; j -= interval)
                    {
                        array[j] = array[j - interval];
                    }
                    array[j] = tempa;
                }
            }
        }

        // Quick sort
        private static void QuickSort(int[] a, int lo, int hi)
        {
            //  lo is the lower index, hi is the upper index
            //  of the region of array a that is to be sorted
            int i = lo, j = hi, h;

            // comparison element x
            int x = a[(lo + hi) / 2];

            //  partition
            do
            {
                while (a[i] < x) i++;
                while (a[j] > x) j--;
                if (i <= j)
                {
                    h = a[i];
                    a[i] = a[j];
                    a[j] = h;
                    i++; j--;
                }
            } while (i <= j);

            //  recursion
            if (lo < j) QuickSort(a, lo, j);
            if (i < hi) QuickSort(a, i, hi);
        }

        static void PrintTable(int[] t)
        {
            foreach (var item in t)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine();
        }



        // Merge sort
        // Merge two subarrays L and M into arr
        static void merge(int[] array, int p, int q, int r)
        {

            // Create L ← A[p..q] and M ← A[q+1..r]
            int n1 = q - p + 1;
            int n2 = r - q;

            int[] L = new int[n1];
            int[] M = new int[n2];

            for (int ii = 0; ii < n1; ii++)
                L[ii] = array[p + ii];
            for (int jj = 0; jj < n2; jj++)
                M[jj] = array[q + 1 + jj];

            // Maintain current index of sub-arrays and main array
            int i, j, k;
            i = 0;
            j = 0;
            k = p;

            // Until we reach either end of either L or M, pick larger among
            // elements L and M and place them in the correct position at A[p..r]
            while (i < n1 && j < n2)
            {
                if (L[i] <= M[j])
                {
                    array[k] = L[i];
                    i++;
                }
                else
                {
                    array[k] = M[j];
                    j++;
                }
                k++;
            }

            // When we run out of elements in either L or M,
            // pick up the remaining elements and put in A[p..r]
            while (i < n1)
            {
                array[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                array[k] = M[j];
                j++;
                k++;
            }
        }

        // Divide the array into two subarrays, sort them and merge them
        static void mergeSort(int[] array, int l, int r)
        {
            if (l < r)
            {

                // m is the point where the array is divided into two subarrays
                int m = (l + r) / 2;

                mergeSort(array, l, m);
                mergeSort(array, m + 1, r);

                // Merge the sorted subarrays
                merge(array, l, m, r);
            }
        }

        static int[] CreateTable(int size)
        {
            // luo ensin taulukko, missä alkiot ei ole järjestyksessä
            int[] taulukko = new int[size];
            // täytetään taulukko satunnaisluvuilla
            Random generaattori = new Random();

            for (int i = 0; i < taulukko.Length; i++)
            {
                taulukko[i] = generaattori.Next(size);
            }

            return taulukko;
        }

        static int[] CreateAscendingTable(int size)
        {
            // luo ensin taulukko, missä alkiot ei ole järjestyksessä
            int[] taulukkoAsc = new int[size];

            for (int i = 0; i < taulukkoAsc.Length; i++)
            {
                taulukkoAsc[i] = i;
            }
            return taulukkoAsc;
        }

        static int[] CreateDescendingTable(int size)
        {
            int[] taulukkoDesc = new int[size];

            for (int i = 0; i < taulukkoDesc.Length; i++)
            {
                taulukkoDesc[i] = taulukkoDesc.Length - i;
            }

            return taulukkoDesc;
        }

        static void Main(string[] args)
        {
            int N = 20000;
            // luodaan taulukko
            int[] taulukko = CreateTable(N);
            int[] taulukkoAsc = CreateAscendingTable(N);
            int[] taulukkoDesc = CreateDescendingTable(N);
            //foreach (var e in taulukkoDesc)
            //Console.WriteLine(e);

            // Selection Rnd
            Stopwatch kello = Stopwatch.StartNew();
            SelectionSort(taulukko);
            kello.Stop();
            var elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Selection sort : {0}", elapsedTime);
            kello.Reset();

            
            // Selection Asc
            kello = Stopwatch.StartNew();
            SelectionSort(taulukkoAsc);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Selection sort Asc: {0}", elapsedTime);
            kello.Reset();

            // Selection Desc
            kello = Stopwatch.StartNew();
            SelectionSort(taulukkoDesc);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Selection sort Desc: {0}", elapsedTime);
            kello.Reset();

            // Insertionsort Rnd
            taulukko = CreateTable(N);  
            kello = Stopwatch.StartNew();
            InsertionSort(taulukko);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Insertion sort: {0}", elapsedTime);
            kello.Reset();

            // Insertionsort Asc
            taulukko = CreateAscendingTable(N);
            kello = Stopwatch.StartNew();
            InsertionSort(taulukkoAsc);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Insertion sort Asc: {0}", elapsedTime);
            kello.Reset();

            // Insertionsort Desc
            taulukko = CreateDescendingTable(N);
            kello = Stopwatch.StartNew();
            InsertionSort(taulukkoDesc);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Insertion sort Desc: {0}", elapsedTime);
            kello.Reset();

            // Array Rnd
            taulukko = CreateTable(N);
            kello = Stopwatch.StartNew();
            Array.Sort(taulukko);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Array.sort: {0}", elapsedTime);
            kello.Reset();

            // Array Asc
            taulukko = CreateAscendingTable(N);
            kello = Stopwatch.StartNew();
            Array.Sort(taulukkoAsc);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Array.sort Asc: {0}", elapsedTime);
            kello.Reset();

            // Array Desc
            taulukko = CreateDescendingTable(N);
            kello = Stopwatch.StartNew();
            Array.Sort(taulukkoDesc);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Array.sort Desc: {0}", elapsedTime);
            kello.Reset();

            // Bubble Rnd
            taulukko = CreateTable(N);
            kello = Stopwatch.StartNew();
            BubbleSort(taulukko);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Bubble sort: {0}", elapsedTime);
            kello.Reset();

            // Bubble Asc
            taulukkoAsc = CreateAscendingTable(N);
            kello = Stopwatch.StartNew();
            BubbleSort(taulukkoAsc);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Bubble sort Asc: {0}", elapsedTime);
            kello.Reset();

            // Bubble Desc
            taulukkoDesc = CreateDescendingTable(N);
            kello = Stopwatch.StartNew();
            BubbleSort(taulukkoDesc);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Bubble sort Desc: {0}", elapsedTime);
            kello.Reset();

            // Shell Rnd
            taulukko = CreateTable(N);
            kello = Stopwatch.StartNew();
            ShellSort(taulukko,N);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Shell sort: {0}", elapsedTime);
            kello.Reset();
            
            // Shell Asc
            taulukkoAsc = CreateAscendingTable(N);
            kello = Stopwatch.StartNew();
            ShellSort(taulukkoAsc,N);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Shell sort Asc: {0}", elapsedTime);
            kello.Reset();

            // Shell Desc
            taulukkoDesc = CreateDescendingTable(N);
            kello = Stopwatch.StartNew();
            ShellSort(taulukkoDesc,N);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Shell sort Desc: {0}", elapsedTime);
            kello.Reset();

            // taulukko
            int koko = 50000;
            int[] qtaulukko = new int[koko];

            // alustetaan taulukko satunnaisluvuilla
            Random gen = new Random();
            for (int i = 0; i < koko; i++)
            {
                qtaulukko[i] = gen.Next(1, koko);
            }

            //PrintTable(taulukko);

            kello = Stopwatch.StartNew();
            QuickSort(qtaulukko, 0, koko - 1);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Quicksort : {0}", elapsedTime);
            kello.Reset();

            //PrintTable(taulukko);

            /*
            // Quicksort Rnd
            taulukko = CreateTable(N);
            kello = Stopwatch.StartNew();
            QuickSort(taulukko, 0, taulukko.Length - 1);
            kello.Stop();
            elapsedTime=kello.ElapsedTicks;
            Console.WriteLine("Quicksort : {0}", elapsedTime);
            kello.Reset();

            // Quicksort Asc
            taulukkoAsc = CreateAscendingTable(N);
            kello = Stopwatch.StartNew();
            QuickSort(taulukkoAsc, 0, taulukkoAsc.Length - 1);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Quicksort Asc: {0}", elapsedTime);
            kello.Reset();

            // Quicksort Desc
            taulukkoDesc = CreateDescendingTable(N);
            kello = Stopwatch.StartNew();
            QuickSort(taulukkoDesc, 0, taulukkoDesc.Length - 1);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Quicksort Desc: {0}", elapsedTime);
            kello.Reset();
            */

            // Mergesort Rnd
            taulukko = CreateTable(N);
            //foreach (var e in taulukko)
            //Console.WriteLine(e);
            kello = Stopwatch.StartNew();
            mergeSort(taulukko, 0, taulukko.Length - 1);
            kello.Stop();
            //foreach (var e in taulukko)
            //Console.WriteLine(e);
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Mergesort : {0}", elapsedTime);
            kello.Reset();

            // Mergesort Asc
            taulukkoAsc = CreateAscendingTable(N);
            kello = Stopwatch.StartNew();
            mergeSort(taulukkoAsc, 0, taulukkoAsc.Length - 1);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Mergesort Asc : {0}", elapsedTime);
            kello.Reset();

            // Mergesort Desc
            taulukko = CreateDescendingTable(N);
            kello = Stopwatch.StartNew();
            mergeSort(taulukkoDesc, 0, taulukkoDesc.Length - 1);
            kello.Stop();
            elapsedTime = kello.ElapsedTicks;
            Console.WriteLine("Mergesort Desc : {0}", elapsedTime);
            kello.Reset();
            

        }
    }
}