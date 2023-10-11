using DataClass.Enums;
using Utility.Extensions;

namespace Utility
{
    public class ChatroomException : Exception
    {
        public ChatroomException(int code, object? value = null) =>
            (ErrorCode, Value) = (code, value);

        public ChatroomException(ChatroomeExceptionCode errorCode, object? value = null) =>
            (ErrorCode, Value) = ((int)errorCode, errorCode.GetDisplayName());

        public int ErrorCode { get; }

        public object? Value { get; }
    }
}