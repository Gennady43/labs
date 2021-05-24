using System;

namespace Lab_3568
{
    class Program
    {
        public static void Next()
        {
            Console.Write("Enter the next button: ");
            Console.ReadKey();
            Console.WriteLine("\n");
        }
        public static int CheckAge()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
                Console.Write("Incorrect input, repeat: ");
            return a;
        }
        public static int CheckRank()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || a < 1 || a > 10)
                Console.Write("Incorrect input, repeat: ");
            return a;
        }
        public static DateTime CheckDate()
        {
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
                Console.Write("Incorrect input, repeat: ");
            return date;
        }
        public static int CheckCompetitions()
        {
            int comp;
            while (!int.TryParse(Console.ReadLine(), out comp) || comp < 0 || comp > 1)
                Console.Write("Incorrect input, repeat: ");
            return comp;
        }
        public static Sportsman SetSportsman()
        {
            Console.WriteLine("\n");
            Sportsman someone = new Sportsman();
            Console.Write("Enter name: ");
            someone.Name = Console.ReadLine();
            Console.Write("Enter the country: ");
            someone.Country = Console.ReadLine();
            Console.Write("Enter the age: ");
            someone.Age = CheckAge();
            if (someone.Age < 14)
            {
                someone.TooYoung(someone.NotPaid);
                return someone;
            }
            Console.Write("Enter the sport: ");
            someone.Sport = Console.ReadLine();
            Console.Write("Enter the sport rank (1- unior3, 2-Junior2, 3-Junior1, 4-Adult3, 5-Adult2, 6-Adult1, 7-CMS, 8-MS, 9-IMS, 10-HMS): ");
            someone.Rank = (Rank)CheckRank();
            Console.Write("Enter the name of competitions: ");
            someone.comp.CompetitionsName = Console.ReadLine();
            Console.Write("Enter the date of copmetitions: ");
            someone.comp.Date = CheckDate();
            Console.Write("Participate?? (0 - no, 1 - yes): ");
            int cont = CheckCompetitions();
            if (cont == 0)
            {
                someone.Payment += () => someone.NotPaid();
                someone.NotAllowed();
                return someone;
            }
            Console.Write("Take a dope? (0 - no,  1 - yes): ");
            int dope = CheckCompetitions();
            if (dope == 0) 
                return someone;
            else
            {
                someone.Dope += delegate
                {
                    someone.TakeDope();
                };
                someone.Violation();
                return someone;
            }
        }
        public static void SetList(Sportsman[] list)
        {
            for (int i = 0; i < list.Length; i++)
                list[i] = SetSportsman();
            Console.Clear();
            Console.WriteLine("List of spotsmen:");
            for (int i = 0; i < list.Length; i++)
                Console.WriteLine(list[i]);
        }
        static void Main(string[] args)
        {
            Sportsman sp1 = new Sportsman();
            Console.WriteLine(sp1);
            Next();
            Sportsman[] list = new Sportsman[2];
            SetList(list);
            Console.Clear();
            Console.WriteLine("Sorted list: ");
            Array.Sort(list);
            foreach (Sportsman s in list)
                Console.WriteLine(s);
            Next();
            Console.WriteLine("Copy of the first sportsman in the list:");
            Sportsman sp2 = (Sportsman)list[0].Clone();
            Console.WriteLine(sp2);
        }
    }
}