using RudeAnchorSN.LogicLayer.Models;

namespace RudeAnchorSN.LogicLayer.Services
{
    public interface IChatService
    {
        public Task<ChatModel> StartChat(List<UserModel> users);
        public Task<ChatModel> GetChat(int chatId);
        public Task<List<ChatModel>> GetChats(int userId);
        public Task RemoveChat(int chatId);
        public Task SendMessage(MessageModel message);
        public Task MarkAsRead(int chatId);
    }
}
