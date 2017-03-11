using DatFramework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.DataViewModels
{
    public class JobDataViewModel : ViewModelBase
    {
        private static int cnt;

        public int Id { get; private set; }

        public string Name { get; set; }

        public JobDataViewModel()
        {
            this.Id = cnt++;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
