using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    public interface ICommandConsole
    {
        IEnumerable<ICommand> Commands { get; }
        void Init();
    }
}
