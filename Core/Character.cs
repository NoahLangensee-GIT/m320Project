namespace Core;

public abstract class Character
{
    protected int Health;
    protected int Defense;
    protected int Attackdamage;
    public List<Item> Items = [];
    public Character(string name, int health, int defense, int attackdamage)
    {
        Name = name;
        Health = health;
        Defense = defense;
        Attackdamage = attackdamage;
    }
    public string Name { get;}
    public int GetHealth()
    {
        return Health;
    }
    
}