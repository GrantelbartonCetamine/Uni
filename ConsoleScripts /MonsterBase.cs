using System;

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
}

public class Ork : MonsterBase
{
    public Ork(int health, int defensepoints, float attackspeed, int attack, int specialability)
        : base(health, defensepoints, attackspeed, attack, specialability)
    {

    }
    public override string ToString() => "Ork";
}

public class Goblin : MonsterBase
{
    public Goblin(int health, int defensepoints, float attackspeed, int attack, int specialability)
        : base(health, defensepoints, attackspeed, attack, specialability)
    {

    }
    public override string ToString() => "Goblin";

}

public class Archer : MonsterBase
{
    public Archer(int health, int defensepoints, float attackspeed, int attack, int specialability)
        : base(health, defensepoints, attackspeed, attack, specialability)
    {

    }
    public override string ToString() => "Archer";

}

public class Troll : MonsterBase
{
    public Troll(int health, int defensepoints, float attackspeed, int attack, int specialability)
        : base(health, defensepoints, attackspeed, attack, specialability)
    {

    }
    public override string ToString() => "Troll";

}

