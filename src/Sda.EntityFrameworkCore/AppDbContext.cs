using Microsoft.EntityFrameworkCore;
using Sda.Core.Models;
using Sda.EntityFrameworkCore.EntityMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sda.EntityFrameworkCore
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
        }

        public DbSet<HREntity> HREntitys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Seed();

            modelBuilder.ApplyConfiguration(new HREntityMapper());
        }
    }
}
