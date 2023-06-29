using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.FaxGuild.Exceptions;
using WPF.FaxGuild.Services.OrderConflictValidators;
using WPF.FaxGuild.Services.OrderCreators;
using WPF.FaxGuild.Services.OrderProviders;

namespace WPF.FaxGuild.Models
{
    public class OrderList
    {
        private readonly IOrderProvider _orderProvider;
        private readonly IOrderCreator _orderCreator;
        private readonly IOrderConflictValidator _orderConflictValidator;

        public OrderList(IOrderProvider orderProvider, IOrderCreator orderCreator, IOrderConflictValidator orderConflictValidator)
        {
            _orderConflictValidator = orderConflictValidator;
            _orderProvider = orderProvider; 
            _orderCreator = orderCreator;
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
        public async Task AddOrder(Order order)
        {
            Order conflictingOrder = await _orderConflictValidator.GetConflictOrder(order);

            if(conflictingOrder != null)
            {
                throw new OrderConflictException(conflictingOrder, order);
            }

            await _orderCreator.CreateOrder(order);
        }
    }
}
