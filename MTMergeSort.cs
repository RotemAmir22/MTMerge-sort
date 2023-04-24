import Thread;

public class MTMergeSort
{
        public List<(string t)> MergeSort(string[] strList, int nMin = 2)
    {
        int l = strList[0];
        int r = strList.Length - 1;
        int mid = (l + r) / 2;
        // create new threads
        Thread leftSide = new Thread(mergeSort(strList, l, mid));
        Thread rightSide = new Thread(mergeSort(strList, mid + 1, r));
        // run the threads
        leftSide.Start();
        rightSide.Start();
        leftSide.Join();
        rightSide.Join();
        Merge(strList,l, mid,r);
        
    }

    static void mergeSort(string[] A, int l, int r)
    {
        if (A.Length < 2 || l > r)
            return;
        int m = (l + r) / 2;
        // create new threads
        Thread leftSide = new Thread(mergeSort(strList, l, m));
        Thread rightSide = new Thread(mergeSort(strList, m + 1, r));
        // run the threads
        leftSide.Start();
        rightSide.Start();
        leftSide.Join();
        rightSide.Join();

    }

    static void Merge(string[] A, int l, int m, int r)
    {
        // Create L ← A[p..q] and M ← A[q+1..r]
        int n1 = m - l + 1;
        int n2 = r - m;

        int L[n1], M[n2];

        for (int i = 0; i < n1; i++)
            L[i] = arr[l + i];
        for (int j = 0; j < n2; j++)
            M[j] = arr[m + 1 + j];

        // Maintain current index of sub-arrays and main array
        int i, j, k;
        i = 0;
        j = 0;
        k = l;

        // Until we reach either end of either L or M, pick larger among
        // elements L and M and place them in the correct position at A[p..r]
        while (i < n1 && j < n2)
        {
            if (L[i] <= M[j])
            {
                arr[k] = L[i];
                i++;
            }
            else
            {
                arr[k] = M[j];
                j++;
            }
            k++;
        }

        // When we run out of elements in either L or M,
        // pick up the remaining elements and put in A[p..r]
        while (i < n1)
        {
            arr[k] = L[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            arr[k] = M[j];
            j++;
            k++;
        }

    }


