using System;

namespace Lab_3568
{
    abstract class Human
    {
        public string Name { get; set; }
        public string Country { get; set; }
        protected string ID { get; set; }
        public Human()
        {
            Name = "Дмитрий";
            Country = "Казахстан";
            ID = GenID();
        }
        public Human(string name, string country)
        {
            Name = name;
            Country = country;
            ID = GenID();
        }
        protected static string GenID() => Guid.NewGuid().ToString();
        public override string ToString() => $"ФИ: {Name}\nСтрана: {Country}\nID: {ID}";
    }
}