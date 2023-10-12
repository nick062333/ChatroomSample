using DataClass.Enums;
using Utility.Extensions;

namespace Utility
{
    public class ChatroomException : Exception
    {
        public ChatroomException(ChatroomStatusCode chatroomStatusCode, string? value = null) =>
            (ChatroomStatusCode, Value) = (chatroomStatusCode, chatroomStatusCode.GetDisplayName());

        public ChatroomStatusCode ChatroomStatusCode { get; }

        public string? Value { get; }
    }
}