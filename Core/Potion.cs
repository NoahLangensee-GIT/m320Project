namespace Core;

public class Potion:Item
{
    public Potion(string name) : base(name)
    {
        
    }
    
    public override void Effect()
    {
        
    }
    
    public Action<Player> PotionEffect;
}