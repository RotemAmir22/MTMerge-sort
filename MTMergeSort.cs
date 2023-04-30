using System;
using System.Threading;

public class MTMergeSort
{
    static void Main(string[] args)
    {
        
        string[] arr = { "a", "k", "r", "b", "s", "v", "c", "w", "z" };
        MTMergeSort mTMergeSort = new MTMergeSort();
        List<string> ans = mTMergeSort.MergeSort(arr,5);
        if (ans == null)
            Console.WriteLine("No list");
        else
        {
            string result = string.Join(", ", ans);
            Console.WriteLine(result);
        }
            
        Console.ReadLine();
    }


    public List<string> MergeSort(string[] strList, int nMin = 2)
    {
        if (strList.Length < nMin) 
        {
            List<string> list = MergeSortNoThread(strList,0,strList.Length-1).ToList();
            return list;
        }

        int mid = strList.Length / 2;

        // create left and right sub-arrays
        string[] left = new string[mid];
        string[] right = new string[strList.Length - mid];
        Array.Copy(strList, 0, left, 0, mid);
        Array.Copy(strList, mid, right, 0, strList.Length - mid);
        
              
        // create threads to sort each sub-array
        Thread leftThread = new Thread(() => run(left, nMin));
        Thread rightThread = new Thread(() => run(right, nMin));

        // start threads and wait for them to complete
        leftThread.Start();
        rightThread.Start();
        leftThread.Join();
        rightThread.Join();
        
        return MergeSortNoThread(strList, 0, strList.Length - 1).ToList();
        
    }

    //need to use a static function for threads
    public static List<string> run(string[] strList, int nMin = 2)
    {
        if (strList.Length < nMin)
        {
            List<string> list = MergeSortNoThread(strList, 0, strList.Length - 1).ToList();
            return list;
        }

        int mid = strList.Length / 2;

        // create left and right sub-arrays
        string[] left = new string[mid];
        string[] right = new string[strList.Length - mid];
        Array.Copy(strList, 0, left, 0, mid);
        Array.Copy(strList, mid, right, 0, strList.Length - mid);

        // create threads to sort each sub-array
        Thread leftThread = new Thread(() => run(left, nMin));
        Thread rightThread = new Thread(() => run(right, nMin));

        // start threads and wait for them to complete
        leftThread.Start();
        rightThread.Start();
        leftThread.Join();
        rightThread.Join();

        return MergeSortNoThread(strList, 0, strList.Length - 1).ToList();
    }

    //without thread- minimum division
    public static string[] MergeSortNoThread(string[] strList,int l, int r)
    {
         if (l < r) 
         {
            // Find the middle
            // point
            int m = l + (r - l) / 2;
 
            // Sort first and
            // second halves
            MergeSortNoThread(strList, l, m);
            MergeSortNoThread(strList, m + 1, r);
 
            // Merge the sorted halves
            Merge(strList, l, m, r);
         }
        
        return strList;
    }

    //merge the arrays
    public static void Merge(string[] arr, int l, int m, int r) 
    {
        // Find sizes of two
        // subarrays to be merged
        int n1 = m - l + 1;
        int n2 = r - m;
 
        // Create temp arrays
        string[] L = new string[n1];
        string[] R = new string[n2];
        int i, j;
 
        // Copy data to temp arrays
        for (i = 0; i < n1; ++i)
            L[i] = arr[l + i];
        for (j = 0; j < n2; ++j)
            R[j] = arr[m + 1 + j];
 
        // Merge the temp arrays
 
        // Initial indexes of first
        // and second subarrays
        i = 0;
        j = 0;
 
        // Initial index of merged
        // subarray array
        int k = l;
        while (i < n1 && j < n2) {
            if (string.Compare(L[i], R[j]) <= 0) {
                arr[k] = L[i];
                i++;
            }
            else {
                arr[k] = R[j];
                j++;
            }
            k++;
        }
 
        // Copy remaining elements
        // of L[] if any
        while (i < n1) {
            arr[k] = L[i];
            i++;
            k++;
        }
 
        // Copy remaining elements
        // of R[] if any
        while (j < n2) {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

}


