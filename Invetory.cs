using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newGame
{
    class Invetory
    {
        public static Image wood = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\wood.png"));
        public static Image coal = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\coal.png"));
        public static Image i3 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\i3.png"));
        public static Image i4 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\i4.png"));
        public static Image i5 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\i5.png"));
        public static Image i6 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\i6.png"));
        public static Image i7 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\i7.png"));
        public static Image i8 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\i8.png"));
        public static Image i9 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\i9.png"));
        public static Image i10 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\i10.png"));
        public static int width = 60;
        public static int height = 60;
        public static int sell = 49;
        public static void DrawInventory(Graphics g)
        {
            switch (Woodman.maxInventoty)
            {

                case 3:
                    Draw(g,i3);
                    break;
                case 4:
                    Draw(g, i4);
                    break;
                case 5:
                    Draw(g, i5);
                    break;
                case 6:
                    Draw(g, i6);
                    break;
                case 7:
                    Draw(g, i7);
                    break;
                case 8:
                    Draw(g, i8);
                    break;
                case 9:
                    Draw(g, i9);
                    break;
                case 10:
                    Draw(g, i10);
                    break;
            }
        }

        private static void Draw(Graphics g, Image i)
        {
            g.DrawImage(i, new Rectangle(new Point(1, 610),
                new Size(i.Width, i.Height)), 0, 0, i.Width, i.Height, GraphicsUnit.Pixel);
            for (var j = 0; j < Woodman.maxInventoty; j++)
            {
                if (Woodman.Inventory[j].wood)
                {
                    g.DrawImage(wood, new Rectangle(new Point(27 + j * sell, 610),
                        new Size(50, 50)), 0, 0, 60, 60, GraphicsUnit.Pixel);
                }
                if (Woodman.Inventory[j].coal)
                {
                    g.DrawImage(coal, new Rectangle(new Point(31 + j * sell, 614),
                        new Size(45, 45)), 0, 0, 60, 60, GraphicsUnit.Pixel);
                }
            }
        }
    }
}
