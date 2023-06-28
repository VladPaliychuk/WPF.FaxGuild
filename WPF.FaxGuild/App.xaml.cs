using Microsoft.EntityFrameworkCore;
using System;
using System.Windows;
using WPF.FaxGuild.Context;
using WPF.FaxGuild.DAL.Models;
using WPF.FaxGuild.Services;
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
        private readonly NavigationStore _navigationStore;
        public App()
        {
            _company = new Company("CHNU");
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(connectionString).Options;
            using (FaxguildDbContext dbContext = new FaxguildDbContext(options))
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
            return new MakeOrderViewModel(_company, new NavigationService(_navigationStore, CreateOrderViewModel));
        }

        private OrderListViewModel CreateOrderViewModel()
        {
            return new OrderListViewModel(_company, new NavigationService(_navigationStore, CreateMakeOrderViewModel));
        }
    }
}
