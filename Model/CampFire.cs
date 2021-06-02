using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newGame
{
    public class CampFire
    {
        public static int health;


        public static int FlameStutus = 0;

        public static void NewFlameStutus()
        {
            FlameStutus = (FlameStutus + 1) % 4;
        }
        public static bool DeterminStatus()
        {
            if (health <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
    }
}
