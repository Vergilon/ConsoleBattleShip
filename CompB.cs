using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Battle_Ship
{
    public class CompB : BattleBoard
    {
        public CompB()
        {
            Ships(CompField);
        }

        public void Strike()
        {
            if (Win())
            {
                return;
            }
            Random();
            Console.SetCursorPosition(30, Indent++);
            Console.WriteLine("Выстрел противника: " + str1[Letter[Step]] + (Index[Step]));
            if (Hit(Index[Step], Letter[Step]))
            {
                Step++;
                Points++;
                Strike();
            }
        }

        private void Random()  //рандомные атаки
        {
            var random = new Random(DateTime.Now.Millisecond);
            Letter[Step] = random.Next(10);
            Index[Step] = random.Next(10);
            while (Field1[Index[Step], Letter[Step]] > 0)
            {
                Letter[Step] = random.Next(10);
                Index[Step] = random.Next(10);
            }
        }

        public bool Hit(int i, int j) 
        {
            if (UserField[i, j] == 0)
            {
                Field1[i, j] = 3;
                UserField[i, j] = 3;
                return false;
            }
            if (UserField[i, j] == 1)
            {
                Field1[i, j] = 2;
                UserField[i, j] = 2;
                return true;
            }
            if (UserField[i, j] > 1)
            {
                return false;
            }
            return false;
        }

        public bool Win()  //проверка на победу
        {
            if (Points == 20)
            {
                Console.SetCursorPosition(30, 0);
                Console.Write("Вы проиграли!");
                //Points = 0;
                return true;
            }
            return false;
        }
    }
}
