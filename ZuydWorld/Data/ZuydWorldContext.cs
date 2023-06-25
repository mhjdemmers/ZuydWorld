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

        public DbSet<ZuydWorld.Models.Game> Game { get; set; } = default!;
    }
}
