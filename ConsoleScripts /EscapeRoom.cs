using System;
class EscapeRoom
{
    static int Height;
    static int Width;
    static int PlayerX = 2;
    static int PlayerY = 2;
    static int KeyX = 0;
    static int KeyY = 0;
    static int DoorX = 0;
    static int DoorY = 0;
    static bool HasKey = false;
    static Random Random = new Random();

    // Manager class handles everything unrelated to gameplay (game logic, initialization)
    class Manager
    {
        public static Manager.ObjectType[,] MapArray;

        // Enum for everything related to the map (walls, player, key, etc.)
        public enum ObjectType
        {
            Ground,
            Wall,
            Player,
            Door,
            Key
        }

        //Let User Set Prefered Map Size
        public static void HandleMapSize()
        {
            {
                Console.WriteLine("Before you can Play Enter youre Prefered Map Size Recomended size : (20,20)");
                while (true)
                {
                    Console.WriteLine("Height: ");
                    string userInput = Console.ReadLine();
                    if (int.TryParse(userInput, out Height) && Height >= 5)
                    {
                        Console.WriteLine($"Set Map height to {Height}");
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
                    if (int.TryParse(userInput, out Width) && Width >= 5)
                    {
                        Console.WriteLine($"Set Map width to {Width}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid width.");
                    }
                }
            }
        }

        // Put the Player to the map
        public static void SetPlayertoMap()
        {
            PlayerX = Random.Next(1, Height - 1);
            PlayerY = Random.Next(1, Width - 1);
            MapArray[PlayerX, PlayerY] = ObjectType.Player;
        }

        public static void SetKeytoMap()
        {
            do
            {
                KeyX = Random.Next(1, Height - 1);
                KeyY = Random.Next(1, Width - 1);

            } while (MapArray[KeyX, KeyY] != ObjectType.Ground);

            MapArray[KeyX, KeyY] = ObjectType.Key;
        }

        public static void SetDoortoMap()
        {
            int randomWall = Random.Next(4);


            if (randomWall == 0)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" ");
                DoorX = 0;
                DoorY = Random.Next(1, Width - 1);
                Console.ResetColor();
            }
            else if (randomWall == 1)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" ");
                DoorX = Height - 1;
                DoorY = Random.Next(1, Width - 1);
                Console.ResetColor();
            }
            else if (randomWall == 2)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" ");
                DoorX = Random.Next(1, Height - 1);
                DoorY = Width - 1;
                Console.ResetColor();
            }
            else if (randomWall == 3)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" ");
                DoorX = Random.Next(1, Height - 1);
                DoorY = Height - 1;
                Console.ResetColor();
            }
            MapArray[DoorX, DoorY] = ObjectType.Door;
        }

        // Handle the Logic for the Maze , if Player has key and touch the door the Player has Won
        public static void WinLogic()
        {
            if (PlayerX == DoorX && PlayerY == DoorY && HasKey == true)
            {
                Console.WriteLine("Congratulations! You've found the door and escaped!");
                Environment.Exit(0);
            }
        }


        //Check if Player Collected the Key
        public static void CheckforKey()
        {
            if (MapArray[PlayerX, PlayerY] == ObjectType.Key)
            {
                HasKey = true;
                Console.WriteLine("You Collected the Key");
                MapArray[PlayerX, PlayerY] = ObjectType.Ground;
            }
        }
        // Initialze the Map
        public static void InitialzeMap()
        {
            MapArray = new ObjectType[Height, Width];
            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    if (x == 0 || x == Height - 1 || y == 0 || y == Width - 1)
                    {
                        MapArray[x, y] = ObjectType.Wall;
                    }
                    else
                    {
                        MapArray[x, y] = ObjectType.Ground;
                    }
                }
            }
        }
    }

    class Informations
    {   // Greet Player and Explain Controlls
        public static void PlayerGreeting()
        {
            Console.Write("You can Press W for going Forward\nA for going Left\nS for going Back \nAnd D for going to the Right");
            Console.WriteLine("Or you can use Numpad or Arrow buttons");
            Console.WriteLine("This is a EscapeRoom \nThe Goal is to find the Exit Good Luck");
        }
    }


    // Class Just for the Game for Handling to Show the Map in Console or the Movement
    class Game
    {
        static void PrintMap()
        {
            for (int x = 0; x < Height; x++)
            {
                for (int y = 0; y < Width; y++)
                {
                    switch (Manager.MapArray[x, y])
                    {
                        case Manager.ObjectType.Ground:
                            Console.BackgroundColor = ConsoleColor.DarkMagenta;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(" ");
                            Console.ResetColor();
                            break;

                        case Manager.ObjectType.Player:
                            Console.Write("P");
                            break;

                        case Manager.ObjectType.Wall:
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.Write(" ");
                            Console.ResetColor();
                            break;

                        case Manager.ObjectType.Door:
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.Write("D");
                            Console.ResetColor();
                            break;

                        case Manager.ObjectType.Key:
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

            if (newPlayerPositionX < 0 || newPlayerPositionX >= Height ||
                newPlayerPositionY < 0 || newPlayerPositionY >= Width ||
                Manager.MapArray[newPlayerPositionX, newPlayerPositionY] == Manager.ObjectType.Wall)
            {
                return;
            }

            if (Manager.MapArray[newPlayerPositionX, newPlayerPositionY] == Manager.ObjectType.Door && !HasKey)
            {
                return;
            }

            Manager.MapArray[PlayerX, PlayerY] = Manager.ObjectType.Ground;
            PlayerX = newPlayerPositionX;
            PlayerY = newPlayerPositionY;

            Manager.CheckforKey();
            Manager.MapArray[PlayerX, PlayerY] = Manager.ObjectType.Player;
            Manager.WinLogic();
        }

        public static void HandlePlayerMovement()
        {
            Informations.PlayerGreeting();
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

                Manager.CheckforKey();
                Console.Clear();
                PrintMap();
            }
        }
    }
    static void Main()
    {
        Manager.HandleMapSize();
        Manager.InitialzeMap();
        Manager.SetPlayertoMap();
        Manager.SetKeytoMap();
        Manager.SetDoortoMap();
        Game.HandlePlayerMovement();
    }


}
