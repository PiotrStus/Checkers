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
            //CoordinateMapper mapper = new CoordinateMapper();
            while (true)
            {
                Console.WriteLine("\nPlayer1 'o' checkers positions: ");
                board.CheckPositionsOfCheckers(player1, 'o');
                board.GetPossibleMovesForChecker(player1);
                Console.Write("\nSelect a checker to move: ");
                string inputCurrentIndex = Console.ReadLine();
                //(int currentRow, int currentColumn) currentPosition = mapper.GetCoordinates($"{inputCurrentIndex.ToUpper()}");
                (int currentRow, int currentColumn) currentPosition = board.GetCoordinates($"{inputCurrentIndex.ToUpper()}");
                //Console.WriteLine($"{inputCurrentIndex}: {currentPosition}");
                //GameTest();
                //Console.WriteLine();
                string currentPositionReturned = board.GetIndex(currentPosition);
                //Console.WriteLine(currentPositionReturned);
                Console.WriteLine($"\nPossible move for {currentPositionReturned}:");
                board.GetPossibleMoveForSpecificChecker(player1, currentPosition);

                Console.Write("Press any key to continue...");
                Console.ReadLine();
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
