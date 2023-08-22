using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Net;

namespace Infrastructure.ModelConfigures;

public class ProductConfiguration : BaseConfiguration<Product>
{

    public override void Configure(EntityTypeBuilder<Product> builder)
    {

        builder.HasKey(a => a.ProductId);
        builder.Property(a => a.ProductId)
            .ValueGeneratedOnAdd();

        builder.Property(a => a.Name)
            .IsRequired();
        builder.Property(a => a.Price)
            .IsRequired(); 
        builder.Property(a => a.ManufactureDate)
            .IsRequired();
        builder.Property(a => a.CategoryId)
            .IsRequired();

        builder.HasOne(a => a.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(a => a.CategoryId);


        base.Configure(builder);
    }
}

