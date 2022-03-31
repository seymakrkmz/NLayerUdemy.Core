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
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)   
        {
          //  var p =new Product() { ProductFeature=new ProductFeature() };   

        }
        public DbSet <Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Assemblyde ki tüm interfaceleri bulsun ve yapsın.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly .GetExecutingAssembly()); 
            //tek bir tane tanımlama yapılacaksa
          //  modelBuilder.ApplyConfiguration(new ProductConfiguration())

           
            base.OnModelCreating(modelBuilder); 
        }


    }
}
