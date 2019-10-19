using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class DataRepository
    {
        private DataContext _dataContext = new DataContext();

        public DataRepository(IDataFiller filler)
        {
            filler.Fill(_dataContext); // Nie wiem czy to zadziała
        }


    }


}
