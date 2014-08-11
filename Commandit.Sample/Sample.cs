using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit.Sample
{
    class Sample : CommandConsole
    {
        static void Main(string[] args)
        {
            var sample = new Sample();

            sample.Init();
        }

        public Sample() : base("Sample Application")
        {

        }

        public override void Init()
        {
            this.Commands = new ICommand[]{
                new SampleCommand()
            };
            
            base.Init();
        }
    }
}
