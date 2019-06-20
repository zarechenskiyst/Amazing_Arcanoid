using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NConsoleGraphics;

namespace OOPGame
{
    class SampleArcanoid : IGameObject
    {
        private List<ArcanoidBrick> bricks;
        private ArcanoidBall ball;
        private ArcanoidPlayerBoat boat;
        private int points;
        private Button btRestart, btHightScore;
        private string message;
        private bool start;
        
        public SampleArcanoid() 
        {
            start = false;
            message = "I want to play with you in one game...";
            Restart();
        }
        public void Render(ConsoleGraphics graphics)
        {
            if (!start)
                MenuPage(graphics);
            else if (ball.y > (boat.y + boat.y + boat.h) / 2)
            {
                message = "You Lose. Your points: " + points.ToString();
                MenuPage(graphics);
            }
            else if (bricks.Count == 0)
            {
                message = "You Win. Your points: " + points.ToString();
                MenuPage(graphics);
            }
            else 
            {
                foreach (var e in bricks)
                    e.Render(graphics);
                ball.Render(graphics);
                boat.Render(graphics);
            }
        }

        public void Update(GameEngine engine)
        {
            for (int i = 0; i < this.bricks.Count; i++)
             {
                 if (ball.Cross(bricks[i]))
                 {
                     bricks.Remove(bricks[i]);
                     points += 10;
                 }
             }
             ball.Cross(boat);
             ball.Update(engine);
             btRestart.Update(engine);
             btHightScore.Update(engine);
        }

        private void Restart()
        {
            List<ArcanoidBrick> bricks = new List<ArcanoidBrick>();
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 8; i++)
                    bricks.Add(new ArcanoidBrick(70 * i, 25 * j));
            }
            this.bricks = bricks;
            this.ball = new ArcanoidBall(220, 555, 10);
            this.boat = new ArcanoidPlayerBoat();
            this.points = 0;
            btRestart = new Button();
            btHightScore = new Button();
        }
        private void MenuPage(ConsoleGraphics graphics)
        {
            graphics.DrawString(message, "Arial", 0xFFFF0000, 100, 100);
            this.btRestart=new Button(20, 20, 100, 30, "Start");
            this.btHightScore = new Button(370, 20, 150, 30, "Hight Score");
            btRestart.Render(graphics);
            btHightScore.Render(graphics);
            btRestart.MouseDown += MouseRestart;
            btHightScore.MouseDown += HightSore;
            UpdatePoints(points);
        }
        private void HightSore(object sender, EventArgs e)
        {
            string path = "Points.txt";
            string score = File.ReadAllText(path);
            message = "Highest score: " + score;
            start = false;
        }
        private void MouseRestart(object obj, EventArgs e)
        {
           Restart();
           start = true;
        }
        private void UpdatePoints(int points)
        {
            int hightScore = 0;
            string path = "Points.txt";
            if (File.Exists(path))
            {
                string str = File.ReadAllText(path);
                hightScore = int.Parse(str);
            }

            if (points >= hightScore)
                File.WriteAllText(path, points.ToString());
            
        }
    }
}
