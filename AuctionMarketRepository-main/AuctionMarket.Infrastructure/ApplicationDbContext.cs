using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionMarket.Infrastructure
{
    public class ApplicationDbContext  : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Additional configuration here if needed
        }

    }
}
