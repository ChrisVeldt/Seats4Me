using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Seats4Me.DataAccess.Interfaces;
using Seats4Me.Model.Result;

namespace Seats4Me.DataAccess.Context
{
    public class Seats4MeContext : DbContext
    {
        public Seats4MeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}
