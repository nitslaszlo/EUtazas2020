using System;
using System.Globalization;

namespace EUtazas2020
{
    class Felszállás
    {
        public int Megálló { get; private set; }
        public DateTime Idő { get; private set; }
        public int Azonosító { get; private set; }

        public virtual bool ÉrvényesFelszállás { get; }

        public Felszállás(string sor)
        {
            // 0 20190326-0700 4170861 NYB 20190404
            string[] m = sor.Split();
            Megálló = int.Parse(m[0]);
            // yyyy 2019, yy 19
            // M 9, MM 09, MMM szept, MMMM szeptember
            // d 3, dd 03, ddd pén, dddd péntek
            // h 9am, de nem lehet pl.: 13
            // hh 09am, de nem lehet pl.: 13
            // H, 9 HH 09, lehet 13 (24 órás formátum)
            // m, mm -> perc
            // s, ss -> másodperc
            Idő = DateTime.ParseExact(m[1], "yyyyMMdd-HHmm", CultureInfo.InvariantCulture);
            Azonosító = int.Parse(m[2]);
        }
    }
}
