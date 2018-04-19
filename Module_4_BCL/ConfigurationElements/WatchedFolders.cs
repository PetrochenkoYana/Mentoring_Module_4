using System.Configuration;

namespace Module_4_BCL
{
    public class WatchedFolders : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new WatchedFolder();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((WatchedFolder)element).FolderName;
        }
    }

    public class WatchedFolder : ConfigurationElement
    {
        [ConfigurationProperty("name", IsKey = true)]
        public string FolderName => (string)this["name"];
    }
}