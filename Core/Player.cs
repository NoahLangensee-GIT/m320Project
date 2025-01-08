namespace Core;

public class Player : Character
{
    public Player(string name, int health, int defense, int attackdamage) : base(name, health, defense, attackdamage)
    {
        
    }

    public void AdjustAttackDamage(int damage)
    {
        Attackdamage += damage;
    }

    public void AdjustDefense(int armor)
    {
        Defense += armor;
    }

    public void AdjustHealth(int stat)
    {
        Health += stat;
    }

    public void SetDefaultStats(int defaultDefense, int defaultAttackDamage)
    {
        Defense = defaultDefense;
        Attackdamage = defaultAttackDamage;
    }
}