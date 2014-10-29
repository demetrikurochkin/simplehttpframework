using System;
using System.Linq;
using System.Runtime.InteropServices;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Xavier.Integration.Tests.Helpers
{
    public static class JsonParserHelper
    {
        public static Tuple<bool?, string>  IsJsonResponseCorrect(string requiredValues, string httpResponse)
        {
            bool? containsAllValues = false;
            string responseErrorValue = "";

            var verifiableValues = requiredValues
                .Split(',')
                .Select(value => value.Trim(' ', '\t'));
            var jsonRequiredString = JObject.Parse(httpResponse);

            foreach (var value in verifiableValues)
            {
                if (jsonRequiredString.ToString().Contains(value))
                {
                    containsAllValues = true;
                }
                else
                {
                    containsAllValues = null;
                    responseErrorValue = value;
                    break;
                }
            }
            return Tuple.Create(containsAllValues, responseErrorValue);
        }

        public static bool ContainsRequiredValuesInJArray()
        {
            return false;//TODO
        }
    }
}
