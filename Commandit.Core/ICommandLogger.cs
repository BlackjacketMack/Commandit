using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    public interface ICommandLogger
    {
        void WriteLine(string message);
        bool Confirm();
    }
}
