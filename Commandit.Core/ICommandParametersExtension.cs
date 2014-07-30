using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commandit
{
    public static class ICommandParametersExtension
    {
        public static string GetAttribute(this ICommandParameters commandParameters, string key, bool required = true)
        {
            var containsKey = commandParameters.Attributes.ContainsKey(key);

            if (required && !containsKey)
            {
                throw new ArgumentException("Attribute missing", key);
            }
            else if (!containsKey)
            {
                return null;
            }

            return commandParameters.Attributes[key];
        } 
    }
}
