using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    public interface ICommandParameters
    {
        string Name { get; set; }

        IDictionary<string, string> Attributes { get; set; }
    }
}
