using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    public class CommandLogger : ICommandLogger
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
