using ECommerce.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class ECommerceDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<CustomerBasket> Baskets { get; set; }

        public DbSet<BasketItem> BasketItems { get; set; }

        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        { 
        }
    }
}
