using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GOvnoKOd.Models;

namespace GOvnoKOd
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Sotrudnik> Sotrudniks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=kaif.db");
        }
    }
}
