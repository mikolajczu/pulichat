using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuliChat.Entities.Models;

namespace PuliChat.Entities.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.HasMany(x => x.Messages)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .HasPrincipalKey(x => x.Id);
            builder.HasMany(x => x.Servers)
                .WithMany(x => x.Users)
                .UsingEntity<UserServer>();
        }
    }
}
