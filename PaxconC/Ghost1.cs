using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PaxconC
{
    class Ghost1
    {
        private Status ghost1status;
        public int x, y;
        private bool u = false, d = false, r = false, l = false;
        private Random movement = new Random();
        public Ghost1(Status ghost1status)
        {
            while (!(u || d || r || l))
            {
                if (movement.Next(3) == 1)
                    u = true;
                else if (movement.Next(3) == 2)
                    d = true;
                if (movement.Next(3) == 1)
                    r = true;
                else if (movement.Next(3) == 2)
                    l = true;
            }
            this.ghost1status = ghost1status;
            x = movement.Next(2, 118); y = movement.Next(2, 38);
            Thread.Sleep(30);
            seat();
        }
        public void ghost1move()
        {
            if (u)
            {
                moveup();
            }
            if (d)
            {
                movedown();
            }
            if (r)
            {
                moveright();
            }
            if (l)
            {
                moveleft();
            }
        }
        private bool isavailable(int i, int j)
        {
            if ((i > 0 && i < 120) && (j > 0 && j < 40) && ((ghost1status.safe(i, j, "#")) && (ghost1status.safe(i, j, "1")) && (ghost1status.safe(i, j, "3"))))// && (ghost1status.safe(i, j, "?"))))
                return true;
            else
                return false;
        }
        private bool iswin(int i, int j)
        {
            if (!(ghost1status.safe(i, j, ".")) || !(ghost1status.safe(i, j, "!")))
                return true;
            else
                return false;
        }
        public void seat()
        {
            ghost1status.save(x, y, " ");
            do
            {
                x = movement.Next(2, 118); y = movement.Next(2, 38);
            } while (ghost1status.safe(x, y, " "));
            ghost1status.save(x, y, "1");
        }
        private bool edge(int i, int j)
        {
            int c = 0;
            if (ghost1status.contain(i + 1, j) == "#")
                c++;
            if (ghost1status.contain(i - 1, j) == "#")
                c++;
            if (ghost1status.contain(i, j + 1) == "#")
                c++;
            if (ghost1status.contain(i, j - 1) == "#")
                c++;
            if (c >= 2)
                return true;
            return false;
        }
        private void upBF()
        {
            ghost1status.position(x, y--, " ");
            Console.CursorLeft -= 1;
            Console.CursorTop -= 1;
            Console.ForegroundColor = ConsoleColor.Red;
            ghost1status.save(x, y, "1");
            Console.Write("1");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void downBF()
        {
            ghost1status.position(x, y++, " ");
            Console.CursorLeft -= 1;
            Console.CursorTop += 1;
            Console.ForegroundColor = ConsoleColor.Red;
            ghost1status.save(x, y, "1");
            Console.Write("1");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void rightBF()
        {
            ghost1status.position(x++, y, " ");
            Console.ForegroundColor = ConsoleColor.Red;
            ghost1status.save(x, y, "1");
            Console.Write("1");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
        }
        private void leftBF()
        {
            ghost1status.position(x--, y, " ");
            Console.CursorLeft -= 2;
            Console.ForegroundColor = ConsoleColor.Red;
            ghost1status.save(x, y, "1");
            Console.Write("1");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void moveup()
        {
            if (isavailable(x, y - 1) && !edge(x, y - 1))
            {
                if (iswin(x, y - 1))
                {

                    ghost1status.misionfailed();
                }
                else
                    upBF();
            }
            else
            {
                u = false; d = true;
                r = false; l = false;
                if (movement.Next(2) == 1)
                    r = true;
                else if (movement.Next(2) == 2)
                    l = true;
                //Console.CursorLeft -= 1;
            }
        }
        private void movedown()
        {
            if (isavailable(x, y + 1) && !edge(x, y + 1))
            {
                if (iswin(x, y + 1))
                {

                    ghost1status.misionfailed();
                }
                else
                    downBF();
            }
            else
            {
                u = true; d = false;
                r = false; l = false;
                if (movement.Next(2) == 1)
                    r = true;
                else if (movement.Next(2) == 2)
                    l = true;
                //Console.CursorLeft -= 1;
            }
        }
        private void moveright()
        {
            if (isavailable(x + 1, y) && !edge(x + 1, y))
            {
                if (iswin(x + 1, y))
                {
                    ghost1status.misionfailed();
                }
                else
                    rightBF();
            }
            else
            {
                r = false; l = true;
                u = false; d = false;
                if (movement.Next(2) == 1)
                    u = true;
                else if (movement.Next(2) == 2)
                    d = true;
            }
        }
        private void moveleft()
        {
            if (isavailable(x - 1, y) && !edge(x - 1, y))
            {
                if (iswin(x - 1, y))
                {
                    ghost1status.misionfailed();
                }
                else
                    leftBF();
            }
            else
            {
                r = true; l = false;
                u = false; d = false;
                if (movement.Next(2) == 1)
                    u = true;
                else if (movement.Next(2) == 2)
                    d = true;
            }
        }
    }
}
