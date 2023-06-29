using Microsoft.EntityFrameworkCore;
using WPF.FaxGuild.BLL.DTOs;

namespace WPF.FaxGuild.Context
{
    public class FaxguildDbContext : DbContext
    {
        public FaxguildDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<OrderDTO> Orders { get; set; }
    }
}
