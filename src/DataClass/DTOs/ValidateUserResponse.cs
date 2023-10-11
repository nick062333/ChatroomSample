namespace DataClass.DTOs
{
    public class ValidateUserResponse
    {
        public ValidateUserResponse(bool isVaild, long userId, string userName)
        {
            IsVaild = isVaild;
            UserId = userId;
            UserName = userName;
        }

        public bool IsVaild { get; set; }

        public long UserId { get; set; }

        public string UserName { get; set; }
    }
}