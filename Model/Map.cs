using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newGame
{
    class Map
    {
        public static int mapWidth=20;
        public static int mapHeight = 20;
        public static int mapCell = 60;
        public static Field[,] map = new Field[mapHeight, mapWidth];
       


        public static void Init()
        {
            map = GetMap();
        }

        public static Field[,] GetMap()
        {
            var rnd = new Random();
            var map1 = new Field[mapWidth, mapHeight];
            for (var i = 1; i < mapWidth-1; i++)
            {
                for (var j = 1; j < mapHeight-1; j++)
                {
                    
                    
                    var value = rnd.Next(3);
                    if (value == 1)
                    {
                        map1[i, j] = new Field { Tree = true, wood=false, leather = false, coal = false };
                    }
                    else
                    {
                        map1[i, j] = new Field { Tree = false, wood=false, leather = false, coal = false };
                    }
                }
                map1[mapWidth / 2, mapHeight / 2] = new Field { Tree = false, player = true };
                map1[mapWidth / 2 + 1, mapHeight / 2] = new Field { Tree = false, campfire = true };
            }

            for (var i = 1; i < 14; i++)
            {
                var j = rnd.Next(19);
                var h = rnd.Next(19);
                map1[j, h] = new Field { Tree = false, wood = false, leather = false, coal = true};
            }
            for (var i = 1; i < 7; i++)
            {
                var j = rnd.Next(19);
                var h = rnd.Next(19);
                map1[j, h] = new Field {Tree = false, wood = false, leather = true, coal = false };
            }

            map1[mapWidth / 2, mapHeight / 2] = new Field { Tree = false, player = true };
            map1[mapWidth / 2 + 1, mapHeight / 2] = new Field { Tree = false, campfire = true };


            for (var i = 0; i < mapWidth; i++)
            {
                map1[i, 0] = new Field { End = true };
                map1[19-i, 19] = new Field { End = true };
                map1[0, (19 - i)] = new Field { End = true };
                map1[19, (19 - i)] = new Field { End = true };
            }
            return map1;
        }
       
    }
}
