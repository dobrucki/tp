using DataLayer;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using ViewData.MVVMLight;

namespace ViewData.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            LoadDataCommand = new RelayCommand(() => DataLayer = new DataRepository());
        }

        public RelayCommand LoadDataCommand
        {
            get; private set;
        }

        public ObservableCollection<Location> Locations
        {
            get { return m_Locations; }
            set
            {
                m_Locations = value;
                RaisePropertyChanged();
            }
        }

        public Location Location
        {
            get
            {
                return m_Location;
            }
            set
            {
                m_Location = value;
                RaisePropertyChanged();
            }
        }

        public DataRepository DataLayer
        {
            get { return m_DataLayer; }
            set
            {
                m_DataLayer = value;

                Task.Run(() =>
                {
                    Locations = new ObservableCollection<Location>(value.GetAllLocations());
                });
            }
        }









        private DataRepository m_DataLayer;
        private ObservableCollection<Location> m_Locations;
        private Location m_Location;
        public int ID { get; set; }
    }


}
