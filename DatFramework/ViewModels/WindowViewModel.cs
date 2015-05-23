using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

        public RelayCommand RegisterCommand(string commandName, Action<object> executeMethod)
        {
            Commands.Add(commandName, new RelayCommand(null, executeMethod));

            return Commands[commandName];
        }

        public RelayCommand RegisterCommand(string commandName, Predicate<object> canExecuteMethod, Action<object> executeMethod)
        {
            Commands.Add(commandName, new RelayCommand(canExecuteMethod, executeMethod));

            return Commands[commandName];
        }
    }
}
