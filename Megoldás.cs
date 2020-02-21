using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EUtazas2020
{
    class Megoldás
    {
        private readonly List<Felszállás> Felszállások = new List<Felszállás>();
        private int[] MegállóStatisztika;

        public int FelszállásokSzáma => Felszállások.Count;

        public int ÉrvénytelenFelszállásokSzáma
        {
            get
            {
                int érvényesFelszállásDb = 0;
                foreach (var i in Felszállások)
                {
                    if (i.ÉrvényesFelszállás) érvényesFelszállásDb++;
                }
                return FelszállásokSzáma - érvényesFelszállásDb;
            }
        }

        public int MaxFelszálló
        {
            get
            {
                MegállóStatisztika = new int[30]; // 0..29 Az indexek itt a megállót azonosítják
                // 4.1 segédvektor feltöltése
                foreach (var i in Felszállások)
                {
                    MegállóStatisztika[i.Megálló]++;
                }
                // 4.2 maximumkeresés a segédvektorban
                int maxFelszálló = MegállóStatisztika[0];
                foreach (var i in MegállóStatisztika.Skip(1))
                {
                    if (i > maxFelszálló) maxFelszálló = i;
                }
                return maxFelszálló;
            }
        }
        public int MaxMegálló
        {
            get
            {
                // 4.3 Az első maximum megkeresése
                int maxMegálló = -1;
                for (int i = 0; i < MegállóStatisztika.Length; i++)
                {
                    if (MegállóStatisztika[i] == MaxFelszálló)
                    {
                        maxMegálló = i;
                        break; // ez nem hagyható el
                    }
                }
                return maxMegálló;
            }
        }

        public int IngyenesUtazásDb
        {
            get
            {
                int ingyenesUtazásDb = 0;
                foreach (var i in Felszállások)
                {
                    if (i is FelszállásBérlet)
                    {
                        // as operátorral
                        FelszállásBérlet aktFelszállás = i as FelszállásBérlet;
                        // típuskényszerítéssel:
                        // FelszállásBérlet aktFelszállás = (FelszállásBérlet)i;
                        if (aktFelszállás.IngyenesUtazás) ingyenesUtazásDb++;
                    }
                }
                return ingyenesUtazásDb;
            }
        }

        public int KedvezményesUtazásDb
        {
            get
            {
                int kedvezményesUtazásDb = 0;
                foreach (var i in Felszállások)
                {
                    if (i is FelszállásBérlet)
                    {
                        // as operátorral
                        FelszállásBérlet aktFelszállás = i as FelszállásBérlet;
                        // típuskényszerítéssel:
                        // FelszállásBérlet aktFelszállás = (FelszállásBérlet)i;
                        if (aktFelszállás.KedvezményesUtazás) kedvezményesUtazásDb++;
                    }
                }
                return kedvezményesUtazásDb;
            }
        }
        public Megoldás(string forrás)
        {
            string[] bérletTípusok = { "FEB", "TAB", "NYB", "NYP", "RVS", "GYK" };
            foreach (var i in File.ReadAllLines(forrás))
            {
                string aktTípus = i.Split()[3];
                if (bérletTípusok.Contains(aktTípus)) // Bérletes utazás
                {
                    Felszállások.Add(new FelszállásBérlet(i));
                }
                if (aktTípus == "JGY") // Jegyes utazás
                {
                    Felszállások.Add(new FelszállásJegy(i));
                }
            }
        }

        public void Figyelmeztet(string fileNév)
        {
            List<string> ki = new List<string>();
            foreach (var i in Felszállások)
            {
                if (i is FelszállásBérlet aktFelszállás)
                {
                    if (aktFelszállás.LejárHáromNaponBelül)
                    {
                        ki.Add($"{aktFelszállás.Azonosító} {aktFelszállás.Érvényes.ToString("yyyy-MM-dd")}");
                    }
                }
            }
            File.WriteAllLines(fileNév, ki);
        }

    }
}
