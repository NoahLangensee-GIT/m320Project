using Core;

namespace ProjektM320;

public class Game
{
    private readonly int _defaultPlayerHealth = 100;
    private int _defaultPlayerDefense = 5;
    private int _defaultPlayerAttackDamage = 15;
    private int _defaultEnemyHealth = 80;
    private int _defaultEnemyDefense = 5;
    private int _defaultEnemyAttackDamage = 10;
    private Player _player = null!;
    private List<Monster> _monsters = [];
    private List<Npc> _npcs = [];

    public Game()
    {
        InitializePlayer();
        StartDungeonExploring();
    }

    private void StartDungeonExploring()
    {
        while (_player.GetHealth() > 0)
        {
            InitializeCharacters();
            RecalculateStats();
            _player.PrintStats();
            Console.WriteLine("Du gehst in den nächsten Raum.");
            var rnd = new Random();
            var isNpc = rnd.Next(0, 4) == 0;
            if (isNpc)
            {
                var npcEncounter = rnd.Next(0, _npcs.Count);
                Console.WriteLine("Ein " + _npcs[npcEncounter].Name + " steht vor dir.");
                Console.WriteLine("[1] Um eine Prophezeiung bitten");
                Console.WriteLine("[2] Fragen, ob er dir hilft");
                Console.WriteLine("[3] Angreifen");
                var choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine(
                            "Der " + _npcs[npcEncounter].Name +
                            " spricht in Rätseln: " + _npcs[npcEncounter].GetRandomQuote());
                        break;
                    case "2":
                        Console.WriteLine("Der " + _npcs[npcEncounter].Name + " schenkt dir einen Heiltrank.");
                        var randomItemDrop = rnd.Next(0, _npcs[npcEncounter].Items.Count);
                        _player.Items.Add(_npcs[npcEncounter].Items[randomItemDrop]);
                        Console.WriteLine("Du erhälst eine " + _npcs[npcEncounter].Items[randomItemDrop].Name);
                        break;
                    case "3":
                        Console.WriteLine(
                            "Der " + _npcs[npcEncounter].Name +
                            " schüttelt den Kopf und bereitet sich auf einen Angriff vor.");
                        EnterCombat(_npcs[npcEncounter]);
                        break;
                    default:
                        Console.WriteLine("Der " + _npcs[npcEncounter].Name +
                                          " schaut dich fragend an. Versuch es nochmal.");
                        break;
                }
            }
            else
            {
                var monsterEncounter = rnd.Next(0, _monsters.Count);
                var enemy = _monsters[monsterEncounter];
                EnterCombat(enemy);
            }
        }

