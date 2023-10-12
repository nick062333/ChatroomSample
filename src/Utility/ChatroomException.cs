using DataClass.Enums;
using Utility.Extensions;

namespace Utility
{
    public class ChatroomException : Exception
    {
        public ChatroomException(ChatroomStatusCode chatroomStatusCode) =>
            (ChatroomStatusCode, StatusMessage) = (chatroomStatusCode, chatroomStatusCode.GetDisplayName());

       public ChatroomException(ChatroomStatusCode chatroomStatusCode, string? message = null) =>
            (ChatroomStatusCode, StatusMessage) = (chatroomStatusCode, message);
        public ChatroomStatusCode ChatroomStatusCode { get; }


        public string? StatusMessage { get; }
    }
}