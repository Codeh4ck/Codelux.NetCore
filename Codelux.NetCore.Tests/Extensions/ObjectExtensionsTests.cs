using System;
using Codelux.NetCore.Common.Extensions;
using NUnit.Framework;

namespace Codelux.NetCore.Tests.Extensions
{
    [TestFixture]
    public class ObjectExtensionsTests
    {
        [Test]
        public void GivenObjectThatIsNullWhenIGuardThenArgumentNullExceptionIsThrownWithCorrectMessage()
        {
            object obj = null;

            ArgumentNullException exception = 
                Assert.Throws<ArgumentNullException>(delegate() { obj.Guard(nameof(obj)); });

            Assert.IsNotNull(exception);
            Assert.IsTrue(exception.Message.Contains(nameof(obj)));
        }

        [Test]
        public void GivenObjectThatIsNotNullWhenIGuardNoExceptionIsThrown()
        {
            object obj = new object();
            Assert.DoesNotThrow(delegate () { obj.Guard(nameof(obj)); });
        }
    }
}
