using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DatFramework.ViewModels
{
    interface IViewModel
    {
        event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(String property);

        bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null);
    }
}
