using System;
using Fiorello_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiorello_API.Helpers.EntityConfigurations
{
    public class BlogConfigurations : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(m => m.Title).IsRequired();
            builder.Property(m => m.Description).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Image).IsRequired();
        }
    }
}

