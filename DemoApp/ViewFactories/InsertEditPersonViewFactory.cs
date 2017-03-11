using DatFramework.ViewFactories;
using DemoApp.DataViewModels;
using DemoApp.ViewModels;
using DemoApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.ViewFactories
{
    public class InsertEditPersonViewFactory : DialogWindowViewFactory<InsertEditPersonView, InsertEditPersonViewModel, InsertEditPersonViewParameters>
    {
    }

    public class InsertEditPersonViewParameters : ViewParameters
    {
        public PersonDataViewModel Person { get; set; }
    }
}
