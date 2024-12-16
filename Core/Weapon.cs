namespace Core;

public class Weapon:Item
{
    public Weapon(string name, int stat) : base(name, stat)
    {
        
    }

    public override void Effect(Player player)
    {
        player.AdjustAttackDamage(Stat);
    }
}