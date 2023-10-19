using MediatR;

namespace webapi.Events
{
    public record ChatroomRemindNoticeSendEvent(Guid ChatroomId, long SendUserId, long MessageId) 
        : INotification;
}
