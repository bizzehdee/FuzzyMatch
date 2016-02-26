using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public abstract class WhenTestingAClass<T> where T : class
    {
        protected T ItemUnderTest { get; set; }

        [SetUp]
        public void SetUp()
        {
            GivenThat();
            When();
        }

        protected virtual void GivenThat()
        {

        }

        protected abstract void When();
    }
}
