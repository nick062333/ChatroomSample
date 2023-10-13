using DataClass.Configs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Security.Cryptography;
using System.Text;

namespace Utility
{
    public class AesEncryptionHelper
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public AesEncryptionHelper(IServiceScopeFactory scopeFactory) 
        {
            _scopeFactory = scopeFactory;
        }

        protected virtual AesEncryptionSettings GetAesEncryptionSettings() 
        {
            using var scope = _scopeFactory.CreateScope();
            var aesEncryptionSettings = scope.ServiceProvider.GetRequiredService<IOptions<AesEncryptionSettings>>();
            return aesEncryptionSettings.Value;
        }

        public string Encrypt(string plainText)
        {
            using Aes aesAlg = Aes.Create();

            var aesEncryptionSettings = GetAesEncryptionSettings();
            aesAlg.Key = Encoding.UTF8.GetBytes(aesEncryptionSettings.Key);
            aesAlg.IV = Encoding.UTF8.GetBytes(aesEncryptionSettings.IV);

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msEncrypt = new();

            using (CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using StreamWriter swEncrypt = new(csEncrypt);
                swEncrypt.Write(plainText);
            }

            //return msEncrypt.ToArray();
            return Convert.ToBase64String(msEncrypt.ToArray());
        }

        public string Decrypt(string cipherText)
        {
            using Aes aesAlg = Aes.Create();

            var aesEncryptionSettings = GetAesEncryptionSettings();
            aesAlg.Key = Encoding.UTF8.GetBytes(aesEncryptionSettings.Key);
            aesAlg.IV = Encoding.UTF8.GetBytes(aesEncryptionSettings.IV);

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using MemoryStream msDecrypt = new(Convert.FromBase64String(cipherText));
            using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
            using StreamReader srDecrypt = new(csDecrypt);

            return srDecrypt.ReadToEnd();
        }
    }
}