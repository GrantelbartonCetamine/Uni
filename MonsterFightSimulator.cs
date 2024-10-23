using System;

class MonsterFight()
{
    public bool isdead = false;

    class Main()
    {
        public Ork ork = new Ork(100, 20, "Nahkampf", "Starker Angriif von Oben", 30, "etwas");

        public Archer archer = new Archer(100, 15, "Range", "Aufgeladener schuss", 25, "can heal 5 healthpoint");

        public Goblin goblin = new Goblin(100, 5, "Nahkampf", "Assozialer Angriff in den Rücken", 15, "can go Invisible and connot be Attacked while this Time");

        public Troll troll = new Troll(100, 25, "Nahkampf", "Sehr Starker Angriff", 40, "10% Armor");

    }

    public class Ork(int health, int DamageDealing, string type, string SpecialAttackMove, int SpecialAttackDamage, string passive)
    {

        int Health = health;
        int Damage = DamageDealing;
        int SpecialAttackDamage = SpecialAttackDamage;

        string fighttype = type;
        string SpecialAttackMove = SpecialAttackMove;
        string passs = passive;

        public override string ToString(){

            return "Ork";
        }
    }

    public class Archer(int health, int DamageDealing, string type, string SpecialAttackMove, int SpecialAttackDamage, string passive)
    {
        int Health = health;
        int Damage = DamageDealing;
        int SpecialAttackDamage = SpecialAttackDamage;

        string fighttype = type;
        string SpecialAttackMove = SpecialAttackMove;
        string passs = passive;

        public override string ToString(){

            return "Archer";
        }
    }

    public class Goblin(int health, int DamageDealing, string type, string SpecialAttackMove, int SpecialAttackDamage, string passive)
    {
        int Health = health;
        int Damage = DamageDealing;
        int SpecialAttackDamage = SpecialAttackDamage;

        string fighttype = type;
        string SpecialAttackMove = SpecialAttackMove;
        string passs = passive;

        public override string ToString(){

            return "Goblin";
        }
    }

    public class Troll(int health, int DamageDealing, string type, string SpecialAttackMove, int SpecialAttackDamage, string passive)
    {
        int Health = health;
        int Damage = DamageDealing;
        int SpecialAttackDamage = SpecialAttackDamage;

        string fighttype = type;
        string SpecialAttackMove = SpecialAttackMove;
        string passs = passive;

        public override string ToString(){

            return "Troll";
        }
    }

}

class GameLogic : MonsterFight
{

    static void Main()
    {
        StartGame();
    }

    static void StartGame()
    {
        var Ork = new MonsterFight.Ork(100, 20, "Nahkampf", "Starker Angriff von Oben", 30, "etwas");
        var Archer = new MonsterFight.Archer(100, 15, "Range", "Aufgeladener Schuss", 25, "kann 5 Lebenspunkte heilen");
        var Goblin = new MonsterFight.Goblin(100, 5, "Nahkampf", "Angriff in den Rücken", 15, "kann unsichtbar werden");
        var Troll = new MonsterFight.Troll(100, 25, "Nahkampf", "Sehr starker Angriff", 40, "10% Rüstung");

        Console.WriteLine("Choose 2 Charackters");
        Console.WriteLine($"Available Classes : {Ork}(1) , {Archer}(2) ,{Goblin}(3) ,{Troll}(4)");

        Console.WriteLine("..Press any key to start the game...");

        Console.ReadLine();

        //if (UserCharackterChoose == "1")


    }


}
