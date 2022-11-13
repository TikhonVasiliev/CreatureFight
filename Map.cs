using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureFight
{
    public class Map
    {
        public IObjectGame[,] _map;
        private int _mapLength;
        private int _mapWidth;
        private int _cellLength;
        private int _cellWidth;

        
        public Map(int mapLength, int mapWidth,int cellLength, int cellWidth)
        {
            _mapLength = mapLength;
            _mapWidth = mapWidth;
            _cellLength = cellLength; 
            _cellWidth = cellWidth;

            _map = new IObjectGame[_mapLength, _mapWidth];

            for (int i = 0; i < _mapLength; i++)
            {
                for (int j = 0; j < _mapWidth; j++)
                {
                    _map[i, j] = new EmptyCell();
                }
            }
            _map[3, 0] = new Tower(Team.Blue);
            _map[3, 6] = new Tower(Team.Red);
        }
        public void Draw()
        {
            for (int i = 0; i < _mapWidth; i++)
            {
                for (int j = 0; j < _mapLength; j++)
                {
                    _map[_mapLength - i - 1, j].Draw(i * _cellWidth + 1, j * _cellLength + 1);
                }
            }
        }
    }
    
}
