using PuliChat.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuliChat.DataAccessLayer.Repositories.Concrete
{
    public class BaseRepository
    {
        protected ApplicationDbContext context;

        public BaseRepository()
        {
            context = ApplicationDbContext.Create();
        }
    }
}
