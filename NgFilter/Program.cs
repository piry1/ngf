using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NgFilter.Filters.WordsFilter;

namespace NgFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            Filter filter = new Filter();
            filter.StartFiltering(@"C:\Users\piry3\Documents\Visual Studio 2017\Projects\NamesDictionary\NamesDictionary\bin\Release\Data\1grams.txt",
                @"Data\n1gram[f].txt", 1);

            //for (int i = 0; i < 100; ++i)
            //{
            //    Console.Write("\r{0}", i);
            //    Thread.Sleep(100);
            //}

            Console.WriteLine("END");
            Console.ReadLine();
        }
    }
}
