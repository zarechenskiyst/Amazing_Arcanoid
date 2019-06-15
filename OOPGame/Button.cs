using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NConsoleGraphics;

namespace OOPGame
{
    class Button : TemplateFigure, IGameObject
    {
        private int w, h;
        private string text;
        public Button()
        {
            w = 0;
            h = 0;
            text = "";
        }
        public Button(int x, int y, int w, int h, string text):base (x,y)
        {
            this.w = w;
            this.h = h;
            this.text = text;
        }
        public void Render(ConsoleGraphics graphics)
        {
            graphics.FillRectangle(0xFF00F0FF, x, y, w, h);
            graphics.DrawString(text, "Arial", 0xFFFFFF00, x, y);

        }

        public void Update(GameEngine engine)
        {
            int mx = Input.MouseX;
            int my = Input.MouseY;

            if (x <= mx && x + w >= mx && y <= my && y + h >= my && Input.IsMouseLeftButtonDown)
                MouseDown?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler MouseDown;
    }
}
