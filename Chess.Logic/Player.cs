using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Logic
{
    public class Player
    {
        public string Name { get; private set; }
        public int Victorys { get; private set; } = 0;
        public Figure[,] Field { get; private set; }
        public Sides Side { get; set; }
        public Player(string name)
        {
            Name = name;
            Side = Sides.White;
        }
        public void AddVictorys()
        {
            Victorys++;
        }
    }
}
