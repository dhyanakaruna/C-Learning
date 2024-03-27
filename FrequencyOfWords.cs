using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a sentence:");
        string sentence = Console.ReadLine();

        string[] words = sentence.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

        Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

        foreach (string word in words)
        {
            string lowerWord = word.ToLower(); 
            if (wordFrequency.ContainsKey(lowerWord))
            {
                wordFrequency[lowerWord]++;
            }
            else
            {
                wordFrequency[lowerWord] = 1;
            }
        }

        Console.WriteLine("Output:");
        Console.WriteLine("{");
        foreach (KeyValuePair<string, int> pair in wordFrequency)
        {
            Console.WriteLine($"    \"{pair.Key}\": {pair.Value},");
        }
        Console.WriteLine("}");

        Console.ReadLine();
    }
}
