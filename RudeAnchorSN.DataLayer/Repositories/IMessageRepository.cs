using RudeAnchorSN.DataLayer.Entities;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public interface IMessageRepository
    {
        public Task CreateMessage(MessageEntity message);
        public Task<MessageEntity> GetMessage(Guid guid);
        public Task<List<MessageEntity>> GetMessages();
        public Task DeleteMessage(Guid guid);
        public Task UpdateMessage(MessageEntity message);
    }
}