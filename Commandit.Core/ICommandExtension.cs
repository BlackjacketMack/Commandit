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

            return attribute;
        }

        public static ICommand GetCommand(  this IEnumerable<ICommand> commands,
                                            string name = null)
        {
            return commands.Select(s => new
            {
                Command = s,
                Attribute = s.GetCommandAttribute()
            })
            .Where(w => (name == null || w.Command.Name.Equals(name,StringComparison.OrdinalIgnoreCase)))
            .Select(s => s.Command)
            .SingleOrDefault();
        }

        public static IEnumerable<CommandAttribute> GetAttributes(this IEnumerable<ICommand> commands)
        {
            return commands.Select(s => s.GetCommandAttribute());
        }
    }
}
