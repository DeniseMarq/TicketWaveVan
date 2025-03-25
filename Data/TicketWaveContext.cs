using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TicketWaveVan.Models;

namespace TWVancouver.Data
{
    public class TicketWaveContext : DbContext
    {
        public class TicketWaveContext : DbContext
        {
            public TicketWaveContext(DbContextOptions<TicketWaveContext> options)
                : base(options) { }

            public DbSet<User> Users { get; set; }

            public DbSet<EventTickets> EventTickets { get; set; }  // Ensure your model is added here


        }
    }
}