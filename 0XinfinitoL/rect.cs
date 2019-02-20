using System;
using System.Collections.Generic;


namespace XinfinitoL
{
    public class rect
    {
        private Char letra;
        private int px, py, width, height, apx, apy, mx, my;
        public bool move, isDraw;
        private ConsoleColor color;
        public rect(int x, int y, int w, int h, bool m, ConsoleColor c, Char ch)
        {
            px = x;
            py = y;
            width = w;
            height = h;
            color = c;
            move = m;
            letra = ch;
            isDraw = false;
            mx = 0;
            my = 0;
        }

        public int X() { return px; }
        public int Y() { return py; }

        public int H() { return height; }
        public int W() { return  width; }

        public ConsoleColor GetColor() { return color; }

        private void SetPosition(int x, int y) {
            apx = px;
            apy = py;
            px = x;
            py = y;
        }

        public bool Collide(ConsoleColor c) {

            if (c == ConsoleColor.Blue) {
                return true;
            }
            if (c == ConsoleColor.White) {
                px = apx;
                py = apy;
            }
            return false;
        } 

        public void anterior() {
            if (color == ConsoleColor.White || color == ConsoleColor.Blue)
            {
                px = apx;
                py = apy;
            }
        }

        public void Tick(ConsoleKeyInfo c) {
            //Movimiento
            Clean();
            switch (c.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (move)
                    {
                        SetPosition(px - 1, py);
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if(move) { 
                        SetPosition(px + 1, py);
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (move)
                    {
                        SetPosition(px, py + 1);
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (move) { 
                        SetPosition(px, py - 1);
                    }
                    break;
                case ConsoleKey.D:
                    isDraw = false;
                    Clean();
                    mx = mx + 4;
                    break;
                case ConsoleKey.A:
                    isDraw = false;
                    Clean();
                    mx = mx - 4;
                    break;
                case ConsoleKey.W:
                    isDraw = false;
                    Clean();
                    my = my - 4;
                    break;
                case ConsoleKey.S:
                    isDraw = false;
                    Clean();
                    my = my + 4;
                    break;
                case ConsoleKey.R:
                    isDraw = false;
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;

                    break;
                default:
                    break;
            }

        }

        public void Clean() {
            if (move || !isDraw)
            {
                rectangle(px, py, width, height, ConsoleColor.Black, ' ', mx, my);
            }
        }

        public void Draw() {
           if (move || !isDraw) { 
                rectangle(px, py, width, height, color, letra, mx, my);
                isDraw = true;
           }
        }

        static void rectangle(int x, int y, int w, int h, ConsoleColor c, Char ch, int mmx, int mmy)
        {
            x += mmx +5;
            y += mmy +5;
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    if( x + i >= 0 && x+i < Console.LargestWindowWidth && y + j >= 0 && y+j < Console.LargestWindowHeight) {
                        Console.BackgroundColor = c;
                        Console.SetCursorPosition(x + i, y + j);
                        Console.Write(ch);

                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                }
            }
        }
    }
}
