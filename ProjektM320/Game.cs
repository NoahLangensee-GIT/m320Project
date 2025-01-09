using Core;

namespace ProjektM320;

public class Game
{
    private int _defaultHealth = 100;
    private int _defaultDefense = 5;
    private int _defaultAttackDamage = 15;
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
            _player.PrintStats();
            Console.WriteLine("Du gehst in den nächsten Raum.");
            var rnd = new Random();
            var encounter = rnd.Next(0, 10);
            if (encounter >= 8)
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
                            " spricht in Rätseln: 'Der Schlüssel zu deinem Erfolg liegt nicht in Stärke, sondern in der Weisheit.'");
                        break;
                    case "2":
                        Console.WriteLine("Der " + _npcs[npcEncounter].Name + " schenkt dir einen Heiltrank.");
                        var randomItemDrop = rnd.Next(0, _npcs[npcEncounter].Items.Count);
                        _player.Items.Add(_npcs[npcEncounter].Items[randomItemDrop]);
                        Console.WriteLine("Du erhälst einen " + _npcs[npcEncounter].Items[randomItemDrop].Name);
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
                EnterCombat(_monsters[monsterEncounter]);
            }
        }

        Console.WriteLine("Game Over! You Died.");
    }

    private void EnterCombat(Character enemy)
    {
        Console.WriteLine("Du stehst einem feindseligen " + enemy.Name + " gegenüber!");
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
                    _player.AdjustHealth(-35);
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
        //TODO implement Attacks
        if (movesFirst)
        {
            while (_player.GetHealth() > 0 && enemy.GetHealth() > 0)
            {
                enemy.DealDamage(_player);
                if (_player.GetHealth() > 0)
                {
                    Console.WriteLine("Was möchtest du tun?");
                    Console.WriteLine("[1] Angreifen");
                    Console.WriteLine("[2] Item benutzen");
                    var choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "2":
                            var consumableItems = _player.Items.Where(item => item.IsConsumable).ToList();
                            Console.WriteLine("Welches Item möchtest du benutzen?");
                            var i = 0;
                            foreach (var consumableItem in consumableItems)
                            {
                                Console.WriteLine(i + " " + consumableItem.Name);
                                i++;
                            }

                            var itemIndex = Convert.ToInt32(Console.ReadLine());
                            consumableItems[itemIndex].Effect(_player);
                            _player.Items.Remove(consumableItems[itemIndex]);
                            break;
                        default:
                            _player.DealDamage(enemy);
                            break;
                    }
                }
            }
        }
        else
        {
            while (_player.GetHealth() > 0 && enemy.GetHealth() > 0)
            {
                _player.DealDamage(enemy);
                if (enemy.GetHealth() > 0)
                {
                    enemy.DealDamage(_player);
                }
            }
        }
        //TODO implement LVL UP after won fight
    }

    private void InitializePlayer()
    {
        Console.WriteLine("Enter your name: ");
        var playerName = Console.ReadLine();
        _player = new Player(playerName ?? string.Empty, _defaultHealth, _defaultDefense, _defaultAttackDamage);
    }

    private void InitializeCharacters()
    {
        //TODO Monster und NPCS intialisieren
        //TODO implement LVL Scaling for monsters
    }

    private void RecalculateStats()
    {
        _player.SetDefaultStats(_defaultDefense, _defaultAttackDamage);
        var nonConsumableItems = _player.Items.Where(item => !item.IsConsumable);
        foreach (var nonConsumableItem in nonConsumableItems)
        {
            nonConsumableItem.Effect(_player);
        }
    }
}