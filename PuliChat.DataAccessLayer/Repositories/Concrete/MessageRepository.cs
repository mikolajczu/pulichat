using Microsoft.EntityFrameworkCore;
using PuliChat.DataAccessLayer.Repositories.Abstract;
using PuliChat.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuliChat.DataAccessLayer.Repositories.Concrete
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public async Task<Message> GetByIdAsync(int id)
        {
            return await context.Messages.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Message>> GetAllAsync()
        {
            return await context.Messages.ToListAsync();
        }

        public async Task<bool> SaveAsync(Message item)
        {
            if (item == null) return false;

            try
            {
                context.Entry(item).State = item.Id == default(int) ? EntityState.Added : EntityState.Modified;

                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteAsync(Message item)
        {
            if (item == null) return false;

            context.Messages.Remove(item);

            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
