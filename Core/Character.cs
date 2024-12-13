namespace Core;

public abstract class Character
{
    private readonly int _health;
    private readonly int _defense;
    private readonly int _attackdamage;
    public Character(string name, int health, int defense, int attackdamage)
    {
        Name = name;
        _health = health;
        _defense = defense;
        _attackdamage = attackdamage;
    }
    public string Name { get;}
    
}