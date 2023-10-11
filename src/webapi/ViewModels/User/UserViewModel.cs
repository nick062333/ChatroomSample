namespace webapi.ViewModels.Users
{
    public class UserViewModel
    {
        public UserViewModel(string userName, string account, string password)
        {
            UserName = userName;
            Account = account;
            Password = password;
        }

        public string UserName { get; set; }
        
        public string Account { get; set; }

        public string Password { get; set; }
    }
}
