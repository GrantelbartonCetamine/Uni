using System;
using static EscapeRoom;

class Game
{
    static EscapeRoom escapeRoom = EscapeRoom.Instance;
    static EscapeRoom.Manager Manager = new EscapeRoom.Manager();

    public void Start()
    {
        EscapeRoom.Manager.HandleMapSize(); 
        Manager.InitialzeMap();
        Manager.SetPlayerToMap();
        Manager.SetKeytoMap();
        Manager.SetDoortoMap();
        HandlePlayerMovement();
    }


    // Show Map in Console
    static void PrintMap()
    {
        for (int x = 0; x < EscapeRoom.Height; x++)
        {
            for (int y = 0; y < EscapeRoom.Width; y++)
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

    // Rules the Movement for the Player
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
                    UpdatePlayerPosition(0, -1);
                    break;


                case ConsoleKey.UpArrow:
                case ConsoleKey.NumPad8:
                case ConsoleKey.W:
                    UpdatePlayerPosition(-1, 0);
                    break;


                case ConsoleKey.RightArrow:
                case ConsoleKey.NumPad6:
                case ConsoleKey.D:
                    UpdatePlayerPosition(0, +1);
                    break;


                case ConsoleKey.DownArrow:
                case ConsoleKey.NumPad2:
                case ConsoleKey.S:
                    UpdatePlayerPosition(+1, 0);
                    break;


            }

            Manager.CheckforKey();
            Console.Clear();
            PrintMap();
        }
    }
    // Update the Position of the Player 
    static void UpdatePlayerPosition(int HorizontalX, int VerticalY)
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
}
