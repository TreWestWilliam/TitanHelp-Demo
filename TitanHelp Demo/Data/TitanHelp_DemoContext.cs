using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TitanHelp_Demo.Models;

namespace TitanHelp_Demo.Data
{
    public class TitanHelp_DemoContext : DbContext
    {
        public TitanHelp_DemoContext (DbContextOptions<TitanHelp_DemoContext> options)
            : base(options)
        {
        }

        public DbSet<TitanHelp_Demo.Models.User> User { get; set; }

        public DbSet<TitanHelp_Demo.Models.Ticket> Ticket { get; set; }
    }
}
