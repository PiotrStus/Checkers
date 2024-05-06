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
            // mapper = new CoordinateMapper();
            InitialBoard();
            DrawBoard();
            InitializeCoordinateMap();
            //int player1NumberOfCheckers = CheckPlayersCheckers('o');
            //Console.WriteLine(player1NumberOfCheckers);
            //int player2NumberOfCheckers = CheckPlayersCheckers('x');
            //Console.WriteLine(player2NumberOfCheckers);

            //Console.WriteLine("Positions of player1: ");
            //CheckPositionsOfCheckers(player1, 'o');
            //Console.WriteLine("Positions of computer: ");
            //CheckPositionsOfCheckers(computer, 'x');
            //Console.WriteLine("dupa123\n");
            //GetPossibleMovesForChecker(player1);

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
        private void DrawBoard()
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
        public void CheckPositionsOfCheckers(Player player, char playerSymbol)
        {
            for (int row = 0; row < NumberOfColumns; row++)
            {
                for (int column = 0; column < NumberOfRows; column++)
                {
                    if (CheckerBoard[row, column] == playerSymbol)
                    {
                        if (!player.PositionsOfCheckers.Contains((row, column)))
                        player.Add((row, column));
                    }
                }
            }
            foreach (var newPlayerC in player.PositionsOfCheckers)
            {
                //Console.WriteLine($"{newPlayerC.ToString()}: {GetIndex(newPlayerC)}");
                Console.Write($"{GetIndex(newPlayerC)}, ");
            }
        }
        public void GetPossibleMovesForChecker(Player player)
        {
            foreach (var checkerPosition in player.PositionsOfCheckers)
            {
                //Console.WriteLine("n123_DUPA_123");
                //Console.WriteLine("sprawdzana pozycja: " + checkerPosition);
                //Console.WriteLine(checker.row);
                //Console.WriteLine(checker.column);
                //Console.WriteLine("123_DUPA_123");
                //Console.WriteLine("Sprawdzanie wiersz +1 i kolumna +1");
                List<(int, int)> possibleMoves = new List<(int, int)>();
                if (checkerPosition.row + 1 < NumberOfRows && checkerPosition.column + 1 < NumberOfColumns)
                {
                    //Console.WriteLine($"Sprawdzane wolne miejsce: {checkerPosition.row + 1}, {checkerPosition.column + 1}");
                    if ((CheckerBoard[checkerPosition.row + 1, checkerPosition.column + 1] != 'o') && (CheckerBoard[checkerPosition.row + 1, checkerPosition.column + 1] != 'x'))
                    {
                        //Console.WriteLine("wolne");
                        if (!possibleMoves.Contains((checkerPosition.row + 1, checkerPosition.column + 1)))
                        possibleMoves.Add((checkerPosition.row + 1, checkerPosition.column + 1));
                    }
                    //else
                    //Console.WriteLine("zajete");
                    //Console.WriteLine("Sprawdzanie wiersz +1 i kolumna -1");
                    //Console.WriteLine($"Sprawdzane wolne miejsce: {checkerPosition.row + 1}, {checkerPosition.column - 1}");
                    if (checkerPosition.row + 1 < NumberOfRows && checkerPosition.column - 1 >= 0)
                    {
                        if ((CheckerBoard[checkerPosition.row + 1, checkerPosition.column - 1] != 'o') && (CheckerBoard[checkerPosition.row + 1, checkerPosition.column - 1] != 'x'))
                        {
                            //Console.WriteLine("wolne");
                            if (!possibleMoves.Contains((checkerPosition.row + 1, checkerPosition.column - 1)))
                                possibleMoves.Add((checkerPosition.row + 1, checkerPosition.column - 1));
                        }
                        //else
                        //Console.WriteLine("zajete");
                    }
                    //else
                    //Console.WriteLine("poza indeksem");
                }
                player.AddPossibleMove(checkerPosition, possibleMoves);
                //Console.WriteLine("Koniec \n");
            }
        }
        public void GetPossibleMoveForSpecificChecker(Player player, (int row, int col) currentPosition)
        {
            if (player.PossibleMoves.ContainsKey(currentPosition))
            {
                List<(int, int)> possibleMoves = player.PossibleMoves[currentPosition];
                foreach (var move in possibleMoves)
                {
                    Console.Write($"{GetIndex(move)}, ");
                }
                Console.WriteLine();
            }
        }
        public void MoveChecker((int currentRow, int currentColumn) currentPosition, (int newRow, int newColumn) newPosition)
        {

        }
    }
}
