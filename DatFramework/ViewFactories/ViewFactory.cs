using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DatFramework.ViewModels;

namespace DatFramework.ViewFactories
{
    public class ViewFactory<T, U, V> 
        where T : Window, new()
        where U : WindowViewModel, new()
        where V : ViewParameters
    {        
        public static void Show(V parameters)
        {
            var view = new T();
            var viewModel = new U();
            viewModel.Parameters = parameters;
            view.DataContext = viewModel;
            view.Show();          
        }
    }
}
