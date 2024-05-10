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
        public static Random random = new Random();
        public void GameInit()
        {
            board = new Board(8, 8, player1, computer);
            while (true)
            {
                board.DrawBoard();
                player1.NumberOfCheckers = board.CheckPlayersCheckers(player1.PlayerSymbol);
                Console.WriteLine($"\nPlayer - NumberOfCheckers: {player1.NumberOfCheckers}");
                computer.NumberOfCheckers = board.CheckPlayersCheckers(computer.PlayerSymbol);
                Console.WriteLine($"\nComputer - NumberOfCheckers: {computer.NumberOfCheckers}");
                Console.WriteLine("\nPlayer1 'o' checkers positions: ");
                board.CheckPositionsOfCheckers(player1);
                board.GetPossibleMovesForChecker(player1);
                Console.WriteLine("\n\nComputer 'x' checkers positions:");
                board.CheckPositionsOfCheckers(computer);
                board.GetPossibleMovesForChecker(computer);
                Console.WriteLine();
                //Player 1 - checker to move
                Console.Write("\nSelect a checker to move: ");
                string inputCurrentIndex = Console.ReadLine().ToUpper();
                while (!player1.CoordinatesOfCheckers.Contains(inputCurrentIndex))
                {
                    Console.Clear();
                    board.DrawBoard();
                    Console.WriteLine("\nPlayer1 'o' checkers positions: ");
                    board.CheckPositionsOfCheckers(player1);
                    Console.Write("\n\nThere is no checker 'o' at that position. Select a checker to move: ");
                    inputCurrentIndex = Console.ReadLine().ToUpper();
                }
                (int currentRow, int currentColumn) currentPosition = board.GetCoordinates($"{inputCurrentIndex.ToUpper()}");
                string currentPositionReturned = board.GetIndex(currentPosition);
                Console.WriteLine($"\nPossible move for {currentPositionReturned}:");
                bool possibleMoves = board.GetPossibleMoveForSpecificChecker(player1, currentPosition);
                while (!possibleMoves)
                {
                    Console.Clear();
                    board.DrawBoard();
                    Console.WriteLine("\nPlayer1 'o' checkers positions: ");
                    board.CheckPositionsOfCheckers(player1);
                    Console.Write("\n\nThere are no possible moves for the selected checker. Select another checker to move: ");
                    inputCurrentIndex = Console.ReadLine().ToUpper();
                    while (!player1.CoordinatesOfCheckers.Contains(inputCurrentIndex))
                    {
                        Console.Clear();
                        board.DrawBoard();
                        Console.WriteLine("\nPlayer1 'o' checkers positions: ");
                        board.CheckPositionsOfCheckers(player1);
                        Console.Write("\n\nThere is no checker 'o' at that position. Select a checker to move: ");
                        inputCurrentIndex = Console.ReadLine().ToUpper();
                    }
                    currentPosition = board.GetCoordinates($"{inputCurrentIndex.ToUpper()}");
                    currentPositionReturned = board.GetIndex(currentPosition);
                    Console.WriteLine($"\nPossible move for {currentPositionReturned}:");
                    possibleMoves = board.GetPossibleMoveForSpecificChecker(player1, currentPosition);
                }
                Console.Write("\nSelect a new position: ");
                string inputNewIndex = Console.ReadLine();
                (int newRow, int newPos) newPosition = board.GetCoordinates($"{inputNewIndex.ToUpper()}");
                board.MoveCheckerTest(player1, computer, currentPosition, newPosition);
                Console.Clear();
                board.DrawBoard();






                //Computer - checker to move
                //Console.Write("\nSelect a checker to move for computer: ");
                //string inputCurrentIndex2 = Console.ReadLine().ToUpper();
                //while (!computer.CoordinatesOfCheckers.Contains(inputCurrentIndex2))
                //{
                //    Console.Clear();
                //    board.DrawBoard();
                //    Console.WriteLine("\nComputer 'x' checkers positions: ");
                //    board.CheckPositionsOfCheckers(computer);
                //    Console.Write("\n\nThere is no checker 'x' at that position. Select a checker to move for computer: ");
                //    inputCurrentIndex2 = Console.ReadLine().ToUpper();
                //}
                //(int currentRow2, int currentColumn2) currentPosition2 = board.GetCoordinates($"{inputCurrentIndex2.ToUpper()}");
                //string currentPositionReturned2 = board.GetIndex(currentPosition2);
                //Console.WriteLine($"\nPossible move for {currentPositionReturned2}:");
                //bool possibleMoves2 = board.GetPossibleMoveForSpecificChecker(computer, currentPosition2);
                //while (!possibleMoves2)
                //{
                //    Console.Clear();
                //    board.DrawBoard();
                //    Console.WriteLine("\nComputer 'x' checkers positions: ");
                //    board.CheckPositionsOfCheckers(computer);
                //    Console.Write("\n\nThere are no possible moves for the selected checker. Select another checker to move: ");
                //    inputCurrentIndex2 = Console.ReadLine().ToUpper();
                //    while (!computer.CoordinatesOfCheckers.Contains(inputCurrentIndex2))
                //    {
                //        Console.Clear();
                //        board.DrawBoard();
                //        Console.WriteLine("\nComputer 'x' checkers positions: ");
                //        board.CheckPositionsOfCheckers(computer);
                //        Console.Write("\n\nThere is no checker 'x' at that position. Select a checker to move: ");
                //        inputCurrentIndex2 = Console.ReadLine().ToUpper();
                //    }
                //    currentPosition2 = board.GetCoordinates($"{inputCurrentIndex2.ToUpper()}");
                //    currentPositionReturned2 = board.GetIndex(currentPosition2);
                //    Console.WriteLine($"\nPossible move for {currentPositionReturned2}:");
                //    possibleMoves2 = board.GetPossibleMoveForSpecificChecker(computer, currentPosition2);
                //}
                //Console.Write("\nSelect a new position: ");
                //string inputNewIndex2 = Console.ReadLine();
                //(int newRow2, int newCol2) newPosition2 = board.GetCoordinates($"{inputNewIndex2.ToUpper()}");


                // TEST //
                Console.WriteLine("dupa");

                var keysWithValues = computer.PossibleMoves.Where(pair => pair.Value.Count > 0).Select(pair => pair.Key).ToList();
                foreach (var key in keysWithValues)
                {
                    Console.WriteLine(key);
                }
                if (keysWithValues.Count > 0)
                {
                    var randomKey = keysWithValues[random.Next(keysWithValues.Count)];
                    Console.WriteLine("dupa2");
                    Console.WriteLine($"randomKey: {randomKey}");

                    var correspondingValues = computer.PossibleMoves[randomKey];
                    foreach (var value in correspondingValues)
                    {
                        Console.WriteLine($"value: {value}");
                    }
                    //Console.WriteLine(correspondingValues);
                    if (correspondingValues.Count > 0)
                    {
                        var randomValue = correspondingValues[random.Next(correspondingValues.Count)];
                        Console.WriteLine("Wybrana losowa wartość:");
                        Console.WriteLine(randomValue);
                        board.MoveCheckerTest(computer, player1, randomKey, randomValue);
                    }
                }
                Console.WriteLine("dupa");
                Console.ReadLine();
                // TEST //



                Console.Clear();
                board.DrawBoard();
                //Console.Write("Press any key to continue...");
                //Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
