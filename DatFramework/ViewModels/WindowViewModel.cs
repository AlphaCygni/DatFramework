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
        public Dictionary<string, RelayCommand> Commands { get; private set; }

        public ViewParameters Parameters { get; set; }

        public WindowViewModel()
            : base()
        {
            Commands = new Dictionary<string, RelayCommand>();

            Initialize();
        }

        private void Initialize()
        {
            InitializeCommands();
            InitializeDelegates();
        }

        public virtual void InitializeCommands()
        {

        }

        public virtual void InitializeDelegates()
        {

        }

        public override void OnPropertyChanged(String property)
        {
            base.OnPropertyChanged(property);

            Commands.Values.ToList().ForEach(c =>
            {                
                c.OnCanExecuteChanged();                
            });
        }

        public RelayCommand RegisterCommand<T>(Expression<Func<T>> commandPropertyExpression, Action<object> executeMethod)
        {
            var commandName = (((MemberExpression)(commandPropertyExpression.Body)).Member).Name;
            
            Commands.Add(commandName, new RelayCommand(executeMethod));

            return Commands[commandName];
        }

        public RelayCommand RegisterCommand<T>(Expression<Func<T>> commandPropertyExpression, Predicate<object> canExecuteMethod, Action<object> executeMethod)
        {
            var commandName = (((MemberExpression)(commandPropertyExpression.Body)).Member).Name;

            Commands.Add(commandName, new RelayCommand(canExecuteMethod, executeMethod));

            return Commands[commandName];
        }
    }
}
