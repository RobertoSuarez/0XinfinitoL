using System;
using System.Collections.Generic;

namespace XinfinitoL
{
    public class Menu
    {
        public List<opcion> op = new List<opcion>();
        public Menu()
        {
        }

        public void Draw() {
            int px = -3, py = 3, scala = 2;
            for (int i = 0; i < op.Count; i++)
            {
                px += 6;
                if((px*scala)+op[i].txt.Length > Console.LargestWindowWidth) {
                    py += 2;
                    px = 0;
                }
                
                if ((px * scala) + op[i].txt.Length < Console.LargestWindowWidth)
                {
                    Console.SetCursorPosition((px * scala), py);
                    Console.ForegroundColor = op[i].hcolor;
                    Console.Write(op[i].txt);
                }
            }
        }
    }

    public class opcion
    {
        public String txt;
        public ConsoleColor hcolor;
        public ConsoleColor bcolor;
        public opcion(String msg, ConsoleColor hc)
        {
            txt = msg;
            hcolor = hc;
        }
    }
}
