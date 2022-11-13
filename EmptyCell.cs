using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureFight
{
    public class EmptyCell: IObjectGame
    {
        public void Draw(int positionY,int positionX)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(positionX, positionY);
            Console.Write("@@@@@@@@@@@@\n");
            Console.SetCursorPosition( positionX,positionY + 1);
            Console.Write("@@@@@@@@@@@@\n");
            Console.SetCursorPosition(positionX,positionY + 2 );
            Console.Write("@@@@@@@@@@@@\n");
            Console.SetCursorPosition(positionX, positionY + 3);
            Console.Write("@@@@@@@@@@@@\n");
            Console.SetCursorPosition(positionX, positionY + 4);
            Console.Write("@@@@@@@@@@@@\n");
            Console.SetCursorPosition(positionX, positionY + 5);
            Console.Write("@@@@@@@@@@@@\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
