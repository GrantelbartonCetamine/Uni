using System;
public class EscapeRoom
{
    public static int Height;
    public static int Width;
    public static int PlayerX = 2;
    public static int PlayerY = 2;
    public static int KeyX = 0;
    public static int KeyY = 0;
    public static int DoorX = 0;
    public static int DoorY = 0;
    public static bool HasKey = false;
    public static Random Random = new Random();
    public static EscapeRoom Instance { get; } = new EscapeRoom();

    // Manager class handles everything unrelated to gameplay (game logic, initialization)
    public class Manager
    {
        public Manager.ObjectType[,] MapArray;

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
            Console.WriteLine("Before you can Play, enter your preferred map size (Recommended: 20x20)");

            int height, width;

            while (true)
            {
                Console.Write("Height: ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out height) && height >= 5)
                {
                    EscapeRoom.Height = height; 
                    Console.WriteLine($"Set map height to {EscapeRoom.Height}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid height (min. 5).");
                }
            }

            while (true)
            {
                Console.Write("Width: ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out width) && width >= 5)
                {
                    EscapeRoom.Width = width; 
                    Console.WriteLine($"Set map width to {EscapeRoom.Width}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid width (min. 5).");
                }
            }
        }


        // Put the Player to the map
        public void SetPlayerToMap()
        {
            if (Height > 2 && Width > 2)
            {
                PlayerX = Random.Next(1, Height - 1);
                PlayerY = Random.Next(1, Width - 1);
            }
            else
            {
                PlayerX = 1;
                PlayerY = 1;
            }
        }

        // Set the Key to the Map
        public void SetKeytoMap()
        {
            do
            {
                KeyX = Random.Next(1, Height - 1);
                KeyY = Random.Next(1, Width - 1);

            } while (MapArray[KeyX, KeyY] != ObjectType.Ground);

            MapArray[KeyX, KeyY] = ObjectType.Key;
        }



        // Set the Door to the Map
        public void SetDoortoMap()
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
                EscapeRoom.DoorX = Random.Next(1, Height - 1);
                DoorY = Height - 1;
                Console.ResetColor();
            }
            MapArray[DoorX, DoorY] = ObjectType.Door;
        }

        // Handle the Logic for the Maze , if Player has key and touch the door the Player has Won
        public void WinLogic()
        {
            if (PlayerX == DoorX && PlayerY == DoorY && HasKey == true)
            {
                Console.WriteLine("Congratulations! You've found the door and escaped!");
                Environment.Exit(0);
            }
        }


        //Check if Player Collected the Key
        public void CheckforKey()
        {
            if (MapArray[PlayerX, PlayerY] == ObjectType.Key)
            {
                HasKey = true;
                Console.WriteLine("You Collected the Key");
                MapArray[PlayerX, PlayerY] = ObjectType.Ground;
            }
        }



        // Initialze the Map
        public void InitialzeMap()
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
}



