using DatFramework.ViewFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatFramework.ViewModels
{
    public class DialogWindowViewModel : ViewModelBase
    {
        public event EventHandler RequestClose;
        
        public bool IsAccept { get; set; }
        
        public RelayCommand AcceptCommand { get; private set; }

        public RelayCommand CancelCommand { get; private set; }        
        
        public List<RelayCommand> Commands { get; private set; }        

        public ViewParameters Parameters { get; set; }

        public DialogWindowViewModel()
            : base()
        {  
            Commands = new List<RelayCommand>();

            AcceptCommand = RegisterCommand(() => AcceptCommand, ce => CanAccept(), e => Accept());
            CancelCommand = RegisterCommand(() => CancelCommand, ce => CanCancel(), e => Cancel());
        }        

        /// <summary>
        /// Used for Initialization based on ViewParameters values
        /// </summary>
        public virtual void Initialize()
        {

        }

        public virtual bool CanAccept()
        {
            return true;
        }

        public virtual bool CanCancel()
        {
            return true;
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

        public virtual void Accept()
        {
            IsAccept = true;

            RequestClose.Invoke(null, null);
        }

        public virtual void Cancel()
        {
            IsAccept = false;

            RequestClose.Invoke(null, null);
        }
    }
}
