using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
