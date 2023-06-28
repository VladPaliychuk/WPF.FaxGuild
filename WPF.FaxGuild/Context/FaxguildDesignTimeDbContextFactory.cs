using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.FaxGuild.Context
{
    public class FaxguildDesignTimeDbContextFactory : IDesignTimeDbContextFactory<FaxguildDbContext>
    {
        public FaxguildDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options =  new DbContextOptionsBuilder().UseSqlite("DataSource=WpfFaxGuild.db").Options;

            return new FaxguildDbContext(options);
        }
    }
}
