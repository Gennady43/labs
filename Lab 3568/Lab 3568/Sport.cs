namespace Lab_3568
{
    enum Rank
    {
        Junior3 = 1,
        Junior2,
        Junior1,
        Adult3,
        Adult2,
        Adult1,
        CMS,
        MS,
        IMS,
        HMS
    }
    abstract class Sport : Human
    {
        public int Age { get; set; }
        public Rank @Rank { get; set; }

        public Sport() : base()
        {
            Age = 23;
            Rank = Rank.CMS;
        }
        public Sport(string nanem, string country, int age, Rank rank) : base(nanem, country)
        {
            Age = age;
            Rank = rank;
        }
        public override string ToString() => base.ToString() + $"\nAge: {Age}\nRank: {Rank}";
    }
}
