using System;
using Fiorello_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fiorello_API.Helpers.EntityConfigurations
{
	public class ProductConfiguration:IEntityTypeConfiguration<Product>
	{

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(m => m.CategoryId).IsRequired();
            builder.Property(m => m.Name).IsRequired().HasMaxLength(30);
            builder.Property(m => m.Price).IsRequired();
        }
    }
}

