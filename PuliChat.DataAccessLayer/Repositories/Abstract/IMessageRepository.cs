using PuliChat.DataAccessLayer.Repositories.Concrete;
using PuliChat.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuliChat.DataAccessLayer.Repositories.Abstract
{
    public interface IMessageRepository : IGenericRepository<Message>
    {
    }
}
