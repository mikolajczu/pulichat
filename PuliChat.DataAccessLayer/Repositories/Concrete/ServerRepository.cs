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
    public class ServerRepository : BaseRepository, IServerRepository
    {
        public async Task<Server> GetByIdAsync(int id)
        {
            return await context.Servers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Server>> GetAllAsync()
        {
            return await context.Servers.ToListAsync();
        }

        public async Task<List<Server>> GetAllAsync(ApplicationUser user)
        {
            return await context.Servers.Where(x => x.Users.Contains(user)).ToListAsync();
        }

        public async Task<bool> SaveAsync(Server item)
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

        public async Task<bool> SaveAsync(Server server, ApplicationUser user)
        {
            if (server == null || user == null) return false;

            try
            {
                if (!context.Servers.Contains(server))
                {
                    context.Servers.Add(server);
                    context.SaveChanges();
                }

                UserServer userServer;
                if (context.UsersServers.Any(x => x.ServerId == server.Id))
                    userServer = new UserServer()
                    {
                        User = user,
                        UserId = user.Id,
                        Server = server,
                        ServerId = server.Id,
                        Role = Role.GUEST
                    };
                else
                    userServer = new UserServer()
                    {
                        User = user,
                        UserId = user.Id,
                        Server = server,
                        ServerId = server.Id,
                        Role = Role.OWNER
                    };

                context.Entry(userServer).State = userServer.Id == default ? EntityState.Added : EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> DeleteAsync(Server item)
        {
            if (item == null) return false;

            context.Servers.Remove(item);

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

        public async Task<bool> RemoveUser(Server item, ApplicationUser user)
        {
            if (item == null) return false;

            var userserver = context.UsersServers.Where(x => x.User == user && x.Server == item).First();
            context.UsersServers.Remove(userserver);

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
