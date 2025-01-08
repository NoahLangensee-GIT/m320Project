namespace Core;

public abstract class Item
{ 
    protected int Stat;
    public string Name { get; }
    public bool IsConsumable { get; }

    public Item(string name, int stat, bool isConsumable)
    {
        Name = name;
        Stat = stat;
        IsConsumable = isConsumable;
    }
    
    public abstract void Effect(Player player);
}