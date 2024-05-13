## Description

The C# checkers game project is a console-based implementation of the classic game of checkers. It allows a player to play against a computer opponent. The game follows standard checkers rules, where players take turns moving their pieces diagonally across the board, aiming to capture their opponent's pieces and ultimately, to reach the opponent's back row.
<p align="center">
  <img width="500px" alt="checkers board" src="https://github.com/PiotrStus/TextGame/assets/158161675/691dbb28-8f87-4ad2-889b-30ade4af0fa5">
</p>

## Class diagram 
<p align="center">
  <img width="500px" alt="class diagram" src="https://github.com/PiotrStus/Checkers/assets/158161675/65a836bd-feeb-4c40-be56-15b4694cc3d1">
</p>

## Video
<p align="center">
  <a href="https://www.youtube.com/watch?v=2-mso4g1fLw">
    <img src="https://img.youtube.com/vi/2-mso4g1fLw/0.jpg" alt="Tekst alternatywny">
  </a>
</p>

## Features

1. **Game Initialization:** The game initializes with an 8x8 checkerboard, where each player starts with 12 checkers positioned on alternating dark squares.

2. **Player vs. Computer:** Players can play against the computer AI. The AI utilizes a basic algorithm to make its moves, focusing on capturing opponent pieces if possible.

3. **Input Validation:** The game validates user input to ensure that players select valid moves and positions during their turns.

4. **End Game Detection:** The game accurately detects the end of the game, either when a player can no longer make valid moves or when one player has captured all of the opponent's pieces.

5. **Clear Console Interface:** The console interface is cleared after each move, providing a clean and intuitive user experience.

6. **Input Method:** Players interact with the game through the console interface, using keyboard input to select their moves.

7. **Basic Algorithm:** The computer opponent utilizes a basic algorithm to determine its moves, prioritizing capturing opponent pieces if available.

8. **Randomization:** Randomization is used in selecting moves for the computer opponent when multiple options are available.

## Requirements

To run the game, follow these steps:

1. Clone the repository or download the code.
2. Open the project in a C# compatible IDE (e.g., Visual Studio).
3. Compile the project.
4. Run the application.

## Future Additions / Potential Enhancements:

1. **Multiple Captures:** Implement the ability for multiple captures, allowing players to continue their moves from the same square after completing the initial capture.

2. **King Logic:** Enhance the game logic to include king pieces, enabling movement in any direction across the board and the ability to make multiple moves in a single turn.
