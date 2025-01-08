namespace ProjektM320;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Neues Spiel gestartet");
            _ = new Game();
            Console.WriteLine("[1] Neues Spiel");
            Console.WriteLine("[2] Beenden");
            var input = Console.ReadLine();
            if (input == "2")
            {
                break;
            }
        }
    }
}