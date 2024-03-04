﻿using HourTrackerBackend.Modals.Database;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HourTrackerBackend.Modals
{
    public class TrackerContext : IdentityDbContext<User>
    {
        public TrackerContext() { }
        public TrackerContext(DbContextOptions<DbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Mechanic> Mechanics { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Common> Commons { get; set; }
        public DbSet<WeekData> WeekData { get; set; }
        public DbSet<ProjectMecanicLink> ProjectMecanicLinks { get; set; }
    }
}