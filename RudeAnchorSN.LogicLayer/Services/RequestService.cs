using AutoMapper;
using Microsoft.Extensions.Configuration;
using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Repositories;
using RudeAnchorSN.LogicLayer.Models;

namespace RudeAnchorSN.LogicLayer.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public RequestService(IMapper mapper, IConfiguration config)
        {
            _requestRepository = new RequestRepository(RSNContext.GetInstance(config));
            _mapper = mapper;
            _config = config;
        }

        public async Task Accept(int id)
        {
            await _requestRepository.Update(id, DataLayer.Enums.RequestStateEnum.Accepted);
        }

        public async Task<List<UserModel>> GetPending(int userId)
        {
            var requests = await _requestRepository.GetPending(userId);

            return _mapper.Map<List<UserModel>>(requests);
        }

        public async Task<RequestModel> GetRequest(int userId, int friendId)
        {
            var request = await _requestRepository.GetRequest(userId, friendId);

            return _mapper.Map<RequestModel>(request);
        }

        public async Task Reject(int id)
        {
            await _requestRepository.Update(id, DataLayer.Enums.RequestStateEnum.Rejected);
        }

        public async Task SendRequest(int userId, int friendId)
        {
            await _requestRepository.CreateRequest(userId, friendId);
        }
    }
}
