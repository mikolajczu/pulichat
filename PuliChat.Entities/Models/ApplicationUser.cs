using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace PuliChat.Entities.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Message>? Messages { get; set; }
        public virtual ICollection<Message>? DeletedMessages { get; set; }
        public virtual ICollection<Server>? Servers { get; set; }
        public virtual List<UserServer>? UsersServers { get; set; }
        public byte[] Image { get; set; }
        public string? Description { get; set; }
    }
}
