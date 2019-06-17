using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    class SampleBall : TemplateFigure, IGameObject
    {
        private int speedX;
        private int speedY;
        private int r;
        public SampleBall(int x, int y, int speed)
        {
            r = 10;
            this.x = x;
            this.y = y;
            this.speedX = speed;
            this.speedY = speed;
        }

        public void Render(ConsoleGraphics graphics)
        {
            for (int j = 0; j < r; j++)
            {
                for (int i = 0; i < 360; i++)
                {
                    double currentAngle = i / Math.PI / 2;
                    double prevAngle = (i - 1) / Math.PI / 2;
                    graphics.DrawLine(0xFF00FF00,
                              (int)(x + j * Math.Cos(prevAngle)),
                              (int)(y + j * Math.Sin(prevAngle)),
                              (int)(x + j * Math.Cos(currentAngle)),
                              (int)(y + j * Math.Sin(currentAngle))
                              );
                }
            }
            if (x - r <= 0 || x + r >= graphics.ClientWidth)
                speedX *= -1;
            if (y - r <= 0)
                speedY *= -1;
        }

        public bool Cross(SampleBrick brick)
        {
            bool cross = isCircleToRect( brick.x, brick.y, brick.w, brick.h);
            if (cross)
                ChageSpeedIfCross(brick.x, brick.y, brick.w, brick.h);
            return cross;
        }

        public void Cross(PlayerBoat boat)
        {
            if (isCircleToRect(boat.x, boat.y, boat.w, boat.h))
               ChageSpeedIfCross(boat.x, boat.y, boat.w, boat.h);              
       }

        private void ChageSpeedIfCross(int x, int y, int w, int h)
        {
            if (this.x + this.r >= x && this.x - this.r <= x + w && this.y > y && this.y < y + h)
                speedX *= -1;
            else if (this.x > x && this.x < x + w && this.y + this.r >= y && this.y - this.r <= y + h)
                speedY *= -1;
            else
                speedY *= -1;
        }

        private bool isCircleToRect(int rx, int ry, int width, int height)
        {
            int x = this.x;
            int y = this.y;

            if (this.x < rx)
                x = rx;
            else if (this.x > (rx + width))
              x = rx + width;
            

            if (this.y < ry)
                y = ry;
            else if (this.y > (ry + height))
                y = ry + height;



            return (((this.x - x) * (this.x - x) + (this.y - y) * (this.y - y)) <= (this.r * this.r));
        }

        public void Update(GameEngine engine)
        {
            

            x += speedX;
            y += speedY;
        }

       
    }
}
