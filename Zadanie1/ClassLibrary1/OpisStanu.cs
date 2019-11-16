using System;


namespace ClassLibrary1
{
    public class OpisStanu
    {

        public Katalog Katalog { get; }
        public int RokWydania { get; }
        public Guid IdOpisuStanu { get; set; }


        public OpisStanu(Katalog katalog, int rokWydania, Guid idOpisuStanu)
        {
            Katalog = katalog;
            RokWydania = rokWydania;
            IdOpisuStanu = idOpisuStanu;
        }
       
    }
}
