using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Searcher.OwnSectionRead
{
    class SearchProviderSection:ConfigurationSection
    {
        [ConfigurationProperty("searchProviderSettings")]
        public SearchAssemColl AssemblyColl
        {
            get { return ((SearchAssemColl)(base["searchProviderSettings"])); }
        }
    }
}
