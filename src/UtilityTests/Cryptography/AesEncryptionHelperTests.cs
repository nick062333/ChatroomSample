using DataClass.Configs;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Utility.Tests
{
    [TestClass()]
    public class AesEncryptionHelperTests
    {
        private static AesEncryptionHelper? _mockAesEncryptionHelper { get; set; }

        [AssemblyInitialize()]
        public static void AssemblyInitialize(TestContext testContext)
        {
            Mock<IServiceScopeFactory> mockServiceScopeFactory = new();
            _mockAesEncryptionHelper = new MockAesEncryptionHelper(mockServiceScopeFactory.Object);

            ////moq不支援設定擴展方法
            //Mock<IServiceProvider> serviceProvider = new Mock<IServiceProvider>();

            //IOptions<AesEncryptionSettings> aesEncryptionSettings = Options.Create<AesEncryptionSettings>(new AesEncryptionSettings()
            //{
            //    Key = "SMZWfgFDtQBT45",
            //    IV = "T4egx@EK9sqB6R3u"
            //});

            //serviceProvider.Setup(x => x.GetRequiredService(typeof(AesEncryptionSettings)))
            //    .Returns(aesEncryptionSettings);

            //Mock<IServiceScope> serviceScope = new Mock<IServiceScope>();

            //serviceScope.Setup(x => x.ServiceProvider).Returns(serviceProvider.Object);

            //serviceProvider.Setup(x => x.CreateScope()).Returns(serviceScope.Object);

            //Mock<IServiceScopeFactory> serviceScopeFactory = new Mock<IServiceScopeFactory>();
            //serviceScopeFactory.Setup(x => x.CreateScope()).Returns(serviceScope.Object);

            //aesEncryptionHelper = new AesEncryptionHelper(serviceScopeFactory.Object);
        }

        [TestMethod()]
        [DataRow("需加密的訊息1234", @"ip/B+FBnR2LJ/RHIpSyCNH4tqy7p+5uwzI9P043VDJU=")]
        [DataRow(@"需加密的訊息!<br>aABC!2345測試ａｂｃ", @"ip/B+FBnR2LJ/RHIpSyCNEE8fMozu/0H1RXH9tBULP1KgbgCT0hziWp/HvQSuS/0")]
        public void EncryptTest(string message, string expected)
        {
            string actual = _mockAesEncryptionHelper!.Encrypt(message);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow("需加密的訊息1234", @"ip/B+FBnR2LJ/RHIpSyCNH4tqy7p+5uwzI9P043VDJU=")]
        [DataRow(@"需加密的訊息!<br>aABC!2345測試ａｂｃ", @"ip/B+FBnR2LJ/RHIpSyCNEE8fMozu/0H1RXH9tBULP1KgbgCT0hziWp/HvQSuS/0")]
        public void DecryptTest(string expected, string encryptText)
        {
            string actual = _mockAesEncryptionHelper!.Decrypt(encryptText);
            Assert.AreEqual(expected, actual);
        }



    }

    public class MockAesEncryptionHelper : AesEncryptionHelper 
    {
        public MockAesEncryptionHelper(IServiceScopeFactory scopeFactory) : base(scopeFactory)
        {
        }

        protected override AesEncryptionSettings GetAesEncryptionSettings() 
        {
            return new AesEncryptionSettings()
            {
                Key = "SMZWfgFDtQBT45!M",
                IV = "T4egx@EK9sqB6R3u"
            };
        }
    }
}