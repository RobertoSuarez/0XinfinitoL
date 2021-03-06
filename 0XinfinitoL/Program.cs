﻿using System;

namespace XinfinitoL
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Clear();

            game g = new game(15, 10);
            //g.start();
            //logos l = new logos();
            //l.logo(Console.LargestWindowWidth/2-15, 5);

            Menu ops = new Menu();
            ops.op.Add(new opcion("Jugar ", ConsoleColor.Blue, ConsoleColor.DarkBlue, g.start));
            ops.op.Add(new opcion("Lista de los jugadores", ConsoleColor.Blue, ConsoleColor.DarkBlue, g.GetList));
            ops.op.Add(new opcion("Ayuda", ConsoleColor.Blue, ConsoleColor.DarkBlue, g.ayuda));

            ops.run();
        }

    }
}
