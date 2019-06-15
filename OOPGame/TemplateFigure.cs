using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame
{
     class TemplateFigure
    {
        public int x;
        public int y;

        public TemplateFigure()
        {
            x = 0;
            y = 0;
        }
        public TemplateFigure(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
