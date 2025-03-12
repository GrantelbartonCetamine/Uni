using System;
using System.Collections.Generic;
using System;


class Manager
{

    private List<int> Numbers = new List<int>();
    public SortingAlgorhytms Algos = new SortingAlgorhytms();

    public void Run()
    {
        Initialize();
        Sorting();
    }
    public void Initialize()
    {
        Console.WriteLine("How You Want to Initialize the numbers ('1' for Manual Or '2' for Random )");
        string choice = Console.ReadLine();
        while (true)
        {
            if (int.TryParse(choice, out int result))

                if (choice == "1")
                {
                    Numbers = InitializeManualNumbers();
                    break;
                }

                else if (choice == "2")
                {
                    Numbers = InitializeRandomNumbers();
                    break;
                }

                else
                {
                    Console.WriteLine("Sorry Wrong Input ");
                    choice = Console.ReadLine();
                }
        }
    }

    private List<int> InitializeManualNumbers()
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
    public List<int> InitializeRandomNumbers()
    {
        List<int> numbers = new List<int>();
        Random rnd = new Random();

        Console.WriteLine("How Many Numbers you Want to Generate?");
        int nNumbers = int.Parse(Console.ReadLine());

        for (int i = 0; i < nNumbers; i++)
        {
            numbers.Add(rnd.Next(1, 50));
        }
        Console.WriteLine("Generated Numbers: ");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine($"Generated: {nNumbers} numbers");
        return numbers;
    }

    public void Sorting()
    {
        Console.WriteLine("Choose between an Algorithm (1 for BubbleGum , 2 for QuickSort , 3 for MergeSort , 4 for ZickZackSort):");
        string userInput = Console.ReadLine();
        bool descending = SortOrder();

        if (int.TryParse(userInput, out int number))
        {

            switch (userInput)
            {
                case "1":
                    SortingAlgorhytms.BubbleGum(Numbers, descending);
                    break;

                case "2":
                    SortingAlgorhytms.QuickSortAlgo(Numbers, 0, Numbers.Count - 1, descending);
                    break;

                case "3":
                    SortingAlgorhytms.MergeSort(Numbers, descending);
                    break;

                case "4":
                    SortingAlgorhytms.ZickZackSort(Numbers);
                    break;

                default:
                    Console.WriteLine("Wrong Input");
                    break;
            }
        }

        Console.WriteLine("Sorted Numbers : ");
        foreach (var numbers in Numbers)
        {
            Console.WriteLine(numbers);
        }
    }

    public static bool SortOrder()
    {
        Console.WriteLine("Do you Want do Sort Ascending '1' or Descending '2' ");
        string orderChoice = Console.ReadLine();

        if (int.TryParse(orderChoice, out int number))

        {
            while (orderChoice != "1" && orderChoice != "2")
            {
                Console.WriteLine("Sorry wrong Input");
                orderChoice = Console.ReadLine();
            }

        }
        return orderChoice == "2";
    }
}