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
            List<string> searchPlaces = new List<string>();
            for (int i = 0; i < ConfigurationManager.AppSettings.Count; i++)
            {
                searchPlaces.Add(ConfigurationManager.AppSettings[i]);
            }
            FindString("Green", searchPlaces);
            Console.ReadLine();
        }

        static void FindString(string str, List<string> possiblePlaces)
        {
            string result = String.Empty;
            foreach (String path in possiblePlaces)
            {
                if (result != String.Empty)
                {
                    Console.WriteLine(result);
                    return;
                }

                Assembly asm = Assembly.LoadFrom(path);
                Type[] t = asm.GetTypes();
                foreach (Type type in t)
                {
                    try
                    {
                        result = (string)type.GetMethod("Search").Invoke(null, new object[] {str});
                    }
                    catch
                    {
                        continue;
                    }
                }
            }
            Console.WriteLine("The "+str+" is not found");
        }
    }
}
