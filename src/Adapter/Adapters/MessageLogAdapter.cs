using System.Data;
using Adapter.Interfaces;
using Adapter.Models;
using Dapper;
using IdentityModel.Internal;

namespace Adapter.Adapters
{
    public class MessageLogAdapter : IMessageLogAdapter
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessageLogAdapter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> GetMessageLogTotalCountByGroupIdAsync(Guid groupId)
        {
            var param = new DynamicParameters();
            param.Add("@GroupId", groupId, DbType.Guid);

            return await _unitOfWork.Connection.QueryFirstAsync<int>("usp_MessageLog_GroupTotalCount_Get", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<long> InsertMessageLogAsync(MessageLog messageLog)
        {
            var param = new DynamicParameters();
            param.Add("@GroupId", messageLog.GroupId, DbType.Guid);
            param.Add("@SendUserId", messageLog.SendUserId, dbType: DbType.Int64);
            param.Add("@Message", messageLog.Message, dbType: DbType.String);
            param.Add("@SendTime", messageLog.SendTime, dbType: DbType.DateTime);

            var messageId = await _unitOfWork.Connection.ExecuteScalarAsync<long>("usp_MessageLog_Insert", param, _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            return messageId;
        }

        public async Task<IEnumerable<MessageLog>> GetNewMessageListAsync(Guid groupId, 
            long startMessageId, int pageNumber, int pageSize)
        {
            var param = new DynamicParameters();
            param.Add("@GroupId", groupId, dbType: DbType.Guid);
            param.Add("@StartId", startMessageId, dbType: DbType.Int64);
            param.Add("@pageNumber", pageNumber, dbType: DbType.Int64);
            param.Add("@pageSize", pageSize, dbType: DbType.Int64);

            return await _unitOfWork.Connection.QueryAsync<MessageLog>("usp_MessageLog_GetNewMessageList", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> GetNewMessageListCountAsync(Guid groupId, long startMessageId)
        {
            var param = new DynamicParameters();
            param.Add("@GroupId", groupId, dbType: DbType.Guid);
            param.Add("@StartId", startMessageId, dbType: DbType.Int64);

            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<int>("usp_MessageLog_GetNewMessageListCount", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MessageLog>> GetHistoryMessageListAsync(Guid groupId, 
            long endMessageId, int pageNumber, int pageSize)
        {
            var param = new DynamicParameters();
            param.Add("@GroupId", groupId, dbType: DbType.Guid);
            param.Add("@EndMessageId", endMessageId, dbType: DbType.Int64);
            param.Add("@pageNumber", pageNumber, dbType: DbType.Int64);
            param.Add("@pageSize", pageSize, dbType: DbType.Int64);

            return await _unitOfWork.Connection.QueryAsync<MessageLog>("usp_MessageLog_GetHistoryList", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> GetHistoryMessageListCountAsync(Guid groupId, long startMessageId)
        {
            var param = new DynamicParameters();
            param.Add("@GroupId", groupId, dbType: DbType.Guid);
            param.Add("@EndMessageId", startMessageId, dbType: DbType.Int64);

            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<int>("usp_MessageLog_GetHistoryListCount", param, commandType: CommandType.StoredProcedure);
        }
    }
}