using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Resources;

namespace Module_4_BCL
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = ((CustomConfigurationSection)ConfigurationManager.GetSection("customConfigurationSection")).Culture.CultureDate;

            Console.WriteLine(Resources.Resources.StartApplication);
            MultipleWatcher multipleWatcher = new MultipleWatcher(new FileHandler(new Logger()));
            multipleWatcher.Run();

        }
    }
}
