/*Треугольник*/
using System;

namespace LB_2_ISP
{
    class Program
    {
        static int Main()
        {
        input_point:
            Console.WriteLine("Задайте длину сторон треугольника: ");
            Console.Write("A = "); double a = Convert.ToInt32(Console.ReadLine());
            Console.Write("B = "); double b = Convert.ToInt32(Console.ReadLine());
            Console.Write("C = "); double c = Convert.ToInt32(Console.ReadLine());
            int menu = 0;
            if (a < b + c && a > b - c && c < a + b && c > a - b && b < a + c && b > a - c)
            {
                do
                {
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("Меню: \n1. Повторный ввод\n2. Вычисление параметров\n0. Выход из программы");
                    menu = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
                    switch (menu)
                    {
                        case 1: goto input_point; break;
                        case 2:
                            double Perimeter, Square, alpha, beta, gamma, radius, RADIUS;
                            Perimeter = a + b + c;
                            Square = Math.Sqrt((Perimeter / 2) * ((Perimeter / 2) - a) * ((Perimeter / 2) - b) * ((Perimeter / 2) - c));
                            alpha = (Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c);
                            beta = (Math.Pow(a, 2) + Math.Pow(c, 2) - Math.Pow(b, 2)) / (2 * a * c);
                            gamma = (Math.Pow(b, 2) + Math.Pow(a, 2) - Math.Pow(c, 2)) / (2 * b * a);
                            radius = 2 * Square / Perimeter;
                            RADIUS = (a * b * c) / (4 * Square);
                            Console.WriteLine("Перимиетр прясрунольника: " + Perimeter);
                            Console.WriteLine("Площадь прясрунольника: " + Square);
                            Console.WriteLine("Косинус угла Альфа: " + alpha);
                            Console.WriteLine("Косинус угла Бета: " + beta);
                            Console.WriteLine("Косинус угла Гамма: " + gamma);
                            Console.WriteLine("Радиус вписанной окружности: " + radius);
                            Console.WriteLine("Радиус описанной окружности: " + RADIUS);
                            break;
                        case 0: break;
                        default: Console.WriteLine("Неправильный ввод пункта меню"); break;
                    }
                } while (menu != 0);
            }
            else
            {
                Console.WriteLine("Треугольника с заданными смторонами не существует\nДля повторного ввода нажмите y: ");
                char again = Convert.ToChar(Console.ReadLine());
                if (again == 'y')
                    goto input_point;
                else
                    return 0;
            }
            return 0;
        }
    }
}

///*Заглавные буквы*/
//using System;

//namespace LB_2_ISP
//{
//    class Program
//    {
//        static int Main()
//        {
//        input_point:
//            Console.WriteLine("Введите строку: ");
//            string str = Console.ReadLine();
//            char[] letters = new char[84];
//            int d = 0; bool check;
//            for (int i = 0; i < 26; i++)
//            {
//                letters[i] = Convert.ToChar(65 + i);
//            }
//            for (int i = 26; i < 52; i++)
//            {
//                letters[i] = Convert.ToChar(97 + d); d++;
//            }
//            d = 0;
//            for (int i = 52; i < 84; i++)
//            {
//                letters[i] = Convert.ToChar(1072 + d); d++;
//            }
//            Console.WriteLine("Заглавные буквы (или вовсе не буквы), не входящие в английский алфавит: ");
//            for (int i = 0; i < str.Length; i++)
//            {
//                check = false;
//                for (int j = 0; j < letters.Length; j++)
//                {
//                    if (str[i] == letters[j])
//                        check = true;
//                }
//                if (check == false)
//                    Console.Write(str[i]);
//            }
//            Console.WriteLine("\nДля повторного ввода нажмите y: ");
//            char again = Convert.ToChar(Console.ReadLine());
//            if (again == 'y')
//                goto input_point;
//            else
//                return 0;
//        }
//    }
//}

///*Буквы после гласных*/
//using System;
//using System.Text;

//namespace LB_2_ISP
//{
//    class Program
//    {
//        static int Main()
//        {
//            char[] vowels = new char[6] { 'a', 'o', 'e', 'i', 'u', 'y' };
//            char[] letters = new char[26];
//            for (int i = 0; i < 26; i++)
//                letters[i] = Convert.ToChar(97 + i);
//            input_point:
//            Console.WriteLine("Введите строку: ");
//            StringBuilder str = new StringBuilder(Console.ReadLine());
//            for (int i = 0; i < str.Length; i++)
//            {
//                if (i == str.Length - 1)
//                    break;
//                for (int j = 0; j < vowels.Length; j++)
//                {
//                    if (str[i] == vowels[j])
//                    {
//                        for (int z = 0; z < letters.Length; z++)
//                        {
//                            if (str[i + 1] == letters[z])
//                            {
//                                if (z == letters.Length - 1)
//                                {
//                                    str.Replace(str[i + 1], letters[0]); i++;
//                                    break;
//                                }
//                                else
//                                {
//                                    str.Replace(str[i + 1], letters[z + 1]); i++;
//                                    break;
//                                }
//                            }
//                        }
//                    }
//                }
//            }
//            Console.WriteLine("Изменённая строка: " + str);
//            Console.WriteLine("Для повторного ввода нажмите y: ");
//            char again = Convert.ToChar(Console.ReadLine());
//            if (again == 'y')
//                goto input_point;
//            else
//                return 0;
//        }
//    }
//}
