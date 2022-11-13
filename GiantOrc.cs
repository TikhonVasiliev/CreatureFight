using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureFight
{
    public class GiantOrc:Creature
    {
        public GiantOrc(int y, int x) : base(y, x)
        {
            Health = 100;
            Damage = 40;
            RangeAttack = 1;
            RangeMotion = 1;
        }

        public override void Draw(int positionY, int positionX)
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("@@@@");
            if (team == Team.Blue)
            {

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("@@@@");
                Console.SetCursorPosition(positionX + 4, positionY);
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(Health);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("@@@@");
                Console.SetCursorPosition(positionX + 4, positionY);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write(Health);
            }
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(positionX + 8, positionY);
            Console.Write("@@@@");
            Console.SetCursorPosition(positionX, positionY + 1);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("@@@@@");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.Write("@@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("@@@@@");
            Console.SetCursorPosition(positionX, positionY + 2);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("@@");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("@@");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write("@@@@");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("@@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("@@");
            Console.SetCursorPosition(positionX, positionY + 3);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("@@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Write("@@@@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.Write("@@");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Write("@");
            if (team == Team.Blue)
            {
                Console.SetCursorPosition(positionX, positionY + 4);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Write("@@@@");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Write("@@");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Write("@@@@");
            }
            else
            {
                Console.SetCursorPosition(positionX, positionY + 4);
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Write("@@@@");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Write("@@");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write("@");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Write("@@@@");

            }

            Console.SetCursorPosition(positionX, positionY + 5);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("@@@@@@@@@@@@");
        }
    }
}
