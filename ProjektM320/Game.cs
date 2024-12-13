using Core;

namespace ProjektM320;

public class Game
{
    private Player _player;

    private readonly List<Monster> _monsters = [];

    private readonly List<Npc> _npcs = [];
    public Game()
    {
        InitializePlayer();
        InitializeCharacters();
    }

    private void InitializePlayer()
    {
        Console.WriteLine("Enter your name: ");
        var playerName = Console.ReadLine();
        _player = new Player(playerName);
    }

    private void InitializeCharacters()
    {
       
    }
}