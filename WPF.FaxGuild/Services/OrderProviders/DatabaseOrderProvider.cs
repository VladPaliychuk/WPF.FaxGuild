using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.FaxGuild.BLL.DTOs;
using WPF.FaxGuild.Context;
using WPF.FaxGuild.Models;

namespace WPF.FaxGuild.Services.OrderProviders
{
    public class DatabaseOrderProvider : IOrderProvider
    {
        private readonly FaxguildDbContextFactory _dbFactory;

        public DatabaseOrderProvider(FaxguildDbContextFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public async Task<IEnumerable<Models.Order>> GetAllOrders()
        {
            using(FaxguildDbContext context = _dbFactory.CreateDbContext())
            {
                IEnumerable<OrderDTO> orderDto = await context.Orders.ToListAsync();

                return orderDto.Select(o => ToOrder(o));
            }
        }

        private static Models.Order ToOrder(OrderDTO o)
        {
            return new Models.Order(new WorkplaceId(o.Roomnumber, o.Placenumber), o.Name, o.Start, o.End);
        }
    }
}
