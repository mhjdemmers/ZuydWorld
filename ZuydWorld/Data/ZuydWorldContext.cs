using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ZuydWorld.Models;

namespace ZuydWorld.Data
{
    public class ZuydWorldContext : DbContext
    {
        public ZuydWorldContext (DbContextOptions<ZuydWorldContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Game { get; set; } = default!;
        public DbSet<Category> Category { get; set; } = default!;
        public DbSet<Comment> Comment { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<Score> Score { get; set; } = default!;
        public DbSet<User> Userss { get; set; } = default!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
           // modelBuilder.Entity<User>()
            //.HasMany(u => u.Likes)
            //.WithMany(g => g.UsersWhoLike);

            //modelBuilder.Entity<User>()
                //.HasMany(u => u.Favorites)
                //.WithMany(g => g.UsersWhoFavorite);
        //}
    }
}
