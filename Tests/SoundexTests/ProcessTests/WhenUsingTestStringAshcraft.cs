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
    public class WhenUsingTestStringAshcraft : WhenTestingTheClass
    {
        protected string Result;

        protected override void When()
        {
            Result = ItemUnderTest.Process("Ashcraft");
        }

        [Test]
        public void SoundExShouldBeA261()
        {
            Assert.That(Result, Is.EqualTo("A261"));
        }
    }
}
