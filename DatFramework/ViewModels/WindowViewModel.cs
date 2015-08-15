using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using DatFramework.ViewFactories;
using DatFramework.Helpers;

namespace DatFramework.ViewModels
{
    public class WindowViewModel : ViewModelBase
    {        
        public Dictionary<string, RelayCommand> Commands { get; private set; }

        public ViewParameters Parameters { get; set; }

        public WindowViewModel()
            : base()
        {
            Commands = new Dictionary<string, RelayCommand>();
        }

        public override void OnPropertyChanged(String property)
        {
            base.OnPropertyChanged(property);

            Commands.Values.ToList().ForEach(c =>
            {
                c.OnCanExecuteChanged();
            });
        }

        public RelayCommand RegisterCommand(string commandName, Action<object> executeMethod)
        {
            Commands.Add(commandName, new RelayCommand(executeMethod));

            return Commands[commandName];
        }

        public RelayCommand RegisterCommand(string commandName, Predicate<object> canExecuteMethod, Action<object> executeMethod)
        {
            Commands.Add(commandName, new RelayCommand(canExecuteMethod, executeMethod));

            return Commands[commandName];
        }

        //public void RegisterDelegate(ViewModelBase viewModel, string member, string memberProperty, Action<object> delegateMethod)
        //{
        //    viewModel.PropertyChanged += delegate
        //    {
        //        if (Proper)
                
        //        GetType().GetProperty(member).GetType().GetProperty(memberProperty);
        //    };
        //}
    }
}
