using FitCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitCore.Infrastructure.Persistence
{
    public class FitCoreDbContext : DbContext
    {
        public FitCoreDbContext(DbContextOptions <FitCoreDbContext> options) : base(options)
        {

        }

        public DbSet<Workout> Workouts { get; set; }
        public DbSet<ExerciseSet> ExerciseSets { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            // En workout måste ha en User
            modelBuilder.Entity<Workout>()
                .HasOne(w => w.User)
                .WithMany(u => u.Workouts)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade); 
        }

    }
}
