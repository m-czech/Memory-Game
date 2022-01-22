using System;

namespace Memory_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            bool restart = false;
            do
            {
                Menu.display();
                string[] words = WordsReader.getRandomWords();
                FourWordsBoard board = new FourWordsBoard(words);
                board.play();

                Console.WriteLine("Do you want to play again?");
                Console.WriteLine("Enter (y/n): ");
                string choice = Console.ReadLine();
                if (choice.Equals("y"))
                {
                    restart = true;
                }
                else
                {
                    restart = false;
                }
            } while (restart);
            
            
        }
    }
}
