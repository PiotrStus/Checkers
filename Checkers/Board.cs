using Checkers;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    internal class Board : CoordinateMapper
    {
        public int NumberOfRows { get; private set; }
        public int NumberOfColumns { get; private set; }
        public char[,] CheckerBoard { get; private set; }
        public Board(int numberOfRows, int numberOfColumns, Player player1, Player computer) : base(new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H' }, 8)
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            CheckerBoard = new char[NumberOfRows, NumberOfColumns];
            InitialBoard();
            InitializeCoordinateMap();
        }
        private void InitialBoard()
        {
            for (int row = 0; row < NumberOfRows; row++)
            {
                for (int column = 0; column < NumberOfColumns; column++)
                {
                    if ((row + column) % 2 == 0)
                    {
                        if (row < 3) CheckerBoard[row, column] = 'o';
                        else if (row > 4) CheckerBoard[row, column] = 'x';
                        else CheckerBoard[row, column] = '_';
                    }
                    else
                    {
                        CheckerBoard[row, column] = '_';
                    }
                }
            }
        }
        public void DrawBoard()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("    A B C D E F G H");
            Console.WriteLine("  -----------------");
            int columns = 1;
            for (int row = 0; row < NumberOfRows; row++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{columns} | ");
                columns++;
                for (int column = 0; column < NumberOfColumns; column++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(CheckerBoard[row, column] + " ");
                }
                Console.WriteLine();
            }
        }
        public int CheckPlayersCheckers(char p)
        {
            int count = 0;
            foreach (char c in CheckerBoard)
            {
                if (c == p) count++;
            }
            return count;
        }
        public void CheckPositionsOfCheckers(Player player)
        {
            for (int row = 0; row < NumberOfColumns; row++)
            {
                for (int column = 0; column < NumberOfRows; column++)
                {
                    if (CheckerBoard[row, column] == player.PlayerSymbol)
                    {
                        if (!player.PositionsOfCheckers.Contains((row, column)))
                            player.Add((row, column));
                    }
                }
            }
            player.UpdateCoordinates();
            foreach (var pos in player.PositionsOfCheckers)
            {
                Console.Write($"{GetIndex(pos)}, ");
                player.CheckCoordinates(GetIndex(pos));
            }
        }
        public void GetPossibleMovesForChecker(Player player)
        {
            foreach (var checkerPosition in player.PositionsOfCheckers)
            {
                List<(int, int)> possibleMoves = new List<(int, int)>();
                List<(int, int)> possibleCaptures = new List<(int, int)>();
                if (player.PlayerSymbol == 'o')
                {
                    // Checking forward, right
                    if (checkerPosition.row + 1 < NumberOfRows && checkerPosition.column + 1 < NumberOfColumns)
                    {
                        if (CheckerBoard[checkerPosition.row + 1, checkerPosition.column + 1] == '_')
                        {
                            if (!possibleMoves.Contains((checkerPosition.row + 1, checkerPosition.column + 1)))
                                possibleMoves.Add((checkerPosition.row + 1, checkerPosition.column + 1));
                        }
                        if (CheckerBoard[checkerPosition.row + 1, checkerPosition.column + 1] == 'x')
                        {
                            if (checkerPosition.row + 2 < NumberOfRows && checkerPosition.column + 2 < NumberOfColumns)
                            {
                                if (CheckerBoard[checkerPosition.row + 2, checkerPosition.column + 2] == '_')
                                {
                                    if (!possibleCaptures.Contains((checkerPosition.row + 2, checkerPosition.column + 2)))
                                    {
                                        possibleCaptures.Add((checkerPosition.row + 2, checkerPosition.column + 2));
                                    }
                                }
                            }
                        }

                    }
                    // Checking forward, left
                    if (checkerPosition.row + 1 < NumberOfRows && checkerPosition.column - 1 >= 0)
                    {
                        if ((CheckerBoard[checkerPosition.row + 1, checkerPosition.column - 1] == '_'))
                        {
                            if (!possibleMoves.Contains((checkerPosition.row + 1, checkerPosition.column - 1)))
                                possibleMoves.Add((checkerPosition.row + 1, checkerPosition.column - 1));
                        }
                        if (CheckerBoard[checkerPosition.row + 1, checkerPosition.column - 1] == 'x')
                        {
                            if (checkerPosition.row + 2 < NumberOfRows && checkerPosition.column - 2 >= 0)
                            {
                                if (CheckerBoard[checkerPosition.row + 2, checkerPosition.column - 2] == '_')
                                {
                                    if (!possibleCaptures.Contains((checkerPosition.row + 2, checkerPosition.column - 2)))
                                    {
                                        possibleCaptures.Add((checkerPosition.row + 2, checkerPosition.column - 2));
                                    }
                                }
                            }
                        }
                    }
                    // Checking backward,right
                    if (checkerPosition.row - 1 >= 0 && checkerPosition.column + 1 < NumberOfColumns)
                    {
                        if (CheckerBoard[checkerPosition.row - 1, checkerPosition.column + 1] == 'x')
                        {
                            if (checkerPosition.row - 2 >= 0 && checkerPosition.column + 2 < NumberOfColumns)
                            {
                                if (CheckerBoard[checkerPosition.row - 2, checkerPosition.column + 2] == '_')
                                {
                                    possibleCaptures.Add((checkerPosition.row - 2, checkerPosition.column + 2));
                                }
                            }
                        }
                    }
                    // Checking backward, left
                    if (checkerPosition.row - 1 >= 0 && checkerPosition.column - 1 >= 0)
                    {
                        if (CheckerBoard[checkerPosition.row - 1, checkerPosition.column - 1] == 'x')
                        {
                            if (checkerPosition.row - 2 >= 0 && checkerPosition.column - 2 >= 0)
                            {
                                if (CheckerBoard[checkerPosition.row - 2, checkerPosition.column - 2] == '_')
                                {
                                    possibleCaptures.Add((checkerPosition.row - 2, checkerPosition.column - 2));
                                }
                            }
                        }
                    }
                }
                else if (player.PlayerSymbol == 'x')
                {
                    // Checking backward, right
                    if (checkerPosition.row - 1 < NumberOfRows && checkerPosition.column + 1 < NumberOfColumns)
                    {
                        if (checkerPosition.row - 1 >= 0)
                        {
                            if (CheckerBoard[checkerPosition.row - 1, checkerPosition.column + 1] == '_')
                            {
                                if (!possibleMoves.Contains((checkerPosition.row - 1, checkerPosition.column + 1)))
                                    possibleMoves.Add((checkerPosition.row - 1, checkerPosition.column + 1));
                            }

                            if (CheckerBoard[checkerPosition.row - 1, checkerPosition.column + 1] == 'o')
                            {
                                if (checkerPosition.row - 2 < NumberOfRows && checkerPosition.column + 2 < NumberOfColumns && checkerPosition.row - 2 >= 0)
                                {
                                    if (CheckerBoard[checkerPosition.row - 2, checkerPosition.column + 2] == '_')
                                    {
                                        if (!possibleCaptures.Contains((checkerPosition.row - 2, checkerPosition.column + 2)))
                                        {
                                            possibleCaptures.Add((checkerPosition.row - 2, checkerPosition.column + 2));
                                        }
                                    }
                                }
                            }
                        }

                    }
                    // Checking backward, left
                    if (checkerPosition.row + 1 <= NumberOfRows && checkerPosition.column - 1 >= 0)
                    {
                        if (checkerPosition.row - 1 >= 0)
                        {
                            if ((CheckerBoard[checkerPosition.row - 1, checkerPosition.column - 1] == '_'))
                            {
                                if (!possibleMoves.Contains((checkerPosition.row - 1, checkerPosition.column - 1)))
                                    possibleMoves.Add((checkerPosition.row - 1, checkerPosition.column - 1));
                            }
                            else if (CheckerBoard[checkerPosition.row - 1, checkerPosition.column - 1] == 'o')
                            {
                                if (checkerPosition.row - 2 < NumberOfRows && checkerPosition.column - 2 >= 0 && checkerPosition.row - 2 >= 0)
                                {
                                    if (CheckerBoard[checkerPosition.row - 2, checkerPosition.column - 2] == '_')
                                    {
                                        if (!possibleCaptures.Contains((checkerPosition.row - 2, checkerPosition.column - 2)))
                                        {
                                            possibleCaptures.Add((checkerPosition.row - 2, checkerPosition.column - 2));
                                        }
                                    }
                                }
                            }
                        }
                    }
                    // Checking forward, right
                    if (checkerPosition.row + 1 < NumberOfRows && checkerPosition.column + 1 < NumberOfColumns)
                    {
                        if (CheckerBoard[checkerPosition.row + 1, checkerPosition.column + 1] == 'o')
                        {
                            if (checkerPosition.row + 2 < NumberOfRows && checkerPosition.column + 2 < NumberOfColumns)
                            {
                                if (CheckerBoard[checkerPosition.row + 2, checkerPosition.column + 2] == '_')
                                {
                                    possibleCaptures.Add((checkerPosition.row + 2, checkerPosition.column + 2));
                                }
                            }
                        }
                    }
                    // Checking forward, left
                    if (checkerPosition.row + 1 < NumberOfRows && checkerPosition.column - 1 >= 0)
                    {
                        if (CheckerBoard[checkerPosition.row + 1, checkerPosition.column - 1] == 'o')
                        {
                            if (checkerPosition.row + 2 < NumberOfRows && checkerPosition.column - 2 >= 0)
                            {
                                if (CheckerBoard[checkerPosition.row + 2, checkerPosition.column - 2] == '_')
                                {
                                    possibleCaptures.Add((checkerPosition.row + 2, checkerPosition.column - 2));
                                }
                            }
                        }
                    }
                }
                if (possibleMoves.Count > 0 ) 
                {
                    player.AddPossibleMove(checkerPosition, possibleMoves);
                }
                if (possibleCaptures.Count > 0)
                {
                    player.AddPossibleCapture(checkerPosition, possibleCaptures);
                }
            }
        }
        public List<string> GetPossibleMoveForSpecificChecker(Player player, (int row, int col) currentPosition)
        {
            List<string> possibleMovesCoordinates = new List<string>();
            if (player.PossibleCaptures.ContainsKey(currentPosition))
            {
                GetPossibleMovesForChecker(player);
                List<(int, int)> possibleCaptures = player.PossibleCaptures[currentPosition];
                if (possibleCaptures.Count > 0)
                {
                    foreach (var move in possibleCaptures)
                    {
                        Console.Write($"{GetIndex(move)}, ");
                        possibleMovesCoordinates.Add(GetIndex(move));
                    }
                    return possibleMovesCoordinates;
                }
                else
                {
                    Console.WriteLine("There are no possible moves.");
                    return possibleMovesCoordinates;
                }
            }
            else if (player.PossibleMoves.ContainsKey(currentPosition))
            {
                GetPossibleMovesForChecker(player);
                List<(int, int)> possibleMoves = player.PossibleMoves[currentPosition];
                if (possibleMoves.Count > 0)
                {
                    foreach (var move in possibleMoves)
                    {
                        Console.Write($"{GetIndex(move)}, ");
                        possibleMovesCoordinates.Add(GetIndex(move));
                    }

                    return possibleMovesCoordinates;
                }
                else
                {
                    Console.WriteLine("There are no possible moves.");
                    return possibleMovesCoordinates;
                }

            }
            Console.WriteLine();

            return possibleMovesCoordinates;
        }
        public void MoveCheckerTest(Player player, Player player2, (int currentRow, int currentColumn) currentPosition, (int newRow, int newColumn) newPosition)
        {
            if (!player.PositionsOfCheckers.Contains(newPosition))
            {
                player.Remove(currentPosition);
                CheckerBoard[newPosition.newRow, newPosition.newColumn] = player.PlayerSymbol;
                CheckerBoard[currentPosition.currentRow, currentPosition.currentColumn] = '_';
                //
                //if (currentPosition.currentRow + 1 < NumberOfRows && currentPosition.currentColumn - 1 >= 0)

                {
                    if (player.PlayerSymbol == 'o')
                    {
                        //capturing forward
                        if (currentPosition.currentRow + 1 < NumberOfRows && currentPosition.currentColumn >= 0)
                        {
                            if (currentPosition.currentColumn + 1 < NumberOfColumns && (CheckerBoard[currentPosition.currentRow + 1, currentPosition.currentColumn + 1] == 'x') && (newPosition.newColumn == (currentPosition.currentColumn + 2)))
                            {
                                    CheckerBoard[currentPosition.currentRow + 1, currentPosition.currentColumn + 1] = '_';
                                    player2.Remove((currentPosition.currentRow + 1, currentPosition.currentColumn + 1));
                            }
                            if (currentPosition.currentColumn - 1 >= 0 && (CheckerBoard[currentPosition.currentRow + 1, currentPosition.currentColumn - 1] == 'x') && (newPosition.newColumn == (currentPosition.currentColumn - 2)))
                            {
                                    CheckerBoard[currentPosition.currentRow + 1, currentPosition.currentColumn - 1] = '_';
                                    player2.Remove((currentPosition.currentRow + 1, currentPosition.currentColumn - 1));
                            }
                        }
                        //capturing backward
                        if (currentPosition.currentRow - 1 >= 0 && currentPosition.currentColumn >= 0)
                        {
                            if (currentPosition.currentColumn + 1 < NumberOfColumns && (CheckerBoard[currentPosition.currentRow - 1, currentPosition.currentColumn + 1] == 'x') && (newPosition.newColumn == (currentPosition.currentColumn + 2)))
                            {
                                CheckerBoard[currentPosition.currentRow - 1, currentPosition.currentColumn + 1] = '_';
                                player2.Remove((currentPosition.currentRow - 1, currentPosition.currentColumn + 1));
                            }
                            if (currentPosition.currentColumn - 1 >= 0 && (CheckerBoard[currentPosition.currentRow - 1, currentPosition.currentColumn - 1] == 'x') && (newPosition.newColumn == (currentPosition.currentColumn - 2)))
                            {
                                CheckerBoard[currentPosition.currentRow - 1, currentPosition.currentColumn - 1] = '_';
                                player2.Remove((currentPosition.currentRow - 1, currentPosition.currentColumn - 1));
                            }

                        }
                        player2.PossibleMoves.Clear();
                        player2.PossibleCaptures.Clear();
                        GetPossibleMovesForChecker(player2);
                    }
                    else if (player.PlayerSymbol == 'x')
                    {
                        // capturing forward
                        if (currentPosition.currentRow - 1 >= 0 && currentPosition.currentColumn >= 0)
                        {
                            if (currentPosition.currentColumn + 1 < NumberOfColumns && (CheckerBoard[currentPosition.currentRow - 1, currentPosition.currentColumn + 1] == 'o') && (newPosition.newColumn == (currentPosition.currentColumn + 2)))
                            {
                                    CheckerBoard[currentPosition.currentRow - 1, currentPosition.currentColumn + 1] = '_';
                                    player2.Remove((currentPosition.currentRow - 1, currentPosition.currentColumn + 1));
                            }
                            if (currentPosition.currentColumn - 1 >= 0 && (CheckerBoard[currentPosition.currentRow - 1, currentPosition.currentColumn - 1] == 'o') && (newPosition.newColumn == (currentPosition.currentColumn - 2)))
                            {
                                    CheckerBoard[currentPosition.currentRow - 1, currentPosition.currentColumn - 1] = '_';
                                    player2.Remove((currentPosition.currentRow - 1, currentPosition.currentColumn - 1));
                            }
                        }
                        // capturing backward
                        if (currentPosition.currentRow + 1 < NumberOfRows && currentPosition.currentColumn >= 0)
                        {
                            if (currentPosition.currentColumn + 1 < NumberOfColumns && (CheckerBoard[currentPosition.currentRow + 1, currentPosition.currentColumn + 1] == 'o') && (newPosition.newColumn == (currentPosition.currentColumn + 2)))
                            {
                                CheckerBoard[currentPosition.currentRow + 1, currentPosition.currentColumn + 1] = '_';
                                player2.Remove((currentPosition.currentRow + 1, currentPosition.currentColumn + 1));
                            }
                            if (currentPosition.currentColumn - 1 >= 0 && (CheckerBoard[currentPosition.currentRow + 1, currentPosition.currentColumn - 1] == 'o') && (newPosition.newColumn == (currentPosition.currentColumn - 2)))
                            {
                                CheckerBoard[currentPosition.currentRow + 1, currentPosition.currentColumn - 1] = '_';
                                player2.Remove((currentPosition.currentRow + 1, currentPosition.currentColumn - 1));
                            }
                        }
                        player2.PossibleMoves.Clear();
                        player2.PossibleCaptures.Clear();
                        GetPossibleMovesForChecker(player2);
                    }
                }
                player.Add(newPosition);
                player.PossibleMoves.Clear();
                player.PossibleCaptures.Clear();
                GetPossibleMovesForChecker(player);
            }
        }
    }
}
