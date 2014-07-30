using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    public interface ICommand
    {
        void Run(ICommandParameters parameters);
    }
}
