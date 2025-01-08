namespace Core;

internal class Armor:Item
{
    public Armor(string name, int stat, bool isConsumable) : base(name, stat, isConsumable)
    {
        
    }
    
    public override void Effect(Player player)
    {
        player.AdjustDefense(Stat);
    }
}