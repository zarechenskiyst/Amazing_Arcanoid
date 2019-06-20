using NConsoleGraphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGame {
  public class ArcanoidGameEngine : GameEngine {

    public ArcanoidGameEngine(ConsoleGraphics graphics): base(graphics)
        {
            AddObject(new SampleArcanoid());        
        }
  }
}
