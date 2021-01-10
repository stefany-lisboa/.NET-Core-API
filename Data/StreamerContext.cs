using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using SS_API.Model;

namespace SS_API.Data
{
    public class StreamerContext : DbContext
    {
        public StreamerContext(DbContextOptions<StreamerContext> option) : base(option) {}

        public StreamerContext() : base()
        {

        }

        public DbSet<Course> Course { get; set; }
        public DbSet<Project> Project { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=SS_DB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().ToTable("Project");
            modelBuilder.Entity<Project>().HasKey(pre => pre.Id);
            modelBuilder.Entity<Project>().Property(pre => pre.Id).HasColumnName("id");
            modelBuilder.Entity<Project>().Property(pre => pre.Name).HasColumnName("name");
            modelBuilder.Entity<Project>().Property(pre => pre.Image).HasColumnName("image");
            modelBuilder.Entity<Project>().Property(pre => pre.Why).HasColumnName("why");
            modelBuilder.Entity<Project>().Property(pre => pre.What).HasColumnName("what");
            modelBuilder.Entity<Project>().Property(pre => pre.WhatWillWeDo).HasColumnName("whatWillWeDo");
            modelBuilder.Entity<Project>().Property(pre => pre.ProjStatus).HasColumnName("projStatus");
            modelBuilder.Entity<Project>().Property(pre => pre.CourseId).HasColumnName("courseId");

            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Course>().HasKey(pre => pre.CourseId);
            modelBuilder.Entity<Course>().Property(pre => pre.CourseId).HasColumnName("id");
            modelBuilder.Entity<Course>().Property(pre => pre.Name).HasColumnName("name");
        }
    }
}