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

    static List<int> InitializeRandomNumbers()   // Give a list with Inputet Numbers Back
    {
        List<int> Numbers = new List<int>();
        Console.WriteLine("Enter numbers (type 'exit' to finish):");

        while (true)
        {
            string UserInput = Console.ReadLine();
            if (UserInput.ToLower() == "exit")
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
                if (MyList[i] > MyList[i + 1]) // checks if the next index is bigger then my current index
                {
                    int PlaceHolder = MyList[i];
                    MyList[i] = MyList[i + 1]; // checks if the next index is bigger then my current index
                    MyList[i + 1] = PlaceHolder; // 
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

    static void Decide(List<int> numbers)
    {

        Console.WriteLine("Choose between an Algorithm (1 for BubbleGum, 2 for QuickSort):");
        string userinput = Console.ReadLine();
        if (userinput == "1")
        {
            BubbleGum(numbers);
        }
        else if (userinput == "2")

        {
            QuickSortAlgo(numbers, 0, numbers.Count - 1);
        }

        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}
