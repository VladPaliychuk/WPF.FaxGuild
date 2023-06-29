using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPF.FaxGuild.Models;

namespace WPF.FaxGuild.Stores
{
    public class CompanyStore
    {
        private readonly List<Models.Order> _orders;
        private readonly Company _company;
        private readonly Lazy<Task> _initializeLazy;
        public IEnumerable<Models.Order> Orders => _orders;

        public CompanyStore(Company company)
        {
            _company = company;
            _initializeLazy = new Lazy<Task>(Initialize);

            _orders = new List<Models.Order>();
        }

        public async Task Load()
        {
            await _initializeLazy.Value;
        }

        public async Task MakeOrder(Models.Order order)
        {
            await _company.MakeOrder(order);

            _orders.Add(order);
        }

        private async Task Initialize()
        {
            IEnumerable<Models.Order> orders = await _company.GetAllOrders();

            _orders.Clear();
            _orders.AddRange(orders);
        }
    }
}
