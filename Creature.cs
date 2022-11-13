using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureFight
{
    public abstract class Creature : IObjectGame
    {
        //protected int winKnight, winOrc, winDragon, iceWizard, fireWizard;
        private int _health, _damage, _rangeAttack, _rangeMotion;
        protected Coords _creatureCoords;
        private bool _creatureMovement;
        public bool CreatureMovement
        {
            get => _creatureMovement;
            set
            {
                _creatureMovement = value;
            }
        }
        public int Health
        {
            get => _health;
            set
            {
                _health = value;
                if (_health < 0)
                    _health = 0;
            }
        }
        //public int Price
        //{
        //    get => _price;
        //    set
        //    {
        //        _price = value;
        //    }
        //}
        public int Damage
        {
            get => _damage;
            protected set
            {
                if (value >= 0)
                    _damage = value;
            }
        }
        public int RangeAttack
        {
            get => _rangeAttack;
            protected set
            {
                if (value >= 0)
                    _rangeAttack = value;
            }
        }
        public int RangeMotion
        {
            get => _rangeMotion;
            protected set
            {
                if (value >= 0)
                    _rangeMotion = value;
            }
        }

        private Team _team;
        public Team team
        {
            get => _team;
            set
            {
                _team = value;
            }
        }

        public Creature(int y, int x)
        {
            _creatureMovement = false;
            _creatureCoords._x = x;
            _creatureCoords._y = y;
        }

        public int GetCoord(string coordName)
        {
            switch (coordName)
            {
                case "X":
                    return _creatureCoords._x;
                case "Y":
                    return _creatureCoords._y;
                default:
                    throw new Exception("Неверное название координаты");

            }
        }
        public void Attack(IObjectGame enemy,int ySource, int xSource, int yEnemy, int xEnemy)
        {
            if (enemy is Creature)
            {
                if ((Math.Abs(xSource - xEnemy) <= RangeAttack) && (Math.Abs(ySource - yEnemy) <= RangeAttack))
                {
                    ((Creature)enemy).Health -= Damage;
                    _creatureMovement = false;
                }
            }
            else
            {
                if ((Math.Abs(xSource - xEnemy) <= RangeAttack) && (Math.Abs(ySource - yEnemy) <= RangeAttack))
                {
                    ((Tower)enemy).Health -= Damage;
                    _creatureMovement = false;
                }
            }
        }
        public void Move(int ySource, int xSource, int yPlace, int xPlace)
        {
            if ((Math.Abs(xSource - xPlace) <= RangeMotion) && (Math.Abs(ySource - yPlace) <= RangeMotion))
            {
                _creatureCoords._x = xPlace;
                _creatureCoords._y = yPlace;
                _creatureMovement = false;
            }
                
        }

        public abstract void Draw(int positionY, int positionX);
    }
}
