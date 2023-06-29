using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.FaxGuild.BLL.DTOs;
using WPF.FaxGuild.Context;

namespace WPF.FaxGuild.Services.OrderCreators
{
    public class DatabaseOrderCreator : IOrderCreator
    {
        private readonly FaxguildDbContextFactory _dbFactory;

        public DatabaseOrderCreator (FaxguildDbContextFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task CreateOrder(Models.Order order)
        {
            using(FaxguildDbContext context = _dbFactory.CreateDbContext())
            {
                OrderDTO orderDto = ToOrderDTO(order);

                context.Orders.Add(orderDto);
                await context.SaveChangesAsync();
            }
        }
        private OrderDTO ToOrderDTO(Models.Order order)
        {
            return new OrderDTO()
            {
                Roomnumber = order.WorkplaceId?.Roomnumber ?? 0,
                Placenumber = order.WorkplaceId?.Placenumber ?? 0,
                Name = order.Name,
                Start = order.Start,
                End = order.End,
            };
        }
    }
}
