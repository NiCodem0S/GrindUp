using GrindUp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrindUp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<ObjectiveSettings> ObjectiveSettings { get; set; }
        public DbSet<ProgressLog> ProgressLogs { get; set; }
        public DbSet<MeasurementType> MeasurementTypes { get; set; }
        public DbSet<FrequencyType> FrequencyTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProgressLog>()
                .HasOne(pl => pl.Objective)
                .WithMany(o => o.ProgressLogs)
                .HasForeignKey(pl => pl.ObjectiveId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProgressLog>()
                .HasOne(pl => pl.User)
                .WithMany(u => u.ProgressLogs)
                .HasForeignKey(pl => pl.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Objective>()
                .HasOne(o => o.Owner)
                .WithMany(u => u.Objectives)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ObjectiveSettings>()
                .HasOne(os => os.Objective)
                .WithOne(o => o.Settings)
                .HasForeignKey<ObjectiveSettings>(os => os.ObjectiveId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
