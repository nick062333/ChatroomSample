using DataClass.Enums;

namespace DataClass
{
    public class ChatroomException : Exception
    {
        public ChatroomException()
        {
        }

        public ChatroomException(string message)
            : base(message)
        {
        }

        public ChatroomException(string message, ChatroomErrorCode chatroomErrorCode)
          : base(message)
            {
            }
    }
}
