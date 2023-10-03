namespace Adapter.DBModel
{
    public class ChatroomMember
    {
        public long Id { get; set; }

        public required string ChatroomId { get; set; }

        public required string UserId { get; set; }
    }
}
