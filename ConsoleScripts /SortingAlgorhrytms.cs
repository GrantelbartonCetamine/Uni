using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System.Collections;

class SortierAlgorhytmen
{

    static void Main()
    {
        List<int> numbers = InitializeRandomNumbers();
        Decide(numbers);
    }

    static List<int> InitializeRandomNumbers()
    {
        List<int> Numbers = new List<int>();
        Console.WriteLine("Enter numbers (type 'Next' to finish):");

        while (true)
        {
            string UserInput = Console.ReadLine();
            if (UserInput.ToLower() == "next")
            {
                break;
            }
            else if (int.TryParse(UserInput, out int number))
            {
                Numbers.Add(number);
                Console.WriteLine($"Added number {number} to the list.");
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
        return Numbers;
    }

    static void BubbleGum(List<int> MyList)
    {
        bool isSorted;
        do
        {
            isSorted = true;
            for (int i = 0; i < MyList.Count - 1; i++)
            {
                if (MyList[i] > MyList[i + 1])
                {
                    int PlaceHolder = MyList[i];
                    MyList[i] = MyList[i + 1];
                    MyList[i + 1] = PlaceHolder;
                    isSorted = false;
                }
            }
        } while (!isSorted);
    }


    static void QuickSortAlgo(List<int> list, int low, int high)
    {
        if (low < high)
        {
            int index = Decision(list, low, high);
            QuickSortAlgo(list, low, index - 1);
            QuickSortAlgo(list, index + 1, high);

        }
    }

    static int Decision(List<int> list, int low, int high)
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

    static List<int> MergeSort(List<int> list)
    {
        if (list.Count <= 1)
            return list;

        int midSort = list.Count / 2;
        List<int> left = list.GetRange(0, midSort);
        List<int> right = list.GetRange(midSort, list.Count - midSort);

        left = MergeSort(left);
        right = MergeSort(right);

        return Merging(left, right);

    }
    static List<int> Merging(List<int> left, List<int> right)
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

        return result;
    }


    static void Decide(List<int> numbers)
    {

        Console.WriteLine("Choose between an Algorithm (1 for BubbleGum , 2 for QuickSort , 3 for MergeSort):");
        string userinput = Console.ReadLine();
        if (userinput == "1")
        {
            BubbleGum(numbers);
        }
        else if (userinput == "2")

        {
            QuickSortAlgo(numbers, 0, numbers.Count - 1);
        }

        else if (userinput == "3")

        {
            List<int> sortedNumbers = MergeSort(numbers); 
            numbers.Clear(); 
            numbers.AddRange(sortedNumbers); 
        }

        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
