using NUnit.Framework;
using System.Collections.Generic;
using Codelux.NetCore.Common.Extensions;

namespace Codelux.NetCore.Tests.Extensions
{
    [TestFixture]
    public class DictionaryExtensionsTests
    {
        [Test]
        public void GivenDictionaryWhenISetItemAndItDoesNotExistThenItemIsAdded()
        {
            Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
            dictionary.Set("Item", true);

            Assert.AreEqual(1, dictionary.Count);
            Assert.AreEqual(true, dictionary["Item"]);
        }

        [Test]
        public void GivenDictionaryWhenISetItemAndItExistsThenValueIsReplaced()
        {
            Dictionary<string, bool> dictionary = new Dictionary<string, bool>();
            dictionary.Set("Item", true);

            Assert.AreEqual(1, dictionary.Count);
            Assert.AreEqual(true, dictionary["Item"]);

            dictionary.Set("Item", false);

            Assert.AreEqual(1, dictionary.Count);
            Assert.AreEqual(false, dictionary["Item"]);
        }

        [Test]
        public void GivenDictionaryWhenIAddARangeOfItemsThenItemsAreAdded()
        {
            List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("One", 1),
                new KeyValuePair<string, int>("Two", 2),
                new KeyValuePair<string, int>("Three", 3)
            };

            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.AddRange(list);

            Assert.AreEqual(list.Count, dictionary.Count);

            foreach (KeyValuePair<string, int> pair in dictionary)
                Assert.IsTrue(list.Contains(pair));
        }
    }
}
