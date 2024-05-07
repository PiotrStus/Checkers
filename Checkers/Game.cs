using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Checkers
{
    internal class Game
    {
        Player player1 = new Player('o');
        Player computer = new Player('x');
        Board board;
        public void GameInit()
        {
            board = new Board(8, 8, player1, computer);
            while (true)
            {
                board.DrawBoard();
                player1.NumberOfCheckers = board.CheckPlayersCheckers(player1.PlayerSymbol);
                Console.WriteLine($"\nplayer1.NumberOfCheckers: {player1.NumberOfCheckers}");

                // new
                computer.NumberOfCheckers = board.CheckPlayersCheckers(computer.PlayerSymbol);
                Console.WriteLine($"\ncomputer.NumberOfCheckers: {computer.NumberOfCheckers}");
                // new

                Console.WriteLine("\nPlayer1 'o' checkers positions: ");
                board.CheckPositionsOfCheckers(player1);
                board.GetPossibleMovesForChecker(player1);

                // new
                Console.WriteLine("\n\nComputer 'x' checkers positions:");
                board.CheckPositionsOfCheckers(computer);
                board.GetPossibleMovesForChecker(computer);
                Console.WriteLine();
                // new

                //Player 1 - checker to move
                    Console.Write("\nSelect a checker to move: ");
                    string inputCurrentIndex = Console.ReadLine();
                    (int currentRow, int currentColumn) currentPosition = board.GetCoordinates($"{inputCurrentIndex.ToUpper()}");
                    string currentPositionReturned = board.GetIndex(currentPosition);
                    Console.WriteLine($"\nPossible move for {currentPositionReturned}:");
                bool possibleMoves = board.GetPossibleMoveForSpecificChecker(player1, currentPosition);

                if (possibleMoves)
                {
                    Console.Write("\nSelect a new position: ");
                    string inputNewIndex = Console.ReadLine();
                    (int newRow, int newPos) newPosition = board.GetCoordinates($"{inputNewIndex.ToUpper()}");
                    //Console.WriteLine(newPosition);
                    board.MoveCheckerTest(player1, currentPosition, newPosition);
                    board.DrawBoard();
                }
                //Computer - checker to move
                Console.Write("\nSelect a checker to move for computer: ");
                string inputCurrentIndex2 = Console.ReadLine();
                (int currentRow2, int currentColumn2) currentPosition2 = board.GetCoordinates($"{inputCurrentIndex2.ToUpper()}");
                //Console.WriteLine(currentPosition2);

                string currentPositionReturned2 = board.GetIndex(currentPosition2);
                Console.WriteLine($"\nPossible move for {currentPositionReturned2}:");
                bool possibleMoves2 = board.GetPossibleMoveForSpecificChecker(computer, currentPosition2);
                if (possibleMoves2)
                {
                    Console.Write("\nSelect a new position: ");
                    string inputNewIndex2 = Console.ReadLine();
                    (int newRow2, int newCol2) newPosition2 = board.GetCoordinates($"{inputNewIndex2.ToUpper()}");
                    //Console.WriteLine(newPosition2);
                    board.MoveCheckerTest(computer, currentPosition2, newPosition2);
                    board.DrawBoard();
                }

                //Console.WriteLine("----------------test----------------");
                //foreach (var dupa in computer.PossibleMoves)
                //{
                //   Console.WriteLine($"key: {dupa.Key}");
                //   Console.WriteLine($"values:");
                //    foreach (var move in dupa.Value)
                //    {
                //        Console.WriteLine(move);
                //    }
                //}
                //Console.WriteLine("----------------test----------------");
                Console.Write("Press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
