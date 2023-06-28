using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.FaxGuild.DAL.Models;
using WPF.FaxGuild.Exceptions;
using WPF.FaxGuild.Services;
using WPF.FaxGuild.ViewModels;

namespace WPF.FaxGuild.Commands
{
    public class MakeOrderCommand : CommandBase 
    {
        private readonly MakeOrderViewModel _makeOrderViewModel;
        private readonly Company _company;
        private readonly NavigationService orderViewNavigationService;

        public MakeOrderCommand(MakeOrderViewModel makeOrderViewModel, Company company,
            NavigationService orderViewNavigationService)
        {
            _makeOrderViewModel = makeOrderViewModel;
            _company = company;
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
        public override void Execute(object parameter)
        {
            var order = new DAL.Models.Order(
                new WorkplaceId(_makeOrderViewModel.Roomnumber, _makeOrderViewModel.Placenumber),
                _makeOrderViewModel.Name,
                _makeOrderViewModel.Start=DateTime.Now,
                _makeOrderViewModel.End=DateTime.MinValue
                );

            try
            {
                _company.MakeOrder(order);
                MessageBox.Show("Відмічення успішне", "Успіх",
                   MessageBoxButton.OK, MessageBoxImage.Information);

                orderViewNavigationService.Navigate();
            }
            catch (OrderConflictException)
            {
                MessageBox.Show("Робоче місце зайнято", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
