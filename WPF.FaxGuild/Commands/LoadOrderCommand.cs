using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.FaxGuild.Models;
using WPF.FaxGuild.Stores;
using WPF.FaxGuild.ViewModels;

namespace WPF.FaxGuild.Commands
{
    public class LoadOrderCommand : AsyncCommandBase
    {
        private readonly OrderListViewModel _orderListViewModel;
        private readonly CompanyStore _companyStore;

        public LoadOrderCommand(OrderListViewModel orderListViewModel, CompanyStore companyStore)
        {
            _orderListViewModel = orderListViewModel;
            _companyStore = companyStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                await _companyStore.Load();

                _orderListViewModel.UpdateOrders(_companyStore.Orders);
            }
            catch (Exception)
            {

                MessageBox.Show("Помилка загрузки відмічення", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
