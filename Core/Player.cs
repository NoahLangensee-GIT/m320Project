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

    public int GetHealth()
    {
        return Health;
    }

    public void SetDefaultStats(int defaultHealth, int defaultDefense, int defaultAttackDamage)
    {
        Health = defaultHealth;
        Defense = defaultDefense;
        Attackdamage = defaultAttackDamage;
    }
}