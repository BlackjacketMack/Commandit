using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    public static class ICommandExtension
    {
        public static CommandAttribute GetCommandAttribute(this ICommand command)
        {
            var attribute = command.GetType().GetCustomAttributes(typeof(CommandAttribute), false).Cast<CommandAttribute>().FirstOrDefault();

            if (attribute == null)
            {
                attribute = new CommandAttribute { Name = command.GetType().Name };
            }

            return attribute;
        }
    }
}
