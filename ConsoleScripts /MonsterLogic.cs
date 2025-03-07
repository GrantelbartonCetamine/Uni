using static GameLogic;
class GameLogic
{
    // Manager Manage Charackters
    public class MonsterManager
    {
        public MonsterBase CreateMonster(string monsterType)
        {

            Console.WriteLine($"Type Youre Attributs for {monsterType}");

            int health = GetUserInt("Health : ", 1, 100);
            int defensepoints = GetUserInt("defensepoints : ", 1, 100);
            int attackspeed = GetUserInt("attackspeed : ", 1, 100);
            int attack = GetUserInt("attack : ", 1, 100);
            int specialability = GetUserInt("specialability : ", 1, 100);

            return monsterType switch
            {
                "Ork" => new Ork(health, defensepoints, attackspeed, attack, specialability),
                "Goblin" => new Goblin(health, defensepoints, attackspeed, attack, specialability),
                "Archer" => new Archer(health, defensepoints, attackspeed, attack, specialability),
                "Troll" => new Troll(health, defensepoints, attackspeed, attack, specialability),
                _ => throw new ArgumentException("Invalid monster type")
            };
        }


        public MonsterBase RandomOponent()
        {
            var opponents = new List<MonsterBase>()
        {
            new Ork(100, 30, 5, 25, 10),
            new Archer(100, 5, 40, 15, 5),
            new Troll(100, 40, 5, 11, 11)
        };

            Random rnd = new Random();
            return opponents[rnd.Next(opponents.Count)];
        }




        public int GetUserInt(string arg, int MinValue, int MaxValue)
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


    public class FightManager
    {
        //Handle the Fight Logic 
        public void Fight(MonsterBase player, MonsterBase enemy)
        {
            Console.WriteLine($"Fight between {player} and {enemy} begins!");
            Random rnd = new Random();

            while (player.HealthPoints > 0 && enemy.HealthPoints > 0)
            {


                Console.WriteLine("Choose an action: Attack(1) or Use Special Ability(2)");
                string userChoice = Console.ReadLine();



                int damage = userChoice == "1" ? player.CalculateBaseDamage(enemy) : player.CalculateDamageSpecialDamage(enemy);
                enemy.TakeDamage(damage);
                Console.WriteLine($"{player} Attacked {enemy} , {enemy} has {enemy.HealthPoints} Hp Left.");



                if (enemy.HealthPoints <= 0)

                {

                    Console.WriteLine($"{enemy} Died Congratulation");
                    break;
                }


                // Random enemy attack
                int enemyChoice = rnd.Next(1, 3);
                int enemyDamage = enemyChoice == 1 ? enemy.CalculateBaseDamage(player) : enemy.CalculateDamageSpecialDamage(player);
                player.TakeDamage(enemyDamage);
                Console.WriteLine($"{enemy} attacked {player}, {player} has {player.HealthPoints} HP left.");


                if (player.HealthPoints <= 0)
                {
                    Console.WriteLine($"{player} has no Hp Left , you Died and Lost");
                    break;
                }
            }
        }
    }



class Game
{

    private MonsterManager monsterManager = new MonsterManager();
    private FightManager fightManager = new FightManager();

    public void StartGame()
    {
        Console.WriteLine("Choose your character:");
        Console.WriteLine("Available Classes: Ork(1), Troll(2), Goblin(3), Archer(4)");
        int choice;

        do
        {
            Console.Write("Choose: ");
        } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4);

        MonsterBase player = monsterManager.CreateMonster(choice switch
        {
            1 => "Ork",
            2 => "Troll",
            3 => "Goblin",
            4 => "Archer",
            _ => throw new ArgumentException("Invalid Choice")
        });

        MonsterBase enemy = monsterManager.RandomOponent();
        Console.WriteLine($"You chose {player}, your opponent is {enemy}!");

        fightManager.Fight(player, enemy);
    }

}

public class Program
{
    public static void Main()
    {
        var game = new Game();
        game.StartGame();
    }
}
