using System;

class MonsterFight()
{
    public bool isdead = false;

    class Main()
    {
    }

    public class Ork(int health, int DamageDealing, int Abwehpunkte ,float AttackSpeed, int Attack )
    {
        public int Hp;
        public int Ap;
        public int Abwehrpunkte;
        public float AttackSpeed;
        public int Attack;


        this.Hp = health;
        int Ap = DamageDealing;
        int Abwehrpunkte = Abwehpunkte;
        float AttackSpeed = AttackSpeed;
        int Attack = Attack;

        public override string ToString(){

            return "Ork";
        }
    }


    public class Troll(int health, int DamageDealing, int Abwehpunkte, float AttackSpeed, int Attack)
    {

        int Hp = health;
        int Ap = DamageDealing;
        int Abwehrpunkte = Abwehpunkte;
        float AttackSpeed = AttackSpeed;
        int Attack = Attack;

        public override string ToString()
        {

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

    void AssignAttributesOrk()
    {

        int OrkHealth = GetUserInt("Enter Troll Health : ");
        var OrkAp = GetUserInt("Enter Troll Ap");
        var OrklAbwehpunkte = GetUserInt("Enter Troll Abwehrpunkte");
        float OrkAttackSpeed = GetUserFloat("Enter Troll AttackSpeed : ");
        var OrkAttack = GetUserInt("Enter Troll Attack Damage");
        var Ork = new MonsterFight.Ork(OrkHealth, OrkAp, OrklAbwehpunkte, OrkAttackSpeed, OrkAttack);
    }
    
    void AssignAttributesTroll()
    {
        int TrollHealth = GetUserInt("Enter Troll Health : ");
        var TrollAp = GetUserInt("Enter Troll Ap");
        var TrollAbwehpunkte = GetUserInt("Enter Troll Abwehrpunkte");
        float TrollAttackSpeed = GetUserFloat("Enter Troll AttackSpeed : ");
        var TrollAttack = GetUserInt("Enter Troll Attack Damage");
        var Troll = new MonsterFight.Troll(TrollHealth, TrollAp, TrollAbwehpunkte, TrollAttackSpeed, TrollAttack);
    }

    static void StartGame()
    {      
        int classcounter = 0;


        Console.WriteLine("Choose 2 Charackters");
        Console.WriteLine($"Available Classes : {AssignAttributes}(1) , {Troll}(2)");

        var userChoice = Console.ReadKey();

        while (classcounter <= 2)
        { 
        switch(userChoice.KeyChar){

            case '1':
            Console.Write($" You Choose {Ork}");
            classcounter ++;
            break;

            case '2':
            Console.Write($" You Choose {Troll}");
            classcounter ++;
            break;
            }

            if (classcounter >= 2){
                Console.WriteLine("Cannot choose more Charackters");
            }

        }
    }
    
    static void fight(){

        
    }

    public int GetUserInt(string UserInput)
    {
        Console.WriteLine(UserInput);
        return int.Parse(Console.ReadLine());
    }

    public float GetUserFloat(string UserInput)
    {
        Console.WriteLine(UserInput);
        return float.Parse(Console.ReadLine());
    }



 


}


