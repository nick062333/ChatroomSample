using Adapter;
using Adapter.Interfaces;
using Adapter.Models;
using AutoMapper;
using DataClass.DTOs;
using DataClass.Models;

namespace DataService.Service
{
    public class MessageLogDataService : IMessageLogDataService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageLogAdapter _messageLogAdapter;
        private readonly IMapper _mapper;

        public MessageLogDataService(IUnitOfWork unitOfWork, IMessageLogAdapter messageLogAdapter, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _messageLogAdapter = messageLogAdapter;
            _mapper = mapper;
        }

        public async Task CreateMessageLogAsync(ReceiveMessageProcessRequest receiveMessageProcessRequest)
        {
            _unitOfWork.BeginTransaction();
            var messageLog = _mapper.Map<MessageLog>(receiveMessageProcessRequest);
            await _messageLogAdapter.InsertMessageLog(messageLog);
            _unitOfWork.Commit();
        }

        public async Task<List<MessageLogModel>> GetMessageLogListAsync(GetMessageLogListRequest getMessageLogListRequest)
        {
            var messageLogs = await _messageLogAdapter.GetMessageLogListAsync(
                getMessageLogListRequest.groupId, 
                getMessageLogListRequest.page, 
                getMessageLogListRequest.pageSize);

            return _mapper.Map<List<MessageLogModel>>(messageLogs);
        }
    }
}
