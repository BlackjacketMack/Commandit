using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit.Sample
{
    [CommandAttribute(  Name="SampleCommandOne",
                        Description="This is a sample command.",
                        Group="Environment 1",
                        Order=1)]
    class SampleCommandOne : ICommand
    {
        public void Run(ICommandParameters parameters)
        {
            Console.Write("Hi");
        }
    }
}
