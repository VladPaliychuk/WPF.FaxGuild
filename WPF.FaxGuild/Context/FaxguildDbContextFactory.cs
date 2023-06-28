using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.FaxGuild.Context
{
    public class FaxguildDbContextFactory
    {
        private readonly string connectionString;

        public FaxguildDbContextFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public FaxguildDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(connectionString).Options;

            return new FaxguildDbContext(options);
        }
    }
}
