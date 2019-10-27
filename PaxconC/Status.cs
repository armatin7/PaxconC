using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;


namespace PaxconC
{
    class Status
    {
        private string[,] array = new string[41, 121];
        public int life = 3;
        public bool seat = false;
        private int gc1 = 0, gc2 = 0, gc3 = 0, gc4 = 0;
        public int count = 0, score = 0, persentage = 0;
        private Stopwatch stopwatch = new Stopwatch();
        public Status(Menue menue)

        {
            makefield();
            gc1 = menue.gc1;
            gc2 = menue.gc2;
            gc3 = menue.gc3;
            gc4 = menue.gc4;
            stopwatch.Start();
            //display();
        }
        private void makefield()
        {
            for (int i = 0; i < 121; i++)
            {
                array[0, i] = "#";
                array[40, i] = "#";
            }
            for (int j = 0; j < 41; j++)
            {
                array[j, 0] = "#";
                array[j, 120] = "#";
            }
            for (int j = 0; j < 41; j++)
                for (int i = 0; i < 121; i++)
                {
                    if (contain(i, j) == null)
                        array[j, i] = " ";
                }
        }
        public string contain(int i, int j)
        {
            return array[j, i];
        }
        public void save(int i, int j, string s)
        {
            array[j, i] = s;
        }
        public void position(int i, int j, string s)
        {
            save(i, j, s);
            Console.SetCursorPosition(i, j);
            Console.Write(contain(i, j));
        }
        public void repair()
        {
            for (int j = 0; j < 41; j++)
                for (int i = 0; i < 121; i++)
                {
                    if (contain(i, j) == "." || contain(i, j) == "!" || contain(i, j) == "?" || contain(i, j) == "3")
                        save(i, j, " ");
                }
        }
        public void makesquare()
        {
            for (int j = 0; j < 41; j++)
                for (int i = 0; i < 121; i++)
                {
                    if (contain(i, j) == "1" || contain(i, j) == "3" || contain(i, j) == "4")
                    {
                        infect(i, j);
                    }
                }
            for (int j = 0; j < 41; ++j)
                for (int i = 0; i < 121; ++i)
                {
                    if (contain(i, j) == " " || contain(i, j) == ".")
                        save(i, j, "#");
                    else if (contain(i, j) == "^")
                    {
                        save(i, j, " ");
                    }
                }
        }
        private void infect(int x, int y)
        {
            if (contain(x, y) == " " || contain(x, y) == "1" || contain(x, y) == "3" || contain(x, y) == "4")
            {
                save(x, y, "^");
                for (int j = -1; j < 2; j++)
                {
                    for (int i = -1; i < 2; i++)
                    {
                        if ((x + i < 120 && x + i > 0) && (y + j < 40 && y + j > 0))
                            infect(x + i, y + j);
                    }
                }
            }
        }
        public bool safe(int i, int j, string s)
        {
            if (array[j, i] == s)
                return false;
            else
                return true;
        }
        public void display()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            count = 0;
            for (int j = 0; j < 41; j++)
            {
                for (int i = 0; i < 121; i++)
                {
                    if (contain(i, j) == "1" || contain(i, j) == "2" || contain(i, j) == "3")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(contain(i, j));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (contain(i, j) == "?")
                    {
                        //Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(" ");
                        //Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (contain(i, j) == "!")
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(contain(i, j));
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (contain(i, j) != " ")
                        Console.Write(contain(i, j));
                    else
                        Console.Write(" ");
                    if (contain(i, j) == "#")
                        count++;
                }
                Console.Write("\n");
            }
            lifeinterface();
            persentageinterface();
            scoreinterface();
        }
        public void fieldcontain()
        {
            int x0, y0;
            x0 = Convert.ToInt32(Console.ReadLine());
            y0 = Convert.ToInt32(Console.ReadLine());
            display();
            Console.Write(contain(x0, y0));
        }
        public void location(int x, int y)
        {
            Console.SetCursorPosition(122, 2);
            Console.Write("{0}  {1}", x, y);
        }
        public void misionaccomplished()
        {
            makesquare();
            display();
        }
        public void misionfailed()
        {
            if (!(seat))
            {
                life--;
                repair();
                //display();
            }
            seat = true;
        }
        private void lifeinterface()
        {
            Console.SetCursorPosition(122, 1);
            Console.ForegroundColor = ConsoleColor.Green;
            //Console.Write("life : {0} ", life);
            Console.Write("life : ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(129, 1);
            for (int i = 0; i < life * 3; i++)
            {
                if (i % 3 == 0)
                    Console.Write(" ", Console.BackgroundColor = ConsoleColor.DarkGray);
                if (life == 3)
                    Console.BackgroundColor = ConsoleColor.Green;
                else if (life == 2)
                    Console.BackgroundColor = ConsoleColor.Yellow;
                else if (life == 1)
                    Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(" ");//, Console.BackgroundColor = ConsoleColor.Green);
            }
            Console.BackgroundColor = ConsoleColor.DarkGray;
        }
        private void persentageinterface()
        {
            count -= 318;
            Console.SetCursorPosition(122, 3);
            //Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("possession = {0}%", count * 100 / 4641);
            persentage = count * 100 / 4641;
            //Console.ForegroundColor = ConsoleColor.White;
        }
        private void scoreinterface()
        {
            Console.SetCursorPosition(122, 4);
            Console.ForegroundColor = ConsoleColor.White;
            score += ((life * 100) / ((Convert.ToInt32(stopwatch.Elapsed.TotalSeconds) * 60) * (gc1 * 15 + gc2 * 19 + gc3 * 13 + gc4 * 8))) + persentage * 300;
            if (Convert.ToInt32(stopwatch.Elapsed.TotalSeconds) != 0)
                Console.Write("SCORE = {0} p", score);
        }
    }
}
