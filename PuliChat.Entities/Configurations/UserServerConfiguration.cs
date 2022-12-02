using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuliChat.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuliChat.Entities.Configurations
{
    public class UserServerConfiguration : IEntityTypeConfiguration<UserServer>
    {
        public void Configure(EntityTypeBuilder<UserServer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(us => us.UserJoined).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.HasOne(us => us.Server)
                   .WithMany(s => s.UsersServers)
                   .HasForeignKey(us => us.ServerId)
                   .HasPrincipalKey(s => s.Id);
            builder.HasOne(us => us.User)
                   .WithMany(u => u.UsersServers)
                   .HasForeignKey(us => us.UserId)
                   .HasPrincipalKey(u => u.Id);
        }
    }
}
