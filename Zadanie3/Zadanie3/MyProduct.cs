using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class MyProduct : Product
    {


       public MyProduct(Product p)
        {
            foreach (var property in p.GetType().GetProperties())
            {
                if (property.CanWrite)
                    property.SetValue(this, property.GetValue(p));
            }
        }


    }
}
