using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using newGame.Model;

namespace newGame
{
    public partial class Form1 : Form
    {
        //private Woodman player;
        private Camera camera;
        private Animations animations;

        private static Image sprite = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\earth3.png"));
        private static Image sprite1 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\tree.png"));
        private static Image end = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\End.png"));
        private static Image wood = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\wood.png"));
        public Image up = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Up1.png"));
        public Image down = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Down1.png"));
        public Image left = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Left1.png"));
        public Image right = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Right1.png"));
        public static Image fire = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\костёр.png"));
        public static Image fire1 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\1.png"));
        public static Image fire2 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\2.png"));
        public static Image fire3 = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\3.png"));
        public static Image nofire = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\0.png"));
        public static Image woods = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\woods.png"));
        public static Image leather = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\кожа.png"));
        public static Image coal = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\coal.png"));
        private bool isPressedAnyKey = false;
        public Form1()
        {
            var timer = new Timer { Interval = 15 };
            timer.Tick += (@object, args) =>
            {
                Game.Update();
                
                Invalidate();
            };
            Game.OnEndGame += OnEndGame;
            timer.Start();
            InitializeComponent();
            Init();
            //progressBar1.Location = new Point(Map.mapWidth / 2 * Map.mapCell + 300, 1);
            //player = new Woodman(Map.mapWidth / 2 * Map.mapCell, Map.mapWidth / 2 * Map.mapCell +10);
            //camera = new Camera {deltaX = -Map.mapWidth / 2 * Map.mapCell + 300 ,deltaY = -Map.mapWidth / 2 * Map.mapCell + 300};
            animations = new Animations();
            timer3.Interval = 70;
            timer2.Interval = 100;
            timer1.Interval =15;
            timer2.Tick += new EventHandler(UpdateFire);
            timer3.Tick += new EventHandler(UpdateAnimations);
            timer1.Tick += new EventHandler(Update);
            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);
        }

        private void OnEndGame()
        {
            camera = new Camera { deltaX = -Map.mapWidth / 2 * Map.mapCell + 300, deltaY = -Map.mapWidth / 2 * Map.mapCell + 300 };
        }


        public void UpdateAnimations(object sender, EventArgs e)
        {
            if (isPressedAnyKey)
            {
                switch (Game.player.direction)
                {
                    case 1:
                        Animations.UpCount++;
                        up = Animations.Up[Animations.UpCount % 3];
                    break;
                    case 2:
                        Animations.DownCount++;
                        down = Animations.Down[Animations.DownCount % 3];
                        break;
                    case 3:
                        Animations.LeftCount++;
                        left = Animations.Left[Animations.LeftCount % 3];
                        break;
                    case 4:
                        Animations.RightCount++;
                        right = Animations.Right[Animations.RightCount % 3];
                        break;
                }
            }
            else
            {
                switch (Game.player.direction)
                {
                    case 1:
                        up = Animations.Up[0];
                        break;
                    case 2:
                        down = Animations.Down[0];
                        break;
                    case 3:
                        left = Animations.Left[0];
                        break;
                    case 4:
                        right = Animations.Right[0];
                        break;
                }
            }
        }

        public void Init()
        {
            Game.NewGame();
            this.Width = 660+17;
            this.Height = 660+40;
            camera = new Camera { deltaX = -Map.mapWidth / 2 * Map.mapCell + 300, deltaY = -Map.mapWidth / 2 * Map.mapCell + 300 };
            this.Location = new Point(Map.mapWidth / 2 * Map.mapCell, Map.mapWidth / 2 * Map.mapCell);
            timer1.Start();
        }

        public void UpdateFire(object sender, EventArgs e)
        {
            CampFire.NewFlameStutus();
        }

