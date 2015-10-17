using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using PclSample.Core.Models;
using PclSample.Core.Services;

namespace PclSample.Core.ViewModels
{
    public class MainViewModel:ViewModelBase
    {
        private readonly IPersonService _personService;

        public MainViewModel(IPersonService personService)
        {
            if (personService == null) throw new ArgumentNullException(nameof(personService));
            _personService = personService;
            if (IsInDesignMode)
            {
                People = new ObservableCollection<Person> {new Person{FirstName = "Doctor Who"}, new Person {FirstName = "Rose", LastName = "Tyler"}, new Person {FirstName = "River", LastName = "Song"} };
            }
            else
            {
                People = new ObservableCollection<Person>();
            }
        }

        public ObservableCollection<Person> People { get; set; }

        public async Task InitAsync()
        {
            var people = await _personService.GetPeople();
            People.Clear();
            foreach (var person in people)
            {
                People.Add(person);
            }
        }
    }
}
