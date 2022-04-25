using Microsoft.EntityFrameworkCore;
using NLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Repository
{
    public class AppDbContext:DbContext
    {
        //startupa db yolunu vermek için yazdık
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)   
        {
          //  var p =new Product() { ProductFeature=new ProductFeature() };   

        }
        //her bir entitye karşılık dbset yazılır
        public DbSet <Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }

        //model oluşurken çalışacak method,entity ile ilgili ayarları yaparken
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Assemblyde ki tüm interfaceleri bulsun ve  kısıtlamaları (configure)yapsın.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly .GetExecutingAssembly());
            //tek bir tane tanımlama yapılacaksa configure yazmak yerine buraya da ekleyebiliriz
            modelBuilder.Entity<ProductFeature>().HasData(
                new ProductFeature() {
                Id = 1,
                Color = "Kırmızı",
                Height = 20,
                Width = 20,
                ProductId = 1,


            },
                new ProductFeature()
                {
                    Id = 2,
                    Color = "Yeşil",
                    Height = 40,
                    Width = 30,
                    ProductId = 2,


                }
            );


          //  modelBuilder.ApplyConfiguration(new ProductConfiguration())

           
            base.OnModelCreating(modelBuilder); 
        }


    }
}
