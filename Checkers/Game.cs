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
        bool gameOn = true;
        /// <summary>
        /// Main logic for checker's game
        /// </summary>
        public void GameOn()
        {
            board = new Board(8, 8, player1, computer);
            while (gameOn)
            {
                GameInit();
                //Player 1 - checker to move
                PlayerLogic();
                //Computer - checker to move
                ComputerLogic();
            }
            Console.Clear();
            Console.WriteLine("---------------------- GAME OVER ----------------------");
    }
        /// <summary>
        /// Game initialization.
        /// </summary>
        public void GameInit()
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
        }
        /// <summary>
        /// Logic for the computer.
        /// </summary>
        public void ComputerLogic()
        {
            var keysWithValuesMoves = new List<(int, int)>();
            var keysWithValuesCaptures = new List<(int, int)>();
            board.CheckPositionsOfCheckers(player1);
            board.GetPossibleMovesForChecker(player1);
            Console.WriteLine();
            board.CheckPositionsOfCheckers(computer);
            board.GetPossibleMovesForChecker(computer);
            keysWithValuesMoves = computer.PossibleMoves.Where(pair => pair.Value.Count > 0).Select(pair => pair.Key).ToList();
            keysWithValuesCaptures = computer.PossibleCaptures.Where(pair => pair.Value.Count > 0).Select(pair => pair.Key).ToList();
            (int, int) randomKey = (0, 0);
            (int, int) randomValue = (0, 0);
            List<(int, int)> correspondingValues = new List<(int, int)>();
            if (keysWithValuesCaptures.Count > 0)
            {

                randomKey = keysWithValuesCaptures[random.Next(keysWithValuesCaptures.Count)];
                correspondingValues = computer.PossibleCaptures[randomKey];
                if (correspondingValues.Count > 0)
                {
                    randomValue = correspondingValues[random.Next(correspondingValues.Count)];
                    board.MoveChecker(computer, player1, randomKey, randomValue);
                }
            }
            else if (keysWithValuesMoves.Count > 0)
            {
                randomKey = keysWithValuesMoves[random.Next(keysWithValuesMoves.Count)];
                correspondingValues = computer.PossibleMoves[randomKey];
                if (correspondingValues.Count > 0)
                {
                    randomValue = correspondingValues[random.Next(correspondingValues.Count)];
                    board.MoveChecker(computer, player1, randomKey, randomValue);
                }
            }
            else if ((computer.PossibleMoves.Count <= 0 && computer.PossibleCaptures.Count <= 0) || computer.NumberOfCheckers <= 0)
                gameOn = false;
            Console.Clear();
        }
        /// <summary>
        /// Logic for a player.
        /// </summary>
        public void PlayerLogic()
        {
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
            Console.Write($"\nPossible move for {currentPositionReturned}: ");
            List<string> possibleMoves = new List<string>();
            possibleMoves = board.GetPossibleMoveForSpecificChecker(player1, currentPosition);
            while (possibleMoves.Count <= 0)
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
                Console.Write($"\nPossible move for {currentPositionReturned}: ");
                possibleMoves = board.GetPossibleMoveForSpecificChecker(player1, currentPosition);
            }
            Console.Write("\nSelect a new position: ");
            string inputNewIndex = Console.ReadLine().ToUpper();
            while (!possibleMoves.Contains(inputNewIndex))
            {
                Console.Clear();
                board.DrawBoard();
                Console.WriteLine("\nWrong position!.");
                Console.Write($"\nPossible move for {currentPositionReturned}: ");
                possibleMoves = board.GetPossibleMoveForSpecificChecker(player1, currentPosition);
                Console.Write("\nSelect a new position: ");
                inputNewIndex = Console.ReadLine().ToUpper();
            }
            (int newRow, int newPos) newPosition = board.GetCoordinates($"{inputNewIndex.ToUpper()}");
            board.MoveChecker(player1, computer, currentPosition, newPosition);
            Console.Clear();
            board.DrawBoard();
            if ((player1.PossibleMoves.Count <= 0 && player1.PossibleCaptures.Count <= 0) || player1.NumberOfCheckers <= 0)
                gameOn = false;
        }
    }
}
