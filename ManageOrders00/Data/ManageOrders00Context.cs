using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ManageOrders00.Models;

namespace ManageOrders00.Data
{
    public class ManageOrders00Context : DbContext
    {
        public ManageOrders00Context (DbContextOptions<ManageOrders00Context> options)
            : base(options)
        {
        }

        public DbSet<ManageOrders00.Models.Customer> Customer { get; set; } = default!;

        public DbSet<ManageOrders00.Models.Order> Order { get; set; } = default!;

        public DbSet<ManageOrders00.Models.Position> Position { get; set; } = default!;

        public DbSet<ManageOrders00.Models.Product> Product { get; set; } = default!;
    }
}
