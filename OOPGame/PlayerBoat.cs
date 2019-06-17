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

        public void Render(ConsoleGraphics graphics)
        {
            if (Input.IsKeyDown(Keys.LEFT))
            {
                if (x > 0)
                    x -= speed;
            }
            else if (Input.IsKeyDown(Keys.RIGHT))
            {
                if (x + w <graphics.ClientWidth)
                    x += speed;
            }
            graphics.FillRectangle(0xFFFF0000, x, y, w, h);
        }

        public void Update(GameEngine engine)
        {
        }

       
    }
}
