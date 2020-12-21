using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Configurations
{
    public class UserGenreConfiguration:IEntityTypeConfiguration<UserGenre>
    {
        public void Configure(EntityTypeBuilder<UserGenre> builder)
        {
            builder.HasKey(c => new { c.UserId, c.GenreId });
            builder.HasOne(c => c.User).WithMany(c => c.PreferredGenres).HasForeignKey(c => c.UserId);
            builder.HasOne(c => c.Genre).WithMany(c => c.UserGenres).HasForeignKey(c => c.GenreId);
        }
    }
}
