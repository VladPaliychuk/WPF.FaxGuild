using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.FaxGuild.Commands
{
    public abstract class AsyncCommandBase : CommandBase
    {
        public override async void Execute(object parameter)
        {
            IsExecuting = true;

            try
            {
                await ExecuteAsync(parameter);
            }
            finally { IsExecuting = false; }
        }
        public override bool CanExecute(object? parameter)
        {
            return !IsExecuting && base.CanExecute(parameter);
        }

        public abstract Task ExecuteAsync(object parameter);

        private bool _isExecuting;
        private bool IsExecuting
        {
            get { return _isExecuting; }
            set
            {
                _isExecuting = value;
            }
        } 
    }
}
