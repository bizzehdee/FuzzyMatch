using FuzzyMatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.SoundexTests
{
    public abstract class WhenTestingTheClass : WhenTestingAClass<Soundex>
    {
        protected override void GivenThat()
        {
            base.GivenThat();

            ItemUnderTest = new Soundex();
        }
    }
}
