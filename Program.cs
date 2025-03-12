class SortingAlgorhytms
{   
    public static void BubbleGum(List<int> myList, bool descending)
    {
        bool isSorted;
        do
        {
            isSorted = true;
            for (int i = 0; i < myList.Count - 1; i++)
            {
                if ((descending && myList[i] > myList[i + 1]) || (!descending && myList[i] > myList[i + 1]))
                {
                    int PlaceHolder = myList[i];
                    myList[i] = myList[i + 1];
                    myList[i + 1] = PlaceHolder;
                    isSorted = false;
                }
            }
        } while (!isSorted);
    }
    public static void QuickSortAlgo(List<int> list, int low, int high, bool descending)
    {
        if (low < high)
        {
            int index = Decision(list, low, high);
            QuickSortAlgo(list, low, index - 1, descending);
            QuickSortAlgo(list, index + 1, high, descending);
        }

        if (descending)
        {
            ReverseSortOrder(list);
        }
    }

    public static void ReverseSortOrder(List<int> list)
    {
        int firstIndex = 0;
        int lastIndex = list.Count - 1;

        int temp = list[firstIndex];
        list[firstIndex] = list[lastIndex];
        list[lastIndex] = temp;

        firstIndex++;
        lastIndex--;
    }
    public static int Decision(List<int> list, int low, int high)
    {
        int boundary = list[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {

            if (list[j] <= boundary)
            {
                i++;
                int placeholder = list[i];
                list[i] = list[j];
                list[j] = placeholder;
            }
        }
        int temp = list[i + 1];
        list[i + 1] = list[high];
        list[high] = temp;
        return i + 1;
    }

    public static List<int> ZickZackSort(List<int> list)
    {
        List<int> zickZackList = new List<int>();
        list.Sort();

        while (list.Count > 0)
        {
            zickZackList.Add(list[list.Count() - 1]);
            list.RemoveAt(list.Count() - 1);

            if (list.Count > 0)
            {
                zickZackList.Add(list[0]);
                list.RemoveAt(0);
            }
        }
        return zickZackList;
    }

    public static List<int> MergeSort(List<int> list, bool descending)
    {
        if (list.Count <= 1)
            return list;

        int midSort = list.Count / 2;
        List<int> left = list.GetRange(0, midSort);
        List<int> right = list.GetRange(midSort, list.Count - midSort);

        left = MergeSort(left, descending);
        right = MergeSort(right, descending);

        List<int> sortedList = Merging(left, right);
        if (descending)
        {
            ReverseSortOrder(list);
        }

        return sortedList;
    }

    public static List<int> Merging(List<int> left, List<int> right)
    {
        List<int> result = new List<int>();
        int i = 0, j = 0;

        while (i < left.Count && j < right.Count)
        {
            if (left[i] < right[j])
            {
                result.Add(left[i]);
                i++;
            }
            else
            {
                result.Add(right[j]);
                j++;
            }
        }

        while (i < left.Count)
        {
            result.Add(left[i]);
            i++;
        }

        while (j < right.Count)
        {
            result.Add(right[j]);
            j++;
        }

        return (result);
    }
}
