using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.FaxGuild.Exceptions;
using WPF.FaxGuild.Services.OrderCreators;
using WPF.FaxGuild.Services.OrderProviders;

namespace WPF.FaxGuild.DAL.Models
{
    public class OrderList
    {
        private readonly IOrderProvider _orderProvider;
        private readonly IOrderCreator _orderCreator;
        

        /// <summary>
        /// Get a order by name.
        /// </summary>
        /// <param name="name">The name of employee</param>
        /// <returns>The order of employee</returns>
        public IEnumerable<Order> GetOrdersForName(string name)
        {
            return _orders.Where(o => o.Name == name);
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orderProvider.GetAllOrders();
        }

        /// <summary>
        /// Make order.
        /// </summary>
        /// <param name="order">The order</param>
        /// <exception cref="OrderConflictException"></exception>
        public void AddOrder(Order order)
        {
            foreach (var existingOrder in _orders)
            {
                if (existingOrder.Conflicts(order))
                {
                    throw new OrderConflictException(existingOrder, order);
                }
            }
            _orders.Add(order);
        }
    }
}
