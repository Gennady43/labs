using System;

namespace Lab_3568
{
    delegate void MyDelegate();
    class Sportsman : Sport, IComparable, ICloneable, ICompetitions
    {
        public string Sport { get; set; }
        public struct Competitions
        {
            public DateTime Date;
            public string CompetitionsName;
        }
        public Competitions comp;
        public Sportsman() : base()
        {
            Sport = "Велоспорт";
            comp.Date = new DateTime(2021, 07, 14);
            comp.CompetitionsName = "Групповые гонки";
        }
        public Sportsman(string name = "", string country = "", int age = 0, string sport = "", Rank rank = default, string competitionsname = "", DateTime date = default) : base(name, country, age, rank)
        {
            Sport = sport;
            comp.Date = date;
            comp.CompetitionsName = competitionsname;
        }
        public override string ToString() => base.ToString() + $"\nВид спорта: {Sport}\nСоревнования: {comp.CompetitionsName}\t{comp.Date.ToString("d")}\n";
        int IComparable.CompareTo(object obj)
        {
            if (this.Age > ((Sportsman)obj).Age) 
                return 1;
            if (this.Age < ((Sportsman)obj).Age) 
                return -1;
            else 
                return 0;
        }
        public object Clone() => (Sportsman)this.MemberwiseClone();
        public event MyDelegate Dope;
        public void TakeDope()
        {
            Name = Country = ID = Sport = comp.CompetitionsName = "Дисквалифицирован";
            Age = 0;
            Rank = 0;
            comp.Date = default;
        }
        public void Violation() => Dope?.Invoke();
        public event MyDelegate Payment;
        public void TooYoung(MyDelegate del) => del();
        public void NotPaid()
        {
            Name = Country = ID = Sport = comp.CompetitionsName = "Не допущен";
            Age = 0;
            Rank = 0;
            comp.Date = default;
        }
        public void NotAllowed() => Payment?.Invoke();
    }
}
