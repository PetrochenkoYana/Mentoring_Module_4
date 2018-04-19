using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Module_4_BCL.ConfigurationElements;

namespace Module_4_BCL
{
    public interface IFileHandler
    {
        void ProcessFile(FileInfo file);
    }

    public class FileHandler : IFileHandler
    {
        public ILogger Logger { get; set; }

        public FileHandler(ILogger logger)
        {
            Logger = logger;
        }
        public void ProcessFile(FileInfo file)
        {
            Logger.Log($"New file named {file.Name} was detected. File was created {file.CreationTime} ");

            var rules =
                ((CustomConfigurationSection)ConfigurationManager.GetSection("customConfigurationSection")).Rules;
            bool match = false;
            try
            {
                foreach (var rule in rules)
                {
                    var fileTemplate = ((Rule)rule).FileTemplate;
                    match = Regex.IsMatch(file.Name, @fileTemplate);
                    if (match)
                    {
                        Logger.Log($"Appropriate template was found ");

                        File.Move(file.FullName, CreateFileName((Rule)rule, file));

                        Logger.Log($"File was moved to {((Rule)rule).Destination} directory ");

                        break;
                    }
                }
                if (!match)
                {
                    File.Move(file.FullName, ConfigurationManager.AppSettings["defaultFolder"]);
                    Logger.Log($"Appropriate template was not found. File was moved to {ConfigurationManager.AppSettings["defaultFolder"]} directory ");
                }
            }
            catch (Exception e)
            {
                Logger.Log(e.Message);
            }
        }

        private static string CreateFileName(Rule rule, FileInfo fileInfo)
        {
            StringBuilder sb = new StringBuilder();
            var directory = new DirectoryInfo(rule.Destination);
            var fileNumber = directory.GetFiles().Length + 1;
            sb.Append(rule.Destination + "\\");
            if (rule.AddIndexNumber)
                sb.Append(fileNumber.ToString() +". ");
            if (rule.AddMoveDate)
                sb.Append(DateTime.Now.ToString(CultureInfo.CurrentCulture).Replace('/','-').Replace(':','-') + " ");
            sb.Append(fileInfo.Name);

            return sb.ToString();
        }

    }
}
