using System;
class GameLogic 
{
    Random rnd = new Random();

    public MonsterBase player1;
    public MonsterBase player2;

    int MaxValue = 100;
    int MinValue = 1;

    public char userchoice { get; set; }

    static void Main()
    {
        var gamelogic = new GameLogic();
        gamelogic.StartGame();
    }

    public MonsterBase AssignAttributes(string MonsterType)
    {
        int health = GetUserInt("Enter Health: " , MinValue, MaxValue);
        int defensepoints = GetUserInt("Enter Defensepoints: ", MinValue, MaxValue);
        int attackspeed = GetUserInt("Enter Attackspeed: ", MinValue, MaxValue);
        int attack = GetUserInt("Enter Attack Damage: ", MinValue, MaxValue);
        int specialability = GetUserInt("Enter Special Ability Damage: ", MinValue, MaxValue);

        switch (MonsterType)
        {
            case "Ork":
                return new Ork(health, defensepoints, attackspeed, attack, specialability);

            case "Goblin":
                return new Goblin(health, defensepoints, attackspeed, attack, specialability);

            case "Archer":
                return new Archer(health, defensepoints, attackspeed, attack, specialability);

            case "Troll":
                return new Troll(health, defensepoints, attackspeed, attack, specialability);

            default:
                throw new ArgumentException("Error");
        }
    }

    public void StartGame()
    {
        Console.WriteLine("Choose your character:");
        Console.WriteLine("Available Classes: Ork(1), Troll(2), Goblin(3), Archer(4)");

        while (player1 == null)
        {
            var userChoice = Console.ReadKey();
            Console.WriteLine();

            switch (userChoice.KeyChar)
            {
                case '1':
                    Console.WriteLine("You choose Ork.");
                    player1 = AssignAttributes("Ork");
                    break;

                case '2':
                    Console.WriteLine("You chose Troll.");
                    player1 = AssignAttributes("Troll");
                    break;

                case '3':
                    Console.WriteLine("You chose Goblin.");
                    player1 = AssignAttributes("Goblin");
                    break;

                case '4':
                    Console.WriteLine("You chose Archer.");
                    player1 = AssignAttributes("Archer");
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    continue;
            }

            if (player1 != null)
            {
                break;
            }
        }
        player2 = RandomOponent();

        Console.WriteLine($"Youre Opponent is {player2}");
        Check(player2);

        Fight(player1, player2);
    }

    public MonsterBase RandomOponent()
    {
        var opponents = new List<MonsterBase>()
    {
        new Ork(100, 30, 5, 25, 10),
        new Archer(100, 5, 40, 15, 5),
        new Troll(100, 40, 5, 11, 11)
    };

        MonsterBase opponent;
        do
        {
            opponent = opponents[rnd.Next(opponents.Count)];  
        }
        while (opponent.GetType() == player1.GetType()); 

        return opponent; 
    }

    void Check(MonsterBase player2)
    {
        if (player2 is Archer)
        {
            Console.WriteLine($"Archer have {player2.DefensePoints} DefensePoints");
        }
        else if (player2 is Ork)
        {
            Console.WriteLine($"Ork have {player2.DefensePoints} DefensePoints");
        }

        else if (player2 is Troll)
        {
            Console.WriteLine($"Troll have {player2.DefensePoints} DefensePoints");
        }
    }

    public int BaseDamage(MonsterBase attacker, MonsterBase target)
    {

        int baseDamage = attacker.Attack  + (int)attacker.AttackSpeed - target.DefensePoints;
        if (baseDamage <= 0)
        {
            baseDamage = 1;
        }

        return baseDamage;
    }
    public int SpecialDamage(MonsterBase attacker, MonsterBase target)
    {

        int specialDamage = attacker.SpecialAbility + (int)attacker.AttackSpeed - target.DefensePoints;

        if (specialDamage <= 0)
        {
            specialDamage = 1;
        }
        return specialDamage;
    }

    public void Fight(MonsterBase player1, MonsterBase player2)
    {
        Console.WriteLine($"Fight between {player1} and {player2} begins!");
        while (player1.HealthPoints > 0 && player2.HealthPoints > 0)
        {
            Console.WriteLine("Choose an action: Attack(1) or Use Special Ability(2)");
            string userChoice = Console.ReadLine();

            int damage = 0;
            if (userChoice == "1")
            {
                damage = BaseDamage(player1, player2);
                player2.HealthPoints -= damage;
                Console.WriteLine($"You Attacked , {player2} has {player2.HealthPoints} HP left.");

                player1.HealthPoints -= damage;
                Console.WriteLine($"Enemy {player2} attacks {player1} and deals {damage} damage.");
                Console.WriteLine($"Enemy {player2} has {player2.HealthPoints} HP left.");
            }
            else if (userChoice == "2")
            {
                damage = SpecialDamage(player1, player2);
                player2.HealthPoints -= damage;
                Console.WriteLine($"You Attacked , {player2} has {player2.HealthPoints} HP left.");

                player1.HealthPoints -= damage;
                Console.WriteLine($"Enemy {player2} attacks {player1} and deals {damage} damage.");
                Console.WriteLine($"Enemy {player2} has {player2.HealthPoints} HP left.");
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }

            if (player2.HealthPoints <= 0)
            {
                Console.WriteLine($"{player2} has been defeated! {player1} wins the fight!");
                break;
            }
            if (player1.HealthPoints <= 0)
            {
                Console.WriteLine($"{player1} has been defeated! {player2} wins the fight!");
                Environment.Exit(0);
            }


        }
    }

    public int GetUserInt(string arg , int MinValue , int MaxValue)
    {
        while (true)
        {
            Console.Write(arg);
            if (int.TryParse(Console.ReadLine(), out int result))
            
            if (result >= MinValue && result <= MaxValue)

                    return result;

            else

                Console.Write("Try Again : ");

        }
    }

    public int GetUserFloat(string arg, int MinValue, int MaxValue)
    {
        while (true)
        {
            Console.Write(arg);
            if (int.TryParse(Console.ReadLine(), out int result))

                if (result >= MinValue && result <= MaxValue)

                    return result;

                else

                    Console.Write("Try Again : ");

        }
    }
}
