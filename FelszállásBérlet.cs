using System;
using System.Globalization;

namespace EUtazas2020
{
    class FelszállásBérlet : Felszállás
    {
        public string Típus { get; private set; }

        public DateTime Érvényes { get; private set; }

        public bool IngyenesUtazás => ÉrvényesFelszállás && (Típus == "NYP" || Típus == "RVS" || Típus == "GYK");

        public bool KedvezményesUtazás => ÉrvényesFelszállás && (Típus == "TAB" || Típus == "NYB");

        public override bool ÉrvényesFelszállás => Idő < Érvényes.AddDays(1);


        public bool LejárHáromNaponBelül => ÉrvényesFelszállás && (Érvényes - Idő).TotalDays <= 3;

        public FelszállásBérlet(string sor) : base(sor)
        {
            string[] m = sor.Split();
            Típus = m[3];
            Érvényes = DateTime.ParseExact(m[4], "yyyyMMdd", CultureInfo.InvariantCulture);
        }

    }
}
