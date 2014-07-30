using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    [CommandAttribute(true, 
                        Name = "Help",
                        Description="This is the default help command.")]
    public class HelpCommand : ICommand
    {
        private IDictionary<CommandAttribute, ICommand> _commandDictionary;

        public HelpCommand(IDictionary<CommandAttribute, ICommand> commandDictionary)
        {
            _commandDictionary = commandDictionary;
        }

        public void Run(ICommandParameters parameters)
        {
            Console.WriteLine("Welcome to the Commandit help section.");
            Console.WriteLine("--------------------------------------");

            foreach (var entry in _commandDictionary.OrderByDescending(ob=>ob.Key.IsInternal))
            {
                describeEntry(entry.Key,entry.Value);
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }

        private void describeEntry(CommandAttribute attribute,ICommand command)
        {
            Console.WriteLine("Name = "  + attribute.Name);
            Console.WriteLine("Description = " + attribute.Description);
            Console.WriteLine("Order = " + attribute.Order);
            Console.WriteLine("Group = " + attribute.Group);
            Console.WriteLine("Internal = " + attribute.IsInternal);
        }
    }
}
