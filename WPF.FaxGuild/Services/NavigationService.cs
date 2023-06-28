using System;
using WPF.FaxGuild.Stores;
using WPF.FaxGuild.ViewModels;

namespace WPF.FaxGuild.Services
{
    public class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        public Func<ViewModelBase> _createViewModel { get; }

        public NavigationService(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createViewModel();

        }
    }
}
