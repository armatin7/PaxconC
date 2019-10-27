using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PaxconC
{
    class Program
    {    
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 50);
            Console.CursorVisible = false;
            Menue menue = new Menue();
            Status state = new Status(menue);
            Pacman pacman = new Pacman(state);
            List<Ghost1> ghosts1 = new List<Ghost1>();
            List<Ghost2> ghosts2 = new List<Ghost2>();
            List<Ghost3> ghosts3 = new List<Ghost3>();
            List<Ghost4> ghosts4 = new List<Ghost4>();
            menue.loadmenue();
            perparetion(state, ghosts1, ghosts2, ghosts3,ghosts4, menue);
            Console.ReadKey();
            run(state, pacman,menue, ghosts1, ghosts2, ghosts3,ghosts4);
        }
        static void perparetion(Status state, List<Ghost1> ghosts1, List<Ghost2> ghosts2, List<Ghost3> ghosts3,List<Ghost4> ghosts4, Menue menue)
        {
            for (int i = 0; i < menue.gc1; i++)
            {
                Ghost1 ghost1 = new Ghost1(state);
                ghosts1.Add(ghost1);
            }
            for (int i = 0; i < menue.gc2; i++)
            {
                Ghost2 ghost2 = new Ghost2(state);
                ghosts2.Add(ghost2);
            }
            for (int i = 0; i < menue.gc3; i++)
            {
                Ghost3 ghost3 = new Ghost3(state);
                ghosts3.Add(ghost3);
            }
            for(int i = 0; i < menue.gc4; i++)
            {
                Ghost4 ghost4 = new Ghost4(state);
                ghosts4.Add(ghost4);
            }
            state.display();
        }
        static void run(Status state, Pacman pacman,Menue menue, List<Ghost1> ghosts1, List<Ghost2> ghosts2, List<Ghost3> ghosts3,List<Ghost4> ghosts4)
        {
            while (true)
            {
                pacman.pacmove();
                foreach (var g1 in ghosts1)
                {
                    g1.ghost1move();
                }
                foreach (var g2 in ghosts2)
                {
                    g2.ghost2move();
                }
                foreach (var g3 in ghosts3)
                {
                    g3.ghost3move();
                }
                foreach (var g4 in ghosts4)
                {
                    g4.ghost4move();
                }
                if ((state.seat))
                {
                    state.misionfailed();
                    pacman.seat();
                    foreach (var g1 in ghosts1)
                        g1.seat();
                    foreach (var g2 in ghosts2)
                        g2.seat();
                    foreach (var g3 in ghosts3)
                        g3.seat();
                    foreach (var g4 in ghosts4)
                        g4.seat();
                    state.seat = false;
                    state.display();
                }
                if (state.life == 0) 
                {
                    Thread.Sleep(250);
                    menue.gameover(state);
                    //Console.ReadKey();
                    Console.ReadLine();
                    break;
                }
                else if (state.count * 100 / 4641 > 80)
                {
                    Thread.Sleep(250);
                    menue.youwon(state);
                    //Console.ReadKey();
                    Console.ReadLine();
                    break;
                }
            }
        }
    }
}
