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
    public class ChannelRepository : BaseRepository, IChannelRepository
    {
        public async Task<Channel> GetByIdAsync(int id)
        {
            return await context.Channels.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Channel>> GetAllAsync()
        {
            return await context.Channels.ToListAsync();
        }

        public async Task<bool> SaveAsync(Channel item)
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

        public async Task<bool> DeleteAsync(Channel item)
        {
            if (item == null) return false;

            context.Channels.Remove(item);

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
