namespace Core;

public class Monster : Character
{
    
    public Monster(string name, int health, int defense, int attackdamage) : base(name, health, defense, attackdamage)
    {
        Items = [
            new Armor("Leather Armor", 5, false), 
            new Weapon("Club", 5, false), 
            new HealthPotion("Health Potion",25, true)];
    }
    
}