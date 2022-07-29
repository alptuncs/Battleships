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
        public IConsole Console { get; private set; }
        public BoardManager ComputerBoard { get; private set; }
        public BoardRenderer BoardRenderer { get; private set; }
        public List<ITarget> Targets { get; private set; }
        public int PlayerLives { get; private set; }
        public int Score { get; private set; }
        public int ShipValue { get; private set; }
        public int ConsecutiveHits { get; private set; }
        public string Message { get; private set; }
        public bool GameStatus { get; private set; }

        public GameManager(IConsole console, BoardManager computerBoard, BoardRenderer boardRenderer, List<ITarget> targets)
        {
            Console = console;
            ComputerBoard = computerBoard;
            BoardRenderer = boardRenderer;
            Targets = targets;
        }

        public void Initialize()
        {
            foreach (ITarget target in Targets)
            {
                ComputerBoard.PlaceShip(5 - target.Size, target);
                ShipValue += target.Size * target.Size * (5 - target.Size);
            }

            GameStatus = true;
            Score = 0;
            ShipValue = 0;
            ConsecutiveHits = 0;
            PlayerLives = 30;
            Message = "" + "\n\n" + Messages.ENTER_COORDS;
        }

        public void SetPlayerLives(int i)
        {
            PlayerLives = i;
        }

        public void UpdateGame(bool manualUpdate = false, string manualInput = "TakeUserInputForCoordinate")
        {
            if (GameStatus == false) return;

            string[] playerInput;

            if (!manualUpdate)
            {
                string userInput = TakeInput();
                if (!InputCheck(userInput)) return;

                playerInput = userInput.Split(',');
            }
            else
            {
                playerInput = manualInput.Split(',');
            }

            FireMissile(ComputerBoard, new Coordinate(int.Parse(playerInput[0]) - 1, int.Parse(playerInput[1]) - 1));
            EndTurn();
        }

        private string TakeInput()
        {
            return Console.ReadLine();
        }

        private bool InputCheck(string input)
        {
            Regex rx = new Regex(@"^\d{1,2},\d{1,2}$");
            string stringPlayerInput = input;
            string[] playerInput = stringPlayerInput.Split(',');

            if (!rx.IsMatch(stringPlayerInput))
            {
                Message = Messages.WRONG_INPUT + "\n\n" + Messages.ENTER_COORDS;
                return false;
            }

            if (int.Parse(playerInput[0]) <= 0 || int.Parse(playerInput[0]) > 10 || int.Parse(playerInput[1]) <= 0 || int.Parse(playerInput[1]) > 10)
            {
                Message = Messages.OUT_OF_BOUND + "\n\n" + Messages.ENTER_COORDS;
                return false;
            }

            return true;
        }

        private void FireMissile(BoardManager board, Coordinate coordinate)
        {

            if (board.IsHit(coordinate) || !board.HasShip(coordinate))
            {
                Message = board.IsHit(coordinate) ? Messages.SAME_COORD : Messages.HIT_MISSED;
                PlayerLives--;
                ConsecutiveHits = 0;
            }
            else
            {
                ConsecutiveHits++;
                Score += 100 * ConsecutiveHits;
                ComputerBoard.RemoveShip(coordinate);
                Message = Messages.HIT_SUCCESS;
            }

            board.HitSquare(coordinate);
        }

        public void EndTurn()
        {
            if (PlayerLives == 0)
            {
                Message = Messages.OUT_OF_LIVES;
                GameStatus = false;
            }
            else if (ComputerBoard.ShipCoordinates.Count == 0)
            {
                Message = Messages.YOU_WON;
                GameStatus = false;
            }
            else
            {
                Message += "\n\n" + Messages.ENTER_COORDS;
            }
        }

        public void RenderGame()
        {
            Console.Clear();
            Console.WriteLine($"Lives: {PlayerLives}    Score: {Score} \n");
            Console.WriteLine(BoardRenderer.Render(ComputerBoard, true));
            Console.WriteLine(Message);
        }
    }
}
