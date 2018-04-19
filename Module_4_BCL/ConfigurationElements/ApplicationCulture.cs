using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_4_BCL.ConfigurationElements
{
    public class ApplicationCulture : ConfigurationElement
    {
        [ConfigurationProperty("name")]
        public string CultureName => (string)this["name"];
        public CultureInfo CultureDate => CultureInfo.GetCultureInfo(CultureName);
    }
}
