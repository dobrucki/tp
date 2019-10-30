using System;


namespace ClassLibrary1
{
    public abstract class Zdarzenie
    {
        public Guid Guid { get; set; }
        public Wykaz Wykaz { get; }
        public OpisStanu OpisStanu { get; }
        public DateTime DataZdarzenia { get; }

        public Zdarzenie(Wykaz wykaz, OpisStanu opisStanu, DateTime dataZdarzenia, Guid guid)
        {
            Wykaz = wykaz;
            OpisStanu = opisStanu;
            DataZdarzenia = dataZdarzenia;
            Guid = guid;
        }
    }
}
