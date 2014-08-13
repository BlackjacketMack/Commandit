using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    public static class ICommandConsoleExtension
    {
        public static void WriteLine(this ICommandConsole console, string message, string lineBreak = null)
        {
            Console.WriteLine(message);

            if (lineBreak != null)
            {
                Console.WriteLine(lineBreak);
            }
        }

        public static string ReadParameters(this ICommandConsole console, string message, params string[] allowedParameters)
        {
            Console.WriteLine("");
            Console.Write(message);

            var input = Console.ReadLine()
                               .Trim()
                               .ToLowerInvariant();

            if (allowedParameters.Any() && !allowedParameters.Contains(input))
            {
                Console.WriteLine("Unknown input...");
                input = console.ReadParameters(message, allowedParameters);
            }

            return input;
        }

        public static string ReadLine(this ICommandConsole console)
        {
            return Console.ReadLine()
                               .Trim()
                               .ToLowerInvariant();
        }

        public static void WriteError(this ICommandConsole console, string message)
        {
            Console.WriteLine("ERROR: " + message);
        }

        public static bool Confirm(this ICommandConsole console)
        {
            var input = console.ReadParameters("Is this correct? (yes | no)", "yes", "no");

            if (input == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
