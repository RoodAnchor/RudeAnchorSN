using AutoMapper;
using Microsoft.Extensions.Configuration;
using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Entities;
using RudeAnchorSN.DataLayer.Repositories;
using RudeAnchorSN.LogicLayer.Models;

namespace RudeAnchorSN.LogicLayer.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public ChatService(IMapper mapper, IConfiguration config)
        {
            _chatRepository = new ChatRepository(RSNContext.GetInstance(config));
            _messageRepository = new MessageRepository(RSNContext.GetInstance(config));
            _mapper = mapper;
            _config = config;
        }

        public async Task<ChatModel> GetChat(int chatId)
        {
            var _chat = await _chatRepository.GetChat(chatId);

            return _mapper.Map<ChatModel>(_chat);
        }

        public async Task<List<ChatModel>> GetChats(int userId)
        {
            var _chats = await _chatRepository.GetChats(userId);

            return _mapper.Map<List<ChatModel>>(_chats);
        }

        public async Task RemoveChat(int chatId)
        {
            await _chatRepository.DeleteChat(chatId);
        }

        public async Task SendMessage(MessageModel message)
        {
            var _message = _mapper.Map<MessageEntity>(message);
            var messageId = await _messageRepository.CreateMessage(_message);

            await _chatRepository.AddMessage(message.ChatId, messageId);
        }

        public async Task<ChatModel> StartChat(List<UserModel> users)
        {
            var chat = new ChatModel();

            chat.Users = users;

            var _chat = _mapper.Map<ChatEntity>(chat);
            var id = await _chatRepository.CreateChat(_chat);
            return await GetChat(id);
        }

        public async Task MarkAsRead(int chatId)
        {
            await _chatRepository.UpdateChat(chatId, false);
        }
    }
}
