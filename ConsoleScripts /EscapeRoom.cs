
using System;
class EscapeRoom
{
    static int height;
    static int width;
    static int PlayerX = 2;
    static int PlayerY = 2;
    static int KeyX = 0;
    static int KeyY = 0;
    static int DoorX = 0;
    static int DoorY = 0;
    static bool haskey = false;
    static Random random = new Random();
    enum ObjectType
    {
        Ground,
        Wall,
        Player,
        Door,
        Key,
    }
    static ObjectType[,] mapArray;
    static void Main()
    {
        var random = new Random();
        HandleMapSize();
        InitialzeMap();
        SetDoortoMap();
        SetKeytoMap();
        SetPlayertoMap();
        CheckforKey();
        PrintMap();
        WinLogic();
        HandlePlayerMovement();
    }
    static void PlayerGreeting()
    {
        Console.WriteLine("This is a EscapeRoom \nThe Goal is to find the Exit");
    }
    static void HandleMapSize()
    {
        {
            Console.WriteLine("Before you can Play Enter youre Prefered Map Size Recomended size : (20,20)");
            while (true)
            {
                Console.WriteLine("Height: ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out height) && height >= 5)
                {
                    Console.WriteLine($"Set Map height to {height}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid height.");
                }
            }
            while (true)
            {
                Console.WriteLine("Width: ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out width) && width >= 5)
                {
                    Console.WriteLine($"Set Map width to {width}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid width.");
                }
            }
        }
    }
    static void SetPlayertoMap()
    {
        PlayerX = random.Next(1, height - 1);
        PlayerY = random.Next(1, width - 1);
        mapArray[PlayerX, PlayerY] = ObjectType.Player;
    }
    static void SetKeytoMap()
    {
        do
        {
            KeyX = random.Next(1, height - 1);
            KeyY = random.Next(1, width - 1);

        } while (mapArray[KeyX, KeyY] != ObjectType.Ground);

        mapArray[KeyX, KeyY] = ObjectType.Key;
    }
    static void SetDoortoMap()
    {
        int randomwall = random.Next(4);


        if (randomwall == 0)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ");
            DoorX = 0;
            DoorY = random.Next(1, width - 1);
            Console.ResetColor();
        }
        else if (randomwall == 1)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ");
            DoorX = height - 1;
            DoorY = random.Next(1, width - 1);
            Console.ResetColor();
        }
        else if (randomwall == 2)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ");
            DoorX = random.Next(1, height - 1);
            DoorY = width - 1;
            Console.ResetColor();
        }
        else if (randomwall == 3)
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ");
            DoorX = random.Next(1, height - 1);
            DoorY = height - 1;
            Console.ResetColor();
        }
        mapArray[DoorX, DoorY] = ObjectType.Door;
    }
    static void WinLogic()
    {
        if (PlayerX == DoorX && PlayerY == DoorY && haskey == true)
        {
            Console.WriteLine("Congratulations! You've found the door and escaped!");
            Environment.Exit(0);
        }
    }
    static void CheckforKey()
    {
        if (mapArray[PlayerX, PlayerY] == ObjectType.Key)
        {
            haskey = true;
            Console.WriteLine("You Collected the Key");
            mapArray[PlayerX, PlayerY] = ObjectType.Ground;
        }
    }

    static void InitialzeMap()
    {
        mapArray = new ObjectType[height, width];
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                if (x == 0 || x == height - 1 || y == 0 || y == width - 1)
                {
                    mapArray[x, y] = ObjectType.Wall;
                }
                else
                {
                    mapArray[x, y] = ObjectType.Ground;
                }
            }
        }
    }
    static void PrintMap()
    {
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                switch (mapArray[x, y])
                {
                    case ObjectType.Ground:
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" ");
                        Console.ResetColor();
                        break;
                    case ObjectType.Player:
                        Console.Write("P");
                        break;
                    case ObjectType.Wall:
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(" ");
                        Console.ResetColor();
                        break;
                    case ObjectType.Door:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("D");
                        Console.ResetColor();
                        break;
                    case ObjectType.Key:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("K");
                        Console.ResetColor();
                        break;
                }
            }
            Console.WriteLine();
        }
    }
    static void PlayerMoved(int HorizontalX, int VerticalY)
    {
        int newPlayerPositionX = PlayerX + HorizontalX;
        int newPlayerPositionY = PlayerY + VerticalY;

        if (newPlayerPositionX < 0 || newPlayerPositionX >= height ||
            newPlayerPositionY < 0 || newPlayerPositionY >= width ||
            mapArray[newPlayerPositionX, newPlayerPositionY] == ObjectType.Wall)
        {
            return;
        }

        if (mapArray[newPlayerPositionX, newPlayerPositionY] == ObjectType.Door && !haskey)
        {
            Console.WriteLine("You need the key to open the door!");
            return;
        }

        mapArray[PlayerX, PlayerY] = ObjectType.Ground;
        PlayerX = newPlayerPositionX;
        PlayerY = newPlayerPositionY;

        CheckforKey();
        mapArray[PlayerX, PlayerY] = ObjectType.Player;
        WinLogic();
    }

    static void HandlePlayerMovement()
    {
        Console.Write("You can Press W for going Forward\nA for going Left\nS for going Back \nAnd D for going to the Right");
        Console.WriteLine("\nOr you can use Numpad or Arrow buttons");
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                case ConsoleKey.NumPad4:
                    PlayerMoved(0, -1);
                    break;
                case ConsoleKey.UpArrow:
                case ConsoleKey.NumPad8:
                case ConsoleKey.W:
                    PlayerMoved(-1, 0);
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.NumPad6:
                case ConsoleKey.D:
                    PlayerMoved(0, +1);
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.NumPad2:
                case ConsoleKey.S:
                    PlayerMoved(+1, 0);
                    break;
            }
            CheckforKey();
            Console.Clear();
            PrintMap();
        }
    }
}
