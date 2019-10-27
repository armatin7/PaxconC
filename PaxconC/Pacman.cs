using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PaxconC
{
    class Pacman
    {
        private Status pacstatus;
        private ConsoleKeyInfo packey;
        public int x, y;
        private int[] footprint = new int[2];
        public int[] home = new int[2];
        private bool key = false, movepermision;
        public Pacman(Status pacstatus)
        {
            this.pacstatus = pacstatus;
            x = 0; y = 0;
            pacstatus.save(x, y, "!");
            footprint[0] = 121; footprint[1] = 41;
            home[0] = 0; home[1] = 0;
        }
        public void pacmove()
        {
            movepermision = true;
            if (!key)
            {
                if (Console.KeyAvailable != key)
                {
                    Thread.Sleep(30);
                    packey = Console.ReadKey();
                }
                else
                {
                    Thread.Sleep(30);
                    movepermision = false;
                }
            }
            else if (Console.KeyAvailable == key)
            {
                packey = Console.ReadKey();
                Thread.Sleep(30);
            }
            else
                Thread.Sleep(30);
            if (movepermision)
            {
                move(packey);
            }
        }
        private void move(ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    {
                        moveup();
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        movedown();
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        moveright();
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        moveleft();
                        break;
                    }
                case ConsoleKey.D:
                    {
                        pacstatus.display();
                        break;
                    }
                case ConsoleKey.L:
                    {
                        pacstatus.location(x, y);
                        break;
                    }
                case ConsoleKey.C:
                    {
                        pacstatus.fieldcontain();
                        break;
                    }
                default:
                    {
                        Console.CursorLeft -= 1;
                        Console.Write(" ");
                        break;
                    }
            }
        }
        public bool ishome(int i, int j)
        {
            if (!(pacstatus.safe(i, j, "#")))
            {
                key = false;
                return true;
            }
            else
            {
                key = true;
                return false;
            }
        }
        public bool islose(int i, int j)
        {
            if (!(pacstatus.safe(i, j, ".")) || !(pacstatus.safe(i, j, "1")) || !(pacstatus.safe(i, j, "2")) || !(pacstatus.safe(i, j, "3")) || !(pacstatus.safe(i, j, "4")))
                return true;
            else
                return false;
        }
        private bool isavailable(int i, int j)
        {
            if ((!(i < 0 || i > 120) && !(j < 0 || j > 40)) && ((footprint[0] != i) || (footprint[1] != j)))
                return true;
            else
                return false;
        }
        public void seat()
        {
            if (x == home[0] && y == home[1])
                pacstatus.position(x, y, "#");
            else
                pacstatus.safe(x, y," ");
            x = 0; y = 0;
            Console.ForegroundColor = ConsoleColor.Yellow;
            pacstatus.position(x, y,"!");
            Console.ForegroundColor = ConsoleColor.White;
            footprint[0] = 121; footprint[1] = 41;
            home[0] = 0; home[1] = 0;
            key = false;
        }
        private void upBF()
        {
            pacstatus.position(x, y--, ".");
            Console.CursorLeft -= 1;
            Console.CursorTop -= 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            pacstatus.save(x, y, "!");
            Console.Write("!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void upH()
        {
            pacstatus.position(x, y--, "#");
            pacstatus.save(x, y, "!");//
            home[0] = x; home[1] = y;
            Console.CursorLeft -= 1;
            Console.CursorTop -= 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void downBF()
        {
            pacstatus.position(x, y++, ".");
            Console.CursorLeft -= 1;
            Console.CursorTop += 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            pacstatus.save(x, y, "!");
            Console.Write("!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void downH()
        {
            pacstatus.position(x, y++, "#");
            pacstatus.save(x, y, "!");//
            home[0] = x; home[1] = y;
            Console.CursorLeft -= 1;
            Console.CursorTop += 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void rightBF()
        {
            pacstatus.position(x++, y, ".");
            Console.ForegroundColor = ConsoleColor.Yellow;
            pacstatus.save(x, y, "!");
            Console.Write("!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
        }
        private void rightH()
        {
            pacstatus.position(x++, y, "#");
            pacstatus.save(x, y, "!");//
            home[0] = x; home[1] = y;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(x, y);
        }
        private void leftBF()
        {
            pacstatus.position(x--, y, ".");
            Console.CursorLeft -= 2;
            Console.ForegroundColor = ConsoleColor.Yellow;
            pacstatus.save(x, y, "!");
            Console.Write("!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void leftH()
        {
            pacstatus.position(x--, y, "#");
            pacstatus.save(x, y, "!");//
            home[0] = x; home[1] = y;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft -= 1;
        }
        private void moveup()
        {
            if (isavailable(x, y - 1))
            {
                if ((home[0] == x && home[1] == y) && ishome(x, y - 1))
                {
                    upH();
                }
                else
                {
                    pacstatus.position(home[0], home[1], "#");
                    footprint[0] = x; footprint[1] = y;
                    if (ishome(x, y - 1))
                    {
                        upBF();
                        pacstatus.save(x, y, "#");
                        pacstatus.misionaccomplished();
                        footprint[0] = 122; footprint[1] = 42;
                        home[0] = x; home[1] = y;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        pacstatus.position(x, y, "!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (islose(x, y - 1))
                    {
                        pacstatus.misionfailed();
                    }
                    else
                        upBF();
                    //pacstatus.position(home[0], home[1], "#");
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                    //pacstatus.position(x, y, "!");
                    //Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.CursorLeft -= 1;
            }
        }
        private void movedown()
        {
            if (isavailable(x, y + 1))
            {
                if ((home[0] == x && home[1] == y) && ishome(x, y + 1))
                {
                    downH();
                }
                else
                {
                    pacstatus.position(home[0], home[1], "#");
                    footprint[0] = x; footprint[1] = y;
                    if (ishome(x, y + 1))
                    {
                        downBF();
                        pacstatus.save(x, y, "#");
                        pacstatus.misionaccomplished();
                        footprint[0] = 122; footprint[1] = 42;
                        home[0] = x; home[1] = y;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        pacstatus.position(x, y, "!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (islose(x, y + 1))
                    {
                        pacstatus.misionfailed();
                    }
                    else
                        downBF();
                    //pacstatus.position(home[0], home[1], "#");
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                    //pacstatus.position(x, y, "!");
                    //Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.CursorLeft -= 1;
            }
        }
        private void moveright()
        {
            if (isavailable(x + 1, y))
            {
                if ((home[0] == x && home[1] == y) && ishome(x + 1, y))
                {
                    rightH();
                }
                else
                {
                    pacstatus.position(home[0], home[1], "#");
                    footprint[0] = x; footprint[1] = y;
                    if (ishome(x + 1, y))
                    {
                        rightBF();
                        pacstatus.save(x, y, "#");
                        pacstatus.misionaccomplished();
                        footprint[0] = 122; footprint[1] = 42;
                        home[0] = x; home[1] = y;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        pacstatus.position(x, y, "!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (islose(x + 1, y))
                    {
                        pacstatus.misionfailed();
                    }
                    else
                        rightBF();
                    //pacstatus.position(home[0], home[1], "#");
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                    //pacstatus.position(x, y, "!");
                    //Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.CursorLeft -= 1;
            }
        }
        private void moveleft()
        {
            if (isavailable(x - 1, y))
            {
                if ((home[0] == x && home[1] == y) && ishome(x - 1, y))
                {
                    leftH();
                }
                else
                {
                    pacstatus.position(home[0], home[1], "#");
                    footprint[0] = x; footprint[1] = y;
                    if (ishome(x - 1, y))
                    {
                        leftBF();
                        pacstatus.save(x, y, "#");
                        pacstatus.misionaccomplished();
                        footprint[0] = 122; footprint[1] = 42;
                        home[0] = x; home[1] = y;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        pacstatus.position(x, y, "!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (islose(x - 1, y))
                    {
                        pacstatus.misionfailed();
                    }
                    else
                        leftBF();
                    //pacstatus.position(home[0], home[1], "#");
                    //Console.ForegroundColor = ConsoleColor.Yellow;
                    //pacstatus.position(x, y, "!");
                    //Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.CursorLeft -= 1;
            }
        }
    }
}
