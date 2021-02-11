using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace EntityFrameWorkHastaneOto
{
    class HastaneDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HastahaneDb;Trusted_connection=true");

        }

        public DbSet<Hasta> Hasta { get; set; }
        public DbSet<HastaDetay> hastadetaylar { get; set; }
        public DbSet<Doktor> doktorlar { get; set; }
        public DbSet<Tani> taniler { get; set; }
    }

}
