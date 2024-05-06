using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    internal class Player
    {
        public char PlayerSymbol { get; private set; }
        public int NumberOfCheckers { get; set; }
        public List<(int row, int column)>? PositionsOfCheckers { get; private set; }
        public Dictionary<(int row, int col), List<(int, int)>> PossibleMoves { get; private set; }
        public void Add((int row, int column) position)
        {
            PositionsOfCheckers.Add(position);
        }

        public void AddPossibleMove((int row, int column) position, List<(int, int)> move)
        {
            if (!PossibleMoves.ContainsKey(position))
            {
                PossibleMoves[position] = new List<(int, int)>();
            }
            PossibleMoves[position].AddRange(move);
        }

        public Player(char playerSymbol)
        {
            PositionsOfCheckers = new List<(int row, int column)>();
            PossibleMoves = new Dictionary<(int row, int col), List<(int, int)>>();
            PlayerSymbol = playerSymbol;
        }
    }
}
