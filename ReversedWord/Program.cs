using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter word: ");
        string word = Console.ReadLine();

        string reversedWord = Reverse(word);
        Console.WriteLine($"Reversed word: {reversedWord}");
    }

    static string Reverse(string word)
    {
        char[] charArray = word.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
}
