using System;
using System.Linq;
using DataLayer;

namespace ServiceLayer
{
    public class DataRepository
    {
        private ProductionDataContext db = new ProductionDataContext();

        public void AddLocation(Location location)
        {
            
                db.Location.InsertOnSubmit(location);
                db.SubmitChanges();
            
        }

        public Location GetLocation(int id)
        {
            Location result = db.Location.FirstOrDefault(loc => loc.LocationID == id);
            return result;
        }

        public IQueryable<Location> GetAllLocations()
        {
                IQueryable<Location> result = from location in db.Location
                                              select location;
                return result;
            
        }

        public void UpdateLocation(int id, string name)
        {
            Location result = db.Location.FirstOrDefault(l => l.LocationID == id);

            if (result != null)
            {
                result.Name = name;
                result.ModifiedDate = DateTime.Today;
                db.SubmitChanges();
            }

        }

        public void DeleteLocation(int id)
        {
            Location result = db.Location.FirstOrDefault(l => l.LocationID == id);

            if (result != null)
            {
                db.Location.DeleteOnSubmit(result);
                db.SubmitChanges();
            }
        }

    }
}
