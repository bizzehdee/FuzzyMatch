using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.SoundexTests.ProcessTests
{
    [TestFixture]
    [Category("Soundex")]
    public class WhenUsingTestStringAshcroft : WhenTestingTheClass
    {
        protected string Result;

        protected override void When()
        {
            Result = ItemUnderTest.Process("Ashcroft");
        }

        [Test]
        public void SoundExShouldBeA261()
        {
            Assert.That(Result, Is.EqualTo("A261"));
        }
    }
}
