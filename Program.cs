using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Console_Battle_Ship
{
    class Program
    {
        static void Main(string[] args)
        {
            ///////////////////тестовый блок/////////////////////////
            /*bool b1 = true;
            String substring = null;
            String substring1 = null;
            int s = new int();
            while (b1)
            {
                string Base = Console.ReadLine();
                char[] Cifr = { '1', '2', '3', '4', '5', '6', ' ',
                    '7', '8', '9', '0', ',', '.', '?', ']', '[', '{', '}'};
                string NetChifr = Base.TrimStart(Cifr);
                substring = NetChifr.Substring(0, 1);
                    
                    
                char[] Bukva = { 'Q', 'B', 'N', 'M', '/', '!', ' ',
                    'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd',
                    'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'W',
                    'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P', 'A', 'S', 'D', 'F', 'G', 'H', 'J',
                    'K', 'L', 'Z', 'X', 'C', 'V', ',', '.', '?', ']', '[', '{', '}'};
                string NetBukv = Base.TrimStart(Bukva);
                substring1 = NetBukv.Substring(0, 1);
                s = Convert.ToInt32(substring1) - 1;
                b1 = false;

            }

            Console.WriteLine(substring);
            Console.WriteLine(substring1);
            Console.WriteLine(s);
            string d = Console.ReadLine();
            int i = Console.Read();*/

            ///////////////////тестовый блок/////////////////////////
            Encoding enc = Encoding.GetEncoding(1251);
            Console.SetWindowSize(Console.WindowWidth + 10, Console.WindowHeight + 30);
            try
            {   
                using (StreamReader sr = new StreamReader("BShip.txt", enc))
                {
                    
                    String line = sr.ReadToEnd();
                    Console.Write(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Неудалось прочитать файл:");
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
            P();
            
            
        }
        public static void P()
        {
            Console.Title = "Морской бой";
            var User = new UserB();
            var Comp = new CompB();
            Boolean yes = true;
            while (yes)
            {
                while (true)
                {
                    User.Output(User.Field1);
                    User.Strike();
                    if (User.Win())
                    {
                        break;
                    }
                    Comp.Strike();
                    if (Comp.Win())
                    {
                        break;
                    }
                }
                Console.SetCursorPosition(30, 1);
                Console.WriteLine("Еще раз? да/нет");
                Console.SetCursorPosition(30, 2);
                if (Console.ReadLine() != "да")
                {

                    Console.Clear();
                    yes = false;
                }
                else
                {
                    P();
                }
            }
        }
    }
}
