using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureFight
{
    public class Player
    {
        private Coords PlayerCoords;

        private Team _team;
        private int _coins;



        public Team Team
        {
            get => _team;
            set
            {
                _team = value;
            }
        }

        

       
        public int Coins
        {
            get => _coins;

            set
            {
                _coins = value;
            }
        }

        public Player(Team team,int coins)
        {
            _team = team;
            PlayerCoords = new Coords(0, 0);
            _coins = coins;
        }

        public int CursorPosition(string coordName) 
        {
            switch (coordName)
            {
                case "X":
                    return PlayerCoords._x;
                case "Y":
                    return PlayerCoords._y;
                default:
                    throw new Exception("Неверное название координаты");

            }
        }

        public void CursorMovement(Direction direction, int mapLength,int mapWidth)
        { 
            switch (direction)
            {
                case Direction.Up:
                    if (PlayerCoords._y < mapWidth-1)
                        PlayerCoords._y++;
                    break;
                case Direction.Down:
                    if (PlayerCoords._y > 0)
                        PlayerCoords._y--;
                    break;
                case Direction.Right:
                    if (PlayerCoords._x < mapLength-1)
                        PlayerCoords._x++;
                    break;
                case Direction.Left:
                    if (PlayerCoords._x > 0)
                        PlayerCoords._x--;
                    break;
            }
        }

        public void DrawCursor(int mapLength,int cellLength,int cellWidth)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(PlayerCoords._x * cellLength + 1, (mapLength - 1) * cellWidth - PlayerCoords._y * cellWidth + 1);
            Console.Write("############");

            Console.SetCursorPosition(PlayerCoords._x * cellLength + 1, (mapLength - 1) * cellWidth - PlayerCoords._y * cellWidth + 2);
            Console.Write("##");
            Console.SetCursorPosition(PlayerCoords._x * cellLength + cellLength-1, (mapLength - 1) * cellWidth - PlayerCoords._y * cellWidth + 2);
            Console.Write("##");

            Console.SetCursorPosition(PlayerCoords._x * cellLength + 1, (mapLength - 1) * 6 - PlayerCoords._y * cellWidth + 3);
            Console.WriteLine("##");
            Console.SetCursorPosition(PlayerCoords._x * cellLength + cellLength - 1, (mapLength - 1) * cellWidth - PlayerCoords._y * cellWidth + 3);
            Console.WriteLine("##");

            Console.SetCursorPosition(PlayerCoords._x * cellLength + 1, (mapLength - 1) * cellWidth - PlayerCoords._y * cellWidth + 4);
            Console.Write("##");
            Console.SetCursorPosition(PlayerCoords._x * cellLength + cellLength - 1, (mapLength - 1) * cellWidth - PlayerCoords._y * cellWidth + 4);
            Console.Write("##");

            Console.SetCursorPosition(PlayerCoords._x * cellLength + 1, (mapLength - 1) * cellWidth - PlayerCoords._y * cellWidth + 5);
            Console.Write("##");
            Console.SetCursorPosition(PlayerCoords._x * cellLength + cellLength - 1, (mapLength - 1) * cellWidth - PlayerCoords._y * cellWidth + 5);
            Console.Write("##");

            Console.SetCursorPosition(PlayerCoords._x * cellLength + 1, (mapLength - 1) * cellWidth - PlayerCoords._y * cellWidth + 6);
            Console.Write("############");
        }
    }
}
