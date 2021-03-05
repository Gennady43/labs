using System;

namespace LB_1_isp
{
	class Program
	{
		static int Main()
		{
			Console.WriteLine("Доступные арифметические операции: +  -  *  / ^");
        input_point:
            Console.WriteLine("Запишите выражение: ");
			string expression = Console.ReadLine();
            bool check = true;
            float[] ArrayNumbers = new float[(expression.Length + 1) / 2];
            char[] ArraySimbols = new char[((expression.Length + 1) / 2)];
            int d = 0, q = 0, p = 0;
            char[] figures = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i = 0; i < expression.Length; i++)
            {
                for (int j = 0; j < figures.Length; j++)
                {
                    if (expression[i] == figures[j])
                    {
                        for (int z = 0; z < figures.Length; z++)
                        {
                            if (i == expression.Length - 1)
                                break;
                            else if (expression[i + 1] == figures[z])
                                check = false;
                        }
                        ArrayNumbers[d] = Convert.ToInt32(expression[i]) - 48; d++;
                    }
                }
                if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/' || expression[i] == '^')
                {
                    if (i == expression.Length - 1 || expression[i + 1] == '+' || expression[i + 1] == '-' || expression[i + 1] == '*' || expression[i + 1] == '/' || expression[i + 1] == '^')
                        check = false;
                    ArraySimbols[q] = expression[i]; q++;
                }
                else
                {
                    p = 0;
                    for (int j = 0; j < figures.Length; j++)
                    {
                        if (expression[i] == figures[j])
                            p = 1;
                    }
                    if (p == 0)
                        check = false;
                }
                if (check == false)
                {
                    Console.WriteLine("Выражение записано неправильно"); break;
                }
            }
            if (check == true)
            {
                float time;
                for (int i = 0; i < (expression.Length + 1) / 2; i++)
                {
                    if (i == 0 && expression[0] == '-')
                    {
                        time = ArrayNumbers[0];
                        ArrayNumbers[0] = -time;
                        for (int j = 0; j < (expression.Length + 1) / 2; j++)
                        {
                            if (j == ((expression.Length + 1) / 2) - 1)
                                ArraySimbols[j] = '?';
                            else
                                ArraySimbols[j] = ArraySimbols[j + 1];
                        }
                    }
                    if (ArraySimbols[i] == '^')
                    {
                        ArrayNumbers[i + 1] = Convert.ToInt32(Math.Pow(ArrayNumbers[i], ArrayNumbers[i + 1]));
                        ArrayNumbers[i] = 0; ArraySimbols[i] = '+';
                        if (i == 0)
                            ArraySimbols[i] = '+';
                        else if (ArraySimbols[i - 1] == '-')
                            ArraySimbols[i] = '-';
                        else
                            ArraySimbols[i] = '+';
                    }
                    else if (ArraySimbols[i] == '*')
                    {
                        time = ArrayNumbers[i];
                        time = time * ArrayNumbers[i + 1];
                        ArrayNumbers[i] = 0; ArrayNumbers[i + 1] = time; ArraySimbols[i] = '+';
                    }
                    else if (ArraySimbols[i] == '/')
                    {
                        time = ArrayNumbers[i];
                        time = time / ArrayNumbers[i + 1];
                        ArrayNumbers[i] = 0; ArrayNumbers[i + 1] = time; ArraySimbols[i] = '+';
                    }
                }
                float Summa = ArrayNumbers[0];
                for (int i = 0; i < (expression.Length + 1) / 2; i++)
                {
                    if (ArraySimbols[i] == '+')
                        Summa = Summa + ArrayNumbers[i + 1];
                    else if (ArraySimbols[i] == '-')
                        Summa = Summa - ArrayNumbers[i + 1];
                }
                Console.WriteLine("Ответ: " + Summa);
            }
            Console.WriteLine("Для повторного ввода нажмите клавишу y: ");
			string again = Console.ReadLine();
			if (again[0] == 'y')
				goto input_point;
			else
				return 0;
		}
	}
}