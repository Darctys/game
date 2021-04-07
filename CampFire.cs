using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newGame
{
    public class CampFire
    {
        private static int health { get; set; }
        private int locationX;
        private int locationY;
        private static bool flame { get; set; }

        public static void DeterminStatus(int health)
        {
            if (health <= 0)
            {
                flame = false;
            }
            else
            {
                flame = true;
            }
        }
    }
}
