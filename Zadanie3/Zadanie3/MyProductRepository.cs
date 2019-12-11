using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MyProductRepository
    {
        public List<MyProduct> myProducts = new List<MyProduct>();

       public MyProductRepository(ProductionDataContext db)
        {
            this.myProducts = db.Product.Select(product => new MyProduct(product)).ToList();
        }
    }
}
