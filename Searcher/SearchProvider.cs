using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using Search;
using Searcher.OwnSectionRead;

namespace Searcher
{
    class SearchProvider
    {
       private SearchProviderSection searchSection;
        private string findTarget = String.Empty;
        public SearchProvider(string targetSearch)
        {
            searchSection = (SearchProviderSection)ConfigurationManager.GetSection("SearchSection");
            findTarget = targetSearch;
            
        }

        public void StartSearch()
        {
            string result = String.Empty;

            for (int i = 0; i < searchSection.AssemblyColl.Count; i++)
            {
                if (!String.IsNullOrEmpty(result))
                {
                    continue;
                }

                string asmName = searchSection.AssemblyColl[i].AssemblyName;
                Assembly asm = Assembly.Load(asmName);
                Type t = asm.GetType(searchSection.AssemblyColl[i].SearchClass);

                object searchObject = t.GetConstructor(new Type[] { }).Invoke(new object[] { });
                if (searchObject == null)
                {
                    Console.WriteLine("Can't create a search object " + searchSection.AssemblyColl[i].SearchClass + " From Assembly" + searchSection.AssemblyColl[i].AssemblyName);
                    return;
                }
                result = (string)t.GetMethod("Search").Invoke(searchObject, new object [2] {findTarget, searchSection.AssemblyColl[i].Param});
            }
            if (String.IsNullOrEmpty(result))
            {
                result = "Couldn't find it anywhere :(";
            }
            Console.WriteLine(result);
        }
    }
}
