using Core;

namespace ProjektM320;

public class Game
{
    private const int DefaultHealth = 100;
    private const int DefaultDefense = 5;
    private const int DefaultAttackDamage = 15;
    private Player _player = null!;

    private readonly List<Monster> _monsters = [];

    private readonly List<Npc> _npcs = [];
    public Game()
    {
        InitializePlayer();
        InitializeCharacters();
        StartDungeonExploring();
    }

    private void StartDungeonExploring()
    {
        while (_player.GetHealth() > 0)
        {
            RecalculateStats();
            var rnd = new Random();
            var encounter = rnd.Next(0, 10);
            if (encounter >= 8)
            {
                var npcEncounter = rnd.Next(0, _npcs.Count);
            }
            else
            {
                var monsterEncounter = rnd.Next(0, _monsters.Count);
                
            }
            
                
            
        }
        Console.WriteLine("Game Over! You Died.");
    }

    private void InitializePlayer()
    {
        Console.WriteLine("Enter your name: ");
        var playerName = Console.ReadLine();
         _player = new Player(playerName ?? string.Empty, DefaultHealth, DefaultDefense, DefaultAttackDamage);
    }

    private void InitializeCharacters()
    {
       
    }

    private void RecalculateStats()
    {
        _player.SetDefaultStats(DefaultHealth, DefaultDefense, DefaultAttackDamage);
        var nonConsumableItems = _player.Items.Where(item => !item.IsConsumable);
        foreach (var nonConsumableItem in nonConsumableItems)
        {
            nonConsumableItem.Effect(_player);
        }
    }
}