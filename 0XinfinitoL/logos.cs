using System;

namespace animacionPunto
{
    public class logos
    {
        public logos()
        {
        }

        public void logo(int x, int y) {
            String[] la = {
                "\ud83c\udf0e \ud83c\udf0e \ud83c\udf0e",
            };
            draw(x,y,la);
        }

        public void draw(int x, int y, String[] logo) {
            for (int i = 0; i < logo.GetLength(0); i++)
            {
                Console.SetCursorPosition(x,y+i);
                Console.WriteLine(logo[i]);
            }
        }
    }
}
