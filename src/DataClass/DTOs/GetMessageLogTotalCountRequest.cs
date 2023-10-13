namespace DataClass.DTOs
{
    public class GetMessageLogTotalCountRequest 
    {
        public GetMessageLogTotalCountRequest(Guid groupId)
        {
            GroupId = groupId;
        }

        public Guid GroupId { get; set; }
    }
}
