using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using DatFramework.ViewFactories;
using DatFramework.Helpers;
using System.Windows;
using System.Linq.Expressions;

namespace DatFramework.ViewModels
{    
    public class WindowViewModel : ViewModelBase
    {  
        public List<RelayCommand> Commands { get; private set; }

        public ViewParameters Parameters { get; set; }

        public WindowViewModel()
            : base()
        {            
            Commands = new List<RelayCommand>();    
        }  

        public override void OnPropertyChanged(String property)
        {
            base.OnPropertyChanged(property);

            Commands.ForEach(c =>
            {
                c.OnCanExecuteChanged();
            });
        }

        public RelayCommand RegisterCommand<T>(Expression<Func<T>> commandPropertyExpression, Action<object> executeMethod)
        {            
            var command = new RelayCommand((((MemberExpression)(commandPropertyExpression.Body)).Member).Name, executeMethod);

            Commands.Add(command);

            return command;
        }

        public RelayCommand RegisterCommand<T>(Expression<Func<T>> commandPropertyExpression, Predicate<object> canExecuteMethod, Action<object> executeMethod)
        {
            var command = new RelayCommand((((MemberExpression)(commandPropertyExpression.Body)).Member).Name, canExecuteMethod, executeMethod);

            Commands.Add(command);

            return command;
        }
    }
}
