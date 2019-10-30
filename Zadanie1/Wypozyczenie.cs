using System;


namespace ClassLibrary1
{
    public class Wypozyczenie : Zdarzenie
    {
        public Wypozyczenie(Wykaz wykaz, OpisStanu opisStanu, DateTime dataZdarzenia, Guid id) : base(wykaz, opisStanu, dataZdarzenia, id)
        {
        }
    }
}
