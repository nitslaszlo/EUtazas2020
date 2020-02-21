using System;

namespace EUtazas2020
{
    class Program
    {
        static void Main()
        {
            Megoldás megoldás = new Megoldás("utasadat.txt");

            Console.WriteLine($"2. feladat\nA buszra {megoldás.FelszállásokSzáma} utas akart felszállni.");

            Console.WriteLine($"3. feladat\nA buszra {megoldás.ÉrvénytelenFelszállásokSzáma} utas nem szállhatott fel.");

            Console.WriteLine($"4. feladat\nA legtöbb utas ({megoldás.MaxFelszálló} fő) a {megoldás.MaxMegálló}. megállóban próbált felszállni.");

            Console.WriteLine("5. feladat");
            Console.WriteLine($"Ingyenesen utazók száma: {megoldás.IngyenesUtazásDb} fő");
            Console.WriteLine($"A kedvezményesen utazók száma: {megoldás.KedvezményesUtazásDb} fő");

            megoldás.Figyelmeztet("figyelmeztetes.txt");

            Console.ReadKey();
        }
    }
}
