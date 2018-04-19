using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Module_4_BCL.ConfigurationElements
{
    public class Rules : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Rule();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Rule)element).FileTemplate;
        }
    }

    public class Rule : ConfigurationElement
    {
        [ConfigurationProperty("regularExpression")]
        public string FileTemplate => (string)this["regularExpression"];

        [ConfigurationProperty("destinationPath")]
        public string Destination => (string)this["destinationPath"];

        [ConfigurationProperty("addIndexNumber")]
        public bool AddIndexNumber => (bool)this["addIndexNumber"];

        [ConfigurationProperty("addMoveDate")]
        public bool AddMoveDate => (bool)this["addMoveDate"];
    }
}