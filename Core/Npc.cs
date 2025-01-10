namespace Core;

public class Npc : Character
{
    private readonly List<string> _npcQuotes =
    [
        "Wahre Stärke kommt nicht durch den Körper, sondern durch den Geist.",
        "Der wahre Weg zum Erfolg liegt nicht in der Macht, sondern in der Einsicht.",
        "Kraft ist vergänglich, doch Weisheit bleibt für immer.",
        "Die besten Kämpfe werden nicht mit Schwertern, sondern mit Verstand gewonnen.",
        "Wissen ist das wahre Erbe eines Kriegers.",
        "Wer nur auf seine Stärke vertraut, wird leicht übersehen, was wirklich zählt.",
        "Wahre Macht kommt von der Fähigkeit, auch in der Dunkelheit den richtigen Weg zu sehen.",
        "Es ist nicht die Rüstung, die dich schützt, sondern die Entscheidungen, die du triffst.",
        "Nicht der Körper ist der wahre Krieger, sondern der Geist, der ihn führt.",
        "Der Weg zum Erfolg ist wie ein Labyrinth – nur der Schlaue findet den Ausgang.",
        "Weisheit ist der stärkste Schild eines Abenteurers.",
        "Die wahre Herausforderung im Leben ist nicht der Kampf, sondern das Wissen, wann man kämpfen muss.",
        "Der wahre Sieg wird nicht im Kampf gewonnen, sondern im Verstehen.",
        "Stärke ohne Weisheit führt oft in die Irre.",
        "Krieger lernen zu kämpfen, aber weise sind die, die wissen, wann sie nicht kämpfen sollten."
    ];
    public Npc(string name, double health, double defense, double attackdamage) : base(name, health, defense, attackdamage)
    {
        Items = [
            new HealthPotion("Minor Health Potion", 10, true), 
            new HealthPotion("Small Health Potion", 15, true), 
            new HealthPotion("Medium Health Potion", 20, true), 
            new HealthPotion("Health Potion", 25, true), 
            new HealthPotion("Big Health Potion", 35, true),
            new HealthPotion("Large Health Potion", 50, true), 
            new HealthPotion("Mega Health Potion", 75, true), 
        ];
    }
    
    public override void SetDefaultStats(double defaultDefense, double defaultAttackDamage, double defaultHealth)
    {
        Defense *= defaultDefense;
        Attackdamage *= defaultAttackDamage;
        Health *= defaultHealth;
    }
    
    public string GetRandomQuote()
    {
        var rnd = new Random();
        var quote = rnd.Next(0, _npcQuotes.Count);
        return _npcQuotes[quote];
    }
   
}