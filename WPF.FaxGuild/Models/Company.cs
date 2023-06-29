using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.FaxGuild.Models
{
    public class Company
    {
        private readonly OrderList _orderList;
        public string Name { get; }

        public Company(string name, OrderList orderList)
        {
            Name = name;

            _orderList = orderList;
        }
        public async Task<IEnumerable<Models.Order>> GetAllOrders()
        {
            return await _orderList.GetAllOrders();
        }
        public async Task MakeOrder(Order order)
        {
            await _orderList.AddOrder(order);
        }
    }
}
