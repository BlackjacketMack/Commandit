using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    public class CommandContext : ICommandContext
    {

        public ICommandLogger Logger { get; private set; }

        public ICommandParameters Parameters { get; private set; }

        public ICommand Command { get; private set; }

        public CommandContext(ICommandLogger logger,
                                ICommandParameters parameters,
                                ICommand command)
        {
            this.Logger = logger;
            this.Parameters = parameters;
            this.Command = command;
        }
    }
}
