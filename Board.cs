using System;
using System.Diagnostics;

namespace Memory_Game
{
    public abstract class Board
    {

        public string[][] boardPattern;
        public string[][] currentBoard;

        public Board (string[] words, int rows) 
        {
        boardPattern = generateBoardPattern(words);
        currentBoard = createBoard(rows);
        }

        public abstract string[][] generateBoardPattern(string[] words);

        public string[][] createBoard(int rows)
        {
            string[][] board = new string[rows][];
            for (int i = 0; i < rows; i++)
            {
                board[i] = new string[4];
                for (int j = 0; j < 4; j++)
                {
                    board[i][j] = "X";
                }
            }
            return board;
        }

        public abstract int getRow(string pick);
        public int getColumn(string pick)
        {
            int col = pick.ToCharArray()[1] - 49;
            while (true)
            {
                if (col < 4)
                {
                    return col;
                }

                Console.WriteLine("Please enter proper value: ");
                pick = Console.ReadLine();
                col = pick.ToCharArray()[1] - 49;
            }
        }
        public abstract void drawBoard();

        void updateBoard(int x, int y)
        {
            currentBoard[x][y] = boardPattern[x][y];
        }

        void reverseChanges(int x, int y)
        {
            currentBoard[x][y] = "X";
        }
        public void play(int maxMoves)
        {
            Console.WriteLine("Level: easy");


            int moves = 0;
            int matches = 0;

            Stopwatch watch = new Stopwatch();
            watch.Start();

            Console.Clear();

            drawBoard();
            while (matches < 4)
            {
                Console.WriteLine("Chances left: {0}", (maxMoves - moves));
                Console.WriteLine("Enter card spot to reveal: ");
                string pick = Console.ReadLine();

                int row = getRow(pick);
                int column = getColumn(pick);


                updateBoard(row, column);
                drawBoard();
                Console.WriteLine("Enter card spot to reveal: ");
                pick = Console.ReadLine();


                int _row = getRow(pick);
                int _column = getColumn(pick);


                updateBoard(_row, _column);
                drawBoard();


                if (boardPattern[row][column].Equals(boardPattern[_row][_column]))
                {
                    matches += 1;
                }
                else
                {
                    reverseChanges(row, column);
                    reverseChanges(_row, _column);
                }

                if (++moves > 10)
                {
                    break;
                };



            }
            watch.Stop();
            TimeSpan ts = watch.Elapsed;


            Scoreboard scoreboard = new Scoreboard();
            if (moves <= 10)
            {
                Console.WriteLine("Congratulations! You have beaten the game in {0} seconds and after {1} tries", ts.TotalSeconds, moves);


                string newScoreboardEntry = scoreboard.gatherScoreInfo(DateTime.Now, ts.TotalSeconds, moves);
                scoreboard.updateScoreboard(newScoreboardEntry);
            }
            else
            {
                Console.WriteLine("Unfortunately, you have exceeded all chances.\nTry again!");
            }
            scoreboard.display();


        }
    }

}

