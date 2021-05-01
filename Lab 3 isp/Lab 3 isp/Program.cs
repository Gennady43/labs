using System;

namespace Lab_3_isp
{
    class Human
    {
        protected string name;
        protected string surname;
        protected int age;
        public Human(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            this.age = age;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
    }
    class Student : Human
    {
        protected int[] ExamGrades = new int[9];
        protected int ResearchActivities;
        protected int SocialWork;
        protected float AverSc = 0;
        public Student(string name, string surname, int age, int[] ExamGrades, int ResearchActivities, int SocialWork) : base(name, surname, age)
        {

            this.ExamGrades = ExamGrades;
            this.ResearchActivities = ResearchActivities;
            this.SocialWork = SocialWork;
        }
        public int[] examGrades
        {
            get { return examGrades; }
            set { examGrades = value; }
        }
        public int researchActivities
        {
            get { return researchActivities; }
            set { researchActivities = value; }
        }
        public int socialWork
        {
            get { return socialWork; }
            set { socialWork = value; }
        }
        public void GetInfo()
        {
            int a = 0, b = 0, c = 0;
            Console.WriteLine($"ФИ: {surname} {name}; Возраст: {age}");
            for (int i = 0; i < 9; i++)
            {
                AverSc = AverSc + ExamGrades[i];
                if (ExamGrades[i] >= 9)
                    a++;
                if (ExamGrades[i] >= 7 && ExamGrades[i] < 9)
                    b++;
                if (ExamGrades[i] >= 6 && ExamGrades[i] < 9)
                    c++;
            }
            AverSc = AverSc / 9;
            Console.WriteLine($"Ваш средний балл: {AverSc}");
            if (ResearchActivities == 1 && SocialWork == 1 && a >= 7 && b <= 2)
                Console.WriteLine("Поздравляем! Вы можете претендовать на бюджетное место");
            else if(a>=5 && c<=4)
            {
                if (AverSc >= 9)
                    Console.WriteLine("Поздравляем! Вы получите скиду на 60%");
                else if (AverSc >= 8.25 && AverSc <= 9)
                    Console.WriteLine("Поздравляем! Вы получите скиду на 40%");
                else if (AverSc >= 7.46 && AverSc <= 8.25)
                    Console.WriteLine("Поздравляем! Вы получите скиду на 20%");
            }
            else
                Console.WriteLine("К сожалению, вам не хватает среднего балла для получения скидки");
        }
    }
    class Program
    {
        static void Main()
        {
            int time, count, menu;
            string name, surname;
            int[] ExamGrades = new int[9];
            int age, ResearchActivities = 0, SocialWork = 0;
            bool check = true;
            do
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("1. Ввести данные\n0. Выход");
                menu = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("------------------------------------------");
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Введите фамилию: ");
                        surname = Console.ReadLine();
                        Console.WriteLine("Введите имя: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите возраст: ");
                        age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите отметки по экзаменам за весь учебный курс: ");
                        for (int i = 0; i < 9; i++)
                        {
                            ExamGrades[i] = Convert.ToInt32(Console.ReadLine());
                        }
                        Console.WriteLine("Вы принимали участие в научно-исследовательской деятельности?");
                        Console.WriteLine("1. Да, принимал\n2. Нет, не принимал");
                        time = Convert.ToInt32(Console.ReadLine());
                        switch (time)
                        {
                            case 1: ResearchActivities = 1; break;
                            case 2: ResearchActivities = 0; ; break;
                            default: Console.WriteLine("Выбран неправильный пункт меню"); break;
                        }
                        Console.WriteLine("Вы принимали участие в общественной работе?");
                        Console.WriteLine("1. Да, принимал\n2. Нет, не принимал");
                        count = Convert.ToInt32(Console.ReadLine());
                        switch (count)
                        {
                            case 1: SocialWork = 1; break;
                            case 2: SocialWork = 0; ; break;
                            default: Console.WriteLine("Выбран неправильный пункт меню"); break;
                        }
                        Student Human1 = new Student(name, surname, age, ExamGrades, ResearchActivities, SocialWork);
                        if (age < 16 || age > 122)
                        {
                            Console.WriteLine("(!!!) Введён неправильный возраст. Введите данные заново");
                            break;
                        }
                        for(int i = 0; i<9; i++)
                        {
                            if(ExamGrades[i]<4 || ExamGrades[i]>10)
                            {
                                Console.WriteLine("(!!!) Введены неправильные отметки. Введите данные заново");
                                check = false; break;
                            }
                        }
                        if (check == true)
                            Human1.GetInfo();
                        break;
                    case 0: return; break;
                    default: Console.WriteLine("Выбран неправильный пункт меню"); break;
                }
            } while (true);
        }
    }
}