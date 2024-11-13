using System;
using static MonsterFight;

class MonsterFight
{
    public class Ork
    {
        public int Hp;
        public int ap;
        public int abwehrpunkte;
        public float attackSpeed;
        public int attack;
        public int SpecialAbility;

        public Ork(int health, int Ap, int Abwehrpunkte, float AttackSpeed, int Attack, int SpecialAbility)
        {
            Hp = health;
            ap = Ap;
            abwehrpunkte = Abwehrpunkte;
            attackSpeed = AttackSpeed;
            attack = Attack;
            SpecialAbility = SpecialAbility;
        }

        public override string ToString() => "Ork";
    }

    public class Troll
    {
        public int Hp;
        public int ap;
        public int abwehrpunkte;
        public float attackSpeed;
        public int attack;
        public int SpecialAbility;

        public Troll(int health, int Ap, int Abwehrpunkte, float AttackSpeed, int Attack, int SpecialAbility)
        {
            Hp = health;
            ap = Ap;
            abwehrpunkte = Abwehrpunkte;
            attackSpeed = AttackSpeed;
            attack = Attack;
            SpecialAbility = SpecialAbility;
        }

        public override string ToString() => "Troll";
    }

    public class Goblin
    {
        public int Hp;
        public int ap;
        public int abwehrpunkte;
        public float attackSpeed;
        public int attack;
        public int SpecialAbility;

        public Goblin(int health, int Ap, int Abwehrpunkte, float AttackSpeed, int Attack, int SpecialAbility)
        {
            Hp = health;
            ap = Ap;
            abwehrpunkte = Abwehrpunkte;
            attackSpeed = AttackSpeed;
            attack = Attack;
            SpecialAbility = SpecialAbility;
        }

        public override string ToString() => "Goblin";
    }

    public class Archer
    {
        public int Hp;
        public int ap;
        public int abwehrpunkte;
        public float attackSpeed;
        public int attack;
        public int SpecialAbility;

        public Archer(int health, int Ap, int Abwehrpunkte, float AttackSpeed, int Attack, int SpecialAbility)
        {
            Hp = health;
            ap = Ap;
            abwehrpunkte = Abwehrpunkte;
            attackSpeed = AttackSpeed;
            attack = Attack;
            SpecialAbility = SpecialAbility;
        }

        public override string ToString() => "Archer";
    }
}

class GameLogic : MonsterFight
{
    private dynamic player1;
    private dynamic player2;

    static void Main()
    {
        var gamelogic = new GameLogic();
        gamelogic.StartGame();
    }

    public void AssignAttributesOrk()
    {
        int OrkHealth = GetUserInt("Enter Ork Health: ");
        int OrkAp = GetUserInt("Enter Ork Ap: ");
        int OrkAbwehrpunkte = GetUserInt("Enter Ork Abwehrpunkte: ");
        float OrkAttackSpeed = GetUserFloat("Enter Ork AttackSpeed: ");
        int OrkAttack = GetUserInt("Enter Ork Attack Damage: ");
        int OrkSpecialAbility = GetUserInt("Enter Ork Special Ability Damage: ");
        player1 = new Ork(OrkHealth, OrkAp, OrkAbwehrpunkte, OrkAttackSpeed, OrkAttack, OrkSpecialAbility);
    }

    public void AssignAttributesTroll()
    {
        int TrollHealth = GetUserInt("Enter Troll Health: ");
        int TrollAp = GetUserInt("Enter Troll Ap: ");
        int TrollAbwehrpunkte = GetUserInt("Enter Troll Abwehrpunkte: ");
        float TrollAttackSpeed = GetUserFloat("Enter Troll AttackSpeed: ");
        int TrollAttack = GetUserInt("Enter Troll Attack Damage: ");
        int TrollSpecialAbility = GetUserInt("Enter Troll Special Ability Damage: ");
        player1 = new Troll(TrollHealth, TrollAp, TrollAbwehrpunkte, TrollAttackSpeed, TrollAttack, TrollSpecialAbility);
    }

