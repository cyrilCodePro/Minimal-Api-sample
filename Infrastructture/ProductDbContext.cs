using Domain.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

    public class ProductDbContext : DbContext
    {
    public ProductDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Assembly assemblyWithConfigurations = typeof(ProductDbContext).Assembly; //get whatever assembly you want
        modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
    }
    public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
       

