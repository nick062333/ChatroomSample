using DataClass.Enums;

namespace Adapter.DBModel
{
    /// <summary>
    /// 聊天室
    /// </summary>
    public class Chatroom
    {
        public Guid Id { get; set; }

        public ChatroomType ChatroomType { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
