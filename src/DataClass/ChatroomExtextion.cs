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

        public ChatroomException(string message, ChatroomeExceptionCode chatroomErrorCode)
          : base(message)
            {
            }
    }
}
