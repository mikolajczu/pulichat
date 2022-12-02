using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PuliChat.Entities.Models;

namespace PuliChat.Entities.Configurations
{
    public class ServerConfiguration : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Created).HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.HasMany(x => x.Channels)
                .WithOne(x => x.Server)
                .HasForeignKey(x => x.ServerId)
                .HasPrincipalKey(x => x.Id);
            builder.HasMany(x => x.Users)
                .WithMany(x => x.Servers)
                .UsingEntity<UserServer>();
        }
    }
}
