using System;

namespace XinfinitoL
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Console.Clear();

            game g = new game(10+5,10);
            //g.start();
            //logos l = new logos();
            //l.logo(Console.LargestWindowWidth/2-15, 5);

            Menu ops = new Menu();
            ops.op.Add(new opcion("opcion 1", ConsoleColor.Blue, g.start));
            ops.op.Add(new opcion("opcion 2", ConsoleColor.Red, null));
            ops.op.Add(new opcion("opcion 3", ConsoleColor.Cyan, null));
            ops.op.Add(new opcion("opcion 4", ConsoleColor.Green, null));
            ops.op.Add(new opcion("opcion 5", ConsoleColor.Magenta, null));

            ops.run();
        }
       
    }
}
