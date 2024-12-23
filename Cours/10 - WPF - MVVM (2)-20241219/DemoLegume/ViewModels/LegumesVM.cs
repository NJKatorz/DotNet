using DemoLegume.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModels
{
    class LegumesVM
    {
        // Change List to ObservableCollection
        private ObservableCollection<LegumeModel> _legumesList;
        private PotagerContext context = new PotagerContext();

        private DelegateCommand _addCommand;
        private LegumeModel _selectedLegume;


        public ObservableCollection<LegumeModel> LegumesList {
            get {
                //if (_legumesList == null) _legumesList = loadLegumes2();
                //return _legumesList;
                return _legumesList = _legumesList ?? loadLegumes2();
            }
        }
         

        private ObservableCollection<LegumeModel> loadLegumes2()
        {
            ObservableCollection<LegumeModel> localCollection = new ObservableCollection<LegumeModel>();
            foreach (var item in context.Legumes)
            {
                localCollection.Add(new LegumeModel(item));

            }

            return localCollection;

        }

        public LegumeModel SelectedLegume
        {
            get { return _selectedLegume; }
            set { _selectedLegume = value; }
        }

        public DelegateCommand NewCommand
        {
            get { return _addCommand = _addCommand ?? new DelegateCommand(NewLegume); }
        }


        private void NewLegume()
        {


            //MessageBox.Show("fskfjs");
            Legume legumeGlobal = new Legume();
            LegumeModel legumeModel = new LegumeModel(legumeGlobal);
            LegumesList.Add(legumeModel);

            SelectedLegume = legumeModel;
           // OnPropertyChanged("SelectedLegume");
           // OnPropertyChanged("LegumesList");

        }





    }
}
