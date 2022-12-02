using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuliChat.Entities.Models
{
    public class Channel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Message>? Messages { get; set; }
        [Required]
        public int ServerId { get; set; }
        public virtual Server? Server { get; set; }
    }
}
