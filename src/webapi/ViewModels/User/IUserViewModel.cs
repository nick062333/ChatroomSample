namespace webapi.ViewModels.Users
{
    public interface IUserViewModel
    {
        string Account { get; set; }
        string Password { get; set; }
        string UserName { get; set; }
    }
}