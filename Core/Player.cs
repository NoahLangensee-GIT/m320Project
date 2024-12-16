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
}