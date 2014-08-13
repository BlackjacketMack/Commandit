using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    [CommandAttribute(true,
                        Description = "This Run Command is used to invoke other commands. For example: run --all, run --name MyCommand, run --group MyGroup, run --step 3 ")]
    public class RunCommand : ICommand
    {
        public string Name
        {
            get { return "Run"; }
        }

        private IEnumerable<ICommand> _commands;

        public RunCommand(IEnumerable<ICommand> commands)
        {
            _commands = commands;
        }

        public void Run(ICommandContext context)
        {
            var parameters = context.Parameters;

            var name = parameters.GetAttribute("name",false);
            var group = parameters.GetAttribute("group",false);
            ICommand commandToRun = null;

            if (name != null)
            {
                Console.WriteLine("Running command " + name);

                commandToRun = _commands.GetCommand(name: name);
                commandToRun.Run(context);
            }
            else
            {
                Console.WriteLine("How would you like to run your commands?");
            }
        }
    }
}
