using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    class PlayerBoat : TemplateFigure, IGameObject
    {

        private int speed = 10;
        public int w = 150;
        public int h = 12;

        public PlayerBoat()
        {
            this.x = 200;
            this.y =560;
        }

        public PlayerBoat(ConsoleGraphics graphics)
        {
            this.x = 20;
            this.y = graphics.ClientHeight-13;
        }

        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(0xFFFF0000, x, y, w, h);
        }

        public void Update(GameEngine engine)
        {

            if (Input.IsKeyDown(Keys.LEFT))
            {
                if (x > Console.WindowLeft)
                    x -= speed;
            }
            else if (Input.IsKeyDown(Keys.RIGHT))
            {
                if (x + w <Console.BufferWidth*8+11/*382*/)
                    x += speed;
            }

        }

       
    }
}
