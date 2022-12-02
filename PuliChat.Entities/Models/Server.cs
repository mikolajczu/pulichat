using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuliChat.Entities.Models
{
    public class Server
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Channel>? Channels { get; set; }
        public virtual ICollection<ApplicationUser>? Users { get; set; }
        public virtual List<UserServer>? UsersServers { get; set; }
        public DateTime Created { get; set; }
        public byte[] ImageData { get; set; }
    }
}
