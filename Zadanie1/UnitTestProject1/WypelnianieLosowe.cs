using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;


namespace UnitTests
{
    public class WypelnianieLosowe : IDataFiller
    {
        private static string[] firstNames = { "Adam", "Bartosz", "Cyryl", "Damian", "Edmund", "Franciszek", "Horacy", "Igor", "Jędrzej", "Karol", "Lucjan", "Łukasz", "Mateusz" };
        private static string[] lastNames = { "Abramowicz", "Bąk", "Celejewski", "Dobrucki", "Ewerkiewicz", "Fajfer", "Hadziewicz", "Idzikowski", "Jaworski", "Kowalski", "Lubaszenko", "Łęcki", "Morawiecki" };
        private static string[] cities = { "Warszawa", "Łódź", "Szczecin", "Kraków", "Wrocław", "Gdańsk", "Lublin", "Toruń", "Zakopane", "Poznań" };
        private static string[] streets = { "Sacharowa", "Gorkiego", "Piotrkowska", "Długa", "Ciasna", "Krótka", "Szeroka", "Fiołkowa", "Kwiatowa", "Niciarnia", "Zegarowa", "Pocztowa", "Bursztynowa", "Leśna", "Łąkowa", "Al. Piłsudskiego" };
        private static string[] titles = { "Quo Vadis", "W pustyni i w puszczy", "Co widać i czego nie widać", "Państwo", "Rozmyślania", "Krzyżacy", "Pan Tadeusz", "Pan Wołodyjowski", "Potop" };




        public void Fill(DataContext dataContext)
        {
            Random random = new Random();

            for (int i = 0; i < random.Next(2, 13); i++)
            {
                string firstName = firstNames[random.Next(firstNames.Length)];
                string lastName = lastNames[random.Next(lastNames.Length)];
                string city = cities[random.Next(cities.Length)];
                string street = streets[random.Next(streets.Length)];
                dataContext.Wykazy.Add(new Wykaz($"{firstName}", $"{lastName}", Guid.NewGuid(), new Wykaz.Adres($"{city}", $"{random.Next(10)}{random.Next(10)}-{random.Next(10)}{random.Next(10)}{random.Next(10)}", $"{street}", $"{random.Next(1, 200)}")));    
            }

            for (int i = 0; i < random.Next(1, 7); i++)
            {
                string title = titles[random.Next(titles.Length)];
                string firstName = firstNames[random.Next(firstNames.Length)];
                string lastName = lastNames[random.Next(lastNames.Length)];
                Guid testGuid = Guid.NewGuid();
                dataContext.Katalogi.Add(testGuid, new Katalog($"{title}", $"{firstName}", $"{lastName}", testGuid));
            }

            List<Katalog> katalogi = Enumerable.ToList(dataContext.Katalogi.Values);
            for (int i = 0; i < random.Next(5, 32); i++)
            {
                OpisStanu opisStanu = new OpisStanu(katalogi.ElementAt(random.Next(katalogi.Count)), random.Next(1900, 2020), Guid.NewGuid());
                dataContext.OpisyStanu.Add(opisStanu);
            }

            for (int i = 0; i < random.Next(3, 8); i++)
            {
                OpisStanu opis = dataContext.OpisyStanu.ElementAt(random.Next(dataContext.OpisyStanu.Count));
                Zdarzenie zdarzenie;
                if(random.Next(1) == 0)
                {
                    zdarzenie = new Wypozyczenie(dataContext.Wykazy.ElementAt(random.Next(dataContext.Wykazy.Count)), opis, DateTime.Today, Guid.NewGuid());
                }
                else
                {
                    zdarzenie = new Oddanie(dataContext.Wykazy.ElementAt(random.Next(dataContext.Wykazy.Count)), opis, DateTime.Today, Guid.NewGuid());
                }
            }
        }

    } 
}
