using DataLayer;
using ServiceLayer;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using ViewData.MVVMLight;
using System.ComponentModel;
using System.Collections.Generic;

namespace ViewData.ViewModel
{
    public class MainViewModel : ViewModelBase, IDataErrorInfo
    {

        public MainViewModel()
        {
            DataLayer = new DataRepository();
            LoadDataCommand = new RelayCommand(() => DataLayer = new DataRepository());
            AddLocationCommand = new RelayCommand(AddLocation);
            RemoveLocationCommand = new RelayCommand(RemoveLocation);
            UpdateLocationCommand = new RelayCommand(UpdateLocation);
            DetailsCommand = new RelayCommand(Detials);
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
            if (ErrorCollection["Name"] != null)
            {
                PopupHelper.Show(ErrorCollection["Name"], "Add location error");
            }
           

            else
            {
                Location location = new Location
                {
                    Name = Name,
                    ModifiedDate = DateTime.Today,
                    CostRate = 0,
                    Availability = 0
                };

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
               
                   m_DataLayer.DeleteLocation(ID);
                
            });
        }

        public void UpdateLocation()
        {

            if (ErrorCollection["Name"] != null)
            {
                PopupHelper.Show(ErrorCollection["Name"], "Update location error");
            }
            else
            {
                Task.Run(() =>
                {
                    m_DataLayer.UpdateLocation(ID, Name);
                });
            }
        }

        public void Detials()
        {
            PopupHelper.ShowDetails();
        }

        public string Name
        {
            get { return m_name; }
            set
            {
                m_name = value;
                RaisePropertyChanged();
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

        public RelayCommand DetailsCommand
        {
            get; private set;
        }

        private DataRepository m_DataLayer;
        private ObservableCollection<Location> m_Locations;
        private Location m_Location;
        private string m_name;

        public IPopupHelper PopupHelper { get; set; }
        public short ID { get; set; }

        public string Error { get { return null; } }

        public Dictionary<string, string> ErrorCollection { get; private set; } = new Dictionary<string, string>();

        public string this[string name]
        {
            get
            {
                string result = null;

                switch (name)
                {
                    case "Name":
                        if (string.IsNullOrWhiteSpace(Name))
                            result = "Name cannot be empty";
                        else if (Name.Length < 3)
                            result = "Name must be a minimum of 3 characters.";
                        break;
                }

                if (ErrorCollection.ContainsKey(name))
                    ErrorCollection[name] = result;
                else if (result != null)
                    ErrorCollection.Add(name, result);

                RaisePropertyChanged("ErrorCollection");
                return result;
            }
        }
    }


}

