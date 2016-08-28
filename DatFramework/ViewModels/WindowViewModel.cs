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
    public delegate void SelectedItemChanged();
    
    public class WindowViewModel : ViewModelBase
    {  
        public List<RelayCommand> Commands { get; private set; }

        //public List<DatDelegate> Delegates { get; private set; }

        public ViewParameters Parameters { get; set; }

        public WindowViewModel()
            : base()
        {            
            Commands = new List<RelayCommand>();
            //Delegates = new List<DatDelegate>();

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

            Commands.ForEach(c =>
            {
                c.OnCanExecuteChanged();
            });

            //Delegates.ForEach(d =>
            //{
            //    if (d.PropertyName.Equals(property))
            //    {
            //        d.Delegate.DynamicInvoke();
            //    }
            //});
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

        //public void RegisterDelegate<T>(object target, Expression<Func<T>> propertyNameExpression, Action<object> executeMethod)
        //{
        //    var property = (((MemberExpression)(propertyNameExpression.Body)).Member).Name;

        //    Delegates.Add(new DatDelegate(property, target, executeMethod));
        //}

        //public void RegisterDelegate<T>(WindowViewModel target, DatList<T> list, Action<object> executeMethod)
        //{
        //    list.SelectedItem

        //    Delegates.Add(new DatDelegate(property, target, executeMethod));
        //}
    }
}
