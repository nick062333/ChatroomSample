using DataClass.Enums;
using Utility.Extensions;

namespace Utility
{
    public class ChatroomException : Exception
    {
        public ChatroomException(int statusCode, object? value = null) =>
            (StatusCode, Value) = (statusCode, value);

        public ChatroomException(ChatroomeExceptionCode statusCode, object? value = null) =>
            (StatusCode, Value) = ((int)statusCode, statusCode.GetDisplayName());

        public int StatusCode { get; }

        public object? Value { get; }
    }
}