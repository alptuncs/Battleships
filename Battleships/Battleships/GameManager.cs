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
        private int shipValue = 500;
        private int consecutiveHits = 0;
        private string message = "";
        bool gameStatus = true;
        public GameManager(IConsole console, BoardManager playerBoard, BoardManager computerBoard, BoardRenderer boardRenderer, List<Target> targets)
        {
            this.console = console;
            _playerBoard = playerBoard;
            _computerBoard = computerBoard;
            _boardRenderer = boardRenderer;
            _targets = targets;
            InitializeComputerBoard();
        }
        public void InitializeComputerBoard()
        {
            foreach (Target target in _targets)
            {
                _computerBoard.RandomPlaceShip(5 - target.Size, target);
                shipValue += target.Size * target.Size * (5 - target.Size);
            }
        }
        public void Play()
        {

            do
            {
                RenderGame();
                UpdateGame();
            } while (gameStatus);
            RenderGame();
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
        private void RenderGame()
        {
            console.Clear();
            console.WriteLine($"Lives: {playerLives}    Score: {score} \n");
            console.WriteLine(_boardRenderer.Render(_computerBoard, true));
            console.WriteLine($"{message} \n");
            if (gameStatus)
            {
                console.WriteLine("Please enter the coordinates");
            }
        }
        private void UpdateGame()
        {
            if (gameStatus == false) return;

            Regex rx = new Regex(@"^\d{1,2},\d{1,2}");
            string[] playerInput = new string[2];
            string stringPlayerInput = "";
            stringPlayerInput = Console.ReadLine();
            playerInput = stringPlayerInput.Split(',');

            if (!rx.IsMatch(stringPlayerInput))
            {
                message = "Wrong input";
            }
            else if (int.Parse(playerInput[0]) < 0 || int.Parse(playerInput[0]) > 10 || int.Parse(playerInput[1]) < 0 || int.Parse(playerInput[1]) > 10)
            {
                message = "Wrong input";
            }
            else
            {
                _coordinates = new Coordinate(int.Parse(playerInput[0]) - 1, int.Parse(playerInput[1]) - 1);
                FireMissile(_computerBoard, _coordinates);
                if (playerLives == 0)
                {
                    message = "Out of lives...";
                    gameStatus = false;
                }
                else if (shipValue == 0)
                {
                    message = "You won !";
                    gameStatus = false;
                }

            }
        }
    }
}
