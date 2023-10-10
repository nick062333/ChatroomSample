using Adapter;
using Adapter.Models;
using AutoMapper;
using DataClass.DTOs;

namespace DataService.Service
{
    public class MessageLogService : IMessageLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageLogAdapter _messageLogAdapter;
        private readonly IMapper _mapper;

        public MessageLogService(IUnitOfWork unitOfWork, IMessageLogAdapter messageLogAdapter, IMapper mapper)
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
    }
}
