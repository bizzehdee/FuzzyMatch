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
    public class WhenStringIsEmpty : WhenTestingTheClass
    {
        protected bool ThrewException;

        protected override void When()
        {
            try
            {
                ItemUnderTest.Process(string.Empty);
            }
            catch (ArgumentException)
            {
                ThrewException = true;
            }
        }

        [Test]
        public void ShouldThrowAnArgumentException()
        {
            Assert.That(ThrewException, Is.True);
        }
    }
}
