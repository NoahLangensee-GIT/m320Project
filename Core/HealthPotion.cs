namespace Core;

internal class HealthPotion:Item
{
    public HealthPotion(string name, int stat, bool isConsumable) : base(name, stat, isConsumable)
    {
        
    }
    
    public override void Effect(Player player)
    {
        player.AdjustHealth(Stat);
    }
}