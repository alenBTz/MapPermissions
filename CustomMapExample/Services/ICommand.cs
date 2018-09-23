using System;

using Xamarin.Forms;

namespace CustomMapExample.Services
{
    public interface ICommand
    {
        void Execute(object arg);
        bool CanExecute(object arg);
        event EventHandler CanExecuteChanged;
    }
}

