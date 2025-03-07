class Program 
{
    static void Main()
    {

        Console.WriteLine("Choose input method (1 for manual, 2 for random):");
        int choice = int.Parse(Console.ReadLine());

        Vector XVector, YVector;

        if (choice == 1)
        {
            // Manual Input
            List<int> inputX = InputHandler.GetManualInput();
            List<int> inputY = InputHandler.GetManualInput();

            // X Y and Z As coordinates
            XVector = new Vector(inputX[0], inputX[1], inputX[2]);
            YVector = new Vector(inputY[0], inputY[1], inputY[2]);
        }
        else
        {
            // Random Input
            List<int> inputX = InputHandler.GetRandomInput();
            List<int> inputY = InputHandler.GetRandomInput();

            // X Y and Z As coordinates
            XVector = new Vector(inputX[0], inputX[1], inputX[2]);
            YVector = new Vector(inputY[0], inputY[1], inputY[2]);
        }

        Console.WriteLine($"First Vector: {XVector}, Second Vector: {YVector}");

        // Addition
        Console.WriteLine($"Addition: {XVector + YVector}");

        // Subtraktion
        Console.WriteLine($"Subtraction: {XVector - YVector}");

        // Multiplikation with a Skalar
        Console.WriteLine($"Multiplication with scalar: {XVector * 4}");

        // DistnaceComputing
        Console.WriteLine($"Distance between XVector and YVector: {XVector.Distance(YVector)}");

        // Lenght Computing
        Console.WriteLine($"Length of XVector: {XVector.Lenght()}");

        // Sqrt Lenght Computing
        Console.WriteLine($"Squared Length of XVector: {XVector.SquaredLenght()}");
    }
}
