namespace DataClass.DTOs
{
    public class ValidateUserResponse
    {
        public ValidateUserResponse(long userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }

        public long UserId { get; set; }

        public string UserName { get; set; }
    }
}