using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PaxconC
{
    class Menue
    {
        private ConsoleKeyInfo loadkey, optionkey, customkey;
        private bool start, option;
        public int gc1 = 3, gc2 = 0, gc3 = 0, gc4 = 0;
        public Menue()
        {
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 140; i++)
            {
                for (int j = 0; j < 70; j++)
                    Console.Write(" ");
            }
            Console.SetCursorPosition(1, 1);
        }
        private void startinterface()
        {
            Console.Clear();
            Console.SetCursorPosition(68, 20);
            Console.Write("--->");//, Console.ForegroundColor = ConsoleColor.);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(75, 20);
            Console.Write("1.Start New Game");//, Console.BackgroundColor = ConsoleColor.Blue);
            Console.SetCursorPosition(75, 22);
            Console.Write("2.Option");//, Console.BackgroundColor = ConsoleColor.Red);
            Console.SetCursorPosition(75, 24);
            Console.Write("3.Help");
            Console.SetCursorPosition(75, 26);
            Console.Write("4.Exit");
            start = false;
        }
        private void optioninterface()
        {
            Console.Clear();
            Console.SetCursorPosition(68, 22);
            Console.Write("--->");//, Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(75, 20);
            Console.Write("1.Start New Game");
            Console.SetCursorPosition(75, 22);
            Console.Write("2.Option");//, Console.BackgroundColor = ConsoleColor.Blue);
            Console.SetCursorPosition(75, 24);
            Console.Write("3.Help");//, Console.BackgroundColor = ConsoleColor.Red);
            Console.SetCursorPosition(75, 26);
            Console.Write("4.Exit");
        }
        private void helpinterface()
        {
            Console.Clear();
            Console.SetCursorPosition(68, 24);
            Console.Write("--->");//, Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(75, 20);
            Console.Write("1.Start New Game");
            Console.SetCursorPosition(75, 22);
            Console.Write("2.Option");
            Console.SetCursorPosition(75, 24);
            Console.Write("3.Help");//, Console.BackgroundColor = ConsoleColor.Blue);
            //Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(75, 26);
            Console.Write("4.Exit");
        }
        private void exit()
        {
            Console.Clear();
            Console.SetCursorPosition(68, 26);
            Console.Write("--->");//, Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(75, 20);
            Console.Write("1.Start New Game");
            Console.SetCursorPosition(75, 22);
            Console.Write("2.Option");
            Console.SetCursorPosition(75, 24);
            Console.Write("3.Help");
            Console.SetCursorPosition(75, 26);
            Console.Write("4.Exit");//, Console.BackgroundColor = ConsoleColor.Blue);
            //Console.BackgroundColor = ConsoleColor.Red;
        }
        private void levelone()
        {
            Console.Clear();
            Console.SetCursorPosition(68, 20);
            Console.Write("--->");//, Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(75, 20);
            Console.Write("1.ghost1 : 3");//, Console.BackgroundColor = ConsoleColor.Blue);
            Console.SetCursorPosition(75, 22);
            Console.Write("2.ghost1 : 3\tghost2 : 1");//, Console.BackgroundColor = ConsoleColor.Red);
            Console.SetCursorPosition(75, 24);
            Console.Write("3.ghost1 : 2\tghost2 : 1\tghost3 : 1");
            Console.SetCursorPosition(75, 26);
            Console.Write("4.custom");
            gc1 = 3; gc2 = 0; gc3 = 0;
        }
        private void leveltwo()
        {
            Console.Clear();
            Console.SetCursorPosition(68, 22);
            Console.Write("--->");//, Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(75, 20);
            Console.Write("1.ghost1 : 3");
            Console.SetCursorPosition(75, 22);
            Console.Write("2.ghost1 : 3\tghost2 : 1");//, Console.BackgroundColor = ConsoleColor.Blue);
            Console.SetCursorPosition(75, 24);
            Console.Write("3.ghost1 : 2\tghost2 : 1\tghost3 : 1");//, Console.BackgroundColor = ConsoleColor.Red);
            Console.SetCursorPosition(75, 26);
            Console.Write("4.custom");
            gc1 = 3; gc2 = 1; gc3 = 0;
        }
        private void levelthree()
        {
            Console.Clear();
            Console.SetCursorPosition(68, 24);
            Console.Write("--->");//, Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(75, 20);
            Console.Write("1.ghost1 : 3");
            Console.SetCursorPosition(75, 22);
            Console.Write("2.ghost1 : 3\tghost2 : 1");
            Console.SetCursorPosition(75, 24);
            Console.Write("3.ghost1 : 2\tghost2 : 1\tghost3 : 1");//, Console.BackgroundColor = ConsoleColor.Blue);
            //Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(75, 26);
            Console.Write("4.custom");
            gc1 = 2; gc2 = 1; gc3 = 1;
        }
        private void custom()
        {
            Console.Clear();
            Console.SetCursorPosition(68, 26);
            Console.Write("--->");//, Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(75, 20);
            Console.Write("1.ghost1 : 3");
            Console.SetCursorPosition(75, 22);
            Console.Write("2.ghost1 : 3\tghost2 : 1");
            Console.SetCursorPosition(75, 24);
            Console.Write("3.ghost1 : 2\tghost2 : 1\tghost3 : 1");
            Console.SetCursorPosition(75, 26);
            Console.Write("4.custom");//, Console.BackgroundColor = ConsoleColor.Blue);
            //Console.BackgroundColor = ConsoleColor.Red;
        }
        private void ghost1()
        {
            Console.Clear();
            Console.SetCursorPosition(68, 20);
            Console.Write("--->");//, Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(75, 20);
            Console.Write("1.ghost1 : {0}", gc1);//, Console.BackgroundColor = ConsoleColor.Blue);
            Console.SetCursorPosition(75, 22);
            Console.Write("2.ghost2 : {0}", gc2);//, Console.BackgroundColor = ConsoleColor.Red);
            Console.SetCursorPosition(75, 24);
            Console.Write("3.ghost3 : {0}", gc3);
            Console.SetCursorPosition(75, 26);
            Console.Write("4.ghost 4 : {0}", gc4);
        }
        private void ghost2()
        {
            Console.Clear();
            Console.SetCursorPosition(68, 22);
            Console.Write("--->");//, Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(75, 20);
            Console.Write("1.ghost1 : {0}", gc1);
            Console.SetCursorPosition(75, 22);
            Console.Write("2.ghost2 : {0}", gc2);//, Console.BackgroundColor = ConsoleColor.Blue);
            Console.SetCursorPosition(75, 24);
            Console.Write("3.ghost3 : {0}", gc3);//, Console.BackgroundColor = ConsoleColor.Red);
            Console.SetCursorPosition(75, 26);
            Console.Write("4.ghost 4 : {0}", gc4);
        }
        private void ghost3()
        {
            Console.Clear();
            Console.SetCursorPosition(68, 24);
            Console.Write("--->");//, Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(75, 20);
            Console.Write("1.ghost1 : {0}", gc1);
            Console.SetCursorPosition(75, 22);
            Console.Write("2.ghost2 : {0}", gc2);
            Console.SetCursorPosition(75, 24);
            Console.Write("3.ghost3 : {0}", gc3);//, Console.BackgroundColor = ConsoleColor.Blue);
            //Console.BackgroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(75, 26);
            Console.Write("4.ghost 4 : {0}", gc4);
        }
        private void ghost4()
        {
            Console.Clear();
            Console.SetCursorPosition(68, 26);
            Console.Write("--->");//, Console.ForegroundColor = ConsoleColor.Yellow);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(75, 20);
            Console.Write("1.ghost1 : {0}", gc1);
            Console.SetCursorPosition(75, 22);
            Console.Write("2.ghost2 : {0}", gc2);
            Console.SetCursorPosition(75, 24);
            Console.Write("3.ghost3 : {0}", gc3);
            Console.SetCursorPosition(75, 26);
            Console.Write("4.ghost 4 : {0}", gc4);//, Console.BackgroundColor = ConsoleColor.Blue);
            //Console.BackgroundColor = ConsoleColor.Red;
        }
        public void loadmenue()
        {
            welcome();
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            do
            {
                startinterface();
                loadkey = Console.ReadKey();
                while (loadkey.Key == ConsoleKey.UpArrow)
                {
                    startinterface();
                    loadkey = Console.ReadKey();
                    if (loadkey.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
                while (loadkey.Key == ConsoleKey.DownArrow)
                {
                    optioninterface();
                    loadkey = Console.ReadKey();
                    if (loadkey.Key == ConsoleKey.Enter)
                    {
                        Console.Beep();
                        loadoption();
                        start = true;
                    }
                    while (loadkey.Key == ConsoleKey.DownArrow)
                    {
                        helpinterface();
                        loadkey = Console.ReadKey();
                        while (loadkey.Key == ConsoleKey.Enter)
                        {
                            Console.Beep();
                            loadkey = Console.ReadKey();
                        }
                        while (loadkey.Key == ConsoleKey.DownArrow)
                        {
                            exit();
                            loadkey = Console.ReadKey();
                            if (loadkey.Key == ConsoleKey.Enter)
                                Environment.Exit(0);
                        }
                        while (loadkey.Key == ConsoleKey.UpArrow)
                        {
                            helpinterface();
                            loadkey = Console.ReadKey();
                            break;
                        }
                    }
                }
                while (loadkey.Key == ConsoleKey.UpArrow)
                {
                    optioninterface();
                    loadkey = Console.ReadKey();
                    if (loadkey.Key == ConsoleKey.Enter)
                    {
                        Console.Beep();
                        loadoption();
                        start = true;
                    }
                    break;
                }
                while (loadkey.Key == ConsoleKey.UpArrow)
                {
                    startinterface();
                    loadkey = Console.ReadKey();
                    if (loadkey.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (loadkey.Key != ConsoleKey.Enter || start);
            Console.Beep();
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            ;
        }
        private void loadoption()
        {
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            do
            {
                levelone();
                optionkey = Console.ReadKey();
                while (optionkey.Key == ConsoleKey.UpArrow)
                {
                    levelone();
                    optionkey = Console.ReadKey();
                }
                while (optionkey.Key == ConsoleKey.DownArrow)
                {
                    leveltwo();
                    optionkey = Console.ReadKey();
                    while (optionkey.Key == ConsoleKey.DownArrow)
                    {
                        levelthree();
                        optionkey = Console.ReadKey();
                        while (optionkey.Key == ConsoleKey.DownArrow)
                        {
                            custom();
                            optionkey = Console.ReadKey();
                            while (optionkey.Key == ConsoleKey.Enter)
                            {
                                Console.Beep();
                                loadcustom();
                                if (option)
                                {
                                    levelone();
                                    custom();
                                    optionkey = Console.ReadKey();
                                }
                                break;
                            }
                            while (optionkey.Key == ConsoleKey.UpArrow)
                            {
                                levelthree();
                                optionkey = Console.ReadKey();
                                break;
                            }
                        }
                    }
                    while (optionkey.Key == ConsoleKey.UpArrow)
                    {
                        leveltwo();
                        optionkey = Console.ReadKey();
                        break;
                    }
                    while (optionkey.Key == ConsoleKey.UpArrow)
                    {
                        levelone();
                        optionkey = Console.ReadKey();
                    }
                }
            } while (optionkey.Key != ConsoleKey.Enter && optionkey.Key != ConsoleKey.Escape);
            Console.Beep();
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
        }
        private void loadcustom()
        {
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            do
            {
                ghost1();
                customkey = Console.ReadKey();
                while (customkey.Key == ConsoleKey.UpArrow || customkey.Key == ConsoleKey.RightArrow || customkey.Key == ConsoleKey.LeftArrow)
                {
                    if (customkey.Key == ConsoleKey.UpArrow)
                        ghost1();
                    else if (customkey.Key == ConsoleKey.RightArrow)
                    {
                        gc1++;
                        ghost1();
                    }
                    else if (customkey.Key == ConsoleKey.LeftArrow && gc1 > 0)
                    {
                        gc1--;
                        ghost1();
                    }
                    customkey = Console.ReadKey();
                }
                while (customkey.Key == ConsoleKey.DownArrow)
                {
                    ghost2();
                    customkey = Console.ReadKey();
                    while (customkey.Key == ConsoleKey.RightArrow || customkey.Key == ConsoleKey.LeftArrow)
                    {
                        if (customkey.Key == ConsoleKey.RightArrow)
                        {
                            gc2++;
                            ghost2();
                        }
                        else if (customkey.Key == ConsoleKey.LeftArrow)
                        {
                            gc2--;
                            ghost2();
                        }
                        customkey = Console.ReadKey();
                    }
                    while (customkey.Key == ConsoleKey.DownArrow)
                    {
                        ghost3();
                        customkey = Console.ReadKey();
                        while (customkey.Key == ConsoleKey.RightArrow || customkey.Key == ConsoleKey.LeftArrow)
                        {
                            if (customkey.Key == ConsoleKey.RightArrow)
                            {
                                gc3++;
                                ghost3();
                            }
                            else if (customkey.Key == ConsoleKey.LeftArrow)
                            {
                                gc3--;
                                ghost3();
                            }
                            customkey = Console.ReadKey();
                        }
                        while (customkey.Key == ConsoleKey.DownArrow)
                        {
                            ghost4();
                            customkey = Console.ReadKey();
                            while (customkey.Key == ConsoleKey.RightArrow || customkey.Key == ConsoleKey.LeftArrow)
                            {
                                if (customkey.Key == ConsoleKey.RightArrow)
                                {
                                    gc4++;
                                    ghost4();
                                }
                                else if (customkey.Key == ConsoleKey.LeftArrow)
                                {
                                    gc4--;
                                    ghost4();
                                }
                                customkey = Console.ReadKey();
                            }
                            //while (customkey.Key == ConsoleKey.Enter)
                            //{
                            //    Console.Beep();
                            //    customkey = Console.ReadKey();
                            //}
                            while (customkey.Key == ConsoleKey.UpArrow)
                            {
                                ghost3();
                                customkey = Console.ReadKey();
                                while (customkey.Key == ConsoleKey.RightArrow || customkey.Key == ConsoleKey.LeftArrow)
                                {
                                    if (customkey.Key == ConsoleKey.RightArrow)
                                    {
                                        gc3++;
                                        ghost3();
                                    }
                                    else if (customkey.Key == ConsoleKey.LeftArrow)
                                    {
                                        gc3--;
                                        ghost3();
                                    }
                                    customkey = Console.ReadKey();
                                }
                                break;
                            }
                        }
                    }
                    while (customkey.Key == ConsoleKey.UpArrow)
                    {
                        ghost2();
                        customkey = Console.ReadKey();
                        while (customkey.Key == ConsoleKey.RightArrow || customkey.Key == ConsoleKey.LeftArrow)
                        {
                            if (customkey.Key == ConsoleKey.RightArrow)
                            {
                                gc2++;
                                ghost2();
                            }
                            else if (customkey.Key == ConsoleKey.LeftArrow)
                            {
                                gc2--;
                                ghost2();
                            }
                            customkey = Console.ReadKey();
                        }
                        break;
                    }
                    while (customkey.Key == ConsoleKey.UpArrow)
                    {
                        ghost1();
                        customkey = Console.ReadKey();
                        while (customkey.Key == ConsoleKey.RightArrow || customkey.Key == ConsoleKey.LeftArrow)
                        {
                            if (customkey.Key == ConsoleKey.RightArrow)
                            {
                                gc1++;
                                ghost1();
                            }
                            else if (customkey.Key == ConsoleKey.LeftArrow)
                            {
                                gc1--;
                                ghost1();
                            }
                            customkey = Console.ReadKey();
                        }
                    }
                }
            } while (customkey.Key != ConsoleKey.Enter && customkey.Key != ConsoleKey.Escape);
            option = false;
            if (customkey.Key == ConsoleKey.Escape)
            {
                option = true;
            }
            //Console.Beep();
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
        }
        public void gameover(Status state)
        {
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            for (int i = 0; i < 140; i++)
            {
                for (int j = 0; j < 70; j++)
                    Console.Write(" ");
            }
            Console.SetCursorPosition(0, 0);
            Thread.Sleep(250);
            Console.SetCursorPosition(65, 20);
            Console.Write(">>GAME ", Console.ForegroundColor = ConsoleColor.Black);
            Thread.Sleep(500);
            Console.Write("OVER<<");
            Thread.Sleep(250);
            Console.SetCursorPosition(65, 22);
            Console.WriteLine("SCORE = {0}p",state.score,Console.ForegroundColor = ConsoleColor.White);
            Thread.Sleep(250);
            Console.SetCursorPosition(65, 24);
            Console.WriteLine("POSSESSION = {0}%", state.count * 100 / 4641, Console.ForegroundColor = ConsoleColor.White);
            Console.SetCursorPosition(0, 0);
        }
        public void youwon(Status state)
        {
            Console.ResetColor();
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            for (int i = 0; i < 140; i++)
            {
                for (int j = 0; j < 70; j++)
                    Console.Write(" ");
            }
            Console.SetCursorPosition(0, 0);
            Thread.Sleep(500);
            Console.SetCursorPosition(65, 20);
            Console.Write(">>YOU WON<<", Console.ForegroundColor = ConsoleColor.Yellow);
            Thread.Sleep(250);
            Console.SetCursorPosition(65, 22);
            Console.WriteLine("SCORE = {0}p",state.score,Console.ForegroundColor = ConsoleColor.White);
            Thread.Sleep(250);
            Console.SetCursorPosition(65, 24);
            Console.WriteLine("POSSESSION = {0}%", state.count * 100 / 4641, Console.ForegroundColor = ConsoleColor.White);
            Console.SetCursorPosition(0, 0);
        }
        private void welcome()
        {
            string pac = "PACXON";
            //Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Thread.Sleep(250);
            Console.SetCursorPosition(65, 18);
            Console.Write("Welcome");
            Thread.Sleep(250);
            Console.SetCursorPosition(72, 19);
            Console.Write("to");
            Thread.Sleep(750);
            Console.SetCursorPosition(74, 20);
            for (int i = 0; i < 6; i++)
            {
                Thread.Sleep(250);
                Console.Write("{0}", pac[i], Console.ForegroundColor = ConsoleColor.Red);
            }
            Thread.Sleep(1250);
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 140; i++)
            {
                for (int j = 0; j < 70; j++)
                    Console.Write(" ");
            }
            Console.SetCursorPosition(1, 1);
        }
    }
}
