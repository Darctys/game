using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace newGame
{
    class ProgressBar
    {
        private static Image Empty = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\progressEmpty.png"));
        private static Image Full = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\ProgressFull.png"));
        public static double  MaxValue = CampFire.health*2;
        public static int  minValue = 0;
       
        public static  int width = 360;
        public static int height = 20;
       
        public static void DrawProgressBar(Graphics g, int currentValue)
        {
            g.DrawImage(Empty, new Rectangle(new Point(150, 10),
                new Size(width, height)), 0, 0, width, height, GraphicsUnit.Pixel);
            g.DrawImage(Full, new Rectangle(new Point(150, 10),
                new Size((int)(width * (currentValue / MaxValue)), height)), 0, 0, (int)(width * (currentValue / MaxValue)), height, GraphicsUnit.Pixel);
        }
    }
}
