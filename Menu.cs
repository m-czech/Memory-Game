using Memory_Game;
using System;

public class Menu
{
    string[] words;

    public void display()
    {
        Console.WriteLine("Choose game difficulty: ");
        Console.WriteLine("[ 1 ] Easy");
        Console.WriteLine("[ 2 ] Hard");
        Console.WriteLine("Enter your choice: ");
    }

    public void chooseGameDifficulty()
    {
        words = WordsReader.getRandomWords();

        string choice = Console.ReadLine();
        if (choice.Equals("1"))
        {
            Board board = new FourWordsBoard(words, 2);
            board.play(10);
        }
        else if (choice.Equals("2"))
        {
            Board board = new EightWordsBoard(words, 4);
            board.play(15);
        }
        else
        {
            Console.WriteLine("You have to choose between 1 and 2");
            chooseGameDifficulty();
        }
    }

    public void playAgain()
    {
        Console.WriteLine("Do you want to play again?");
        Console.WriteLine("Enter (y/n): ");

        string choice = Console.ReadLine();
        if (choice.Equals("y"))
        {
            display();
            chooseGameDifficulty();
        }
        else if (!choice.Equals("n"))
        {
            Console.WriteLine("You have to choose between 'y' and 'n'");
            playAgain();
        }
        
    }
}