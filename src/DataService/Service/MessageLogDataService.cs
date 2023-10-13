using Adapter;
using Adapter.Interfaces;
using Adapter.Models;
using AutoMapper;
using DataClass.DTOs;
using DataClass.Models;
using System.Collections.Generic;
using Utility;

namespace DataService.Service
{
    public class MessageLogDataService : IMessageLogDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageLogAdapter _messageLogAdapter;
        private readonly IMapper _mapper;
        private readonly AesEncryptionHelper _aesEncryptionHelper;

        public MessageLogDataService(IUnitOfWork unitOfWork, IMessageLogAdapter messageLogAdapter, IMapper mapper, AesEncryptionHelper aesEncryptionHelper)
        {
            _unitOfWork = unitOfWork;
            _messageLogAdapter = messageLogAdapter;
            _mapper = mapper;
            _aesEncryptionHelper = aesEncryptionHelper;
        }

        public async Task CreateMessageLogAsync(ReceiveMessageProcessRequest receiveMessageProcessRequest)
        {
            _unitOfWork.BeginTransaction();
            var messageLog = _mapper.Map<MessageLog>(receiveMessageProcessRequest);
            messageLog.Message = _aesEncryptionHelper.Encrypt(messageLog.Message);
            await _messageLogAdapter.InsertMessageLogAsync(messageLog);
            _unitOfWork.Commit();
        }

        public async Task<List<MessageLogModel>> GetMessageLogListAsync(GetMessageLogListRequest getMessageLogListRequest)
        {
            var messageLogs = await _messageLogAdapter.GetMessageLogListAsync(
                getMessageLogListRequest.GroupId, 
                getMessageLogListRequest.StartIndex, 
                getMessageLogListRequest.PageSize);

            MessageDecrypt(messageLogs);

            return _mapper.Map<List<MessageLogModel>>(messageLogs);
        }

        public async Task<List<MessageLogModel>> GetMessageLogListByIdRangeAsync(Guid groupId, int startId)
        {
            List<MessageLog> result = new();
            int dataTotalCount = await _messageLogAdapter.GetMessageLogListByIdRangeCountAsync(groupId, startId);

            if (dataTotalCount == 0)
                return new();

            int pageSize = 10;
            int totalPage = dataTotalCount / pageSize;
            totalPage = totalPage < 1 ? 1 : (dataTotalCount % pageSize) > 0 ? totalPage + 1 : totalPage;

            for (int pageNumber = 1; pageNumber <= totalPage; pageNumber++)
            {
                var messageLogs = await _messageLogAdapter.GetMessageLogListByIdRangeAsync(groupId, startId, pageNumber, pageSize);
                result.AddRange(messageLogs);
            }

            MessageDecrypt(result);
            return _mapper.Map<List<MessageLogModel>>(result);
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
                    item.Message = _aesEncryptionHelper.Decrypt(item.Message);
                }
        }
    }
}
