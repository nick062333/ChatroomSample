namespace DataClass.Configs
{
    public class AesEncryptionSettings
    {
        /// <summary>
        /// key:16字节（128位）的AES密钥
        /// </summary>
        public string Key { get;set;}

        /// <summary>
        /// iv:16字节（128位）的初始向量
        /// </summary>
        public string IV { get;set;}
    }
}