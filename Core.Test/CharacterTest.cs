namespace Core.Test;

[TestClass]
public class CharacterTest
{
    private readonly Player _player;

    public CharacterTest()
    {
        _player = new Player("Noah", 100, 5, 15);
    }

    [TestMethod]
    public void GetHealth()
    {
        var result = _player.GetHealth();
        Assert.AreEqual(result, 100);
    }
    
    [TestMethod]
    public void TakeDamage()
    {
        _player.TakeDamage(20);
        Assert.AreEqual(_player.GetHealth(), 85);
    }
}