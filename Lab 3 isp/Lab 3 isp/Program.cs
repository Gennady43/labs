using System;

namespace Lab_3_isp
{
    class Human
    {
        protected string name;
        protected string surname;
        protected int age;
        protected bool check = true;
        public Human(string name, string surname, int age)
        {
            this.name = name;
            this.surname = surname;
            if (age < 16 || age > 122)
            {
                Console.WriteLine("(!!!) Введён неправильный возраст. Введите данные заново");
                check = false;
                return;
            }
            else
                this.age = age;
        }
    }
    class Student : Human
    {
        protected int[] ExamGrades = new int[20];
        char[] figures = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        protected int ResearchActivities;
        protected int SocialWork;
        protected float AverSc = 0;
        public Student(string name, string surname, int age, string expression, int ResearchActivities, int SocialWork) : base(name, surname, age)
        {
            int d = 0;
            for (int i = 0; i < expression.Length; i++)
            {
                for (int j = 0; j < figures.Length; j++)
                {
                    if (d == 10)
                    {
                        Console.WriteLine("(!!!) Введены неправильные отметки. Введите данные заново");
                        check = false;
                        return;
                    }
                    if (expression[i] == '1' && expression[i + 1] == '0')
                    {
                        ExamGrades[d] = 10; d++;
                        i++;
                    }
                    else if (expression[i] == figures[j])
                    {
                        ExamGrades[d] = Convert.ToInt32(expression[i]) - 48; d++;
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                if (ExamGrades[i] < 4 || ExamGrades[i] > 10)
                {
                    Console.WriteLine("(!!!) Введены неправильные отметки. Введите данные заново");
                    check = false;
                    return;
                }
                else
                    this.ExamGrades = ExamGrades;
            }
            this.ResearchActivities = ResearchActivities;
            this.SocialWork = SocialWork;
        }
        public void GetInfo()
        {
            if (check == true)
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
                else if (a >= 5 && c <= 4)
                {
                    if (AverSc >= 9)
                        Console.WriteLine("Поздравляем! Вы получите скиду на обучение в 60%");
                    else if (AverSc >= 8.25 && AverSc <= 9)
                        Console.WriteLine("Поздравляем! Вы получите скиду на обучение в 40%");
                    else if (AverSc >= 7.46 && AverSc <= 8.25)
                        Console.WriteLine("Поздравляем! Вы получите скиду на обучение в 20%");
                }
                else
                    Console.WriteLine("К сожалению, вам не хватает среднего балла для получения скидки");
            }
            else
                return;
        }
    }
    class Program
    {
        static void Main()
        {
            char time = ' ', count = ' ', menu = ' ';
            string name, surname;
            string expression;
            int age, ResearchActivities = 0, SocialWork = 0;
            do
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("1. Ввести данные\n0. Выход");
                string testmenu = Console.ReadLine();
                if (testmenu.Length == 1)
                    menu = Convert.ToChar(testmenu);
                else
                    menu = '-';
                Console.WriteLine("------------------------------------------");
                switch (menu)
                {
                    case '1':
                        Console.WriteLine("Введите фамилию: ");
                        surname = Console.ReadLine();
                        Console.WriteLine("Введите имя: ");
                        name = Console.ReadLine();
                        Console.WriteLine("Введите возраст: ");
                        age = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите отметки по экзаменам за весь учебный курс (9 оценок): ");
                        expression = Console.ReadLine();
                        int tmp = 1;
                        while (tmp == 1)
                        {
                            Console.WriteLine("Вы принимали участие в научно-исследовательской деятельности?");
                            Console.WriteLine("1. Да, принимал\n2. Нет, не принимал");
                            string testtime = Console.ReadLine();
                            if (testtime.Length == 1)
                                time = Convert.ToChar(testtime);
                            else
                                time = '-';
                            switch (time)
                            {
                                case '1': ResearchActivities = 1; tmp = 0;  break;
                                case '2': ResearchActivities = 0; tmp = 0; break;
                                default: Console.WriteLine("(!!!) Выбран неправильный пункт меню"); break;
                            }
                        }
                        while (tmp == 0)
                        {
                            Console.WriteLine("Вы принимали участие в общественной работе?");
                            Console.WriteLine("1. Да, принимал\n2. Нет, не принимал");
                            string testcount = Console.ReadLine();
                            if (testcount.Length == 1)
                                count = Convert.ToChar(testcount);
                            else
                                count = '-';
                            switch (count)
                            {
                                case '1': SocialWork = 1; tmp = 1; break;
                                case '2': SocialWork = 0; tmp = 1; break;
                                default: Console.WriteLine("(!!!) Выбран неправильный пункт меню"); break;
                            }
                        }
                        Student Human1 = new Student(name, surname, age, expression, ResearchActivities, SocialWork);
                        Human1.GetInfo();
                        break;
                    case '0': return; break;
                    default: Console.WriteLine("Выбран неправильный пункт меню"); break;
                }
            } while (true);
        }
    }
}