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
        Player player2 = new Player('x');
        Board board;
        public void GameInit()
        {
            board = new Board(8, 8, player1, player2);
            while (true)
            {
                board.DrawBoard();
                player1.NumberOfCheckers = board.CheckPlayersCheckers(player1.PlayerSymbol);
                Console.WriteLine($"\nplayer1.NumberOfCheckers: {player1.NumberOfCheckers}");
                Console.WriteLine("\nPlayer1 'o' checkers positions: ");
                board.CheckPositionsOfCheckers(player1, 'o');
                board.GetPossibleMovesForChecker(player1);
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
                    (int currentRow, int currentColumn) newPosition = board.GetCoordinates($"{inputNewIndex.ToUpper()}");
                    Console.WriteLine(newPosition);
                    board.MoveCheckerTest(player1, currentPosition, newPosition);
                }

                Console.Write("Press any key to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public void GameTest()
        {
            player1.NumberOfCheckers = board.CheckPlayersCheckers(player1.PlayerSymbol);
            Console.WriteLine($"\nplayer1.NumberOfCheckers: {player1.NumberOfCheckers}");

            player2.NumberOfCheckers = board.CheckPlayersCheckers(player2.PlayerSymbol);
            Console.WriteLine($"player2.NumberOfCheckers: {player2.NumberOfCheckers}");



            Console.WriteLine("\nPlayer2 'x' checkers positions: ");
            board.CheckPositionsOfCheckers(player2, 'x');

            Console.WriteLine("\nTEST MOZLIWE RUCHY");
            board.GetPossibleMovesForChecker(player1);

            foreach (var pair in player1.PossibleMoves)
            {
                Console.WriteLine($"Pozycja pionka: {pair.Key}");
                Console.WriteLine("Lista możliwych ruchów:");
                foreach (var move in pair.Value)
                {
                    Console.WriteLine(move);
                }
            }
        }
    }
}
