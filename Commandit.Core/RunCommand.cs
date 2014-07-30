using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    [CommandAttribute(true,
                        Name="Run",
                        Description = "This Run Command is used to invoke other commands. For example: run --all, run --name MyCommand, run --group MyGroup, run --step 3 ")]
    public class RunCommand : ICommand
    {
        private IDictionary<CommandAttribute, ICommand> _commandDictionary;

        public RunCommand(IDictionary<CommandAttribute, ICommand> commandDictionary)
        {
            _commandDictionary = commandDictionary;
        }

        public void Run(ICommandParameters parameters)
        {
            var name = parameters.GetAttribute("name",false);
            var group = parameters.GetAttribute("group",false);

            if (name != null)
            {
                Console.WriteLine("Running command " + name);
            }
            else
            {
                Console.WriteLine("How would you like to run your commands?");
            }
        }
    }
}
