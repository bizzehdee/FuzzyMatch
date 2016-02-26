using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FuzzyMatch
{
    public class Levenshtein
    {
        public int Distance(string s, string t)
        {
            return Distance(s, s != null ? s.Length : 0, t, t != null ? t.Length : 0);
        }


        public int Distance(string s, int lenS, string t, int lenT)
        {
            if (lenS == 0)
            {
                return 0;
            }

            if (lenT == 0)
            {
                return 0;
            }

            int cost = 0;

            if (s[lenS - 1] == t[lenT - 1])
            {
                cost = 0;
            }
            else
            {
                cost = 1;
            }

            int a = Distance(s, lenS - 1, t, lenT) + 1;
            int b = Distance(s, lenS, t, lenT - 1) + 1;
            int c = Distance(s, lenS - 1, t, lenT - 1) + cost;

            return Math.Min(a, Math.Min(b, c));
        }
    }
}
