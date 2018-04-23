using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Seats4Me.DataAccess.Context
{
    // Used for creating migrations
    class Seats4MeContextDesignTimeFactory : IDesignTimeDbContextFactory<Seats4MeContext>
    {
        public Seats4MeContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            var contextOptions = optionsBuilder
                .UseSqlServer(
                    "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Seats4MeDB;Integrated Security=True;").Options;

            return new Seats4MeContext(contextOptions);
        }
    }
}
