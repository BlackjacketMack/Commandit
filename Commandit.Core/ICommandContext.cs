using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    public interface ICommandContext
    {
        ICommandConsole Console { get; }
        ICommandParameters Parameters { get; }
        ICommand Command { get; }
    }
}
