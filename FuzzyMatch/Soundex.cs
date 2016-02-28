using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FuzzyMatch
{
    public class Soundex
    {
        private readonly Regex codexStepOne = new Regex("(?<!^)([aouieyhw]*(?![aouieyhw]))", RegexOptions.ECMAScript | RegexOptions.IgnoreCase);
        private readonly IDictionary<string, string> codexStepTwo = new Dictionary<string, string>()
        {
            {"([bfpv]+)", "1"},
            {"([cgjkqsxz]+)", "2"},
            {"([dt]+)", "3"},
            {"([l]+)", "4"},
            {"([mn]+)", "5"},
            {"([r]+)", "6"},
        };

        public string Process(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("str cannot be null", "str");
            }

            var codex = str.ToUpper();

            codex = codexStepOne.Replace(codex, "");

            var charOne = codex.Substring(0, 1);
            var charRest = codex.Substring(1);

            foreach (var step in codexStepTwo)
            {
                charRest = Regex.Replace(charRest, step.Key, step.Value, RegexOptions.ECMAScript | RegexOptions.IgnoreCase);
            }

            codex = charOne + charRest;

            if (codex.Length > 4)
            {
                codex = codex.Substring(0, 4);
            }
            else if (codex.Length < 4)
            {
                codex = codex.PadRight(4, '0');
            }

            return codex;
        }
    }
}
