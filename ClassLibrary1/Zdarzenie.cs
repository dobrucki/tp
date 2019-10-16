﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Zdarzenie
    {
        private Wykaz _wykaz;
        private OpisStanu _opisStanu;
        private DateTime _checkoutDate;

        public Wykaz Wykaz { get; private set; }
        public OpisStanu OpisStanu { get; private set; }
        public DateTime CheckoutDate { get; private set; }
    }
}
