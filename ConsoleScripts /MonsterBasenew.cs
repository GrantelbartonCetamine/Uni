using System;

public abstract class MonsterBase
{
    public int HealthPoints { get; set; }
    public int DefensePoints { get; set; }
    public float AttackSpeed { get; set; }
    public int Attack { get; set; }
    public int SpecialAbility { get; set; }

    protected MonsterBase(int health, int defensepoints, float attackspeed, int attack, int specialability)
    {

        HealthPoints = health;
        DefensePoints = defensepoints;
        AttackSpeed = attackspeed;
        Attack = attack;
        SpecialAbility = specialability;
    }

    public virtual int CalculateBaseDamage(MonsterBase target)
    {
        // Logic for BaseDamage and return atleast 1 damage
        int damage = Attack + (int)AttackSpeed - target.DefensePoints;
        return Math.Max(damage, 1);
    }

    public virtual int CalculateDamageSpecialDamage(MonsterBase target)
    {
        int specialDamage = SpecialAbility + (int)AttackSpeed - target.DefensePoints;
        return Math.Max(specialDamage, 1);
    }

    public void TakeDamage(int damageAmount)
    {
        HealthPoints -= damageAmount;
    }
    public abstract override string ToString();
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