        public void Update(object sender, EventArgs e)
        {
            
            switch (Game.player.direction)
            {
                case 1:
                    if (!Map.map[(Game.player.locationX + 50) / Map.mapCell,
                        (Game.player.locationY - Game.player.speed) / Map.mapCell].CanGO() && !Map.map[(Game.player.locationX + 10) / Map.mapCell,
                        (Game.player.locationY - Game.player.speed) / Map.mapCell].CanGO() && isPressedAnyKey)
                    {
                        if (Game.player.GetY() >= 5 && Game.player.GetY() <= 18 - 5)
                            camera.deltaY += Game.player.speed;
                        Game.player.MoveU = true;
                        Game.player.MoveD = false;
                        Game.player.MoveL = false;
                        Game.player.MoveR = false;
                        //Game.player.MoveUp();
                        //Game.player.TakeWood();
                    }
                    else
                    {
                        Game.player.MoveU = false;
                        Game.player.MoveD = false;
                        Game.player.MoveL = false;
                        Game.player.MoveR = false;
                    }
                    break;
                case 2:
                    if (!Map.map[(Game.player.locationX + 50) / Map.mapCell,
                        (Game.player.locationY + Map.mapCell + Game.player.speed) / Map.mapCell].CanGO() && !Map.map[(Game.player.locationX + 10) / Map.mapCell,
                        (Game.player.locationY + Map.mapCell + Game.player.speed) / Map.mapCell].CanGO() && isPressedAnyKey)
                    {
                        if (18 - Game.player.GetY() >= 5 && Game.player.GetY() >= 5)
                            camera.deltaY -= Game.player.speed;
                        Game.player.MoveU = false;
                        Game.player.MoveD = true;
                        Game.player.MoveL = false;
                        Game.player.MoveR = false;
                        //Game.player.MoveDown();
                        //Game.player.TakeWood();
                    }
                    else
                    {
                        Game.player.MoveU = false;
                        Game.player.MoveD = false;
                        Game.player.MoveL = false;
                        Game.player.MoveR = false;
                    }
                    break;
                case 3:
                    if (!Map.map[(Game.player.locationX - Game.player.speed) / Map.mapCell,
                        (Game.player.locationY + 50) / Map.mapCell].CanGO() && !Map.map[(Game.player.locationX - Game.player.speed) / Map.mapCell,
                        (Game.player.locationY + 10) / Map.mapCell].CanGO() && isPressedAnyKey)
                    {
                        if (Game.player.GetX() >= 5 && Game.player.GetX() <= 18 - 5)
                            camera.deltaX += Game.player.speed;
                        Game.player.MoveU = false;
                        Game.player.MoveD = false;
                        Game.player.MoveL = true;
                        Game.player.MoveR = false;
                        //Game.player.MoveLeft();
                        //Game.player.TakeWood();

                    }
                    else
                    {
                        Game.player.MoveU = false;
                        Game.player.MoveD = false;
                        Game.player.MoveL = false;
                        Game.player.MoveR = false;
                    }
                    break;
                case 4:
                    if (!Map.map[(Game.player.locationX + Map.mapCell + Game.player.speed) / Map.mapCell,
                        (Game.player.locationY + 50) / Map.mapCell].CanGO() && !Map.map[(Game.player.locationX + Map.mapCell + Game.player.speed) / Map.mapCell,
                        (Game.player.locationY + 10) / Map.mapCell].CanGO() && isPressedAnyKey)
                    {
                        if (18 - Game.player.GetX() >= 5 && Game.player.GetX() >= 5)
                            camera.deltaX -= Game.player.speed;
                        Game.player.MoveU = false;
                        Game.player.MoveD = false;
                        Game.player.MoveL = false;
                        Game.player.MoveR = true;
                        //Game.player.MoveRight();
                        //Game.player.TakeWood();
                    }
                    else
                    {
                        Game.player.MoveU = false;
                        Game.player.MoveD = false;
                        Game.player.MoveL = false;
                        Game.player.MoveR = false;
                    }
                    break;
            }
            //if (CampFire.health>0)
            //    CampFire.health--;
            this.Invalidate();
        }

