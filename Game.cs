using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureFight
{
    public class Game
    {

        //private Player _player = new Player();
        private Map _map;
        private int _NMove = 0;
        private int _bonus = 5;
        private const int _mapLength = 7;
        private const int _mapWidth = 7;
        private const int _cellLength = 12;
        private const int _cellWidth = 6;
        public Game()
        {
            _map = new Map(_mapLength, _mapWidth, _cellLength, _cellWidth);
        }

        private void Cursor(Player player,ConsoleKey pressed)
        {
            switch (pressed)
            {
                case ConsoleKey.RightArrow:
                    player.CursorMovement(Direction.Right, _mapLength, _mapWidth);
                    break;
                case ConsoleKey.LeftArrow:
                    player.CursorMovement(Direction.Left, _mapLength, _mapWidth);
                    break;
                case ConsoleKey.UpArrow:
                    player.CursorMovement(Direction.Up, _mapLength, _mapWidth);
                    break;
                case ConsoleKey.DownArrow:
                    player.CursorMovement(Direction.Down, _mapLength, _mapWidth);
                    break;
                default:
                    break;
            }
            
        }
        private void Move(Player player)
        {
            bool move = true;
            while (move)
            {
               
                Console.SetCursorPosition(0, _mapWidth * _cellWidth + 1);
                ConsoleKey pressed = Console.ReadKey().Key;
                switch (pressed)
                {
                    case ConsoleKey.B:
                        Store(player);
                        break;
                    case ConsoleKey.Spacebar:
                        if (_map._map[player.CursorPosition("Y"), player.CursorPosition("X")] is Creature)
                        {
                            if (((Creature)_map._map[player.CursorPosition("Y"), player.CursorPosition("X")]).team == player.Team)
                            {
                                if (((Creature)_map._map[player.CursorPosition("Y"), player.CursorPosition("X")]).CreatureMovement)
                                {
                                    CreatureAction((Creature)_map._map[player.CursorPosition("Y"), player.CursorPosition("X")], player, player.CursorPosition("Y"), player.CursorPosition("X"));
                                    if ((((Tower)_map._map[3, 0]).Health == 0) || (((Tower)_map._map[3, 6]).Health == 0))
                                        move = false;
                                }
                            }
                        }
                        break;
                    case ConsoleKey.Enter:
                        move = false;
                        break;
                    default:
                        Cursor(player,pressed);
                        break;
                }
                //Console.Clear();
                Draw(player);
            }
        }
        public void Start()
        {
            Player player1 = new Player(Team.Blue, 300);
            Player player2 = new Player(Team.Red,300);
            while ((((Tower)_map._map[3, 0]).Health > 0) && (((Tower)_map._map[3, 6]).Health > 0))
            {
                _NMove++;
                if (((_NMove / 2) % _bonus == 0) && (_NMove > 1) && (_NMove % 2 == 0))
                    player2.Coins += 100;
                if (((_NMove / 2 + 1) % _bonus == 0) && (_NMove % 2 == 1)) 
                    player1.Coins += 100;
                for (int i = 0; i < _mapLength; i++)
                {
                    for (int j = 0; j < _mapWidth; j++)
                    {
                        if (_map._map[i, j] is Creature)
                        {
                            ((Creature)_map._map[i, j]).CreatureMovement = true;
                        }

                    }
                }
                Console.Clear();
                if (_NMove % 2 == 1)
                {
                    Draw(player1);
                    Move(player1);
                }
                else
                {
                    Draw(player2);
                    Move(player2);
                }
               




            }
            Console.Clear();
            if (((Tower)_map._map[3, 0]).Health == 0)
                Console.WriteLine("Red win");
            else
                Console.WriteLine("Blue win");
            Console.ReadKey();
        }
        private void CreatureAction(Creature creature, Player player, int previousY, int previousX)
        {
            bool choise = true;
            while (creature.CreatureMovement && choise)
            {
                ConsoleKey pressed = Console.ReadKey().Key;
                switch (pressed)
                {

                    case ConsoleKey.Spacebar:
                        if (_map._map[player.CursorPosition("Y"), player.CursorPosition("X")] is Creature)
                        {
                            if (((Creature)_map._map[player.CursorPosition("Y"), player.CursorPosition("X")]).team != player.Team)
                            {
                                creature.Attack((Creature)_map._map[player.CursorPosition("Y"), player.CursorPosition("X")], creature.GetCoord("Y"), creature.GetCoord("X"), player.CursorPosition("Y"), player.CursorPosition("X"));
                                if (((Creature)_map._map[player.CursorPosition("Y"), player.CursorPosition("X")]).Health == 0)
                                    _map._map[player.CursorPosition("Y"), player.CursorPosition("X")] = new EmptyCell();


                            }
                        }
                        else if (_map._map[player.CursorPosition("Y"), player.CursorPosition("X")] is Tower)
                        {
                            if (((Tower)_map._map[player.CursorPosition("Y"), player.CursorPosition("X")]).team != player.Team)
                                creature.Attack((Tower)_map._map[player.CursorPosition("Y"), player.CursorPosition("X")], creature.GetCoord("Y"), creature.GetCoord("X"), player.CursorPosition("Y"), player.CursorPosition("X"));
                        }
                        else
                            creature.Move(creature.GetCoord("Y"), creature.GetCoord("X"), player.CursorPosition("Y"), player.CursorPosition("X"));
                        if (!((creature.GetCoord("Y") == previousY) && (creature.GetCoord("X") == previousX)))
                        {
                            _map._map[creature.GetCoord("Y"), creature.GetCoord("X")] = creature;
                            _map._map[previousY, previousX] = new EmptyCell();
                        }
                        break;
                    case ConsoleKey.Escape:
                        choise = false;
                        break;
                    default:
                        Cursor(player,pressed);
                        break;
                }
                //Console.Clear();
                Draw(player);
            }
        }
        private void Store(Player player)
        {
            Console.Clear();
            Draw(player);
            int priceMusketeer = 60;
            int priceGhostKnight = 40;
            int priceGiantOrc = 100;
            Console.SetCursorPosition(1,_mapWidth * _cellWidth+1 );
            Console.WriteLine($"Coins: {player.Coins}");
            Console.WriteLine($"\n1-Cannon ({priceMusketeer})\n2-Ghost Knight ({priceGhostKnight})\n3-Giant Orc ({priceGiantOrc})\n");
            ConsoleKey pressed = Console.ReadKey().Key;
            int place;
            switch (pressed)
            {
                case ConsoleKey.D1:
                    if (player.Coins >= priceMusketeer)
                    {
                        place = LandingPlace(player,(int)player.Team);
                        if (place != -1)
                        {
                            _map._map[place, (int)player.Team] = new Cannon(place, (int)player.Team);
                            ((Cannon)_map._map[place, (int)player.Team]).team = player.Team;
                            player.Coins -= priceMusketeer;
                        }
                    }
                    break;
                case ConsoleKey.D2:
                    if (player.Coins >= priceGhostKnight)
                    {
                        place = LandingPlace(player,(int)player.Team);
                        if (place != -1)
                        {
                            _map._map[place, (int)player.Team] = new GhostKnight(place, (int)player.Team);
                            ((GhostKnight)_map._map[place, (int)player.Team]).team = player.Team;
                            player.Coins -= priceGhostKnight;
                        }
                    }
                    break;
                case ConsoleKey.D3:
                    if (player.Coins >= priceGiantOrc)
                    {
                        place = LandingPlace(player,(int)player.Team);
                        if (place != -1)
                        {
                            _map._map[place, (int)player.Team] = new GiantOrc(place, (int)player.Team);
                            ((GiantOrc)_map._map[place, (int)player.Team]).team = player.Team;
                            player.Coins -= priceGiantOrc;
                        }
                    }
                    break;  
            }
            Console.Clear();
        }
        private int LandingPlace(Player player,int startingPoint)
        { 
            while (true)
            {
                Console.SetCursorPosition(89, 3);
                Console.WriteLine("Escape-Back");
                ConsoleKey pressed = Console.ReadKey().Key;
                switch (pressed)
                {
                    case ConsoleKey.Spacebar:
                        if ((_map._map[player.CursorPosition("Y"), player.CursorPosition("X")] is EmptyCell) && (player.CursorPosition("X") == startingPoint))
                        {
                            int start = player.CursorPosition("Y");
                            return start;
                        }
                        break;
                    case ConsoleKey.Escape:
                        return -1;
                    default:
                        Cursor(player,pressed);
                        break;
                }
                //Console.Clear();
                Draw(player);
            }
        }
        private void Draw(Player player)
        {
            
            _map.Draw();
            player.DrawCursor(_mapLength, _cellLength, _cellWidth);


            Console.SetCursorPosition(_mapLength * _cellLength + 5, 1);
            if (player.Team == Team.Blue)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("BLUE MOVE");
                Console.SetCursorPosition(_mapLength * _cellLength + 5, 4);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write($"{_bonus  - (_NMove / 2+1) % _bonus} moves left to get a hundred coins");

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write("RED MOVE");
                Console.SetCursorPosition(_mapLength * _cellLength + 5, 4);
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write($"{_bonus - (_NMove / 2) % _bonus } moves left to get a hundred coins");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(_mapLength * _cellLength + 5, 2);
            Console.Write("B - Store");
            Console.SetCursorPosition(_mapLength * _cellLength + 5, 3);
            Console.Write("Enter - End the move");
            
        }
    }
}
