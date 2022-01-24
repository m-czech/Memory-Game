using System;

namespace Memory_Game
{
    public static class RandomNumber
    {
       
        public static int get(int max)
        {
            Random r = new Random();
            return r.Next(max);
        }
    }
}
