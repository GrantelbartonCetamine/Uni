using System;
using System.Collections.Generic;

class SortierAlgorhytmen
{
    static void Main()
    {
        InitializeRandomNumbers();
        AscendingAlgo();
    }

    static List<int> InitializeRandomNumbers()
    {

        List<int> Numbers = new List<int>();
        Console.WriteLine($"Enter Some Numbers");

        while (true)
        {
            string UserInput = Console.ReadLine();
            if (UserInput == null)
            {
                Console.WriteLine("Please Enter a Valid Number");
                continue;
            }
            else if (int.TryParse(UserInput, out int numbers))
            {

                Numbers.Add(numbers);
                Console.WriteLine($"Added number {numbers} to List");

                foreach (int i in Numbers)
                {
                    Console.WriteLine($"List : {i}");
                }
            }
        }
        return Numbers;
    }

    static void AscendingAlgo(List<int> MyList)
    {   


        do 
        for (int i = 0 ; i < MyList.Count - 1; i++)
        {
            for (int a = 0; a < MyList.Count - i; a++)
            {
                if (MyList[a] > MyList[a + 1])
                {
                    int PlaceHolder = MyList[a];
                    MyList[a] = MyList[j + 1];
                    MyList[j + 1] = PlaceHolder;

                }
            }
        }while (true);

    }

}




