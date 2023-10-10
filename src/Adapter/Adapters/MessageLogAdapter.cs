using System.Data;
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
            await _unitOfWork.Connection.ExecuteAsync("Sp_InsertMessageLog", messageLog, commandType: CommandType.StoredProcedure);
        }
    }
}