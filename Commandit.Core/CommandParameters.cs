using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    class CommandParameters : ICommandParameters
    {
        public const StringComparison ComparisonType = StringComparison.OrdinalIgnoreCase;

        public string Name { get; set; }

        public IDictionary<string,string> Attributes { get; set; }

        public CommandParameters()
        {
            this.Attributes = new Dictionary<string, string>();
        }

        public string GetAttribute(string key, bool required = true)
        {
            var containsKey = this.Attributes.ContainsKey(key);

            if (required && !containsKey)
            {
                throw new ArgumentException("Attribute missing", key);
            }
            else if (!containsKey)
            {
                return null;
            } 

            return this.Attributes[key];
        }

        public const string ATTRIBUTE_KEY = "--";
        /// <summary>
        /// Searches an input string and converts to a dictionary.
        /// Any parameter beginning with '--' is a 'key', and optionally and 
        /// value after that is the value.
        /// </summary>
        /// <returns></returns>
        public static IDictionary<string, string> ParseAttributes(string input)
        {
            var attributes = new Dictionary<string, string>();
            var inputSplit = input.Split(' ').ToList();

            for (int i = 0; i < inputSplit.Count(); i++)
            {
                if (inputSplit[i].StartsWith(ATTRIBUTE_KEY))
                {
                    var key = inputSplit[i];
                    var value = inputSplit.ElementAtOrDefault(i + 1);

                    if (value == null || value.StartsWith("--"))
                    {

                        attributes.Add(inputSplit[i], null);
                    }
                    else
                    {
                        attributes.Add(key, value);
                        i++;
                    }
                }
            }

            return attributes;
        }
    }
}
