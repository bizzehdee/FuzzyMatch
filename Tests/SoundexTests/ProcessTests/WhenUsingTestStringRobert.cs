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
    public class WhenUsingTestStringRobert : WhenTestingTheClass
    {
        protected string Result;

        protected override void When()
        {
            Result = ItemUnderTest.Process("Robert");
        }

        [Test]
        public void SoundExShouldBeR163()
        {
            Assert.That(Result, Is.EqualTo("R163"));
        }
    }
}
