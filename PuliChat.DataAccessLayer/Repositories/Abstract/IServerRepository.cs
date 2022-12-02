using PuliChat.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuliChat.DataAccessLayer.Repositories.Abstract
{
    public interface IServerRepository : IGenericRepository<Server>
    {
        public Task<List<Server>> GetAllAsync(ApplicationUser user);
        public Task<bool> SaveAsync(Server server, ApplicationUser user);
        public Task<bool> RemoveUser(Server server, ApplicationUser user);
    }
}