    public void AssignAttributesGoblin()
    {
        int GoblinHealth = GetUserInt("Enter Goblin Health: ");
        int GoblinAp = GetUserInt("Enter Goblin Ap: ");
        int GoblinAbwehrpunkte = GetUserInt("Enter Goblin Abwehrpunkte: ");
        float GoblinAttackSpeed = GetUserFloat("Enter Goblin AttackSpeed: ");
        int GoblinAttack = GetUserInt("Enter Goblin Attack Damage: ");
        int GoblinSpecialAbility = GetUserInt("Enter Goblin Special Ability Damage: ");
        player1 = new Goblin(GoblinHealth, GoblinAp, GoblinAbwehrpunkte, GoblinAttackSpeed, GoblinAttack, GoblinSpecialAbility);
    }

    public void AssignAttributesArcher()
    {
        int ArcherHealth = GetUserInt("Enter Archer Health: ");
        int ArcherAp = GetUserInt("Enter Archer Ap: ");
        int ArcherAbwehrpunkte = GetUserInt("Enter Archer Abwehrpunkte: ");
        float ArcherAttackSpeed = GetUserFloat("Enter Archer AttackSpeed: ");
        int ArcherAttack = GetUserInt("Enter Archer Attack Damage: ");
        int ArcherSpecialAbility = GetUserInt("Enter Archer Special Ability Damage: ");
        player1 = new Archer(ArcherHealth, ArcherAp, ArcherAbwehrpunkte, ArcherAttackSpeed, ArcherAttack, ArcherSpecialAbility);
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
                    Console.WriteLine("You chose Ork.");
                    AssignAttributesOrk();
                    break;

                case '2':
                    Console.WriteLine("You chose Troll.");
                    AssignAttributesTroll();
                    break;

                case '3':
                    Console.WriteLine("You chose Goblin.");
                    AssignAttributesGoblin();
                    break;

                case '4':
                    Console.WriteLine("You chose Archer.");
                    AssignAttributesArcher();
                    break;

                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }

        Console.WriteLine("Opponent is a Troll.");
        player2 = new Troll(100, 10, 5, 1.0f, 15, 25); 

        Fight(player1, player2);
    }

    static void Fight(dynamic player1, dynamic player2)
    {
        Console.WriteLine($"Fight between {player1} and {player2} begins!");

        while (player1.Hp > 0 && player2.Hp > 0)
        {
            Console.WriteLine("Choose an action: Attack(1) or Use Special Ability(2)");
            string userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                int damageToOpponent = player1.attack - player2.abwehrpunkte;
                damageToOpponent = Math.Max(damageToOpponent, 0);

                Console.WriteLine($"{player1} attacks {player2} and deals {damageToOpponent} damage.");
                player2.Hp -= damageToOpponent;
            }
            else if (userChoice == "2")
            {
                int specialDamage = player1.SpecialAbility - player2.abwehrpunkte;
                specialDamage = Math.Max(specialDamage, 0);

                Console.WriteLine($"{player1} uses their special ability on {player2} and deals {specialDamage} damage.");
                player2.Hp -= specialDamage;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                continue;
            }

            Console.WriteLine($"{player2} has {player2.Hp} HP left.");

            if (player2.Hp <= 0)
            {
                Console.WriteLine($"{player2} has been defeated! {player1} wins the fight!");
                break;
            }

            int damageToPlayer = player2.attack - player1.abwehrpunkte;
            damageToPlayer = Math.Max(damageToPlayer, 0);

            Console.WriteLine($"{player2} attacks {player1} and deals {damageToPlayer} damage.");
            player1.Hp -= damageToPlayer;

            Console.WriteLine($"{player1} has {player1.Hp} HP left.");

            if (player1.Hp <= 0)
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
