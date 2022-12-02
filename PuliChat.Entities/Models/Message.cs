using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuliChat.Entities.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int ChannelId { get; set; }
        public virtual Channel? Channel { get; set; }
        public string UserName { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser? User { get; set; }
        public DateTime Created { get; set; }
    }
}
