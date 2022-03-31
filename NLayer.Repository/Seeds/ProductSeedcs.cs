using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository.Seeds
{
    internal class ProductSeedcs : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product { 
                id = 1,
                CategoryId=1,
                Name = "Kalem 1",
                Price=100,
                Stock=20,
                CreatedDate=DateTime.Now,   
            }, 
                new Product
                {
                    id = 2,
                    CategoryId = 1,
                    Name = "Kalem 2",
                    Price = 180,
                    Stock = 20,
                    CreatedDate = DateTime.Now,
                }, 
                new Product
                {
                    id = 3,
                    CategoryId = 1,
                    Name = "Kalem 3",
                    Price = 120,
                    Stock = 70,
                    CreatedDate = DateTime.Now,
                },
                new Product
                { 
                   id = 4,
                CategoryId = 2,
                Name = "Kitap 1",
                Price = 145,
                Stock = 35,
                CreatedDate = DateTime.Now,
            }, 
                new Product
                {
                    id = 5,
                    CategoryId =2,
                    Name = "Kitap 2",
                    Price = 230,
                    Stock = 70,
                    CreatedDate = DateTime.Now,
                }, 
                new Product
                {
                    id = 6,
                    CategoryId = 2,
                    Name = "Kitap 3",
                    Price = 180,
                    Stock = 290,
                    CreatedDate = DateTime.Now,
                },
                new Product
                {
                    id = 7,
                    CategoryId = 3,
                    Name = "Defter 1",
                    Price = 500,
                    Stock = 340,
                    CreatedDate = DateTime.Now,
                },
                new Product
                {
                    id = 8,
                    CategoryId = 3,
                    Name = "Defter 2",
                    Price = 300,
                    Stock = 45,
                    CreatedDate = DateTime.Now,
                },
                new Product
                {
                    id = 9,
                    CategoryId = 3,
                    Name = "Defter 3",
                    Price = 50,
                    Stock = 10,
                    CreatedDate = DateTime.Now,
                });
        }
    }
}
