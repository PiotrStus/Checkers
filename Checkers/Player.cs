using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    internal class Player
    {
        public int NumberOfCheckers { get; set; }

        public List<(int row, int col)>? PositionsOfCheckers { get; private set; }

        public void Add((int row, int column) position)
        {
            PositionsOfCheckers.Add(position);
        }

        public Player()
        {
            PositionsOfCheckers = new List<(int row, int column)>();
        }
    }
}
