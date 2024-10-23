
﻿using System;

class MonsterFight()
{
    public bool isdead = false;

    class Main()
    {
        public Ork ork = new Ork(100, 20, "Nahkampf", "Starker Angriif von Oben", 30, "etwas");
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
        int classcounter = 0;

        var Ork = new MonsterFight.Ork(100, 20, "Nahkampf", "Starker Angriff von Oben", 30, "etwas");
        var Troll = new MonsterFight.Troll(100, 25, "Nahkampf", "Sehr starker Angriff", 40, "10% Rüstung");

        Console.WriteLine("Choose 2 Charackters");
        Console.WriteLine($"Available Classes : {Ork}(1) , {Troll}(2)");

        var userChoice = Console.ReadKey();

        while (classcounter < 1)
        { 
        switch(userChoice.KeyChar){

            case '1':
            Console.WriteLine($" You Choose {Ork}");
            classcounter ++;
            break;

            case '2':
            Console.WriteLine($" You Choose {Troll}");
            classcounter ++;
            break;
            }

            if (classcounter > 1){
                Console.WriteLine("Cannot choose more Charackters");
            }

        }
    }
    
    static void fight(){

        
    }



}
