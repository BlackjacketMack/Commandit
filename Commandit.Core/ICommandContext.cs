using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    internal interface ICommandContext
    {
        ICommandLogger Logger { get; }
        ICommandParameters Parameters { get; }
        ICommand Command { get; }
    }
}
