using NConsoleGraphics;
using System;

namespace OOPGame {

  public class Program {

    static void Main(string[] args) {

            Console.WindowWidth = 65;
            Console.WindowHeight = 35;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.BackgroundColor = ConsoleColor.White;
            Console.CursorVisible = false;
            Console.Clear();

            ConsoleGraphics graphics = new ConsoleGraphics();

            GameEngine engine = new ArcanoidGameEngine(graphics);
            engine.Start();
    }
  }
}
