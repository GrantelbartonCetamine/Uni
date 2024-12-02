using System;
using System.Collections.Generic;

class SortierAlgorhytmen
{
    List<int> Numbers = new List<int> { 10 };

    static void Main()
    {
        RandomNumbers();
    }

    static void RandomNumbers()
    {

        List<int> Numbers = new List<int>();
        Console.WriteLine($"Enter Some Numbers");

        while (true)
        {
            string UserInput = Console.ReadLine();
            if (UserInput == null)
            {
                Console.WriteLine("Please Enter a Valid Number");
                return;
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

    }

}



