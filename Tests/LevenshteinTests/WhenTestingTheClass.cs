using FuzzyMatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.LevenshteinTests
{
    public abstract class WhenTestingTheClass : WhenTestingAClass<Levenshtein>
    {
        protected override void GivenThat()
        {
            base.GivenThat();

            ItemUnderTest = new Levenshtein();
        }
    }
}
