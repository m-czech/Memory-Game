using System;
using System.IO;
public class WordsReader
{
    public WordsReader() { }

    static string[] readWords(string filename)
    {
        if (File.Exists(filename)) {
            return File.ReadAllLines(filename);
        }
        else
        {
            Console.WriteLine("File does not exists. Exiting ...");
            Environment.Exit(1);
        }

        return new string[1];
    }


    public static string[] getRandomWords()
    {
        // TODO get user's path
        string[] words = readWords(@"C:\Users\Mat\source\repos\Memory-Game\Words.txt");
        string[] randomWords = new string[8];
        bool[] wasWordChosenBefore = new bool[words.Length];

        Random r = new Random();

        int i = 0;
        while (i < 8)
        {
            int randomIndex = r.Next() % words.Length;
            if (wasWordChosenBefore[randomIndex] == false)
            {
                randomWords[i] = words[randomIndex];

                wasWordChosenBefore[i] = true;
                i += 1;
            }

        }
        return randomWords;
    }
}