namespace Core.Test;

[TestClass]
public class CharacterTest
{
    [TestMethod]
    public void GetHealth()
    {
        //Arrange
        var health = 100;
        var player = new Player("John Wick", health,0,0);
        //Act
        var result = player.GetHealth();
        //Assert
        Assert.AreEqual(result, health, "Gibt nicht die richtige Lebenspunktanzahl zurück");
    }
    
    [TestMethod]
    public void TakeDamage()
    {
        //Arrange
        var health = 100;
        var defense = 10;
        var damage = 20;
        var excpected = 90;
        var player = new Player("John Wick", health,defense,0);
        //Act
        player.TakeDamage(damage);
        //Assert
        var actual = player.GetHealth();
        Assert.AreEqual(excpected, actual, "Leben werden nicht korrekt abgezogen");
    }
}