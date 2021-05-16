using System;

namespace MyLib
{
    public static class Class1
    {
        public static void DLL()
        {
            unsafe
            {
                Console.WriteLine("Объявляем указатель на целое число X");
                int* x;
                Console.WriteLine("Задайте значение переменной Y: ");
                int y = Convert.ToInt32(Console.ReadLine());
                x = &y;
                Console.WriteLine($"Указатель X теперь указывает на адрес переменной Y (x = &y): {*x}");
                Console.WriteLine("Введите число, которое хотите прибавить к переменной Y: ");
                int tmp = Convert.ToInt32(Console.ReadLine()); ;
                y = y + tmp;
                Console.WriteLine($"Переменная Y теперь равна: {y}\nУказатель X указывает на адрес переменной Y: {*x}");
                Console.WriteLine("Введите число, которое хотите присвоить указателю X: ");
                int time = Convert.ToInt32(Console.ReadLine()); ;
                *x = time;
                Console.WriteLine($"Указатель X теперь равен: {*x}\nПеременная Y теперь равна: {y}");
                Console.WriteLine("Преобразуем указатель к целочисленному типу.\nПолучим адрес памяти, на который указывает указатель X (ulong adr = (ulong)x).");
                ulong adr = (ulong)x;
                Console.WriteLine("Адрес переменной Y: {0}", adr);
            }
        }
    }
}
