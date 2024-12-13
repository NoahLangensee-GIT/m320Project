namespace ProjektM320;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Neues Spiel gestartet");
            _ = new Game();
            Console.WriteLine("Starten sie ein neues Spiel mit \"exit\" oder beenden sie das Spiel mit einer beliebigen Taste.");
            var input = Console.ReadLine();
            if (input == "exit")
            {
                break;
            }
        }
    }
}