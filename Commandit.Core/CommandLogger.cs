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
        private ICommandConsole _console;

        public CommandLogger(ICommandConsole console)
        {
            _console = console;
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

        public bool Confirm()
        {
            var input = _console.ReadParameters("Is this correct? (yes | no)", "yes", "no");

            if (input == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
