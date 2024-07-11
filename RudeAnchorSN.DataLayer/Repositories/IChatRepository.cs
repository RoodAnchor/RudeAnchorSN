using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public interface IChatRepository
    {
        public Task<int> CreateChat(ChatEntity chat);
        public Task<ChatEntity?> GetChat(int id);
        public Task<List<ChatEntity>> GetChats(int userId);
        public Task DeleteChat(int id);
        public Task AddMessage(int chatId, int messageId);
        public Task UpdateChat(int chatId, bool hasNew);
    }
}