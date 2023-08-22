using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Net;

namespace Infrastructure.ModelConfigures;

public class CategoryConfiguration : BaseConfiguration<Category>
{

    public override void Configure(EntityTypeBuilder<Category> builder)
    {

        builder.HasKey(a => a.CategoryId);
        builder.Property(a => a.CategoryId)
            .ValueGeneratedOnAdd();

        builder.Property(a => a.Name)
            .IsRequired();



        base.Configure(builder);
    }
}

