using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Battle_Ship
{
    public class BattleBoard
    {

        public int[,] Field1 = new int[10, 10]; //0 - пустая клетка, 1 - корабль, 2 - попадание по кораблю, 3 - промах
        public static readonly string[] str1 = { "A", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "K" };  //разметка буквами (сверху)
        public static readonly string[] str2 = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }; //разметка циффрами (сбоку)
        public int Step;  //номер хода
        protected int[] Letter = new int[101]; 
        protected int[] Index = new int[101];
        public int Points = 0;  //проверка на победу
        public static int Indent = 2;  //число отвечающее за номер строки, которая выведена в секторе ходов\негласный подсчет строк

        protected static int[,] CompField = new int[10, 10];

        protected static int[,] UserField = new int[10, 10];

        public void Output(int[,] Field)  //отрисовка полей для игры
        {

            if (Indent > 20)
            {
                Indent = 2;
                Console.Clear();
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(2 * i + 3, 0);  //сдвиг
                Console.Write(str1[i]); //вывод разметки
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, i + 1);  //сдвиг
                Console.Write(str2[i]);  //вывод разметки
                Console.SetCursorPosition(2, i + 1);
                Console.Write("| ");
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(2 * j + 3, i + 1);
                    Part(UserField[i, j]);  //вывод поля игрока
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(2 * i + 3, 13);
                Console.Write(str1[i]);
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(0, i + 14);
                Console.Write(str2[i]);
                Console.SetCursorPosition(2, i + 14);
                Console.Write("| ");
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(2 * j + 3, i + 14);
                    Part(Field[i, j]);

                }
            }
        }
        public void Part(int a)
        {
            switch (a)
            {
                case 0:   //живое поле
                    Console.Write('.');
                    break;
                case 1:   //месторасположение палубы/корабля
                    Console.Write('■');
                    break;
                case 2:   //попадение 
                    Console.Write('X');
                    break;
                case 3:   //промах
                    Console.Write('O');
                    break;
            }
        }

        public void Init(int[,] Field)  //зачистка поля (на всякий случай)
        {
            for (int i = 0; i < 10; i++)
                for (int j = 0; j < 10; j++)
                    Field[i, j] = 0;
        }

        public bool Freedom(int x, int y, int[,] Field)  //проверка на возможность утсановки в клетку и соседние клетки (однопалубник)
        {
            int[,] mas = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 }, { 1, 1 }, { -1, 1 }, { 1, -1 }, { -1, -1 } };
            int dx, dy;
            if ((x >= 0) && (x < 10) && (y >= 0) && (y < 10) && (Field[x, y] == 0))
            {
                for (int i = 0; i < 8; i++)
                {
                    dx = x + mas[i, 0];
                    dy = y + mas[i, 1];
                    if ((dx >= 0) && (dx < 10) && (dy >= 0) && (dy < 10) && (Field[dx, dy] > 0))
                    {
                        return false;

                    }

                }
                return true;
            }
            else
                return false;
        }

        public void Ships(int[,] Field)  //метод для генерации кораблей на карте
        {
            bool b;
            int kx, ky;
            Init(Field);
            for (int n = 3; n >= 0; n--)
                for (int m = 0; m <= 3 - n; m++)
                {
                    do
                    {
                        var random = new Random();
                        int x = random.Next(10);
                        int y = random.Next(10);
                        kx = random.Next(2);

                        if (kx == 0)
                            ky = 1;
                        else
                            ky = 0;
                        b = true;

                        for (int i = 0; i <= n; i++)
                            if (!Freedom(x + kx * i, y + ky * i, Field))
                                b = false;
                        if (b)
                            for (int j = 0; j <= n; j++)
                                Field[x + kx * j, y + ky * j] = 1;
                    }
                    while (!b);
                }
        }
        
    }
}
