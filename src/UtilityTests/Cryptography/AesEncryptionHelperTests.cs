using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Utility.Tests
{
    [TestClass()]
    public class AesEncryptionHelperTests
    {
        /// <summary>
        /// // key:16字节（128位）的AES密钥
        /// </summary>
        private const string _key = "SMZWfgFDtQBT45!M";

        /// <summary>
        /// iv:16字节（128位）的初始向量
        /// </summary>
        private const string _iv = "T4egx@EK9sqB6R3u";

        //[AssemblyInitialize]
        //public static async Task AssemblyInitialize(TestContext testContext)
        //{
            
        //}

        [TestMethod()]
        [DataRow("需加密的訊息1234", @"ip/B+FBnR2LJ/RHIpSyCNH4tqy7p+5uwzI9P043VDJU=")]
        [DataRow(@"需加密的訊息!<br>aABC!2345測試ａｂｃ", @"ip/B+FBnR2LJ/RHIpSyCNEE8fMozu/0H1RXH9tBULP1KgbgCT0hziWp/HvQSuS/0")]
        public void EncryptTest(string message, string expected)
        {
            string actual = AesEncryptionHelper.Encrypt(message, _key, _iv);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow("需加密的訊息1234", @"ip/B+FBnR2LJ/RHIpSyCNH4tqy7p+5uwzI9P043VDJU=")]
        [DataRow(@"需加密的訊息!<br>aABC!2345測試ａｂｃ", @"ip/B+FBnR2LJ/RHIpSyCNEE8fMozu/0H1RXH9tBULP1KgbgCT0hziWp/HvQSuS/0")]
        public void DecryptTest(string expected, string encryptText)
        {
            string actual = AesEncryptionHelper.Decrypt(encryptText, _key, _iv);
            Assert.AreEqual(expected, actual);
        }
    }
}