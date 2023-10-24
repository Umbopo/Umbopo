using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int num = 0;
                num = GetNextRandom();
                Console.WriteLine(num);
                Console.ReadLine();
            }
        }

        private static int GetNextRandom()
        {
            Random r = new Random();
            var num = r.Next();
            return num;
        }
        
    }
}
