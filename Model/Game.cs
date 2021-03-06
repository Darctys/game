using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newGame.Model
{
    static class Game
    {
        public static Woodman player;
        

        public static void Init()
        {
            Map.Init();
            player = new Woodman(Map.mapWidth / 2 * Map.mapCell, Map.mapWidth / 2 * Map.mapCell);
            CampFire.health = 1000;
        }
        public static void Update()
        {
            if (player.MoveU)
            {
                player.MoveUp();
                player.Take();
            }
            if (player.MoveD)
            {
                player.MoveDown();
                player.Take();
            }
            if (player.MoveR)
            {
                player.MoveRight();
                player.Take();
            }
            if (player.MoveL)
            {
                player.MoveLeft();
                player.Take();
            }

            if (CampFire.health > 0)
                CampFire.health--;
            else
                NewGame();

        }
        public static void NewGame()
        {
            Init();
            OnEndGame?.Invoke();
        }

        //public static bool EndGame()
        //{
        //    return !CampFire.DeterminStatus();
        //}
        public delegate void EndGame();

        public static event EndGame OnEndGame;
    }
}
