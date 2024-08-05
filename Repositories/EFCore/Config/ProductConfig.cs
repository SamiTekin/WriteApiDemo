using Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id = 1, ProductName = "Telefon", ProductDescription = "Açıklama yakında gelecek", ProductPrice = 19000, ProductType = true },
                new Product { Id = 2, ProductName = "Tablet", ProductDescription = "Açıklama yakında gelecek", ProductPrice = 6000, ProductType = true },
                new Product { Id = 3, ProductName = "Bilgisayar", ProductDescription = "Açıklama yakında gelecek", ProductPrice = 29000, ProductType = true }
                );
        }
    }
}
