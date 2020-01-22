using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IDataRepository
    {
         void AddLocation(Location location);

         Location GetLocation(short id);

         IQueryable<Location> GetAllLocations();

         void UpdateLocation(int id, string name);

         void DeleteLocation(int id);
        
    }
}
