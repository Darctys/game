using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using newGame.Model;

namespace newGame
{
    class Woodman
    {
        public int firewood;
        public static int  maxInventoty = 3;
        public int locationX;
        public  int locationY;
        public int speed = 3;
        public int direction = 1;
        public int deltaX;
        public int deltaY;

        public bool MoveU = false;
        public bool MoveD = false;
        public bool MoveL = false;
        public bool MoveR = false;
        public static InventoryField[] Inventory = new InventoryField[11];

        
        
        public Woodman(int locationX, int locationY)
        {
            this.locationX = locationX;
            this.locationY = locationY;
            for (var i = 0; i < Inventory.Length; i++)
            {
                Inventory[i] = new InventoryField();
                Inventory[i].wood = false;
                Inventory[i].coal = false;
            }
        }

        public  int GetX()
        {
            return (locationX) / Map.mapCell;
        }

        public int GetY()
        {
            return (locationY) / Map.mapCell;
        }
        public int GetXC()
        {
            return (locationX+30) / Map.mapCell;
        }

        public int GetYC()
        {
            return (locationY+30) / Map.mapCell;
        }
        public void MoveUp()
        {
            locationY -= speed;
        }
        public  void MoveRight()
        {
            locationX += speed;
        }
        public  void MoveLeft()
        {
            locationX -= speed;
        }
        public  void MoveDown()
        {
            locationY += speed;
        }

      

        public void Cut(int direction)
        {
            switch (direction)
            {
                case 1:
                    if (Map.map[GetXC(), GetYC() - 1].Tree)
                    {
                        Map.map[GetXC(), GetYC() - 1].Tree = false;
                        Map.map[GetXC(), GetYC() - 1].wood = true;
                    }
                  
                    break;
                case 2:
                    if (Map.map[GetXC(), GetYC() + 1].Tree)
                    {
                        Map.map[GetXC(), GetYC() + 1].Tree = false;
                        Map.map[GetXC(), GetYC() + 1].wood = true;
                    }
                       
                    break;
                case 3:
                    if (Map.map[GetXC() - 1, GetYC()].Tree)
                    {
                        Map.map[GetXC() - 1, GetYC()].Tree = false;
                        Map.map[GetXC() - 1, GetYC()].wood = true;
                    }
                       
                    break;
                case 4:
                    if (Map.map[GetXC() + 1, GetYC()].Tree)
                    {
                        Map.map[GetXC() + 1, GetYC()].Tree = false;
                        Map.map[GetXC() + 1, GetYC()].wood = true;
                    }
                        
                    break;
            }
        }

        public void Take()
        {
            if (Map.map[GetXC(), GetYC()].wood)
            {
                for (var i = 0; i < maxInventoty; i++)
                {
                    if (!Inventory[i].IsFull())
                    {
                        Map.map[GetXC(), GetYC()].wood = false;
                        Inventory[i].wood = true;
                        break;
                    }
                }
            }
            if (Map.map[GetXC(), GetYC()].coal)
            {
                for (var i = 0; i < maxInventoty; i++)
                {
                    if (!Inventory[i].IsFull())
                    {
                        Map.map[GetXC(), GetYC()].coal = false;
                        Inventory[i].coal = true;
                        break;
                    }
                }
            }
            if (Map.map[GetXC(), GetYC()].leather && maxInventoty <= 9)
            {
                Map.map[GetXC(), GetYC()].leather = false;
                maxInventoty++;
            }
        }
        public void Put(int direction)
        {
            switch (direction)
            {
                case 1:
                    if (Map.map[GetXC(), GetYC() - 1].campfire)
                    {

                        for (var i = maxInventoty - 1; i >= 0; i--)
                        {
                            if (Inventory[i].IsFull())
                            {
                                if (Inventory[i].wood)
                                {
                                    CampFire.health += 100;
                                    Inventory[i].wood = false;
                                }
                                if (Inventory[i].coal)
                                {
                                    CampFire.health += 150;
                                    Inventory[i].coal = false;
                                }
                                break;
                            }
                        }
                    }

                    break;
                case 2:
                    if (Map.map[GetXC(), GetYC() + 1].campfire)
                    {

                        for (var i = maxInventoty - 1; i >= 0; i--)
                        {
                            if (Inventory[i].IsFull())
                            {
                                if (Inventory[i].wood)
                                {
                                    CampFire.health += 100;
                                    Inventory[i].wood = false;
                                }
                                if (Inventory[i].coal)
                                {
                                    CampFire.health += 150;
                                    Inventory[i].coal = false;
                                }
                                break;
                            }
                        }
                    }

                    break;
                case 3:
                    if (Map.map[GetXC() - 1, GetYC()].campfire)
                    {

                        for (var i = maxInventoty - 1; i >= 0; i--)
                        {
                            if (Inventory[i].IsFull())
                            {
                                if (Inventory[i].wood)
                                {
                                    CampFire.health += 100;
                                    Inventory[i].wood = false;
                                }
                                if (Inventory[i].coal)
                                {
                                    CampFire.health += 150;
                                    Inventory[i].coal = false;
                                }
                                break;
                            }
                        }
                    }

                    break;
                case 4:
                    if (Map.map[GetXC() + 1, GetYC()].campfire)
                    {

                        for (var i = maxInventoty - 1; i >= 0; i--)
                        {
                            if (Inventory[i].IsFull())
                            {
                                if (Inventory[i].wood)
                                {
                                    CampFire.health += 100;
                                    Inventory[i].wood = false;
                                }
                                if (Inventory[i].coal)
                                {
                                    CampFire.health += 150;
                                    Inventory[i].coal = false;
                                }
                                break;
                            }
                        }
                    }
                    break;
            }
        }
    }
}
