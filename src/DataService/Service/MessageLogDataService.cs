using System.Net.Http.Headers;
using Adapter;
using Adapter.Interfaces;
using Adapter.Models;
using AutoMapper;
using DataClass.DTOs;
using DataClass.Models;
using Utility;

namespace DataService.Service
{
    public class MessageLogDataService : IMessageLogDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageLogAdapter _messageLogAdapter;
        private readonly IMapper _mapper;
        private readonly AesEncryptionHelper _aesEncryptionHelper;
        private const int _pageSize = 10;

        public MessageLogDataService(IUnitOfWork unitOfWork, IMessageLogAdapter messageLogAdapter, IMapper mapper, AesEncryptionHelper aesEncryptionHelper)
        {
            _unitOfWork = unitOfWork;
            _messageLogAdapter = messageLogAdapter;
            _mapper = mapper;
            _aesEncryptionHelper = aesEncryptionHelper;
        }

        public async Task<long> CreateMessageLogAsync(ReceiveMessageProcessRequest receiveMessageProcessRequest)
        {
            _unitOfWork.BeginTransaction();
            var messageLog = _mapper.Map<MessageLog>(receiveMessageProcessRequest);
            messageLog.Message = _aesEncryptionHelper.Encrypt(messageLog.Message);
            var result = await _messageLogAdapter.InsertMessageLogAsync(messageLog);
            _unitOfWork.Commit();

            return result;
        }

        public async Task<List<MessageLogModel>> GetNewMessageListAsync(Guid groupId, 
            long startMessageId, int maxCount)
        {
         List<MessageLog> result = new();
            int dataTotalCount = await _messageLogAdapter.GetNewMessageListCountAsync(groupId, startMessageId);

            if (dataTotalCount == 0)
                return new();

            int totalPage = dataTotalCount / _pageSize;
            totalPage = totalPage < 1 ? 1 : (dataTotalCount % _pageSize) > 0 ? totalPage + 1 : totalPage;

            for (int pageNumber = 1; pageNumber <= totalPage; pageNumber++)
            {
                IEnumerable<MessageLog> messageLogs = await _messageLogAdapter.GetNewMessageListAsync(groupId, startMessageId, pageNumber, _pageSize);
                result.AddRange(messageLogs);

                if(maxCount > 0 && result.Count >= maxCount)
                {
                    result = result.Take(maxCount).ToList();
                    break;
                }
            }
             
            MessageDecrypt(result);
  
            return _mapper.Map<List<MessageLogModel>>(result);
        }

        public async Task<List<MessageLogModel>> GetHistoryMessageListAsync(Guid groupId, long endMessageId, int maxCount)
        {
            List<MessageLog> result = new();
            int dataTotalCount = await _messageLogAdapter.GetHistoryMessageListCountAsync(groupId, endMessageId);

            if (dataTotalCount == 0)
                return new();

            int totalPage = dataTotalCount / _pageSize;
            totalPage = totalPage < 1 ? 1 : (dataTotalCount % _pageSize) > 0 ? totalPage + 1 : totalPage;

            for (int pageNumber = 1; pageNumber <= totalPage; pageNumber++)
            {
                IEnumerable<MessageLog> messageLogs = await _messageLogAdapter.GetHistoryMessageListAsync(groupId, endMessageId, pageNumber, _pageSize);
                result.AddRange(messageLogs);

                if(maxCount > 0 && result.Count >= maxCount)
                {
                    result = result.Take(maxCount).ToList();
                    break;
                }
            }

            MessageDecrypt(result);
            return  _mapper.Map<List<MessageLogModel>>(result);
        }

        public async Task<int> GetMessageLogTotalCountByGroupIdAsync(Guid groupId)
        {
            var totalCount = await _messageLogAdapter.GetMessageLogTotalCountByGroupIdAsync(groupId);
            return totalCount;
        }

        private void MessageDecrypt(IEnumerable<MessageLog> messageLogs)
        {
            if (messageLogs != null)
                foreach (var item in messageLogs)
                {
                    if(!string.IsNullOrWhiteSpace(item.Message))
                        item.Message = _aesEncryptionHelper.Decrypt(item.Message);
                }
        }
    }
}
