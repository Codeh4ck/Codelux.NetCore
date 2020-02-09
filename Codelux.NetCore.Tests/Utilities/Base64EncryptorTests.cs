using NUnit.Framework;
using Codelux.NetCore.Utilities;

namespace Codelux.NetCore.Tests.Utilities
{
    [TestFixture]
    public class Base64EncryptorTests
    {
        private Base64Encryptor _encryptor;

        private const string TestString = "This is a test string!";
        private const string TestStringBase64 = "VGhpcyBpcyBhIHRlc3Qgc3RyaW5nIQ==";

        [SetUp]
        public void Setup()
        {
            _encryptor = new Base64Encryptor();
        }

        [Test]
        public void GivenBase64EncryptorWhenIEncryptThenValidBase64IsReturned()
        {
            string result = _encryptor.Encrypt(TestString);
            Assert.AreEqual(TestStringBase64, result);
        }

        [Test]
        public void GivenBase64EncryptorWhenIDecryptBase64StringThenCorrectResultIsReturned()
        {
            string result = _encryptor.Encrypt(TestString);
            Assert.AreEqual(TestStringBase64, result);

            result = _encryptor.Decrypt(result);
            Assert.AreEqual(TestString, result);
        }
    }
}
