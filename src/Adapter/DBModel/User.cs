namespace Adapter.DBModel
{
    public class User
    {
        public long Id { get; set; }

        public required string Account { get; set; }

        public required string UserName { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
