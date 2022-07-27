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
        private BoardManager computerBoard;
        private BoardRenderer boardRenderer;
        public List<ITarget> Targets { get; private set; }
        public int PlayerLives { get; private set; }
        public int Score { get; private set; }
        public int ShipValue { get; private set; }
        public int ConsecutiveHits { get; private set; }
        public string Message { get; private set; }
        public bool GameStatus { get; private set; }
        public GameManager(IConsole console, BoardManager computerBoard, BoardRenderer boardRenderer, List<ITarget> targets)
        {
            this.console = console;
            this.computerBoard = computerBoard;
            this.boardRenderer = boardRenderer;
            Targets = targets;
            GameStatus = true;
            Score = 0;
            ShipValue = 0;
            ConsecutiveHits = 0;
            PlayerLives = 30;
            Message = "" + "\n\n" + Messages.ENTER_COORDS;
        }
        public void Initialize()
        {
            foreach (ITarget target in Targets)
            {
                computerBoard.PlaceShip(5 - target.Size, target);
                ShipValue += target.Size * target.Size * (5 - target.Size);
            }
        }
        public void SetPlayerLives(int i)
        {
            PlayerLives = i;
        }
        public void UpdateGame(bool manualUpdate = false, string manualInput = "TakeUserInputForCoordinate")
        {
            if (GameStatus == false) return;
            if (!manualUpdate)
            {
                string userInput = TakeInput();
                if (!InputCheck(userInput)) return;

                string[] playerInput = userInput.Split(',');

                FireMissile(computerBoard, new Coordinate(int.Parse(playerInput[0]) - 1, int.Parse(playerInput[1]) - 1));
                if (PlayerLives == 0)
                {
                    Message = Messages.OUT_OF_LIVES;
                    GameStatus = false;
                }
                else if (ShipValue == 0)
                {
                    Message = Messages.YOU_WON;
                    GameStatus = false;
                }
            }
            else
            {
                string[] givenInput = manualInput.Split(',');
                FireMissile(computerBoard, new Coordinate(int.Parse(givenInput[0]) - 1, int.Parse(givenInput[1]) - 1));
                if (PlayerLives == 0)
                {
                    Message = Messages.OUT_OF_LIVES;
                    GameStatus = false;
                }
                else if (ShipValue == 0)
                {
                    Message = Messages.YOU_WON;
                    GameStatus = false;
                }
            }
        }
        private void FireMissile(BoardManager board, Coordinate coordinates)
        {

            if (board.IsHit(coordinates))
            {
                Message = Messages.SAME_COORD + "\n\n" + Messages.ENTER_COORDS;
                PlayerLives--;
                ConsecutiveHits = 0;
            }
            else if (!board.HasShip(coordinates))
            {
                board.HitSquare(coordinates);
                Message = Messages.HIT_MISSED + "\n\n" + Messages.ENTER_COORDS;
                PlayerLives--;
                ConsecutiveHits = 0;

            }
            else if (board.HasShip(coordinates))
            {
                board.HitSquare(coordinates);
                ShipValue -= board.Board[coordinates.XPos, coordinates.YPos].shipType;
                ConsecutiveHits++;
                Score += 100 * ConsecutiveHits;
                Message = Messages.HIT_SUCCESS + "\n\n" + Messages.ENTER_COORDS;
            }
        }
        public void RenderGame()
        {
            console.Clear();
            console.WriteLine($"Lives: {PlayerLives}    Score: {Score} \n");
            console.WriteLine(boardRenderer.Render(computerBoard, false));
            console.WriteLine(Message);
        }

        private string TakeInput()
        {
            return console.ReadLine();
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
    }
}
