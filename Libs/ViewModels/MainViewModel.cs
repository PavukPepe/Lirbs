using BindLib;
using Libs.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Libs.ViewModels
{
    internal class MainViewModel : BindLib.BindingHelper
    {
        ObservableCollection<Person> persons { get; set; }

        private ObservableCollection<Person> People;

        public ObservableCollection<Person> people
        {
            get { return People; }
            set { People = value;
                OnPropertyChanged();
            }
        }

        public CommandHelper SaveBut { get; set; }
        public CommandHelper LoadBut { get; set; }

        public MainViewModel()
        {
            people = new ObservableCollection<Person>();
            SaveBut = new CommandHelper(_ => save());
            LoadBut = new CommandHelper(_ => load());
        }

        void save()
        {
            SerializerLib.Serializer.Write(people, "people.json");
        }

        void load()
        {
            people = SerializerLib.Serializer.Read<ObservableCollection<Person>>("people.json");
        }

    }
}
