using System;
using System.IO;

namespace Memory_Game
{

    class Scoreboard
    {
        StreamReader sr;
        StreamWriter sw;
        string path = String.Format("{0}\\Scoreboard.txt", Directory.GetCurrentDirectory());

        void openFileToRead()
        {
            try
            {
                sr = new StreamReader(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Exiting ...");
                Environment.Exit(1);
            }
        }
        void closeFileToRead()
        {
            try
            {
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        void openFileToWrite()
        {
            try
            {
                sw = new StreamWriter(path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Exiting ...");
                Environment.Exit(1);
            }
        }

        void closeFileToWrite()
        {
            try
            {
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void display()
        {
            openFileToRead();
            string line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            closeFileToRead();

            Console.WriteLine('\n');
        }

        void shiftArrayToTheRight(string[] array, int idx)
        {
            for (int i = array.Length - 1; i > idx; i--)
            {
                array[i] = array[i - 1];
            }
        }

        void updateScoreboard(string newEntry)
        {
            openFileToRead();
            string[] scoreboard = new string[10];

            string entry = sr.ReadLine();

            int counter = 0;
            while (entry != null)
            {
                scoreboard[counter] = entry;
                entry = sr.ReadLine();
                counter += 1;
            }

            closeFileToRead();

            string[] splitNewEntry = newEntry.Split('|');
            float newTime = float.Parse(splitNewEntry[2]);
            for (int i = 0; i < 10; i++)
            {
                if (scoreboard[i] == null)
                {
                    scoreboard[i] = newEntry;
                    break;
                }

                string[] splitOldEntry = scoreboard[i].Split('|');
                float oldTime = float.Parse(splitOldEntry[2]);

                if (newTime < oldTime)
                {
                    shiftArrayToTheRight(scoreboard, i);
                    scoreboard[i] = newEntry;
                    break;
                }
            }

            openFileToWrite();
            foreach (string s in scoreboard)
            {
                if (s == null)
                    break;
                sw.WriteLine(s);
            }
            closeFileToWrite();
        }

        public string gatherScoreInfo(DateTime date, double time, int triesAmount)
        {
            Console.WriteLine("Enter your nickname: ");
            string nickname = Console.ReadLine();
            return String.Format("{0}|{1:d}|{2}|{3}", nickname, date, time, triesAmount);
        }

        public void update(int moves, int maxMoves, TimeSpan time)
        {
            if (moves <= maxMoves)
            {
                Console.WriteLine("Congratulations! You have beaten the game in {0} seconds and after {1} tries", time.TotalSeconds, moves);


                string newScoreboardEntry = gatherScoreInfo(DateTime.Now, time.TotalSeconds, moves);
                updateScoreboard(newScoreboardEntry);
            }
            else
            {
                Console.WriteLine("Unfortunately, you have exceeded all chances.\nTry again!");
            }
        }

    }
}