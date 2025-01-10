namespace Core;

internal class Weapon:Item
{
    public Weapon(string name, int stat, bool isConsumable) : base(name, stat, isConsumable)
    {
        
    }

    public override void Effect(Player player)
    {
        player.AdjustAttackDamage(Stat);
    }
}