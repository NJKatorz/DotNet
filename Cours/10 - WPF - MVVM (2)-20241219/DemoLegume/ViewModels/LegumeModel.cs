using DemoLegume.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModels
{
    class LegumeModel : INotifyPropertyChanged
    {
        private readonly Legume _legume;


        // Property changed standard handling
        public event PropertyChangedEventHandler PropertyChanged;
        // La view s'enregistera automatiquement sur cet event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public LegumeModel(Legume legume)
        {
            _legume = legume;
        }
        
        
        public int Id {
            get { return _legume.Id; }
        }


        public string NameCombo
        {
            get { return _legume.Name; }
        }

        public string Name
        {
            get { return _legume.Name; }
            set
            {
                _legume.Name = value; OnPropertyChanged("NameCombo");
            }
        }

    }
}
