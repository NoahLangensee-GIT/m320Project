namespace Core;

public class Potion:Item
{
    public Potion(string name, int stat) : base(name, stat)
    {
        
    }
    
    public override void Effect(Player player)
    {
        
    }
    
    public Action<Player> PotionEffect;
}