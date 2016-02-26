using FuzzyMatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.ApproximateTests
{
    public abstract class WhenTestingTheClass : WhenTestingAClass<MatchRating>
    {
        protected override void GivenThat()
        {
            base.GivenThat();

            ItemUnderTest = new MatchRating();
        }
    }
}
