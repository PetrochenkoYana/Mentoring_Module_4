using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Module_4_BCL.ConfigurationElements;

namespace Module_4_BCL
{
    public class CustomConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("culture")]
        public ApplicationCulture Culture => (ApplicationCulture)this["culture"];

        [ConfigurationProperty("folders")]
        public WatchedFolders Folders => (WatchedFolders)this["folders"];

        [ConfigurationProperty("rules")]
        public Rules Rules => (Rules) this["rules"];
    }
}
