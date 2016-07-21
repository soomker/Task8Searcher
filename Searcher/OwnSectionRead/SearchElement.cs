using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Searcher.OwnSectionRead
{
    class SearchElement:ConfigurationElement
    {
        [ConfigurationProperty("assembly", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string AssemblyName
        {
           get { return ((string)(base["assembly"])); }
           set { base["assembly"] = value; }
        }

        [ConfigurationProperty("class", DefaultValue = "", IsKey = false, IsRequired = true)]

        public string SearchClass
        {
            get { return (string)(base["class"]); }
            set { base["class"] = value; }
        }

        [ConfigurationProperty("param", DefaultValue = "", IsKey = false, IsRequired = false)]

        public string Param
        {
            get { return (string)(base["param"]); }
            set { base["param"] = value; }
        }

    }
}
