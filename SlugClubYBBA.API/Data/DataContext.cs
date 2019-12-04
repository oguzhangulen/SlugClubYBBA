using Microsoft.EntityFrameworkCore;
using SlugClubYBBA.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlugClubYBBA.API.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hesap>().HasKey(u => new
            {
                u.HesapNo,
                u.EkNo
            });
        }
        public DbSet<HavaleVirman> HavaleVirman { get; set; }
        public DbSet<Hesap> Hesap { get; set; }
        public DbSet<Musteri> Musteri { get; set; }
    }
}
