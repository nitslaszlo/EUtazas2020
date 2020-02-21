namespace EUtazas2020
{
    class FelszállásJegy: Felszállás

    {
        public int UtazásokSzám { get; private set; }
        public override bool ÉrvényesFelszállás => UtazásokSzám > 0;

        public FelszállásJegy(string sor) : base(sor)
        {
            UtazásokSzám = int.Parse(sor.Split()[4]);
        }

    }
}
