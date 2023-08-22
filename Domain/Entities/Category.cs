﻿

namespace Domain.Entities;

public class Category : BaseEntity
{
    public int CategoryId { get; set; }
    public string Name { get; set; }

    public List<Product> Products { get; set; }

}
