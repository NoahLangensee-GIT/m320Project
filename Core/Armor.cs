namespace Core;

public class Armor:Item
{
    public Armor(string name, int stat) : base(name, stat)
    {
        
    }
    
    public override void Effect(Player player)
    {
        player.AdjustDefense(Stat);
    }
}