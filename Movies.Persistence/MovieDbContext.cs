using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Persistence
{

    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        {
        }
        public MovieDbContext() { }

        public DbSet<User> Users { get; set; }
        public DbSet<WatchlistItem> WatchlistItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<WatchlistItem>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<WatchlistItem>()
                .HasOne(w=>w.User)
                .WithMany(u=>u.WatchlistItems)
                .HasForeignKey(w=>w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}