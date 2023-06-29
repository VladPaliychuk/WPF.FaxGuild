using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.FaxGuild.Exceptions;
using WPF.FaxGuild.Models;
using WPF.FaxGuild.Services;
using WPF.FaxGuild.Stores;
using WPF.FaxGuild.ViewModels;

namespace WPF.FaxGuild.Commands
{
    public class MakeOrderCommand : AsyncCommandBase 
    {
        private readonly MakeOrderViewModel _makeOrderViewModel;
        private readonly CompanyStore _companyStore;
        private readonly NavigationService orderViewNavigationService;

        public MakeOrderCommand(MakeOrderViewModel makeOrderViewModel, CompanyStore companyStore,
            NavigationService orderViewNavigationService)
        {
            _makeOrderViewModel = makeOrderViewModel;
            _companyStore = companyStore;
            this.orderViewNavigationService = orderViewNavigationService;
            _makeOrderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(MakeOrderViewModel.Name) ||
                e.PropertyName == nameof(MakeOrderViewModel.Roomnumber))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_makeOrderViewModel.Name)
                && _makeOrderViewModel.Roomnumber > 0 
                && base.CanExecute(parameter);
        }
        public override async Task ExecuteAsync(object parameter)
        {
            var order = new Models.Order(
                new WorkplaceId(_makeOrderViewModel.Roomnumber, _makeOrderViewModel.Placenumber),
                _makeOrderViewModel.Name,
                _makeOrderViewModel.Start=DateTime.Now,
                _makeOrderViewModel.End
                );

            try
            {
                await _companyStore.MakeOrder( order );
                
                MessageBox.Show("Відмічення успішне", "Успіх",
                   MessageBoxButton.OK, MessageBoxImage.Information);

                orderViewNavigationService.Navigate();
            }
            catch (OrderConflictException)
            {
                MessageBox.Show("Робоче місце зайнято", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Помилка відмічення", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
