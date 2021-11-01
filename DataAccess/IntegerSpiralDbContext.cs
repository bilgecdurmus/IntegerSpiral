using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace DataAccess
{
    public class IntegerSpiralDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-5KO111R;Database=IntegerSpiralDb;Integrated Security=true;");
        }
        public DbSet<Layout> Layouts { get; set; }
    }
}