        private  void OnPress(object sender, KeyEventArgs e)
        {
            
            Game.player.speed = 3;
            switch (e.KeyCode)
            {
                   
                case Keys.D:
                    isPressedAnyKey = true;
                    //Game.player.MoveR = true;
                    Game.player.direction = 4;
                    break;
                case Keys.S:
                    isPressedAnyKey = true;
                    //Game.player.MoveD = true;
                    Game.player.direction = 2;
                    break;
                case Keys.A:
                    isPressedAnyKey = true;
                    //Game.player.MoveL = true;
                    Game.player.direction = 3;
                    break;
                case Keys.W:
                    isPressedAnyKey = true;
                    //Game.player.MoveU = true;
                    Game.player.direction = 1;
                    
                    break;
                case Keys.Space:
                    Game.player.Cut(Game.player.direction);
                   
                    break;
                case Keys.L:
                    Game.player.PutWood(Game.player.direction);
                   
                    break;

            }
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
           
            switch (e.KeyCode)
            {
                case Keys.W:
                    isPressedAnyKey = false;
                    Game.player.MoveU = false;
                    break;
                case Keys.S:
                    isPressedAnyKey = false;
                    Game.player.MoveD = false;
                    break;
                case Keys.A:
                    isPressedAnyKey = false;
                    Game.player.MoveL = false;
                    break;
                case Keys.D:
                    isPressedAnyKey = false;
                    Game.player.MoveR = false;
                    break;
                
            }
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DrawMap(g, camera.deltaX, camera.deltaY);
            DrawPlayer(g, Game.player.direction, camera.deltaX, camera.deltaY);
            DrawTrees(g, camera.deltaX, camera.deltaY);
            DrawFire(g, camera.deltaX, camera.deltaY);
            Invetory.DrawInventory(g);
            ProgressBar.DrawProgressBar(g, CampFire.health);
        }

        private static void DrawMap(Graphics g, int deltaX, int deltaY)
        {
            for (var i = 0; i < Map.mapWidth; i++)
            {
                g.DrawImage(end, new Rectangle(new Point(i * Map.mapCell + deltaX, 0 * Map.mapCell + deltaY),
                    new Size(Map.mapCell, Map.mapCell)), 0, 0, Map.mapCell, Map.mapCell, GraphicsUnit.Pixel);
                g.DrawImage(end, new Rectangle(new Point((19 - i) * Map.mapCell + deltaX, 19 * Map.mapCell + deltaY),
                    new Size(Map.mapCell, Map.mapCell)), 0, 0, Map.mapCell, Map.mapCell, GraphicsUnit.Pixel);
                g.DrawImage(end, new Rectangle(new Point(0 * Map.mapCell + deltaX, (19 - i) * Map.mapCell + deltaY),
                    new Size(Map.mapCell, Map.mapCell)), 0, 0, Map.mapCell, Map.mapCell, GraphicsUnit.Pixel);
                g.DrawImage(end, new Rectangle(new Point(19 * Map.mapCell + deltaX, (19 - i) * Map.mapCell + deltaY),
                    new Size(Map.mapCell, Map.mapCell)), 0, 0, Map.mapCell, Map.mapCell, GraphicsUnit.Pixel);
            }

            for (var i = 1; i < Map.mapWidth - 1; i++)
            {
                for (var j = 1; j < Map.mapHeight - 1; j++)
                {
                    g.DrawImage(sprite, new Rectangle(new Point(j * Map.mapCell + deltaX, i * Map.mapCell + deltaY),
                        new Size(Map.mapCell, Map.mapCell)), 0, 0, Map.mapCell, Map.mapCell, GraphicsUnit.Pixel);
                }
            }

            for (var i = 1; i < Map.mapWidth - 1; i++)
            {
                for (var j = 1; j < Map.mapHeight - 1; j++)
                {
                    if (Map.map[i, j].wood)
                    {
                        g.DrawImage(wood, new Rectangle(new Point(i * Map.mapCell + deltaX, j * Map.mapCell + deltaY),
                            new Size(Map.mapCell, Map.mapCell)), 0, 0, 60, 60, GraphicsUnit.Pixel);
                    }
                    if (Map.map[i, j].leather)
                    {
                        g.DrawImage(leather, new Rectangle(new Point(i * Map.mapCell+10 + deltaX, j * Map.mapCell + deltaY+10),
                            new Size(40, 40)), 0, 0, 60, 60, GraphicsUnit.Pixel);
                    }
                    if (Map.map[i, j].coal)
                    {
                        g.DrawImage(coal, new Rectangle(new Point(i * Map.mapCell + 10 + deltaX, j * Map.mapCell + deltaY + 10),
                            new Size(40, 40)), 0, 0, 60, 60, GraphicsUnit.Pixel);
                    }
                }
            }
        }

