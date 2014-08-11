using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    [CommandAttribute(true, 
                        Description="This is the default help command.")]
    public class HelpCommand : ICommand
    {
        public string Name
        {
            get { return "Help"; }
        }

        private IEnumerable<ICommand> _commands;

        public HelpCommand(IEnumerable<ICommand> commands)
        {
            _commands = commands;
        }

        public void Run(ICommandParameters parameters)
        {
            Console.WriteLine("Welcome to the Commandit help section.");
            Console.WriteLine("--------------------------------------");

            var dictionary = _commands.ToDictionary(k => k.GetCommandAttribute(), v=>v);

            foreach (var entry in dictionary.OrderByDescending(ob => ob.Key.IsInternal))
            {
                describeEntry(entry.Key,entry.Value);
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }

        private void describeEntry(CommandAttribute attribute,ICommand command)
        {
            Console.WriteLine("Name = " + command.Name);
            Console.WriteLine("Description = " + attribute.Description);
            Console.WriteLine("Order = " + attribute.Order);
            Console.WriteLine("Group = " + attribute.Group);
            Console.WriteLine("Internal = " + attribute.IsInternal);
        }
    }
}
