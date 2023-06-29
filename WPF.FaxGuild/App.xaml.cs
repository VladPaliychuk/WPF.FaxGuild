using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;
using WPF.FaxGuild.Context;
using WPF.FaxGuild.Models;
using WPF.FaxGuild.Services;
using WPF.FaxGuild.Services.OrderConflictValidators;
using WPF.FaxGuild.Services.OrderCreators;
using WPF.FaxGuild.Services.OrderProviders;
using WPF.FaxGuild.Stores;
using WPF.FaxGuild.ViewModels;

namespace WPF.FaxGuild
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string connectionString = "DataSource=WpfFaxGuild.db";
        private readonly Company _company;
        private readonly CompanyStore _companyStore;
        private readonly NavigationStore _navigationStore;
        private readonly FaxguildDbContextFactory _faxguildDbContextFactory;

        public App()
        {
            _faxguildDbContextFactory = new FaxguildDbContextFactory(connectionString);
            IOrderProvider orderProvider = new DatabaseOrderProvider(_faxguildDbContextFactory);
            IOrderCreator orderCreator = new DatabaseOrderCreator(_faxguildDbContextFactory);
            IOrderConflictValidator orderConflictValidator = new DatabaseOrderConflctValidator(_faxguildDbContextFactory);

            OrderList orderList = new OrderList(orderProvider, orderCreator, orderConflictValidator);

            _company = new Company("CHNU", orderList);
            _companyStore = new CompanyStore(_company);
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            using (FaxguildDbContext dbContext = _faxguildDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            } ;


            _navigationStore.CurrentViewModel = CreateOrderViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            }; 
            MainWindow.Show();

            base.OnStartup(e);
        }

        private MakeOrderViewModel CreateMakeOrderViewModel()
        {
            return new MakeOrderViewModel(_companyStore, new NavigationService(_navigationStore, CreateOrderViewModel));
        }

        private OrderListViewModel CreateOrderViewModel()
        {
            return OrderListViewModel.LoadViewModel(_companyStore, CreateMakeOrderViewModel(), new NavigationService(_navigationStore, CreateMakeOrderViewModel));
        }
    }
}
