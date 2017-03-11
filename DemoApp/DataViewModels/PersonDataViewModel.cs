using DatFramework.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.DataViewModels
{
    public class PersonDataViewModel : ViewModelBase
    {
        private static int cnt = 0;
        
        public int Id { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public Gender Gender { get; set; }
        
        public string Job { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public PersonDataViewModel()
        {
            this.Id = ++cnt;
        }
    }
}
