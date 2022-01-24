using System;

namespace Memory_Game
{
    class Program
    {
        static void Main(string[] args)
        {   

            Menu menu = new Menu();
            menu.display();
            menu.chooseGameDifficulty();
            menu.playAgain();
        }
    }
}