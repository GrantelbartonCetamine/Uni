using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System.Collections;

class SortierAlgorhytmen
{

    static void Main()
    {
        List<int> numbers = Initialize();
        Decide(numbers);
    }

    static List<int> Initialize()
    {
        List<int> Numbers = new List<int>();

        Console.WriteLine("How You Want to Initialize the numbers ('1' for Manual Or '2' for Random )");

        string Choice = Console.ReadLine();

        while (true)
        {
            if (Choice == "1")
            {
                Numbers = InitializeManualNumbers();
                break;
            }

            else if (Choice == "2")
            {
                Numbers = InitializeRandomNumbers();
                break;
            }

            else
            {
                Console.WriteLine("Sorry Wrong Input ");
                Choice = Console.ReadLine();
            }

        }

        return Numbers;
    }

    static List<int> InitializeManualNumbers()
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter numbers (type 'Next' to Choose Between an Algorhytm):");

        while (true)
        {
            string userInput = Console.ReadLine();
            if (userInput.ToLower() == "next")
            {
                break;
            }
            else if (int.TryParse(userInput, out int number))
            {
                numbers.Add(number);
                Console.WriteLine($"Added number {number} to the list.");
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }

        return numbers;
    }

    static List<int> ZickZackSort(List<int> list)
    {
        List <int> zickZackList = new List<int>();
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

    static List<int> InitializeRandomNumbers()
    {
        List<int> numbers = new List<int>();
        Random rnd = new Random();

        Console.WriteLine("How Many Numbers you Want to Generate?");
        int nNumbers = int.Parse(Console.ReadLine());

        for (int i = 0; i < nNumbers; i++)
        {
            numbers.Add(rnd.Next(1, 50));
        }
        Console.WriteLine($"Generated : {nNumbers} numbers ");
        return numbers;
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

        return (result) ;
    }



    static void Decide(List<int> numbers)
    {

        Console.WriteLine("Choose between an Algorithm (1 for BubbleGum , 2 for QuickSort , 3 for MergeSort , 4 for ZickZackSort):");
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

        else if (userinput == "4")

        {
            numbers = ZickZackSort(numbers);
        }

        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
