namespace Core;

public class Npc : Character
{
    
    public Npc(string name, int health, int defense, int attackdamage) : base(name, health, defense, attackdamage)
    {
        Items = [
            new HealthPotion("Small Health Potion", 15,true), 
            new HealthPotion("Health Potion",25, true), 
            new HealthPotion("Big Health Potion",35, true),];
    }
}