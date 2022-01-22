using System;
using System.IO;

namespace Memory_Game
{

   class Scoreboard
    {
        StreamReader sr;
        StreamWriter sw;

        void openFileToRead()
        {
            try
            {
                sr = new StreamReader(@"C:\Users\Mat\source\repos\Memory-Game\Scoreboard.txt");
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
                sw = new StreamWriter(@"C:\Users\Mat\source\repos\Memory-Game\Scoreboard.txt");
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

        public void updateScoreboard(string newEntry)
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
            foreach(string s in scoreboard)
            {
                if (s == null)
                    break;
                sw.WriteLine(s);
            }
            closeFileToWrite();
          
        }

        public string gatherScoreInfo(DateTime date, double time, int triesAmount)
        {
            // do poprawy zaokroglenie do 2 cyfr po przecinku (max 3)
            Console.WriteLine("Enter your nickname: ");
            string nickname = Console.ReadLine();
            return String.Format("{0}|{1:d}|{2}|{3}", nickname, date, time, triesAmount);
        }

    }
}
