using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    internal class Board
    {
        public int NumberOfRows { get; private set; }
        public int NumberOfColumns { get; private set; }

        public char[,] CheckerBoard { get; private set; }

        public Board(int numberOfRows, int numberOfColumns) 
        {
            NumberOfRows = numberOfRows;
            NumberOfColumns = numberOfColumns;
            CheckerBoard = new char[NumberOfRows, NumberOfColumns];
            InitialBoard();
            DrawBoard();
            int personCheckers = CheckPlayersCheckers('x');
            Console.WriteLine(personCheckers);
            int computerCheckers = CheckPlayersCheckers('o');
            Console.WriteLine(computerCheckers);

            Player newPlayer = new Player();
            Console.WriteLine("test test");
            if (CheckerBoard[4, 0] != 'o' && CheckerBoard[4, 0] != 'x')
            {
                Console.WriteLine("wolne");
            }
            for (int row = 0; row < numberOfColumns; row++)
            {
                for (int column = 0; column < numberOfRows; column++)
                {
                    if (CheckerBoard[row, column] == 'o')
                    {
                        Console.WriteLine("dupa123");
                        newPlayer.Add((row, column));
                    }
                }
            }
            foreach (var newPlayerC in newPlayer.PositionsOfCheckers)
            {
                Console.WriteLine(newPlayerC.ToString());
            }

        }

        private void InitialBoard ()
        {
            for (int row = 0; row < NumberOfRows; row++) 
            {
                for (int column = 0; column < NumberOfColumns; column++)
                {
                    if ((row+column) % 2 == 0)
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

        private int CheckPlayersCheckers(char p)
        {
            int count = 0;
            foreach (char c in CheckerBoard) 
            {
                if (c == p) count++;
            }
            return count;
        }

        private List<Move> CheckPossibleMoves(int row, int col, int player) 
        {
            int possibles = 0;
            List<Move> moves = new List<Move>();



            return moves;
        }

    }
}