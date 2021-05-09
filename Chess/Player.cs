using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Logic
{
    class Player
    {
        public string Name { get; private set; }
        public int Victorys { get; private set; } 
        public Figure[,] Field { get; private set; }
        public Sides Side { get; private set; }
        public Player(string name)
        {
            Name = name;
            Side = Sides.White;
        }
        public void AssignSide(Sides side)
        {
            Side = side;
        }
        public void AddVictorys()
        {
            Victorys++;
        }
    }
}
