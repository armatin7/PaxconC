using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PaxconC
{
    class Ghost4
    {
        private Status ghost4status;
        private Random movement = new Random();
        public int x, y;
        private int cx = 0, cy = 0;
        private bool ud = false, rl = false, u = false, d = false, r = false, l = false;
        public Ghost4(Status ghost4status)
        {
            this.ghost4status = ghost4status;
            int num = movement.Next(2);
            x = 120; y = 40;
            Thread.Sleep(30);
            seat();
            if (num == 0)
            {
                ud = true;
                checky(x, y);
            }
            else if (num == 1)
            {
                rl = true;
                checkx(x, y);
            }
        }
        public void seat()
        {
            int num = movement.Next(4);
            ghost4status.save(x, y, "#");
            do
            {
                if (num == 0)
                {
                    x = movement.Next(0, 120); y = 40;
                }
                else if (num == 1)
                {
                    x = 120; y = movement.Next(0, 40);
                }
                else if (num == 2)
                {
                    x = 0; y = movement.Next(0, 40);
                }
                else if (num == 3)
                {
                    x = movement.Next(0, 120); y = 0;
                }
            } while (startavailable(x, y));
            ghost4status.save(x, y, "4");
        }
        private bool startavailable(int i, int j)
        {
            if ((i > 0 && i < 120) && (j > 0 && j < 40))
            {
                if ((ghost4status.contain(i + 1, j) == "#" || ghost4status.contain(i + 1, j) == "4") && (ghost4status.contain(i - 1, j) == "#" || ghost4status.contain(i - 1, j) == "4") && (ghost4status.contain(i, j + 1) == "#" || ghost4status.contain(i, j + 1) == "4") && (ghost4status.contain(i, j - 1) == "#" || ghost4status.contain(i, j - 1) == "4"))
                    return false;
            }
            else if ((i > 0 && i < 120) && (j == 0) && ((ghost4status.contain(i + 1, j) == "#" || ghost4status.contain(i + 1, j) == "4") && (ghost4status.contain(i - 1, j) == "#" || ghost4status.contain(i - 1, j) == "4") && (ghost4status.contain(i, j + 1) == "#" || ghost4status.contain(i, j + 1) == "4")))
                return false;
            else if ((i > 0 && i < 120) && (j == 40) && ((ghost4status.contain(i + 1, j) == "#" || ghost4status.contain(i + 1, j) == "4") && (ghost4status.contain(i - 1, j) == "#" || ghost4status.contain(i - 1, j) == "4") && (ghost4status.contain(i, j - 1) == "#" || ghost4status.contain(i, j - 1) == "4")))
                return false;
            else if ((j > 0 && j < 40) && (i == 0) && ((ghost4status.contain(i + 1, j) == "#" || ghost4status.contain(i + 1, j) == "4") && (ghost4status.contain(i, j + 1) == "#" || ghost4status.contain(i, j + 1) == "4") && (ghost4status.contain(i, j - 1) == "#" || ghost4status.contain(i, j - 1) == "4")))
                return false;
            else if ((j > 0 && j < 40) && (i == 120) && ((ghost4status.contain(i - 1, j) == "#" || ghost4status.contain(i - 1, j) == "4") && (ghost4status.contain(i, j + 1) == "#" || ghost4status.contain(i, j + 1) == "4") && (ghost4status.contain(i, j - 1) == "#" || ghost4status.contain(i, j - 1) == "4")))
                return false;
            else if ((i == 0 && j == 0) || (i == 0 && j == 40) || (i == 120 && j == 0) || (i == 120 && j == 40))
                return false;

            return true;
        }
        private bool isavailable(int i, int j)
        {
            if ((i >= 0 && i <= 120) && (j >= 0 && j <= 40) && (ghost4status.safe(i, j, " ")) && (ghost4status.safe(i, j, ".")) && (ghost4status.safe(i, j, "1")) && (ghost4status.safe(i, j, "2")) && (ghost4status.safe(i, j, "3")))
                return true;
            return false;
        }
        public bool iswin(int i, int j)
        {
            if (!(ghost4status.safe(i, j, "!")))
                return true;
            else
                return false;
        }
        public void ghost4move()
        {
            if (ud)
            {
                if (u)
                {
                    if (isavailable(x, y - 1))
                        if (iswin(x, y - 1))
                            ghost4status.misionfailed();
                        else
                            upH();
                    //else
                    //{
                    //    u = false;
                    //    d = true;
                    //}
                }

                else if (d)
                {
                    if (isavailable(x, y + 1))
                        if (iswin(x, y + 1))
                            ghost4status.misionfailed();
                        else
                            downH();
                    //else
                    //{
                    //    d = false;
                    //    u = true;
                    //}
                }
            }
            else if (rl)
            {
                if (r)
                {
                    if (isavailable(x + 1, y))
                        if (iswin(x + 1, y))
                            ghost4status.misionfailed();
                        else
                            rightH();
                    //else
                    //{
                    //    r = false;
                    //    l = true;
                    //}
                }
                else if (l)
                {
                    if (isavailable(x - 1, y))
                        if (iswin(x - 1, y))
                            ghost4status.misionfailed();
                        else
                            leftH();
                    //else
                    //{
                    //    l = false;
                    //    r = true;
                    //}
                }
            }
            if (isedge(x, y))
            {
                if (ud)
                {
                    ud = false;
                    rl = true;
                    //checky(x, y);
                    checkx(x, y);
                    if (d)
                    {
                        if (!startavailable(x + 1, y))
                        {
                            r = false; l = true;
                        }
                    }
                    else if (l)
                    {
                        if (!startavailable(x - 1, y))
                        {
                            l = false; r = true;
                        }
                    }
                }
                else
                {
                    rl = false;
                    ud = true;
                    checky(x, y);
                    if (u)
                    {
                        if (!startavailable(x, y - 1))
                        {
                            u = false; d = true;
                        }
                    }
                    else if (d)
                    {
                        if (!startavailable(x, y + 1))
                        {
                            d = false; u = true;
                        }
                    }
                    //checkx(x, y);
                }
            }
        }
        private bool isedge(int i, int j)
        {
            if ((i > 0 && i < 120) && (j > 0 && j < 40) && (ghost4status.contain(i + 1, j) == " " || ghost4status.contain(i - 1, j) == " ") && (ghost4status.contain(i, j + 1) == " " || ghost4status.contain(i, j - 1) == " "))
                return true;
            else if ((i > 0 && i < 120) && (j > 0 && j < 40) && (ghost4status.contain(i + 1, j) == "#" && ghost4status.contain(i - 1, j) == "#" && ghost4status.contain(i, j + 1) == "#" && ghost4status.contain(i, j - 1) == "#"))
                return true;
            else if ((i > 0 && i < 120) && (j == 0) && (ghost4status.contain(i + 1, j) == "#" && ghost4status.contain(i - 1, j) == "#" && ghost4status.contain(i, j + 1) == "#"))
                return true;
            else if ((i > 0 && i < 120) && (j == 40) && (ghost4status.contain(i + 1, j) == "#" && ghost4status.contain(i - 1, j) == "#" && ghost4status.contain(i, j - 1) == "#"))
                return true;
            else if ((j > 0 && j < 40) && (i == 0) && (ghost4status.contain(i, j + 1) == "#" && ghost4status.contain(i, j - 1) == "#" && ghost4status.contain(i + 1, j) == "#"))
                return true;
            else if ((j > 0 && j < 40) && (i == 120) && (ghost4status.contain(i, j + 1) == "#" && ghost4status.contain(i, j - 1) == "#" && ghost4status.contain(i - 1, j) == "#"))
                return true;
            else if ((i == 0 && j == 0) || (i == 0 && j == 40) || (i == 120 && j == 0) || (i == 120 && j == 40))
                return true;
            return false;
        }
        private void checkx(int i, int j)
        {
            //cx = movement.Next(2);
            //if (cx == 2)
            //{
            //    u = false; d = false;
            //}
            //if ((i > 0 && i < 120) && (ghost4status.contain(i + 1, j) == "#") && (ghost4status.contain(i + 1, j) == "#") && (l || r))
            //{
            //    if (l)
            //        r = false;
            //    else if (r)
            //        l = false;

            //}
            if ((i > 0 && i < 120) && (ghost4status.contain(i + 1, j) == "#"))
            {
                r = true; l = false;
            }
            else if ((i > 0 && i < 120) && (ghost4status.contain(i - 1, j) == "#"))
            {
                l = true; r = false;
            }
            else if (i == 0)
            {
                r = true; l = false;
            }
            else if (i == 120)
            {
                l = true; r = false;
            }
        }
        private void checky(int i, int j)
        {
            //cy = movement.Next(2);
            //if (cy % 2 == 0)
            //{
            //    r = false; l = false;
            //}
            //if ((j > 0 && j < 40) && (ghost4status.contain(i, j + 1) == "#") && (ghost4status.contain(i, j - 1) == "#") && (u || d))
            //{
            //    if (u)
            //        d = false;
            //    else if (d)
            //        u = false;
            //}
            if ((j > 0 && j < 40) && (ghost4status.contain(i, j + 1) == "#"))
            {
                d = true; u = false;
            }
            else if ((j > 0 && j < 40) && (ghost4status.contain(i, j - 1) == "#"))
            {
                u = true; d = false;
            }
            else if (j == 0)
            {
                d = true; u = false;
            }
            else if (j == 40)
            {
                u = true; d = false;
            }
        }
        private void upH()
        {
            ghost4status.position(x, y--, "#");
            ghost4status.save(x, y, "4");//
            Console.CursorLeft -= 1;
            Console.CursorTop -= 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("4");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void downH()
        {
            ghost4status.position(x, y++, "#");
            ghost4status.save(x, y, "4");//
            Console.CursorLeft -= 1;
            Console.CursorTop += 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("4");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void rightH()
        {
            ghost4status.position(x++, y, "#");
            ghost4status.save(x, y, "4");//
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("4");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
        }
        private void leftH()
        {
            ghost4status.position(x--, y, "#");
            ghost4status.save(x, y, "4");//
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("4");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
    }
}