        Console.WriteLine("Game Over! You Died.");
    }

    private void EnterCombat(Character enemy)
    {
        enemy.SetDefaultStats(_defaultEnemyDefense, _defaultEnemyAttackDamage, _defaultEnemyHealth);
        Console.WriteLine("Du stehst einem feindseligen " + enemy.Name + " gegenüber!");
        enemy.PrintStats();
        Console.WriteLine("[1] Kämpfen");
        Console.WriteLine("[2] Fliehen");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.WriteLine("Du bereitest dich auf einen Kampf vor.");
                RoundBasedCombat(enemy, false);
                break;
            case "2":
                var rnd = new Random();
                if (rnd.Next(0, 3) == 0)
                {
                    Console.WriteLine("Du rennst in Sicherheit, der Feind verfolgt dich nicht.");
                }
                else
                {
                    Console.WriteLine("Du rennst in Sicherheit, der Feind verletzt dich beim wegrennen.");
                    _player.AdjustHealth(-30);
                }

                break;
            default:
                Console.WriteLine("Dein Zögern gibt dem Feind die Gelegenheit, zuerst anzugreifen!");
                RoundBasedCombat(enemy, true);
                break;
        }
    }

    private void RoundBasedCombat(Character enemy, bool movesFirst)
    {
        if (movesFirst)
        {
            while (_player.GetHealth() > 0 && enemy.GetHealth() > 0)
            {
                enemy.DealDamage(_player);
                if (_player.GetHealth() > 0)
                {
                    PlayerAttack(enemy);
                }
            }
        }
        else
        {
            while (_player.GetHealth() > 0 && enemy.GetHealth() > 0)
            {
                PlayerAttack(enemy);
                if (enemy.GetHealth() > 0)
                {
                    enemy.DealDamage(_player);
                }
            }
        }

        if (enemy.GetHealth() <= 0)
        {
            Console.WriteLine("Monster besiegt!");
            LevelUp();
            var rnd = new Random();
            if ( rnd.Next(0, 2) == 0)
            {
                var randomItemDrop = rnd.Next(0, enemy.Items.Count);
                _player.Items.Add(enemy.Items[randomItemDrop]);
                Console.WriteLine("Du erhälst " + enemy.Items[randomItemDrop].Name); 
            }
        }
    }

    private void PlayerAttack(Character enemy)
    {
        Console.WriteLine("Was möchtest du tun?");
        Console.WriteLine("[1] Angreifen");
        Console.WriteLine("[2] Item benutzen");
        var choice = Console.ReadLine();
        if (choice == "2")
        {
            var consumableItems = _player.Items.Where(item => item.IsConsumable).ToList();
            int itemIndex;
            do
            {
                Console.WriteLine("Welches Item möchtest du benutzen?");
                var i = 0;
                foreach (var consumableItem in consumableItems)
                {
                    Console.WriteLine(i + " " + consumableItem.Name);
                    i++;
                }
            } while (!int.TryParse(Console.ReadLine(), out itemIndex));
            
            consumableItems[itemIndex].Effect(_player);
            _player.Items.Remove(consumableItems[itemIndex]);
        }
        else
        {
            _player.DealDamage(enemy);
        }
    }

    private void InitializePlayer()
    {
        Console.WriteLine("Enter your name: ");
        var playerName = Console.ReadLine();
        _player = new Player(playerName ?? string.Empty, _defaultPlayerHealth, _defaultPlayerDefense,
            _defaultPlayerAttackDamage);
    }

    private void InitializeCharacters()
    {
        _monsters =
        [
            new Monster("Goblin", 0.7, 0.6, 0.8),
            new Monster("Wolf", 0.8, 0.7, 0.9),
            new Monster("Zombie", 1.0, 0.9, 0.7),
            new Monster("Orc", 1.2, 1.0, 1.3),
            new Monster("Skeleton Archer", 0.6, 0.5, 1.1),
            new Monster("Troll", 1.5, 1.4, 1.2),
            new Monster("Slime", 0.5, 0.5, 0.6),
            new Monster("Dragon Whelp", 1.3, 1.2, 1.5),
            new Monster("Vampire", 1.1, 1.0, 1.4),
            new Monster("Dark Knight", 1.4, 1.5, 1.3),
            new Monster("Cave Spider", 0.9, 0.7, 0.8),
            new Monster("Ice Elemental", 1.2, 1.3, 1.0),
            new Monster("Fire Imp", 0.6, 0.5, 1.2),
            new Monster("Warlock", 1.0, 0.8, 1.4),
            new Monster("Giant Bat", 0.8, 0.6, 0.9)
        ];

        _npcs =
        [
            new Npc("Villager", 0.6, 0.4, 0.3),
            new Npc("Merchant", 0.8, 0.5, 0.4),
            new Npc("Guard", 1.0, 0.9, 0.8),
            new Npc("Blacksmith", 0.9, 0.7, 0.6),
            new Npc("Farmer", 0.5, 0.3, 0.4),
            new Npc("Healer", 0.7, 0.4, 0.3),
            new Npc("Noble", 0.4, 0.3, 0.2),
            new Npc("Bandit Leader", 3.0, 2.5, 3.5),
            new Npc("Traveling Bard", 0.3, 0.2, 0.25),
            new Npc("Adventurer", 1.2, 1.0, 1.1),
            new Npc("Scholar", 0.6, 0.5, 0.3),
            new Npc("Hunter", 0.9, 0.8, 0.7),
            new Npc("Royal Guard", 3.5, 4.0, 2.8),
            new Npc("Master Blacksmith", 2.0, 2.2, 1.5),
            new Npc("Warlord", 4.0, 3.8, 4.0),
            new Npc("Mage", 0.8, 0.5, 3.5),
            new Npc("Rogue", 1.5, 0.9, 1.3),
            new Npc("Dragon Priest", 2.8, 3.0, 3.5)
        ];
    }

    private void RecalculateStats()
    {
        _player.SetDefaultStats(_defaultPlayerDefense, _defaultPlayerAttackDamage);
        var nonConsumableItems = _player.Items.Where(item => !item.IsConsumable);
        foreach (var nonConsumableItem in nonConsumableItems)
        {
            nonConsumableItem.Effect(_player);
        }
    }

    private void LevelUp()
    {
        _player.AdjustHealth(50);
        _defaultPlayerDefense += 5;
        _defaultPlayerAttackDamage += 10;
        _defaultEnemyHealth += 10;
        _defaultEnemyDefense += 8;
        _defaultEnemyAttackDamage += 13;
    }
}