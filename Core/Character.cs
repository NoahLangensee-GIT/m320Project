namespace Core;

public abstract class Character
{
    protected double Health;
    protected double Defense;
    protected double Attackdamage;
    public List<Item> Items = [];
    public Character(string name, double health, double defense, double attackdamage)
    {
        Name = name;
        Health = health;
        Defense = defense;
        Attackdamage = attackdamage;
    }
    public string Name { get;}
    public abstract void SetDefaultStats(double defaultDefense, double defaultAttackDamage, double defaultHealth = 0);
    public double GetHealth()
    {
        return Health;
    }

    public void DealDamage(Character target)
    {
        var damageDealt = Attackdamage;
        target.TakeDamage(damageDealt);
    }

    public void TakeDamage(double damage)
    {
        Health -= damage - Defense;
        if (Health<0)
        {
            Health = 0;
        }
        Console.WriteLine(Name + " hat " + Convert.ToInt32(Health) + " Leben");
    }
    public void PrintStats()
    {
        Console.WriteLine(Name + " hat " + Convert.ToInt32(Health) + " Leben");
        Console.WriteLine(Name + " hat " + Convert.ToInt32(Defense) + " Rüstung");
        Console.WriteLine(Name + " hat " + Convert.ToInt32(Attackdamage) + " Angriffskraft");
    }
}