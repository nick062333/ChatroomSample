using Adapter;
using Adapter.DBModel;
using AutoMapper;
using DataService.Models.Message;

namespace DataService.Service
{
    public class MessageLogService : IMessageLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMessageLogAdapter _messageLogAdapter;
        private readonly IMapper _mapper;
        private readonly IMessageLogService _messageLogService;

        public MessageLogService(IUnitOfWork unitOfWork, IMessageLogAdapter messageLogAdapter, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _messageLogAdapter = messageLogAdapter;
            _mapper = mapper;
        }


        public async Task CreateMessageLogAsync(CreateMessageLogModel createMessageLogModel)
        {
            _unitOfWork.BeginTransaction();
            await _messageLogAdapter.InsertMessageLog(_mapper.Map<MessageLog>(createMessageLogModel));
            _unitOfWork.Commit();
        }
    }
}
