using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Battle_Ship
{
    public class UserB : BattleBoard
    {
        public UserB()  //конструктор для основного вызова
        {
            Console.Clear();
            Ships(UserField);

        }

        public void Strike()  //обработка "выстрела"
        {
            if (Win())
            {
                return;
            }
            Console.SetCursorPosition(30, Indent++);
            o:

            Console.WriteLine("Выстрел №: " + ++Step);
            Boolean letter = true;
            int s = new int();
            while (letter)
            {
                Console.SetCursorPosition(30, Indent++);

                Console.Write("Ваш выстрел: ");



                String substring = null;
                String substring1 = null;

                try
                {
                    string Base = Console.ReadLine();
                    char[] Cifr = { '1', '2', '3', '4', '5', '6', ' ',
                    '7', '8', '9', '0', ',', '.', '?', ']', '[', '{', '}', ','};
                    string NetChifr = Base.TrimStart(Cifr);
                    substring = NetChifr.Substring(0, 1);


                    char[] Bukva = { 'Q', 'B', 'N', 'M', '/', '!', ' ',
                    'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd',
                    'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'W',
                    'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J',
                    'K', 'L', 'Z', 'X', 'C', 'V', ',', '.', '?', ']', '[', '{', '}',
                    'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'ф',
                    'у', 'х', 'ц', 'ч', 'й', 'ш', 'щ', 'ы', 'ь', 'ъ', 'э', 'ю', 'я', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё',
                    'Ж', 'З', 'И', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ы',
                    'Ь', 'Ъ', 'Э', 'Ю', 'Я', '`', 'Й', ','};
                    string NetBukv = Base.TrimStart(Bukva);
                    substring1 = NetBukv.Substring(0, 1);
                    s = Convert.ToInt32(substring1);

                }
                catch (ArgumentOutOfRangeException)
                {
                    Step--;
                    Console.SetCursorPosition(30, Indent++);
                    goto o;
                }
                catch (FormatException)
                {
                    Console.SetCursorPosition(30, 0);
                    Console.WriteLine("Что там было написано?!");
                    Step--;
                    Console.SetCursorPosition(30, Indent++);
                    goto o;
                }

                char l1 = Convert.ToChar(substring);
                if ((int)l1 >= 65 && (int)l1 <= 122)
                {
                    Console.SetCursorPosition(30, 0);
                    Console.WriteLine("I don't speak English");
                    Step--;
                    Console.SetCursorPosition(30, Indent++);
                    goto o;
                }

                if ((int)l1 >= 1072 && (int)l1 <= 1082)
                {
                    switch (l1)  //переделываем значение, которое ввели в виде буквы
                    {
                        case 'а':
                            Letter[Step] = 0;
                            letter = false;
                            break;
                        case 'б':
                            Letter[Step] = 1;
                            letter = false;
                            break;
                        case 'в':
                            Letter[Step] = 2;
                            letter = false;
                            break;
                        case 'г':
                            Letter[Step] = 3;
                            letter = false;
                            break;
                        case 'д':
                            Letter[Step] = 4;
                            letter = false;
                            break;
                        case 'е':
                            Letter[Step] = 5;
                            letter = false;
                            break;
                        case 'ж':
                            Letter[Step] = 6;
                            letter = false;
                            break;
                        case 'з':
                            Letter[Step] = 7;
                            letter = false;
                            break;
                        case 'и':
                            Letter[Step] = 8;
                            letter = false;
                            break;
                        case 'к':
                            Letter[Step] = 9;
                            letter = false;
                            break;
                    }

                }

            }
            try
            {
                Index[Step] = s;
            }

            catch (FormatException)
            {

            }

            if (Hit(Index[Step], Letter[Step]))  //обработка случая, если попал еще раз
            {
                Points++;
                Strike();
            }
        }

        public bool Hit(int i, int j)  //проверка на попадение
        {
            try
            {
                if (CompField[i, j] == 0)
                {
                    CompField[i, j] = 3;
                    Field1[i, j] = 3;
                    Output(Field1);
                    Console.SetCursorPosition(30, 0);
                    Console.Write("Промах!                       ");
                    return false;
                }
                if (CompField[i, j] == 1)
                {
                    CompField[i, j] = 2;
                    Field1[i, j] = 2;
                    Output(Field1);
                    Console.SetCursorPosition(30, 0);
                    Console.Write("Попадание!                         ");
                    return true;
                }
            }

            catch (IndexOutOfRangeException)
            {
                Console.SetCursorPosition(30, 0);
                Console.WriteLine("Поле не 100х100                   ");
                Step--;
                return true;
            }
            Console.SetCursorPosition(30, 0);
            Console.Write("Уже было              ");
            Console.SetCursorPosition(30, 4);
            Console.WriteLine();
            Step--;
            return true;

        }

        public bool Win()  //проверка на победу
        {
            if (Points == 20)
            {
                Console.SetCursorPosition(30, 0);
                Console.Write("Победа!");
                //Points = 0;
                return true;
            }
            return false;
        }
    }
}
