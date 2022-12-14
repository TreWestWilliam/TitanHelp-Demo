using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TitanHelp_Demo.Models;

namespace TitanHelp_Demo.Data
{
    public class TicketsContext : DbContext
    {
        public TicketsContext (DbContextOptions<TicketsContext> options)
            : base(options)
        {
        }

        public DbSet<TitanHelp_Demo.Models.User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Ticket>().ToTable("Tickets");
            modelBuilder.Entity<Comment>().ToTable("Comments");
        }
    }
}
