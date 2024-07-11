using RudeAnchorSN.DataLayer.DataBase;
using RudeAnchorSN.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace RudeAnchorSN.DataLayer.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly RSNContext _dbContext;

        public ChatRepository(RSNContext context)
        {
            _dbContext = context;
        }

        public async Task<int> CreateChat(ChatEntity chat)
        {
            var users = new List<UserEntity>();

            foreach(var user in chat.Users)
            {
                var _user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
                users.Add(_user);
            }

            chat.Users = users;

            var entry = _dbContext.Entry(chat);

            if (entry.State == EntityState.Detached)
                await _dbContext.Chats.AddAsync(chat);

            await _dbContext.SaveChangesAsync();

            return chat.Id;
        }

        public async Task DeleteChat(int id)
        {
            var chat = await _dbContext.Chats.FirstOrDefaultAsync(x => x.Id == id);

            _dbContext.Chats.Remove(chat);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<ChatEntity> GetChat(int id)
        {
            return await _dbContext.Chats.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ChatEntity>> GetChats(int userId)
        {
            return await _dbContext.Chats.Where(x => x.Users.Any(y => y.Id == userId)).ToListAsync();
        }

        public async Task AddMessage(int chatId, int messageId)
        {
            var message = await _dbContext.Messages.FirstOrDefaultAsync(x => x.Id == messageId);
            var chat = await GetChat(chatId);

            chat.Messages.Add(message);
            chat.HasNew = true;

            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateChat(int chatId, bool hasNew)
        {
            var chat = await GetChat(chatId);

            chat.HasNew = hasNew;

            await _dbContext.SaveChangesAsync();
        }
    }
}
