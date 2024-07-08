using Microsoft.EntityFrameworkCore;
using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Entities;
using RudeAnchorSN.DataLayer.Exceptions;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly RSNContext _dbContext;

        public MessageRepository(RSNContext context)
        {
            _dbContext = context;
        }

        public async Task CreateMessage(MessageEntity message)
        {
            var entry = _dbContext.Entry(message);

            if (entry.State == EntityState.Detached)
                await _dbContext.Messages.AddAsync(message);

            await _dbContext.SaveChangesAsync();
        }


        public async Task UpdateMessage(MessageEntity message)
        {
            var _message = await GetMessage(message.Id);

            if (_message is null) throw new MessageNotFoundException();

            _message.Content = message.Content;

            await _dbContext.SaveChangesAsync();
        }

        public async Task<MessageEntity> GetMessage(int id) =>
            await _dbContext.Messages.FirstOrDefaultAsync(x => x.Id == id);

        public async Task<List<MessageEntity>> GetMessages() =>
            await _dbContext.Messages.ToListAsync();

        public async Task DeleteMessage(int id)
        {
            var message = await GetMessage(id);

            if (message is null) throw new MessageNotFoundException();

            _dbContext.Messages.Remove(message);

            await _dbContext.SaveChangesAsync();
        }
    }
}
