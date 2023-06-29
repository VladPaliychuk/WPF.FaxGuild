using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.FaxGuild.BLL.DTOs;
using WPF.FaxGuild.Context;
using WPF.FaxGuild.Models;

namespace WPF.FaxGuild.Services.OrderConflictValidators
{
    public class DatabaseOrderConflctValidator : IOrderConflictValidator
    {
        private readonly FaxguildDbContextFactory _dbFactory;

        public DatabaseOrderConflctValidator(FaxguildDbContextFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<Models.Order> GetConflictOrder(Models.Order order)
        {
            using(FaxguildDbContext context = _dbFactory.CreateDbContext())
            {
                OrderDTO orderDto = await context.Orders
                    .Where(o => o.Roomnumber == order.WorkplaceId.Roomnumber)
                    .Where(o => o.Placenumber == order.WorkplaceId.Placenumber)
                    .FirstOrDefaultAsync();

                if(orderDto == null)
                {
                    return null;
                }

                return ToOrder(orderDto);
            }
        }
        private static Models.Order ToOrder(OrderDTO o)
        {
            return new Models.Order(new WorkplaceId(o.Roomnumber, o.Placenumber), o.Name, o.Start, o.End);
        }
    }
}
