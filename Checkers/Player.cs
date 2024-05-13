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
        public List<string>? CoordinatesOfCheckers { get; private set; }
        public Dictionary<(int row, int col), List<(int, int)>> PossibleMoves { get; private set; }
        public Dictionary<(int row, int col), List<(int, int)>> PossibleCaptures { get; private set; }
        public Player(char playerSymbol)
        {
            PositionsOfCheckers = new List<(int row, int column)>();
            PossibleMoves = new Dictionary<(int row, int col), List<(int, int)>>();
            PossibleCaptures = new Dictionary<(int row, int col), List<(int, int)>>();
            CoordinatesOfCheckers = new List<string>();
            PlayerSymbol = playerSymbol;
        }
        public void Add((int row, int column) position)
        {
            PositionsOfCheckers.Add(position);
        }
        public void UpdateCoordinates()
        {
            CoordinatesOfCheckers.Clear();
        }
        public void CheckCoordinates(string position)
        {
            CoordinatesOfCheckers.Add(position);
        }
        public void Remove((int row, int column) position)
        {
            PositionsOfCheckers.Remove(position);
        }
        public void AddPossibleMove((int row, int column) position, List<(int, int)> move)
        {
            if (!PossibleMoves.ContainsKey(position))
            {
                PossibleMoves[position] = new List<(int, int)>();
            }
            else
            {
                PossibleMoves[position].Clear();
            }
            PossibleMoves[position].AddRange(move);
        }
        public void AddPossibleCapture((int row, int column) position, List<(int, int)> move)
        {
            if (!PossibleCaptures.ContainsKey(position))
            {
                PossibleCaptures[position] = new List<(int, int)>();
            }
            else
            {
                PossibleCaptures[position].Clear();
            }
            PossibleCaptures[position].AddRange(move);
        }
    }
}
