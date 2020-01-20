using DataLayer;
using ServiceLayer;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ViewData.MVVMLight;
using System.Linq;

namespace ViewData.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            LoadDataCommand = new RelayCommand(() => DataLayer = new DataRepository());
            AddLocationCommand = new RelayCommand(AddLocation);
            RemoveLocationCommand = new RelayCommand(RemoveLocation);
            UpdateLocationCommand = new RelayCommand(UpdateLocation);
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

        public void AddLocation()
        {
            Location location = new Location
            {
                Name = Name,
                ModifiedDate = DateTime.Today,
                CostRate = 0,
                Availability = 0
            };

            if (location.Name == null || location.Name == "")
            {
                
            }

            else
            {
                Task.Run(() =>
                {
                    m_DataLayer.AddLocation(location);
                });
            }

        }


        public void RemoveLocation()
        {
            Task.Run(() =>
            {
                if (ID == 0)
                {
                    
                }
                else
                {
                    m_DataLayer.DeleteLocation(ID);
                }
            });
        }

        public void UpdateLocation()
        {

            if (Name == null || Name == "")
            {
                
            }
            else
            {
                Task.Run(() =>
                {
                    m_DataLayer.UpdateLocation(ID, Name);
                });
            }
        }

       

        public RelayCommand LoadDataCommand
        {
            get; private set;
        }

        public RelayCommand AddLocationCommand
        {
            get; private set;
        }

        public RelayCommand RemoveLocationCommand
        {
            get; private set;
        }

        public RelayCommand UpdateLocationCommand
        {
            get; private set;
        }

        private DataRepository m_DataLayer;
        private ObservableCollection<Location> m_Locations;
        private Location m_Location;
        public string Name { get; set; }
        public short ID { get; set; }
    }


}

