﻿using Codelux.NetCore.Utilities;
using NUnit.Framework;

namespace Codelux.NetCore.Tests.Utilities
{
    [TestFixture]
    public class Md5PasswordEncryptorTests
    {
        private Md5PasswordEncryptor _encryptor;

        private const string PlainTextPassword = "TestPassword123";
        private const string HashedPassword = "9b599faac222a0dfcfab49148ce40c26";

        [SetUp]
        public void Setup()
        {
            _encryptor = new Md5PasswordEncryptor();
        }

        [Test]
        public void GivenMd5EncryptorWhenIEncryptAPasswordThenValidMd5HashIsReturned()
        {
            string md5 = _encryptor.Encrypt(PlainTextPassword);
            Assert.AreEqual(HashedPassword, md5);
        }

        [Test]
        public void GivenMd5EncryptorWhenIDecryptThenHashedPasswordIsReturned()
        {
            string result = _encryptor.Decrypt(HashedPassword);
            Assert.AreEqual(HashedPassword, result);
        }
    }
}
