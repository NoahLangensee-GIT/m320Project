namespace ProjektM320;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Neues Spiel gestartet");
            _ = new Game();
            Console.WriteLine("Beenden sie das Spiel mit \"exit\" oder starten sie ein neues Spiel mit Enter.");
            var input = Console.ReadLine();
            if (input == "exit")
            {
                break;
            }
        }
    }
}