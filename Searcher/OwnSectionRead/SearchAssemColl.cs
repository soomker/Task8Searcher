using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Searcher.OwnSectionRead
{
    [ConfigurationCollection(typeof(SearchElement))]
    class SearchAssemColl:ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SearchElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SearchElement)(element)).AssemblyName;
        }

       public SearchElement this[int idx]
        {
            get {return (SearchElement)BaseGet(idx); }
        }
    }
}
