using DatFramework.ViewModels;
using DemoApp.DataViewModels;
using DemoApp.ViewFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.ViewModels
{
    public class InsertEditPersonViewModel : DialogWindowViewModel
    {
        private string firstName;
        private string lastName;
        private int age;

        public DatList<string> Genders { get; set; }

        public DatList<JobDataViewModel> Jobs { get; set; }
        
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                Set(ref firstName, value);
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                Set(ref lastName, value);
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                Set(ref age, value);
            }
        }
        
        public InsertEditPersonViewModel()
            : base()
        {
            Genders = new DatList<string>()
            {
                "M",
                "F"
            };

            #region "Populating the Jobs list with demo data"

            Jobs = new DatList<JobDataViewModel>()
            {                
                new JobDataViewModel()
                {
                    Name = "Database Administrator"
                },
                new JobDataViewModel()
                {
                    Name = "Help Desk Technician"
                },
                new JobDataViewModel()
                {
                    Name = "IT Systems Administrator"
                },
                new JobDataViewModel()
                {
                    Name = "Programmer"
                },
                new JobDataViewModel()
                {
                    Name = "Project Manager"
                },
                new JobDataViewModel()
                {
                    Name = "Systems Analyst"
                },
                new JobDataViewModel()
                {
                    Name = "Web Developper"
                }
            };

            #endregion
        }

        public override void Initialize()
        {
            base.Initialize();

            var p = ((InsertEditPersonViewParameters)Parameters).Person;
            
            // Add
            if (p == null)
            {
                this.Genders.SelectedItem = this.Genders[0];
            }
            // Edit
            else
            {
                this.FirstName = p.FirstName;
                this.LastName = p.LastName;
                this.Age = p.Age;
                this.Genders.SelectedItem = p.Gender == Gender.M ? this.Genders[0] : this.Genders[1];
                this.Jobs.SelectedItem = Jobs.FirstOrDefault(j => j.Name == p.Job);
            }
        }

        public override bool CanAccept()
        {
            return !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && Age > 0 && Genders.SelectedItem != null && Jobs.SelectedItem != null;
        }

        public override void Accept()
        { 
            // Add
            if (((InsertEditPersonViewParameters)this.Parameters).Person == null)
            {
                ((InsertEditPersonViewParameters)this.Parameters).Person = new PersonDataViewModel();
            }

            var p = ((InsertEditPersonViewParameters)this.Parameters).Person;

            p.FirstName = this.FirstName;
            p.LastName = this.LastName;
            p.Age = this.Age;
            p.Gender = this.Genders.SelectedItem == "M" ? Gender.M : Gender.F;
            p.Job = this.Jobs.SelectedItem.Name;
            
            base.Accept();
        }
    }
}
