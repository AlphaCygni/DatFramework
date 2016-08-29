using DatFramework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DatFramework.ViewFactories
{
    public class DialogWindowViewFactory<T, U, V>
        where T : Window, new()
        where U : DialogWindowViewModel, new()
        where V : ViewParameters
    {
        public static bool Show(V parameters)
        {
            var view = new T();
            var viewModel = new U() { Parameters = parameters };
            view.DataContext = viewModel;
            viewModel.RequestClose += (sender, e) => view.Close();

            view.ShowDialog();

            return viewModel.IsAccept;
        }
    }
}
