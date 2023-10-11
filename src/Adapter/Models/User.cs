using Utility.Cryptography;

namespace Adapter.Models
{
    public class User
    {
        public User()
        {}
        
        public User(string userName, string account, DateTime createTime)
        {
            UserName = userName;
            Account = account;
            CreateTime = createTime;
        }

        public long Id { get; set; }

        public string Account { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public DateTime CreateTime { get; set; }

        public void SetPassword(string password) 
        {
            this.Password = Sha256Helper.Encrypt(password);
        }
    }
}
