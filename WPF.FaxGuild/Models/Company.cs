using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.FaxGuild.DAL.Models
{
    public class Company
    {
        private readonly OrderList _orderList;
        public string Name { get; }

        public Company(string name)
        {
            Name = name;

            _orderList = new OrderList();
        }

        public IEnumerable<Order> GetOrdersForName(string name)
        {
            return _orderList.GetOrdersForName(name);
        }
        public void MakeOrder(Order order)
        {
            _orderList.AddOrder(order);
        }
        public IEnumerable<Order> GetAllOrders() { return _orderList.GetAllOrders(); }
    }
}
