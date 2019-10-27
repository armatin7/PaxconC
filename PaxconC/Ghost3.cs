using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PaxconC
{
    class Ghost3
    {
        private Status ghost3status;
        public int x, y;
        private bool u = false, d = false, r = false, l = false;
        private Random movement = new Random();
        public Ghost3(Status ghost3status)
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
            this.ghost3status = ghost3status;
            x = movement.Next(2, 118); y = movement.Next(2, 38);
            Thread.Sleep(30);
            seat();
        }
        public void ghost3move()
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
        public void seat()
        {
            ghost3status.save(x, y, " ");
            do
            {
                x = movement.Next(2, 118); y = movement.Next(2, 38);
            } while (ghost3status.safe(x, y, " "));
            ghost3status.save(x, y, "3");
        }
        private bool iswin(int i, int j)
        {
            if (!(ghost3status.safe(i, j, ".")) || !(ghost3status.safe(i, j, "!")))
                return true;
            else
                return false;
        }
        private bool isavailable(int i, int j)
        {
            if ((i > 0 && i < 120) && (j > 0 && j < 40) && ((ghost3status.safe(i, j, "#")) && (ghost3status.safe(i, j, "1")) && (ghost3status.safe(i, j, "3")) && (ghost3status.safe(i, j, "?"))))
                return true;
            else
                return false;
        }
        private void upBF()
        {
            ghost3status.position(x, y--, " ");
            Console.CursorLeft -= 1;
            Console.CursorTop -= 1;
            Console.ForegroundColor = ConsoleColor.Red;
            ghost3status.save(x, y, "3");
            Console.Write("3");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void downBF()
        {
            ghost3status.position(x, y++, " ");
            Console.CursorLeft -= 1;
            Console.CursorTop += 1;
            Console.ForegroundColor = ConsoleColor.Red;
            ghost3status.save(x, y, "3");
            Console.Write("3");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void rightBF()
        {
            ghost3status.position(x++, y, " ");
            Console.ForegroundColor = ConsoleColor.Red;
            ghost3status.save(x, y, "3");
            Console.Write("3");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
        }
        private void leftBF()
        {
            ghost3status.position(x--, y, " ");
            Console.CursorLeft -= 2;
            Console.ForegroundColor = ConsoleColor.Red;
            ghost3status.save(x, y, "3");
            Console.Write("3");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void destroy(int i, int j)
        {
            ghost3status.save(i, j, " ");
            Console.SetCursorPosition(i, j);
            Console.Write(" ");
            if (d)
                Console.CursorLeft -= 1;
        }
        private void moveup()
        {
            if (isavailable(x, y - 1))
            {
                if (iswin(x, y - 1))
                {
                    ghost3status.misionfailed();
                }
                else
                    upBF();
            }
            else
            {
                if (y != 1 && ghost3status.safe(x, y - 1, "?"))
                {
                    destroy(x, y - 1);
                }
                u = false; d = true;
                r = false; l = false;
                if (movement.Next(2) == 1)
                    r = true;
                else if (movement.Next(2) == 2)
                    l = true;
            }
        }
        private void movedown()
        {
            if (isavailable(x, y + 1))
            {
                if (iswin(x, y + 1))
                {
                    ghost3status.misionfailed();
                }
                else
                    downBF();
            }
            else
            {
                if (y != 39 && ghost3status.safe(x, y + 1, "?"))
                {
                    destroy(x, y + 1);
                }
                u = true; d = false;
                r = false; l = false;
                if (movement.Next(2) == 1)
                    r = true;
                else if (movement.Next(2) == 2)
                    l = true;
            }
        }
        private void moveright()
        {
            if (isavailable(x + 1, y))
            {
                if (iswin(x + 1, y))
                {
                    ghost3status.misionfailed();
                }
                else
                    rightBF();
            }
            else
            {
                if (x != 119 && ghost3status.safe(x + 1, y, "?"))
                {
                    destroy(x + 1, y);
                }
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
            if (isavailable(x - 1, y))
            {
                if (iswin(x - 1, y))
                {
                    ghost3status.misionfailed();
                }
                else
                    leftBF();
            }
            else
            {
                if (x != 1 && ghost3status.safe(x - 1, y, "?"))
                {
                    destroy(x - 1, y);
                }
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
