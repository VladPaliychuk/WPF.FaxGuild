using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF.FaxGuild.Commands;
using WPF.FaxGuild.Models;
using WPF.FaxGuild.Services;
using WPF.FaxGuild.Stores;

namespace WPF.FaxGuild.ViewModels
{
    public class OrderListViewModel : ViewModelBase
    {
        private readonly ObservableCollection<OrderViewModel> _orders;
        private readonly MakeOrderViewModel _makeOrderViewModel;
        public IEnumerable<OrderViewModel> Orders => _orders;

        public ICommand MakeOrderCommand { get; }
        public ICommand LoadOrderCommand { get; }

        public OrderListViewModel(CompanyStore companyStore,
            MakeOrderViewModel makeOrderViewModel,
            NavigationService makeOrderNavigationService)
        {
            _orders = new ObservableCollection<OrderViewModel>();
            _makeOrderViewModel = makeOrderViewModel;

            LoadOrderCommand = new LoadOrderCommand(this, companyStore);
            MakeOrderCommand = new NavigateCommand(makeOrderNavigationService);
        }

        public static OrderListViewModel LoadViewModel(CompanyStore companyStore, MakeOrderViewModel makeOrderViewModel,
            NavigationService makeOrderNavigationService)
        {
            OrderListViewModel viewModel = new OrderListViewModel(companyStore,
                makeOrderViewModel, makeOrderNavigationService);

            viewModel.LoadOrderCommand.Execute(null);

            return viewModel;
        }

        public void UpdateOrders(IEnumerable<Models.Order> orders)
        {
            _orders.Clear();

            foreach (var order in orders)
            {
                OrderViewModel orderViewModel = new OrderViewModel(order);
                _orders.Add(orderViewModel);
            }
        }
    }
}
