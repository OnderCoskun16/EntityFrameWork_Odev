using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EksiSozluk
{
    public class AppDbContext : DbContext
    {
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Konu>       Subject    { get; set; }
        public DbSet<Kullanici>  User       { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\sqlexpress;database=EksiSozluk;uid=sa;pwd=123");
        }




    }
}
