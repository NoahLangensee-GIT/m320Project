namespace Core;

public abstract class Item
{
    public string Name { get; }

    protected int Stat;

    public Item(string name, int stat)
    {
        Name = name;
        Stat = stat;
    }
    
    public abstract void Effect(Player player);
}