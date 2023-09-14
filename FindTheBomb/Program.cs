namespace FindTheBomb;

public class Program
{
    static void Main(string[] args)
    {
        // Create a function that finds the word "bomb" in the given string (not case sensitive).
        // If found, return "Duck!!!", otherwise, return "There is no bomb, relax.".
        Console.WriteLine("Should be a bomb found");
        Console.WriteLine(AnalyseForBomb("aazijejaiejzeijieja Bomb aaaa"));

        Console.WriteLine("Should do not be a bomb found");
        Console.WriteLine(AnalyseForBomb("aazijejaiejzeijieja Bomba aaaa"));

        Console.WriteLine("Should be a bomb found");
        Console.WriteLine(AnalyseForBomb("BoMb is big"));
    }

    static  string AnalyseForBomb(string val)
    {
        if (ContainsBomb(val)) return "Duck!!!";

        return "There is no bomb, relax.";
    }

     static bool ContainsBomb(string val)
    {
        var words = val.ToUpper().Split(',', ' ', '.', ';');

        return words.Any(w => w == "BOMB");
    }
}