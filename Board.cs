using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory_Game
{
    public abstract class Board
    {
        public abstract string[][] generateBoardPattern(string[] words);
        public abstract void play();

        public string[][] createBoard(int difficulty) //0 - easy, 1 - hard
        {
            string[][] board;
            if (difficulty == 0)
            {
                board = new string[2][];
                board[0] = new string[4];
                board[1] = new string[4];

                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        board[i][j] = "X";
                    }
                }

                return board;
            }

            board = new string[4][];
            for (int i = 0; i < 4; i++)
            {
                board[i] = new string[4];
                for (int j = 0; j < 4; j++)
                {
                    board[i][j] = "X";
                }
            }


            return board;
        }

    }
}
