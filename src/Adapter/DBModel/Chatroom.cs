using DataClass.Enums;

namespace Adapter.DBModel
{
    public class Chatroom
    {
        public long Id { get; set; }

        public ChatroomType ChatroomType { get; set; }

        public string ChatroomName { get; set; }
    }
}
