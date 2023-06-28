using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF.FaxGuild.Commands;
using WPF.FaxGuild.DAL.Models;
using WPF.FaxGuild.Services;
using WPF.FaxGuild.Stores;

namespace WPF.FaxGuild.ViewModels
{
    public class OrderListViewModel : ViewModelBase
    {
        private readonly Company _company;
        private readonly ObservableCollection<OrderViewModel> _orders;

        public IEnumerable<OrderViewModel> Orders => _orders;

        public ICommand MakeOrderCommand { get; }
        public OrderListViewModel(Company company, NavigationService makeOrderNavigationService)
        {
            _company = company;
            _orders = new ObservableCollection<OrderViewModel>();

            MakeOrderCommand = new NavigateCommand(makeOrderNavigationService);

            UpdateOrders();
        }

        private void UpdateOrders()
        {
            _orders.Clear();

            foreach (var orders in _company.GetAllOrders())
            {
                OrderViewModel orderViewModel = new OrderViewModel(orders);
                _orders.Add(orderViewModel);
            }
        }
    }
}
