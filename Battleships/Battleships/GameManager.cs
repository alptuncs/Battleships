using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Battleships
{
    public class GameManager
    {
        private IConsole console;
        private BoardManager _playerBoard;
        private BoardManager _computerBoard;
        private BoardRenderer _boardRenderer;
        private Coordinate _coordinates;
        List<Target> _targets = new List<Target>();
        private int playerLives = 30;
        private int score = 0;
        private int shipValue = 0;
        private int consecutiveHits = 0;
        private string message = "";
        public string Message => message;
        public bool GameStatus { get; private set; }
        public GameManager(IConsole console, BoardManager playerBoard, BoardManager computerBoard, BoardRenderer boardRenderer, List<Target> targets)
        {
            this.console = console;
            _playerBoard = playerBoard;
            _computerBoard = computerBoard;
            _boardRenderer = boardRenderer;
            _targets = targets;
            GameStatus = true;
        }
        public void Initialize()
        {
            foreach (Target target in _targets)
            {
                _computerBoard.PlaceShip(5 - target.Size, target);
                shipValue += target.Size * target.Size * (5 - target.Size);
            }
        }
        private void FireMissile(BoardManager board, Coordinate coordinates)
        {
            if (board.IsHit(coordinates))
            {
                message = "That coordinate has already been hit";
                playerLives--;
                consecutiveHits = 0;
            }
            else if (!board.HasShip(coordinates))
            {
                board.HitSquare(coordinates);
                message = "You missed...";
                playerLives--;
                consecutiveHits = 0;

            }
            else if (board.HasShip(coordinates))
            {
                board.HitSquare(coordinates);
                shipValue -= board.Board[coordinates.XPos][coordinates.YPos].shipType;
                consecutiveHits++;
                score += 100 * consecutiveHits;
                message = "Successful hit !";
            }
        }
        public void RenderGame()
        {
            console.Clear();
            console.WriteLine($"Lives: {playerLives}    Score: {score} \n");
            console.WriteLine(_boardRenderer.Render(_computerBoard, false));
            console.WriteLine($"{message} \n");
            SetDefaultGameMessage();
        }
        public void SetDefaultGameMessage()
        {
            if (GameStatus)
            {
                message = "Please enter the coordinates";
                console.WriteLine(message);
            }
        }
        public void UpdateGame(string optionalInput = "TakeUserInputForCoordinate")
        {
            if (GameStatus == false) return;
            if (optionalInput == "TakeUserInputForCoordinate")
            {
                Regex rx = new Regex(@"^\d{1,2},\d{1,2}$");
                string[] playerInput = new string[2];
                string stringPlayerInput = "";
                stringPlayerInput = console.ReadLine();
                playerInput = stringPlayerInput.Split(',');

                if (!rx.IsMatch(stringPlayerInput))
                {
                    message = "Wrong input";
                    return;
                }
                else if (int.Parse(playerInput[0]) <= 0 || int.Parse(playerInput[0]) > 10 || int.Parse(playerInput[1]) <= 0 || int.Parse(playerInput[1]) > 10)
                {
                    message = "Wrong input";
                    return;
                }

                _coordinates = new Coordinate(int.Parse(playerInput[0]) - 1, int.Parse(playerInput[1]) - 1);
                FireMissile(_computerBoard, _coordinates);
                if (playerLives == 0)
                {
                    message = "Out of lives...";
                    GameStatus = false;
                }
                else if (shipValue == 0)
                {
                    message = "You won !";
                    GameStatus = false;
                }
            }
            else
            {
                string[] givenInput = optionalInput.Split(',');

                _coordinates = new Coordinate(int.Parse(givenInput[0]) - 1, int.Parse(givenInput[1]) - 1);
                FireMissile(_computerBoard, _coordinates);
                if (playerLives == 0)
                {
                    message = "Out of lives...";
                    GameStatus = false;
                }
                else if (shipValue == 0)
                {
                    message = "You won !";
                    GameStatus = false;
                }

            }

        }
    }
}
