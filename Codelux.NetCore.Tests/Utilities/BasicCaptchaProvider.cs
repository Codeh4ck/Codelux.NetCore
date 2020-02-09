using System.Drawing;
using Codelux.NetCore.Utilities;
using NUnit.Framework;

namespace Codelux.NetCore.Tests.Utilities
{
    [TestFixture]
    public class BasicCaptchaProviderTests
    {
        private BasicCaptchaProvider _captchaProvider;

        [SetUp]
        public void Setup()
        {
            _captchaProvider = new BasicCaptchaProvider();
        }

        [Test]
        public void GivenBasicCaptchaProviderWhenIGenerateACaptchaThenBitmapIsReturned()
        {
            Bitmap captcha = _captchaProvider.CreateCaptchaImage();

            Assert.NotNull(captcha);
            Assert.NotNull(_captchaProvider.CaptchaText);
            Assert.Greater(_captchaProvider.CaptchaText.Length, 0);

            Assert.AreEqual(200, captcha.Width);
            Assert.AreEqual(50, captcha.Height);
        }
    }
}
