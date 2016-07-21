using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;

namespace Searcher
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchProvider provider = new SearchProvider("Red");
            provider.StartSearch();
            Console.ReadLine();
        }

    }
}
