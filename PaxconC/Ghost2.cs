using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PaxconC
{
    class Ghost2
    {
        private Status ghost2status;
        private Random movement = new Random();
        public int x, y;
        private bool u = false, d = false, r = false, l = false;
        public Ghost2(Status ghost2status)
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
            this.ghost2status = ghost2status;
            x = movement.Next(2, 118); y = movement.Next(2, 38);
            Thread.Sleep(30);
            seat();
        }
        public void ghost2move()
        {
            if (((x > 0 && x < 120) && (y > 0 && y < 40)) && (ghost2status.contain(x + 1, y) == "#" || ghost2status.contain(x - 1, y) == "#" || ghost2status.contain(x, y + 1) == "#" || ghost2status.contain(x, y - 1) == "#"))
                ghost2status.save(x, y, "2");
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
            if (ghost2status.contain(x, y) == "2" || ghost2status.contain(x, y) == "#")
            {
                if ((i > 0 && i < 120) && (j > 0 && j < 40) && (ghost2status.safe(i, j, " ")) && (ghost2status.safe(i, j, ".")) && (ghost2status.safe(i, j, "1")) && (ghost2status.safe(i, j, "2")) && (ghost2status.safe(i, j, "3")))
                    return true;
            }
            return false;
        }
        public bool iswin(int i, int j)
        {
            if (!(ghost2status.safe(i, j, "!")))
                return true;
            else
                return false;
        }
        public void seat()
        {
            if (ghost2status.contain(x, y) == "?" || ghost2status.contain(x, y) == " ")
                ghost2status.save(x, y, " ");
            else
                ghost2status.save(x, y, "#");
            x = movement.Next(2, 118); y = movement.Next(2, 38);
            ghost2status.save(x, y, "?");
        }
        private void upH()
        {
            ghost2status.position(x, y--, "#");
            ghost2status.save(x, y, "2");//
            Console.CursorLeft -= 1;
            Console.CursorTop -= 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("2");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void downH()
        {
            ghost2status.position(x, y++, "#");
            ghost2status.save(x, y, "2");//
            Console.CursorLeft -= 1;
            Console.CursorTop += 1;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("2");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void rightH()
        {
            ghost2status.position(x++, y, "#");
            ghost2status.save(x, y, "2");//
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("2");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
        }
        private void leftH()
        {
            ghost2status.position(x--, y, "#");
            ghost2status.save(x, y, "2");//
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("2");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void moveup()
        {
            if (isavailable(x, y - 1))
            {
                if (iswin(x, y - 1))
                {
                    ghost2status.misionfailed();
                }
                else
                    upH();
            }
            else
            {
                u = false; d = true;
                if (isavailable(x, y + 1))
                {
                    r = false; l = false;
                    if (movement.Next(2) == 1)
                        r = true;
                    else if (movement.Next(2) == 2)
                        l = true;
                    //Console.CursorLeft -= 1;
                }
            }
        }
        private void movedown()
        {
            if (isavailable(x, y + 1))
            {
                if (iswin(x, y + 1))
                {
                    ghost2status.misionfailed();
                }
                else
                    downH();
            }
            else
            {
                u = true; d = false;
                if (isavailable(x, y - 1))
                {
                    r = false; l = false;
                    if (movement.Next(2) == 1)
                        r = true;
                    else if (movement.Next(2) == 2)
                        l = true;
                    //Console.CursorLeft -= 1;
                }
            }
        }
        private void moveright()
        {
            if (isavailable(x + 1, y))
            {
                if (iswin(x + 1, y))
                {
                    ghost2status.misionfailed();
                }
                else
                    rightH();
            }
            else
            {
                r = false; l = true;
                if (isavailable(x - 1, y))
                {
                    u = false; d = false;
                    if (movement.Next(2) == 1)
                        u = true;
                    else if (movement.Next(2) == 2)
                        d = true;
                }
            }
        }
        private void moveleft()
        {
            if (isavailable(x - 1, y))
            {
                if (iswin(x - 1, y))
                {
                    ghost2status.misionfailed();
                }
                else
                    leftH();
            }
            else
            {
                r = true; l = false;
                if (isavailable(x + 1, y))
                {
                    u = false; d = false;
                    if (movement.Next(2) == 1)
                        u = true;
                    else if (movement.Next(2) == 2)
                        d = true;
                }
            }
        }
    }
}
