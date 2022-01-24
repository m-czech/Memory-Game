using System;


namespace Memory_Game
{
    class EightWordsBoard : Board
    {
        public EightWordsBoard(string[] words, int rows) : base(words, rows) { }
        public override string[][] generateBoardPattern(string[] words)
        {
            boardPattern = new string[4][];
            boardPattern[0] = new string[4];
            boardPattern[1] = new string[4];
            boardPattern[2] = new string[4];
            boardPattern[3] = new string[4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    boardPattern[i][j] = "X";
                }
            }

            int counter = 0;
            int midcounter = 0;
            while (counter < 8)
            {
                int row = RandomNumber.get(4);
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

        public override int getRow(string pick)
        {
            pick = pick.ToUpper();
            char x = pick.ToCharArray()[0];
            while (true)
            {
                if (x.Equals('A'))
                {
                    return 0;
                }
                else if (x.Equals('B'))
                {
                    return 1;
                }
                else if (x.Equals('C'))
                {
                    return 2;
                }
                else if (x.Equals('D'))
                {
                    return 3;
                }

                Console.WriteLine("Please enter proper value: ");
                pick = Console.ReadLine();
                pick = pick.ToUpper();
                x = pick.ToCharArray()[0];
            }
        }

        public override void drawBoard()
        {
            Console.WriteLine(String.Format("{0,-14} {1,-14} {2,-14} {3,-14} {4,-14}", " ", 1, 2, 3, 4));
            Console.WriteLine(String.Format("{0,-14} {1,-14} {2,-14} {3,-14} {4,-14}", 'A', currentBoard[0][0], currentBoard[0][1], currentBoard[0][2], currentBoard[0][3]));
            Console.WriteLine(String.Format("{0,-14} {1,-14} {2,-14} {3,-14} {4,-14}", 'B', currentBoard[1][0], currentBoard[1][1], currentBoard[1][2], currentBoard[1][3]));
            Console.WriteLine(String.Format("{0,-14} {1,-14} {2,-14} {3,-14} {4,-14}", 'C', currentBoard[2][0], currentBoard[2][1], currentBoard[2][2], currentBoard[2][3]));
            Console.WriteLine(String.Format("{0,-14} {1,-14} {2,-14} {3,-14} {4,-14}", 'D', currentBoard[3][0], currentBoard[3][1], currentBoard[3][2], currentBoard[3][3]));
            Console.WriteLine('\n');
        }

    }
}
