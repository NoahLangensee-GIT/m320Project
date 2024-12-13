namespace Core;

public abstract class Item
{
    public string Name { get; set; }

    public Item(string name)
    {
        Name = name;
    }
    
    public abstract void Effect();
}