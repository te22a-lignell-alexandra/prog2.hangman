using System.Net;
using System.Runtime.InteropServices;


Console.WriteLine("Välkommer till hangman!\n");
Console.WriteLine("Välj ett ord:");

string word = Console.ReadLine().ToLower();
string[] HiddenWord = MakeUnderscores(word);
List<string> WrongGuesses = new();
int lives = 5;

Console.Clear();


while (WrongGuesses.Count < lives && string.Join("", HiddenWord) != word)
{
    Console.Clear();
    Console.WriteLine("Gissa en bokstav.");
    Console.WriteLine(string.Join(" ", HiddenWord));
    Console.WriteLine(string.Join("",WrongGuesses));
    Console.WriteLine("\n");

    string guess = "";
    bool moveon = false;
    while (moveon == false)
    {
        guess = Console.ReadLine().ToLower();
        CheckGuessLength(guess, ref moveon);
    }
    

    if (word.Contains(guess))
    {
        Console.WriteLine("Korrekt!");
        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == guess[0])
            {
                HiddenWord[i] = guess;
            }
        }
        // int pos = word.IndexOf(guess[0]);
        // HiddenWord[pos] = guess;
    }
    else
    {
        Console.WriteLine("Nej, fel!");
        WrongGuesses.Add(guess);
    }
}

Console.WriteLine("Spelet är över.");
Console.ReadLine();


/*---------------------------
METODER
----------------------------*/

static string[] MakeUnderscores(string word)
{
    string[] underscores = new string[word.Length];

    for (int i = 0; i < underscores.Length; i++)
    {
        underscores[i] = "_";
    }

    return underscores;

}

static bool CheckGuessLength(string guess, ref bool moveon)
{

    if (guess.Length > 1)
    {
        Console.WriteLine("Gissa EN bokstav >:(\n");
        return moveon = false;
    }
    else if (guess.Length == 1)
    {
         return moveon = true;
    }
    else
    {
        Console.WriteLine("Hallå. GISSA en bokstav. >:(");
        return moveon = false;
    }
}