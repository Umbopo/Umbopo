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
            //FilterListWithAnotherList();
            UsingOptionalParameters();
        }

        public static void UsingOptionalParameters() 
        {
            // Omit the optional parameters.
            Method();

            // Omit second optional parameter.
            Method(4);

            // You can't omit the first but keep the second.
            // Method("Dot");

            // Classic calling syntax.
            Method(4, "Dot");

            // Specify one named parameter.
            Method(name: "Sundar");

            // Specify both named parameters.
            Method(value: 5, name: "Pichai");
        }
        /// <summary>
        /// Used to demonstrate optional params. I.e. you can call the mehthod without any params
        /// </summary>
        /// <param name="value"></param>
        /// <param name="name"></param>
        static void Method(int value = 1, string name = "Perl")
        {
            Console.WriteLine("value = {0}, name = {1}", value, name);
        }




        public static void FilterListWithAnotherList()
        {
            var listData = new List<string>();

            var listFilter = new List<string>();

            listData.Add("1");
            listData.Add("1");
            listData.Add("2");
            listData.Add("3");

            listFilter.Add("1");
            listFilter.Add("2");

            var filteredList = listData
                   .Where(x => listFilter.Any(y => y == x));

            foreach (var item in filteredList)
            {
                Console.WriteLine("VALUE: {0}", item);
            }
            Console.ReadLine();
        }

        private static void GenerateRandomNumbers()
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
