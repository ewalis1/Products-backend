using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Product.DataAccess.Models;

namespace Product.DataAccess
{
    public class ProductContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
    }
}
