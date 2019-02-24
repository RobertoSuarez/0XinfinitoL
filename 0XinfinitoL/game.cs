using System;
using System.IO;
using System.Collections.Generic;


namespace XinfinitoL
{
    public class game
    {
        static private string name = "data.txt";
        // Rectangulos que se van a controlar en el Screen
        static private List<rect> Rects = new List<rect>();
        static private int width, height, score;    //size from maze
        static private string nick;

        public game(int w, int h)
        {
            width = w;
            height = h;
            score = 0;
        }

        //Agregar Rectangulos
        public void addRect(rect r)
        {
            Rects.Add(r);
        }

        //Inicio del Juego
        public bool start()
        {
            GetDataUser();
            buildLevel(width, height, score);
            Draw();
            ConsoleKeyInfo dato;
            do
            {
                dato = Console.ReadKey(true);

                Tick(dato); // marca o Cambio
                checkCollisions();
                Draw();
                if (dato.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.WriteLine("{0} has llegado hasta el nivel {1} \n[Presione una tecla para continuar]", nick, score);
                    StreamWriter escritor = File.AppendText(name);
                    escritor.WriteLine(nick + "," + score);
                    escritor.Close();
                    Console.ReadKey(true);
                    width = 15;
                    height = 10;
                    score = 0;
                    Rects.Clear();
                }

            } while (dato.Key != ConsoleKey.Escape);
            return true;
        }

        static void GetDataUser()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.LargestWindowWidth / 3, 5);
            Console.Write("Ingrese su nick: ");
            nick = Console.ReadLine();
            Console.Clear();
        }

        //Lista todos los Rectangulo para realizar cambio en los rectangulos.
        static void Tick(ConsoleKeyInfo c)
        {
            foreach (rect rectangulo in Rects)
            {
                rectangulo.Tick(c);
            }
        }

        //Lista todos los Rectangulos y los Dibuja.
        static void Draw()
        {
            foreach (rect rectangulo in Rects)
            {
                rectangulo.Draw();
            }
        }

        // Chequeamos si hay coliciones entre rectangulos
        public bool checkCollisions()
        {
            int count = 0;
            foreach (rect p in Rects)
            {
                foreach (rect c in Rects)
                {
                    if (p == c)
                    {
                        continue;
                    }
                    int px = p.X(), py = p.Y(); // Posicion Del Rectangulo 1
                    int cx = c.X(), cy = c.Y(); // Posicion Del Rectangulo 2
                    // Tamaños de los Rectangulos
                    int pw = p.W(), ph = p.H();
                    int cw = c.W(), ch = c.H();
                    if (px < cx + cw && px + pw > cx && py < cy + ch && py + ph > cy)
                    {
                        //return true;
                        /* codigo que si funciona
                        if (p.GetColor() == ConsoleColor.Red) {
                            //c.Collide(p.GetColor());
                            foreach (rect r in Rects)
                            {
                                r.anterior();
                            }
                            if (p.Collide(c.GetColor()))
                            {
                                Rects.Clear();
                                p.Clean();
                                width += 1;
                                height += 1;
                                score += 1;
                                buildLevel(width, height, score);
                                Console.SetCursorPosition(0, 0);
                                Console.WriteLine("Nivel: {0}", score);
                                return true;
                            }
                            return true;
                        }*/
                        if (p.Collide(c.GetColor()))
                        {
                            foreach (var item in Rects)
                            {
                                item.isDraw = false;
                                item.Clean();
                            }
                            Rects.Clear();
                            width += 9;
                            height += 3;
                            score += 1;
                            buildLevel(width, height, score);
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine("Nivel: {0}", score);
                            return true;
                        }
                    }
                }
                count++;
            }
            return false;
        }

        public void buildLevel(int w, int h, int score)
        {
            char[][] maze = generateMaze(w, h);
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze[i].GetLength(0); j++)
                {
                    char path = maze[i][j];
                    if (path == '*')
                    {
                        addRect(new rect(i, j, 1, 1, false, ConsoleColor.White, ' '));
                    }
                    else if (path == 's')
                    {
                        addRect(new rect(i, j, 1, 1, true, ConsoleColor.Red, ' '));
                    }
                    else if (path == 'l')
                    {
                        addRect(new rect(i, j, 1, 1, false, ConsoleColor.Blue, ' '));
                    }
                }
            }
        }

        static List<Point> adjacentes(Point point, char[][] maze)
        {
            List<Point> res = new List<Point>();
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if ((i == 0 && j == 0) || (i != 0 && j != 0))
                    {
                        continue;
                    }
                    try
                    {
                        if (maze[point.X + i][point.Y + j] == '.')
                        {
                            continue;
                        }
                    }
                    catch
                    {
                        continue;
                    }
                    res.Add(new Point(point.X + i, point.Y + j, point));
                }
            }
            return res;
        }

        static bool estaEnElLaberinto(int x, int y, int w, int h)
        {
            return x >= 0 && x < w && y >= 0 && y < h;
        }

        public char[][] generateMaze(int w, int h)
        {
            Random r = new Random();

            char[][] maze = new char[w][];
            //Lenamos la matriz
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                maze[i] = new char[h];
                for (int j = 0; j < maze[i].GetLength(0); j++)
                {
                    maze[i][j] = '*';
                }
            }
            Point point = new Point(r.Next(w), r.Next(h), null);
            maze[point.X][point.Y] = 's';   // Punto de inicio (Rojo)
            Point last = null;
            List<Point> walls = adjacentes(point, maze);
            while (walls.Count > 0)
            {
                Point wall = walls[r.Next(walls.Count)];    //escojemo uno al azar
                int c = 0;
                //Eliminar point escojido
                foreach (var wa in walls)
                {
                    if (wa.X == wall.X && wa.Y == wall.Y)
                    {
                        walls.RemoveAt(c);
                        break;
                    }
                    c++;
                }
                Point opp = wall.opposite();
                try
                {
                    if (maze[opp.X][opp.Y] == '*' && maze[wall.X][wall.Y] == '*')
                    {
                        maze[wall.X][wall.Y] = '.';
                        maze[opp.X][opp.Y] = '.';
                        foreach (var item in adjacentes(opp, maze))
                        {
                            walls.Add(item);
                        }
                        last = opp;
                    }
                }
                catch { }
            }
            maze[last.X][last.Y] = 'l'; // Punto azul (llegada)
            char[][] border = new char[maze.GetLength(0) + 2][];

            for (int i = 0; i < border.GetLength(0); i++)
            {
                border[i] = new char[maze[0].GetLength(0) + 2];
                for (int j = 0; j < border[i].GetLength(0); j++)
                {
                    if (i == 0 || i == maze.GetLength(0) + 1 || j == 0 || j == maze[0].GetLength(0) + 1)
                    {
                        border[i][j] = '*';
                    }
                    else
                    {
                        border[i][j] = maze[i - 1][j - 1];
                    }
                }
            }

            return border;
        }
    }

}
