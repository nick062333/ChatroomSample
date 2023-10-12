using DataClass.Enums;

namespace DataClass
{
    public sealed class ResponseBase
    {
        public ResponseBase(){}

        public ResponseBase(ChatroomStatusCode chatroomStatusCode, string description){
            ChatroomStatusCode = chatroomStatusCode;
            Description = description;
        }

        public ResponseBase(ChatroomStatusCode chatroomStatusCode, string description, object data){
            ChatroomStatusCode = chatroomStatusCode;
            Description = description;
            Data = data;
        }
        public ResponseBase(object data){
            ChatroomStatusCode = ChatroomStatusCode.Success;
            Description = string.Empty;
            Data = data;
        }

        public ChatroomStatusCode ChatroomStatusCode { get; set; }
        
        public string Description { get; set; }

        public object Data { get; set; }
    };
}