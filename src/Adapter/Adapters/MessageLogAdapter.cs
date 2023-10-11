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

        public async Task<IEnumerable<MessageLog>> GetMessageLogListAsync(string groupId, int page, int pageSize)
        {
            var param = new DynamicParameters();
            param.Add("@GroupId", groupId, DbType.String);
            param.Add("@PageNumber", page, dbType: DbType.Int64);
            param.Add("@PageSize", pageSize, dbType: DbType.Int64);

            return await _unitOfWork.Connection.QueryAsync<MessageLog>("usp_MessageLog_GetList", param, commandType: CommandType.StoredProcedure);
        }

        public async Task InsertMessageLog(MessageLog messageLog)
        {
            var param = new DynamicParameters();
            param.Add("@GroupId", messageLog.GroupId, DbType.String);
            param.Add("@SendUserId", messageLog.SendUserId, dbType: DbType.Int64);
            param.Add("@Message", messageLog.Message, dbType: DbType.String);
            param.Add("@SendTime", messageLog.SendTime, dbType: DbType.DateTime);

            //dbo.usp_MessageLog_Insert
            await _unitOfWork.Connection.ExecuteAsync("usp_MessageLog_Insert", param, _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
        }
    }
}