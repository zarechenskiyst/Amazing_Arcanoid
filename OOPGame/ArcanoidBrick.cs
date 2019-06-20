using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    class  ArcanoidBrick : TemplateFigure, IGameObject
    {
        public int w, h;
        public ArcanoidBrick(int x, int y):base(x,y)
        {
            w = 50;
            h = 20;
        }

        public void Render(ConsoleGraphics graphics)
        {
             graphics.FillRectangle(0x0F0F0F0F, x, y, w, h);
        }

        public void Update(GameEngine engine)
        {
           
        }
    }
}
