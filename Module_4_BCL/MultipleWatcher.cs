using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module_4_BCL
{
    public interface IMultipleWatcher
    {
        WatchedFolders WatchedFolders { get; set; }
        void Run();
    }


    /// <summary>
    /// Responsible for file watching. When file was found MultipleWatcher delegate control to IFileHandler object
    /// </summary>
    public class MultipleWatcher : IMultipleWatcher
    {
        public WatchedFolders WatchedFolders { get; set; }
        public IFileHandler FileHandler { get; set; }

        public MultipleWatcher(IFileHandler fileHandler)
        {
            WatchedFolders = ((CustomConfigurationSection)ConfigurationManager.GetSection("customConfigurationSection")).Folders;
            FileHandler = fileHandler;
        }

        public void Run()
        {
            bool stopWatching = false;
            Console.CancelKeyPress += delegate { stopWatching = true; };
            foreach (var folder in WatchedFolders)
            {
                StartWatch((WatchedFolder)folder);
            }
            while (!stopWatching) { }
        }

        private void StartWatch(WatchedFolder folder)
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher { Path = folder.FolderName };
            fileSystemWatcher.Created += OnChanged;
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private void OnChanged(object source, FileSystemEventArgs e)
        {
            FileHandler.ProcessFile(new FileInfo(e.FullPath));

        }

    }
}
