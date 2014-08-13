using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit.Sample
{
    [CommandAttribute(  Description="This is a sample command.",
                        Group="Environment 1",
                        Order=1)]
    class SampleCommand : ICommand
    {
        public string Name
        {
            get { return "SampleCommand"; }
        }

        public void Run(ICommandContext context)
        {
            context.Logger.WriteLine("Hi");
        }
    }
}
