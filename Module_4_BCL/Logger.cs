using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Module_4_BCL
{
    public interface ILogger
    {
        void Log(string log);
    }
    public class Logger : ILogger
    {
        public void Log(string log)
        {
            Console.WriteLine("LOG *******  : " + log);
        }
    }
}
