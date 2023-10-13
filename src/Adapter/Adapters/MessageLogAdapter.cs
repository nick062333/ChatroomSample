using System.Data;
using System.Text.RegularExpressions;
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

        public async Task<IEnumerable<MessageLog>> GetMessageLogListAsync(Guid groupId, int startIndex, int pageSize)
        {
            var param = new DynamicParameters();
            param.Add("@GroupId", groupId, DbType.Guid);
            param.Add("@StartIndex", startIndex, dbType: DbType.Int64);
            param.Add("@PageSize", pageSize, dbType: DbType.Int64);

            return await _unitOfWork.Connection.QueryAsync<MessageLog>("usp_MessageLog_GetList", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<MessageLog>> GetMessageLogListByIdRangeAsync(Guid groupId, int startId, int pageNumber, int pageSize)
        {
            var param = new DynamicParameters();
            param.Add("@GroupId", groupId, dbType: DbType.Guid);
            param.Add("@StartId", startId, dbType: DbType.Int64);
            param.Add("@pageNumber", pageNumber, dbType: DbType.Int64);
            param.Add("@pageSize", pageSize, dbType: DbType.Int64);

            return await _unitOfWork.Connection.QueryAsync<MessageLog>("usp_MessageLog_GetListByIdRange", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> GetMessageLogListByIdRangeCountAsync(Guid groupId, int startId)
        {
            var param = new DynamicParameters();
            param.Add("@GroupId", groupId, dbType: DbType.Guid);
            param.Add("@StartId", startId, dbType: DbType.Int64);

            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<int>("usp_MessageLog_GetListByIdRangeCount", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> GetMessageLogTotalCountByGroupIdAsync(Guid groupId)
        {
            var param = new DynamicParameters();
            param.Add("@GroupId", groupId, DbType.Guid);

            return await _unitOfWork.Connection.QueryFirstAsync<int>("usp_MessageLog_GroupTotalCount_Get", param, commandType: CommandType.StoredProcedure);
        }

        public async Task InsertMessageLogAsync(MessageLog messageLog)
        {
            var param = new DynamicParameters();
            param.Add("@GroupId", messageLog.GroupId, DbType.Guid);
            param.Add("@SendUserId", messageLog.SendUserId, dbType: DbType.Int64);
            param.Add("@Message", messageLog.Message, dbType: DbType.String);
            param.Add("@SendTime", messageLog.SendTime, dbType: DbType.DateTime);

            //dbo.usp_MessageLog_Insert
            await _unitOfWork.Connection.ExecuteAsync("usp_MessageLog_Insert", param, _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
        }
    }
}