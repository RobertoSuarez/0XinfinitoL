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

        public void Draw(int posicion)
        {
            int px = -3, py = 3, scala = 2;
            for (int i = 0; i < op.Count; i++)
            {
                px += 6;
                if ((px * scala) + op[i].txt.Length > Console.LargestWindowWidth)
                {
                    py += 2;
                    px = 0;
                }

                if ((px * scala) + op[i].txt.Length < Console.LargestWindowWidth)
                {
                    Console.SetCursorPosition((px * scala), py);
                    if (posicion == i)
                    {
                        Console.ForegroundColor = op[i].hcolor;
                    }
                    else
                    {
                        Console.ForegroundColor = op[i].bcolor;
                    }
                    //Console.ForegroundColor = op[i].hcolor;
                    Console.Write(op[i].txt);
                }
            }
        }

        public void clear()
        {
            int px = -3, py = 3, scala = 2;
            for (int i = 0; i < op.Count; i++)
            {
                px += 6;
                if ((px * scala) + op[i].txt.Length > Console.LargestWindowWidth)
                {
                    py += 2;
                    px = 0;
                }

                if ((px * scala) + op[i].txt.Length < Console.LargestWindowWidth)
                {
                    Console.SetCursorPosition((px * scala), py);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(op[i].txt);
                }
            }
        }

        public void run()
        {
            ConsoleKeyInfo dato;
            int posicion = 0, limite = op.Count - 1;
            Draw(posicion);
            do
            {
                dato = Console.ReadKey(true);
                clear();
                switch (dato.Key)
                {
                    case ConsoleKey.LeftArrow:
                        //flecha izquierda
                        if (posicion > 0)
                        {
                            posicion--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        //Flecha derecha
                        if (posicion < limite)
                        {
                            posicion++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        op[posicion].funcionalidad();
                        Console.Clear();
                        Draw(posicion);
                        break;
                    default:
                        break;
                }
                Draw(posicion);
                //Console.WriteLine(posicion);

            } while (dato.Key != ConsoleKey.Escape);
        }
    }

    public class opcion
    {
        public String txt;
        public ConsoleColor hcolor;
        public ConsoleColor bcolor;
        public Func<bool> funcionalidad;
        public opcion(String msg, ConsoleColor hc, ConsoleColor bc, Func<bool> f)
        {
            txt = msg;
            hcolor = hc;
            bcolor = bc;
            funcionalidad = f;
        }
    }
}
