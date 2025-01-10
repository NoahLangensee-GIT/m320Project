namespace Core;

public class Monster : Character
{
    
    public Monster(string name, double health, double defense, double attackdamage) : base(name, health, defense, attackdamage)
    {
        Items = [
            new Armor("Leather Armor", 5, false), 
            new Armor("Iron Armor", 10, false), 
            new Armor("Steel Armor", 15, false), 
            new Armor("Golden Armor", 25, false), 
            new Armor("Dragon Scale Armor", 50, false), 
            new Weapon("Club", 5, false), 
            new Weapon("Sword", 10, false), 
            new Weapon("Bow", 15, false), 
            new Weapon("Axe", 20, false), 
            new Weapon("Spear", 30, false), 
            new Weapon("Greatsword", 40, false), 
            new Weapon("Magic Staff", 50, false),
            new HealthPotion("Big Health Potion", 35, true),
            new HealthPotion("Large Health Potion", 50, true), 
            new HealthPotion("Mega Health Potion", 75, true)
        ];
    }
    public override void SetDefaultStats(double defaultDefense, double defaultAttackDamage, double defaultHealth)
    {
        Defense *= defaultDefense;
        Attackdamage *= defaultAttackDamage;
        Health *= defaultHealth;
    }
}