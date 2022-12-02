using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuliChat.Entities.Models
{
    public enum Role
    {
        OWNER,
        ADMIN,
        GUEST
    }
    public class UserServer
    {
        public long Id { get; set; }
        public DateTime UserJoined { get; set; }
        public Role Role { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public int ServerId { get; set; }
        public virtual Server Server { get; set; }
    }
}
