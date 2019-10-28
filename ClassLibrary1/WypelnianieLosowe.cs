using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class WypelnianieLosowe : IDataFiller
    {

        public void Fill(DataContext dataContext)
        {
            Random random = new Random();
            for (int i=0; i<5; i++)
            {
                dataContext.Wykazy.Add(new Wykaz($"firstName{random.Next(0, 10000)}", $"lastName{random.Next(0, 10000)}", Guid.NewGuid(), new Wykaz.Adres($"Łódź{random.Next(0, 10000)}", $"92-{random.Next(0, 10000)}", $"Sacharowa{random.Next(0, 10000)}", $"{random.Next(1, 10000)}")));    
            }

            
            for (int i = 0; i < 5; i++)
            {
                Guid testGuid = Guid.NewGuid();
                dataContext.Katalogi.Add(testGuid, new Katalog($"Tytul{random.Next(0, 10000)}", $"ImieAutora{random.Next(0, 10000)}", $"NaziwskoAutora{random.Next(0, 10000)}", testGuid));
            }



        }

    } 
}
