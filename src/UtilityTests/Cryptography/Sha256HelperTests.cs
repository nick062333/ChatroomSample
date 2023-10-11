using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utility.Cryptography.Tests
{
    [TestClass()]
    public class Sha256HelperTests
    {
        [TestMethod()]
        [DataRow("ABCabc123!@", "9f5f6407f78bd8734956730a573ee1438388c7558c47762f458fc9486375fcf5")]
        [DataRow("asdfew1234143252dsade2dsffsfd!@", "93053c8c40d1956c8d7519fb8be2382eac96b1303af7bdb0329245ab7a0524c7")]
        public void EncryptTest(string source, string expected)
        {
            var actual = Sha256Helper.Encrypt(source);
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(actual.Length, 64);
        }
    }
}