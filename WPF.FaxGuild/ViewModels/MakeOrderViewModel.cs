using System;
using System.Windows.Input;
using WPF.FaxGuild.Commands;
using WPF.FaxGuild.DAL.Models;
using WPF.FaxGuild.Services;
using WPF.FaxGuild.Stores;

namespace WPF.FaxGuild.ViewModels
{
    public class MakeOrderViewModel : ViewModelBase
    {
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public MakeOrderViewModel(Company company, NavigationService orderViewNavigationService)
        {
            SubmitCommand = new MakeOrderCommand(this, company, orderViewNavigationService);
            CancelCommand = new NavigateCommand(orderViewNavigationService);
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value; 
                OnPropertyChanged(nameof(Name)); 
            }
        }

        private int _roomnumber;
        public int Roomnumber
        {
            get { return _roomnumber; }
            set
            {
                _roomnumber = value;
                OnPropertyChanged(nameof(Roomnumber));
            }
        }

        private int _placenumber;
        public int Placenumber
        {
            get { return _placenumber; }
            set
            {
                _placenumber = value;
                OnPropertyChanged(nameof(Placenumber));
            }
        }

        private DateTime _start;
        public DateTime Start
        {
            get { return _start; }
            set
            {
                _start = value;
                OnPropertyChanged(nameof(Start));
            }
        }

        private DateTime _end;
        public DateTime End
        {
            get { return _end; }
            set
            {
                _end = value;
                OnPropertyChanged(nameof(End));
            }
        }
    }
}
