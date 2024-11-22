using System;


class MonsterFight
{
    public class MonsterBase
    {
        public int HealthPoints { get; set; }
        public int DefensePoints { get; set; }
        public float AttackSpeed { get; set; }
        public int Attack { get; set; }
        public int SpecialAbility { get; set; }

        public MonsterBase(int health, int defensepoints, float attackspeed, int attack, int specialability)
        {

            HealthPoints = health;
            DefensePoints = defensepoints;
            AttackSpeed = attackspeed;
            Attack = attack;
            SpecialAbility = specialability;

        }

        public override string ToString() => "Monster";
    }

    public class Ork : MonsterBase
    {
        public Ork(int health, int defensepoints, float attackspeed, int attack, int specialability)
            : base(health, defensepoints, attackspeed, attack, specialability)
        {

        }
    }

    public class Goblin : MonsterBase
    {
        public Goblin(int health, int defensepoints, float attackspeed, int attack, int specialability)
            : base(health, defensepoints, attackspeed, attack, specialability)
        {

        }

    }

    public class Archer : MonsterBase
    {
        public Archer(int health, int defensepoints, float attackspeed, int attack, int specialability)
            : base(health, defensepoints, attackspeed, attack, specialability)
        {

        }

    }

    public class Troll : MonsterBase
    {
        public Troll(int health, int defensepoints, float attackspeed, int attack, int specialability)
            : base(health, defensepoints, attackspeed, attack, specialability)
        {

        }

    }
}


class GameLogic : MonsterFight
{
    Random rnd = new Random();
    bool run = true;

    public MonsterBase player1;
    public MonsterBase player2;

    public char userchoice { get; set; }

    static void Main()
    {
        var gamelogic = new GameLogic();
        gamelogic.StartGame();
    }

    public MonsterBase AssignAttributes(string MonsterType)
    {
        int health = GetUserInt("Enter Health: ");
        int defensepoints = GetUserInt("Enter Ap: ");
        int attackspeed = GetUserInt("Enter Abwehrpunkte: ");
        float attackSpeed = GetUserFloat("Enter AttackSpeed: ");
        int attack = GetUserInt("Enter Attack Damage: ");
        int specialability = GetUserInt("Enter Special Ability Damage: ");

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

        Fight(player1, player2);
    }

    public MonsterBase RandomOponent()
    {
        var opponents = new List<MonsterBase>()
            {
                new Ork(100, 100, 5, 25, 10),           // + 10% AttackDamage)                                                               
                new Archer(100, 100, 40, 15, 5),       //Stärkerer Schuss + 5% AttackDamage)
                new Troll(100, 100, 5, 11 , 11)         // + 11% AttackDamage)
            };
        int choice = rnd.Next(opponents.Count);

        return opponents[choice];
    }

    static void Fight(MonsterBase player1, MonsterBase player2)
    {
        Console.WriteLine($"Fight between {player1} and {player2} begins!");

        while (player1.HealthPoints > 1 || player2.HealthPoints > 1)
        {
            Console.WriteLine("Choose an action: Attack(1) or Use Special Ability(2)");
            string userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                int damageToOpponent = player1.Attack - player2.DefensePoints;
                damageToOpponent = Math.Max(damageToOpponent, 0);

                Console.WriteLine($"{player1} attacks {player2} and deals {damageToOpponent} damage to {player2}.");
                player2.HealthPoints -= damageToOpponent;
            }
            else if (userChoice == "2")
            {
                int specialDamage = player1.SpecialAbility - player2.DefensePoints;
                specialDamage = Math.Max(specialDamage, 0);

                Console.WriteLine($"{player1} uses their special ability on {player2} and deals {specialDamage} damage.");
                player2.HealthPoints -= specialDamage;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }

            Console.WriteLine($"{player2} has {player2.HealthPoints} HP left.");

            if (player2.HealthPoints <= 0)
            {
                Console.WriteLine($"{player2} has been defeated! {player1} wins the fight!");
                break;
            }

            int damageToPlayer = player2.Attack - player1.DefensePoints;
            damageToPlayer = Math.Max(damageToPlayer, 0);

            Console.WriteLine($"{player2} attacks {player1} and deals {damageToPlayer} damage.");
            player1.HealthPoints -= damageToPlayer;

            Console.WriteLine($"{player1} has {player1.HealthPoints} HP left.");

            if (player1.HealthPoints <= 0)
            {
                Console.WriteLine($"{player1} has been defeated! {player2} wins the fight!");
                break;
            }
        }
    }

    public int GetUserInt(string arg)
    {
        while (true)
        {
            Console.Write(arg);
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else
            {
                Console.Write("Only numbers are allowed. ");
            }
        }
    }

    public float GetUserFloat(string arg)
    {
        while (true)
        {
            Console.Write(arg);
            if (float.TryParse(Console.ReadLine(), out float result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
}
