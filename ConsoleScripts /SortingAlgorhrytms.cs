class SortierAlgorhytmen
{
    static void Main()
    {
        Manager manager = new Manager();
        manager.Initialize();
        manager.Sorting();
    }
    class Manager
    {

        private List<int> Numbers = new List<int>();
        public void Initialize()
        {
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

            switch (userInput)
            {
                case "1":
                    Algorhytms.BubbleGum(Numbers, descending);
                    break;

                case "2":
                    Algorhytms.QuickSortAlgo(Numbers, 0, Numbers.Count - 1, descending);
                    break;

                case "3":
                    Algorhytms.MergeSort(Numbers, descending);
                    break;

                case "4":
                    Algorhytms.ZickZackSort(Numbers);
                    break;

                default:
                    Console.WriteLine("Wrong Input");
                    break;
            }
            Console.WriteLine("Sorted Numbers : ");
            foreach (var numbers in Numbers)
            {
                Console.WriteLine(numbers);
            }
        }
        

    }

    public static bool SortOrder()
    {
        Console.WriteLine("Do you Want do Sort Ascending '1' or Descending '2' ");
        string orderChoice = Console.ReadLine();

        while (orderChoice != "1" && orderChoice != "2")
        {
            Console.WriteLine("Sorry wrong Input");
            orderChoice = Console.ReadLine();
        }
        return orderChoice == "2";
    }

    class Algorhytms
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
                list.Reverse();
            }
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
            if (descending) sortedList.Reverse();

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
}

