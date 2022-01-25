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
        public abstract int getRow(string pick);
        public abstract void drawBoard();

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
    
        public int getColumn(string pick)
        {
            int column = pick.ToCharArray()[1] - 49;
            if (column < 4)
            {
                return column;
            }
            return -1;
        }

        public string getUserInput()
        {
            Console.WriteLine("Enter card spot to reveal: ");
            string pick = Console.ReadLine();
            
            while (!validateInput(pick))
            {
                Console.WriteLine("Wrong coordinates. Try again!");
                pick = Console.ReadLine();
            }
            return pick.ToUpper();           
        }

        bool validateInput(string pick)
        {
            if (pick.Length != 2)
            {
                return false;
            }
            if (!char.IsLetter(pick.ToCharArray()[0]))
            {
                return false;
            }
            if (!char.IsNumber(pick.ToCharArray()[1]))
            {
                return false;
            }
            return true;
        }
    
        void updateBoard(int x, int y)
        {
            currentBoard[x][y] = boardPattern[x][y];
        }

        void reverseChanges(int x, int y)
        {
            currentBoard[x][y] = "X";
        }
        public void play(int maxMoves, int cardsAmount)
        {
            int moves = 0;
            int matches = 0;

            Stopwatch watch = new Stopwatch();
            watch.Start();

            Console.Clear();

            drawBoard();
            while (matches < cardsAmount)
            {
                Console.WriteLine("Chances left: {0}", (maxMoves - moves));

                string pick;
                int row, column;
                do
                {
                    pick = getUserInput();
                    row = getRow(pick);
                    column = getColumn(pick);
                }
                while (row == -1 || column == -1);
                

                updateBoard(row, column);
                drawBoard();
                
                int _row, _column;
                do
                {
                    pick = getUserInput();
                    _row = getRow(pick);
                    _column = getColumn(pick);
                }
                while (_row == -1 || _column == -1);
                

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

                if (++moves > maxMoves)
                {
                    break;
                };
            }
            watch.Stop();
            TimeSpan ts = watch.Elapsed;


            Scoreboard scoreboard = new Scoreboard();
            if (moves <= maxMoves)
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

