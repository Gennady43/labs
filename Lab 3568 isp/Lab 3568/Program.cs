using System;

namespace Lab_3568
{
    class Program
    {
        public static void Next()
        {
            Console.Write("Нажмите любую клавишу, чтобы продолжить: ");
            Console.ReadKey();
            Console.WriteLine("\n");
        }
        public static int CheckAge()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || a <= 0)
                Console.Write("Неправильный ввод. Повторите: ");
            return a;
        }
        public static int CheckRank()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a) || a < 1 || a > 10)
                Console.Write("Неправильный ввод. Повторите: ");
            return a;
        }
        public static DateTime CheckDate()
        {
            DateTime date;
            while (!DateTime.TryParse(Console.ReadLine(), out date))
                Console.Write("Неправильный ввод. Повторите: ");
            return date;
        }
        public static int CheckCompetitions()
        {
            int comp;
            while (!int.TryParse(Console.ReadLine(), out comp) || comp < 0 || comp > 1)
                Console.Write("Неправильный ввод. Повторите: ");
            return comp;
        }
        public static Sportsman SetSportsman()
        {
            Console.WriteLine("\n");
            Sportsman someone = new Sportsman();
            Console.Write("Введите ФИ: ");
            someone.Name = Console.ReadLine();
            Console.Write("Введите страну: ");
            someone.Country = Console.ReadLine();
            Console.Write("Введите возраст: ");
            someone.Age = CheckAge();
            if (someone.Age < 18)
            {
                someone.TooYoung(someone.NotPaid);
                return someone;
            }
            Console.Write("Введите вид спорта: ");
            someone.Sport = Console.ReadLine();
            Console.Write("Введите спортивный разряд (1 - юношеский 3-й, 2 - юношшеский 2-й, 3 - юношеский 1-й, 4 - спортивный 3-й, 5 - спортивный 2-й, 6 - спортивный 1-й, 7 - КМС, 8 - МС, 9 - МСМК, 10 - ЗМС): ");
            someone.Rank = (Rank)CheckRank();
            Console.Write("Введите название соревнований: ");
            someone.comp.CompetitionsName = Console.ReadLine();
            Console.Write("Введите дату начала соревнований: ");
            someone.comp.Date = CheckDate();
            Console.Write("Принимать участие? (0 - нет, 1 - да): ");
            int cont = CheckCompetitions();
            if (cont == 0)
            {
                someone.Payment += () => someone.NotPaid();
                someone.NotAllowed();
                return someone;
            }
            Console.Write("Принять допинг? (0 - нет,  1 - да): ");
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
            Console.WriteLine("Список спортсменов:");
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
            Console.WriteLine("Отсортированный список: ");
            Array.Sort(list);
            foreach (Sportsman s in list)
                Console.WriteLine(s);
            Next();
            Console.WriteLine("Копия первого спортсмена в списке: ");
            Sportsman sp2 = (Sportsman)list[0].Clone();
            Console.WriteLine(sp2);
        }
    }
}