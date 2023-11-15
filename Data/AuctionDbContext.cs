using Microsoft.EntityFrameworkCore;
using BackMicroservices.Entities;

namespace BackMicroservices.Data
{
    public class AuctionDbContext : DbContext
    {
        public AuctionDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Auction> Auctions { get; set; }
    }
}
