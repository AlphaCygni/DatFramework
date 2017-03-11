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
    public class MainViewModel : WindowViewModel
    {
        private string textFilter;
        
        public string TextFilter
        {
            get
            {
                return textFilter;
            }
            set
            {
                Set(ref textFilter, value);
                RefreshPersons();
            }
        }
        
        public DatList<PersonDataViewModel> Persons { get; set; }

        public DatList<PersonDataViewModel> DisplayedPersons { get; set; }

        public DatList<JobDataViewModel> Jobs { get; set; }

        public RelayCommand AddPersonCommand { get; private set; }

        public RelayCommand EditPersonCommand { get; private set; }

        public RelayCommand DeletePersonCommand { get; private set; }

        public InsertEditPersonViewFactory InsertEditPersonViewFactory { get; private set; }

        public MainViewModel()
            : base()
        {
            #region "Populating the Lists with demo data"

            Jobs = new DatList<JobDataViewModel>()
            {                
                new JobDataViewModel()
                {
                    Name = "All"
                },
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

            Persons = new DatList<PersonDataViewModel>()
            {
                new PersonDataViewModel()
                {
                    FirstName = "Jeffrey",
                    LastName = "Coleman",
                    Job = Jobs[1].Name,
                    Age = 42,
                    Gender = Gender.M
                },
                new PersonDataViewModel()
                {
                    FirstName = "Herman",
                    LastName = "Griffith",
                    Job = Jobs[2].Name,
                    Age = 47,
                    Gender = Gender.M
                },
                new PersonDataViewModel()
                {
                    FirstName = "Andres",
                    LastName = "Nichols",
                    Job = Jobs[3].Name,
                    Age = 35,
                    Gender = Gender.M
                },
                new PersonDataViewModel()
                {
                    FirstName = "Matt",
                    LastName = "Holland",
                    Job = Jobs[4].Name,
                    Age = 27,
                    Gender = Gender.M
                },
                new PersonDataViewModel()
                {
                    FirstName = "Pete",
                    LastName = "Pittman",
                    Job = Jobs[5].Name,
                    Age = 36,
                    Gender = Gender.M
                },
                new PersonDataViewModel()
                {
                    FirstName = "Alyssa",
                    LastName = "Gordon",
                    Job = Jobs[7].Name,
                    Age = 29,
                    Gender = Gender.F
                }
            };

            DisplayedPersons = new DatList<PersonDataViewModel>(Persons.ToList());

            #endregion

            Jobs.SelectedItem = Jobs[0];
            Jobs.SelectedItemChanged += this.RefreshPersons;            
            
            AddPersonCommand = RegisterCommand(() => AddPersonCommand, e => AddPerson());
            EditPersonCommand = RegisterCommand(() => EditPersonCommand, ce => DisplayedPersons.SelectedItem != null, e => EditPerson());
            DeletePersonCommand = RegisterCommand(() => DeletePersonCommand, ce => DisplayedPersons.SelectedItem != null, e => DeletePerson());
        }

        private void AddPerson()
        {
            var parameter = new InsertEditPersonViewParameters();

            if (InsertEditPersonViewFactory.Show(parameter))
            {
                Persons.Add(parameter.Person);
                
                RefreshPersons();
            }
        }

        private void EditPerson()
        {
            var parameter = new InsertEditPersonViewParameters()
                            {
                                Person = DisplayedPersons.SelectedItem
                            };

            if (InsertEditPersonViewFactory.Show(parameter))
            {
                var person = Persons.FirstOrDefault(p => p.Id == parameter.Person.Id);

                if (person != null)
                {
                    person.FirstName = parameter.Person.FirstName;
                    person.LastName = parameter.Person.LastName;
                    person.Age = parameter.Person.Age;
                    person.Gender = parameter.Person.Gender;
                    person.Job = parameter.Person.Job;

                    RefreshPersons();
                }
            }
        }

        private void DeletePerson()
        {
            var person = Persons.FirstOrDefault(p => p.Id == DisplayedPersons.SelectedItem.Id);

            if (person != null)
            {
                Persons.Remove(person);

                RefreshPersons();
            }
        }

        private void RefreshPersons()
        {
            var txtFilter = string.IsNullOrEmpty(TextFilter) ? "" : TextFilter.ToLower();
            
            var personsToShow = Persons.Where(p => (Jobs.SelectedItem == Jobs[0] || p.Job.Equals(Jobs.SelectedItem.Name)) &&
                                                   (string.IsNullOrEmpty(TextFilter) || (p.FullName.ToLower().Contains(txtFilter) || p.Job.ToLower().Contains(txtFilter) || p.Age.ToString().Contains(txtFilter))));

            DisplayedPersons.SetItems(personsToShow.ToList());
        }
    }
}
