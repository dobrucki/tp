using System;


namespace ClassLibrary1
{
    public class Oddanie : Zdarzenie
    {
        public Oddanie(Wykaz wykaz, OpisStanu opisStanu, DateTime dataZdarzenia, Guid id) : base(wykaz, opisStanu, dataZdarzenia, id)
        {
        }

        public Oddanie() : base() { }
    }
}
