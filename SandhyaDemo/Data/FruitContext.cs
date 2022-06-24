using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SandhyaDemo.DbModels;

namespace SandhyaDemo.Data
{
    public class FruitContext : DbContext
    {
        public FruitContext (DbContextOptions<FruitContext> options)
            : base(options)
        {
        }

        public DbSet<SandhyaDemo.DbModels.Fruit>? Fruit { get; set; }
    }
}
