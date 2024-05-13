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
        /// <summary>
        /// Add a new checker to PositionsOfChecker list.
        /// </summary>
        /// <param name="position"></param>
        public void Add((int row, int column) position)
        {
            PositionsOfCheckers.Add(position);
        }
        /// <summary>
        /// Prepare a new CoordinatesOfCheckers list.
        /// </summary>
        public void UpdateCoordinates()
        {
            CoordinatesOfCheckers.Clear();
        }
        /// <summary>
        /// Add a new coordinate for a checker.
        /// </summary>
        /// <param name="position"></param>
        public void CheckCoordinates(string position)
        {
            CoordinatesOfCheckers.Add(position);
        }
        /// <summary>
        /// Remove a checker from the position.
        /// </summary>
        /// <param name="position"></param>
        public void Remove((int row, int column) position)
        {
            PositionsOfCheckers.Remove(position);
        }
        /// <summary>
        /// Fill PossibleMoves dictionary with all possible position for a speficic checker's possition.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="move"></param>
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
        /// <summary>
        /// Fill PossibleCaptures dictionary with all possible position for a speficic checker's possition.
        /// </summary>
        /// <param name="position"></param>
        /// <param name="move"></param>
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
