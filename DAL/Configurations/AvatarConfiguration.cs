using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class AvatarConfiguration:IEntityTypeConfiguration<Avatar>
    {
        public void Configure(EntityTypeBuilder<Avatar> builder)
        {
            builder.HasOne(c => c.User).WithMany(c => c.Avatars).HasForeignKey(c=>c.UserId);
            builder.HasOne(c => c.Image).WithOne(c => c.Avatar).HasForeignKey<Avatar>(x=>x.ImageId);
        }
    }
}
