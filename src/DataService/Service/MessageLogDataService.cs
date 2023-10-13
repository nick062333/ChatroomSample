using Adapter;
using Adapter.Interfaces;
using Adapter.Models;
using AutoMapper;
using DataClass.Configs;
using DataClass.DTOs;
using DataClass.Models;
using Microsoft.Extensions.Options;
using System.Text.RegularExpressions;
using Utility;

namespace DataService.Service
{
    public class MessageLogDataService : IMessageLogDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageLogAdapter _messageLogAdapter;
        private readonly IMapper _mapper;
        private readonly AesEncryptionSettings _aesEncryptionSettings;

        public MessageLogDataService(IUnitOfWork unitOfWork, IMessageLogAdapter messageLogAdapter, IMapper mapper, IOptions<AesEncryptionSettings> aesEncryptionSettings)
        {
            _unitOfWork = unitOfWork;
            _messageLogAdapter = messageLogAdapter;
            _mapper = mapper;
            _aesEncryptionSettings = aesEncryptionSettings.Value;
        }

        public async Task CreateMessageLogAsync(ReceiveMessageProcessRequest receiveMessageProcessRequest)
        {
            _unitOfWork.BeginTransaction();
            var messageLog = _mapper.Map<MessageLog>(receiveMessageProcessRequest);
            messageLog.Message = AesEncryptionHelper.Encrypt(messageLog.Message, _aesEncryptionSettings.Key, _aesEncryptionSettings.IV);
            await _messageLogAdapter.InsertMessageLog(messageLog);
            _unitOfWork.Commit();
        }

        public async Task<List<MessageLogModel>> GetMessageLogListAsync(GetMessageLogListRequest getMessageLogListRequest)
        {
            var messageLogs = await _messageLogAdapter.GetMessageLogListAsync(
                getMessageLogListRequest.GroupId, 
                getMessageLogListRequest.StartIndex, 
                getMessageLogListRequest.PageSize);

            if(messageLogs != null)
                foreach(var item in messageLogs)
                {
                    item.Message = AesEncryptionHelper.Decrypt(
                        item.Message, 
                        _aesEncryptionSettings.Key, 
                        _aesEncryptionSettings.IV);
                }

            return _mapper.Map<List<MessageLogModel>>(messageLogs);
        }

        public async Task<int> GetMessageLogTotalCountByGroupIdAsync(Guid groupId)
        {
            var totalCount = await _messageLogAdapter.GetMessageLogTotalCountByGroupIdAsync(groupId);
            return totalCount;
        }
    }
}
