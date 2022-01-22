using System;
using System.Diagnostics;

namespace Memory_Game
{
    public class FourWordsBoard : Board
    {
        string[][] boardPattern;
        string[][] currentBoard;
        public FourWordsBoard(string[] words)
        {
            boardPattern = generateBoardPattern(words);
            currentBoard = createBoard(0);
        }
        public override string[][] generateBoardPattern(string[] words)
        {
            boardPattern = new string[2][];
            boardPattern[0] = new string[4];
            boardPattern[1] = new string[4];
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    boardPattern[i][j] = "X";
                }
            }

            int counter = 0;
            int midcounter = 0;
            while (counter < 4)
            {
                int row = RandomNumber.get(2);
                int column = RandomNumber.get(4);

                if (boardPattern[row][column].Equals("X"))
                {
                    boardPattern[row][column] = words[counter];
                    midcounter += 1;
                    if (midcounter >= 2)
                    {
                        counter += 1;
                        midcounter = 0;
                    }
                }
            }
            return boardPattern;
        }


     
        int getRow(string pick)
        {
            char x = pick.ToCharArray()[0];
            if (x.Equals('A')) return 0;
            else if (x.Equals('B')) return 1;
            return -1;
        }

        int getColumn(string pick)
        {
            int col =  pick.ToCharArray()[1] - 49;
            if (col > 3) return -1;
            return col;
        }

        void updateBoard(int x, int y)
        {
            currentBoard[x][y] = boardPattern[x][y];
        }

        void reverseBoard(int x, int y)
        {
            currentBoard[x][y] = "X";
        }

        void drawBoard()
        {
            Console.WriteLine(String.Format("{0,-14} {1,-14} {2,-14} {3,-14} {4,-14}", " ", 1, 2, 3, 4));
            Console.WriteLine(String.Format("{0,-14} {1,-14} {2,-14} {3,-14} {4,-14}", 'A', currentBoard[0][0], currentBoard[0][1], currentBoard[0][2], currentBoard[0][3]));
            Console.WriteLine(String.Format("{0,-14} {1,-14} {2,-14} {3,-14} {4,-14}", 'B', currentBoard[1][0], currentBoard[1][1], currentBoard[1][2], currentBoard[1][3]));
            Console.WriteLine('\n');
        }

        public override void play()
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
                Console.WriteLine("Chances left: {0}", (10 - moves));
                Console.WriteLine("Enter card spot to reveal: ");
                string pick = Console.ReadLine();

                int row = getRow(pick.ToUpper());
                int column = getColumn(pick);
                while (row == -1 || column == -1)
                {
                    Console.WriteLine("Please enter proper value: ");
                    pick = Console.ReadLine();
                    pick = pick.ToUpper();
                    row = getRow(pick);
                    column = getColumn(pick);
                }


                updateBoard(row, column);
                drawBoard();
                Console.WriteLine("Enter card spot to reveal: ");
                pick = Console.ReadLine();

                // TODO
                // powtorzony klon walidacji row i col
                int _row = getRow(pick.ToUpper());
                int _column = getColumn(pick);
                while (_row == -1 || _column == -1)
                {
                    Console.WriteLine("Please enter proper value: ");
                    pick = Console.ReadLine();
                    pick = pick.ToUpper();
                    _row = getRow(pick);
                    _column = getColumn(pick);
                }
                updateBoard(_row, _column);
                drawBoard();


                if (boardPattern[row][column].Equals(boardPattern[_row][_column])) {
                    matches += 1;
                }
                else
                {
                    reverseBoard(row, column);
                    reverseBoard(_row, _column);
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
