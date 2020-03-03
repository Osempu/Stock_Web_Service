using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Stock_API.Models;

namespace Stock_API.Data
{
    public class StockContext : DbContext
    {
        public StockContext (DbContextOptions<StockContext> options)
            : base(options)
        {
        }

        public DbSet<Stock_API.Models.Products> Products { get; set; }
    }
}
