using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple=false)]
    public class CommandAttribute : Attribute
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
    }
}
