using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public interface IMessageRepository
    {
        public Task<int> CreateMessage(MessageEntity message);
        public Task<MessageEntity?> GetMessage(int id);
        public Task<List<MessageEntity>> GetMessages();
        public Task DeleteMessage(int id);
        public Task UpdateMessage(MessageEntity message);
    }
}