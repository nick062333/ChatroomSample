using System.Data;
using Adapter.Interfaces;
using Adapter.Models;
using Dapper;

namespace Adapter.Adapters
{
    public class MessageLogAdapter : IMessageLogAdapter
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessageLogAdapter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task InsertMessageLog(MessageLog messageLog)
        {
            var param = new DynamicParameters();
            param.Add("@ChatroomId", messageLog.ChatroomId, DbType.String);
            param.Add("@SendUserId", messageLog.SendUserId, dbType: DbType.Int64);
            param.Add("@Message", messageLog.Message, dbType: DbType.String);
            param.Add("@SendTime", messageLog.SendTime, dbType: DbType.DateTime);

            //dbo.usp_MessageLog_Insert
            await _unitOfWork.Connection.ExecuteAsync("usp_MessageLog_Insert", param, _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
        }
    }
}