        private void DrawTrees(Graphics g, int deltaX, int deltaY)
        {
            for (var i = 1; i < Map.mapWidth - 1; i++)
            {
                for (var j = 1; j < Map.mapHeight - 1; j++)
                {
                    if (Map.map[i, j].Tree)
                    {
                        g.DrawImage(sprite1, new Rectangle(new Point(i * Map.mapCell + deltaX, j * Map.mapCell + deltaY),
                            new Size(Map.mapCell, Map.mapCell)), 0, 0, 60, 60, GraphicsUnit.Pixel);
                    }
                }
            }
        }
        

        private void DrawFire(Graphics g, int deltaX, int deltaY)
        {
            for (var i = 1; i < Map.mapWidth - 1; i++)
            {
                for (var j = 1; j < Map.mapHeight - 1; j++)
                {
                    if (Map.map[i, j].campfire)
                    {
                        if (CampFire.DeterminStatus())
                        {
                            switch (CampFire.FlameStutus)
                            {
                                case 0:
                                    g.DrawImage(fire1, new Rectangle(
                                        new Point(i * Map.mapCell + deltaX, j * Map.mapCell + deltaY),
                                        new Size(Map.mapCell, Map.mapCell)), 0, 0, 60, 60, GraphicsUnit.Pixel);
                                    break;
                                case 1:
                                    g.DrawImage(fire2, new Rectangle(
                                        new Point(i * Map.mapCell + deltaX, j * Map.mapCell + deltaY),
                                        new Size(Map.mapCell, Map.mapCell)), 0, 0, 60, 60, GraphicsUnit.Pixel);
                                    break;
                                case 2:
                                    g.DrawImage(fire3, new Rectangle(
                                        new Point(i * Map.mapCell + deltaX, j * Map.mapCell + deltaY),
                                        new Size(Map.mapCell, Map.mapCell)), 0, 0, 60, 60, GraphicsUnit.Pixel);
                                    break;
                                case 3:
                                    g.DrawImage(fire2, new Rectangle(
                                        new Point(i * Map.mapCell + deltaX, j * Map.mapCell + deltaY),
                                        new Size(Map.mapCell, Map.mapCell)), 0, 0, 60, 60, GraphicsUnit.Pixel);
                                    break;
                            }
                        }
                        else
                        {
                            g.DrawImage(nofire, new Rectangle(new Point(i * Map.mapCell + deltaX, j * Map.mapCell + deltaY),
                                new Size(Map.mapCell, Map.mapCell)), 0, 0, 60, 60, GraphicsUnit.Pixel);
                        }
                    }
                }
            }
        }

        private void DrawPlayer(Graphics g, int direction, int deltaX, int deltaY)
        {
            switch (direction)
            {
                case 1:
                    g.DrawImage(up, new Rectangle(new Point(Game.player.locationX + deltaX, Game.player.locationY + deltaY),
                        new Size(Map.mapCell, Map.mapCell)), 0, 0, Map.mapCell, Map.mapCell, GraphicsUnit.Pixel);
                    break;
                case 2:
                    g.DrawImage(down, new Rectangle(new Point(Game.player.locationX + deltaX, Game.player.locationY + deltaY),
                        new Size(Map.mapCell, Map.mapCell)), 0, 0, Map.mapCell, Map.mapCell, GraphicsUnit.Pixel);
                    break;
                case 3:
                    g.DrawImage(left, new Rectangle(new Point(Game.player.locationX + deltaX, Game.player.locationY + deltaY),
                        new Size(Map.mapCell, Map.mapCell)), 0, 0, Map.mapCell, Map.mapCell, GraphicsUnit.Pixel);
                    break;
                case 4:
                    g.DrawImage(right, new Rectangle(new Point(Game.player.locationX + deltaX, Game.player.locationY + deltaY),
                        new Size(Map.mapCell, Map.mapCell)), 0, 0, Map.mapCell, Map.mapCell, GraphicsUnit.Pixel);
                    break;
            }
        }

        private void label1_Click(object sender, MouseEventArgs e)
        {
          Init();
        }

       

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Text = Game.player.GetY().ToString();
        }

        
    }
}
