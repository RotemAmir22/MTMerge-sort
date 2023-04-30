using System.Threading;

public class MTMergeSort
{
    static void Main(string[] args)
    {
        string[] arr = { "3", "5", "1", "7", "4", "9", "8", "6", "2" };
        arr = MergeSort(arr);
        Console.WriteLine(string.Join(",", arr));
    }


    public List<string> MergeSort(string[] strList, int nMin = 2)
    {
        if (strList.Length < nMin) 
        {
            Merge(strList, strList, string[]);
            List<string> list = strList.ToList();
            return list;
        }


        int mid = strList.Length / 2;

        // create left and right sub-arrays
        string[] left = new int[mid];
        string[] right = new int[strList.Length - mid];
        Array.Copy(strList, 0, left, 0, mid);
        Array.Copy(strList, mid, right, 0, strList.Length - mid);

        // create threads to sort each sub-array
        Thread leftThread = new Thread(() => MergeSort(left));
        Thread rightThread = new Thread(() => MergeSort(right));

        // start threads and wait for them to complete
        leftThread.Start();
        rightThread.Start();
        leftThread.Join();
        rightThread.Join();

        // merge the sorted sub-arrays
        Merge(strList, left, right);
        
        
    }

    static void Merge(string[] arr, string[] left, string[] right) 
    {
        int i = 0, j = 0, k = 0;

        // merge left and right sub-arrays into arr
        while (i < left.Length && j < right.Length) 
        {
            if (left[i] < right[j]) {
                arr[k++] = left[i++];
            } else {
                arr[k++] = right[j++];
            }
        }

        // copy any remaining elements from left and right
        while (i < left.Length) 
        {
            arr[k++] = left[i++];
        }
        while (j < right.Length) 
        {
            arr[k++] = right[j++];
        }
    }

    
}


