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
        public IMessage Message { get; private set; }
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
            Message = UpdateMessage(7);
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
                    Message = UpdateMessage(3);
                    GameStatus = false;
                }
                else if (ShipValue == 0)
                {
                    Message = UpdateMessage(4);
                    GameStatus = false;
                }
            }
            else
            {
                string[] givenInput = manualInput.Split(',');
                FireMissile(computerBoard, new Coordinate(int.Parse(givenInput[0]) - 1, int.Parse(givenInput[1]) - 1));
                if (PlayerLives == 0)
                {
                    Message = UpdateMessage(3);
                    GameStatus = false;
                }
                else if (ShipValue == 0)
                {
                    Message = UpdateMessage(4);
                    GameStatus = false;
                }
            }
        }
        private void FireMissile(BoardManager board, Coordinate coordinates)
        {

            if (board.IsHit(coordinates))
            {
                Message = UpdateMessage(0);
                PlayerLives--;
                ConsecutiveHits = 0;
            }
            else if (!board.HasShip(coordinates))
            {
                board.HitSquare(coordinates);
                Message = UpdateMessage(2);
                PlayerLives--;
                ConsecutiveHits = 0;

            }
            else if (board.HasShip(coordinates))
            {
                board.HitSquare(coordinates);
                ShipValue -= board.Board[coordinates.XPos, coordinates.YPos].shipType;
                ConsecutiveHits++;
                Score += 100 * ConsecutiveHits;
                Message = UpdateMessage(1);
            }
        }
        public void RenderGame()
        {
            console.Clear();
            console.WriteLine($"Lives: {PlayerLives}    Score: {Score} \n");
            console.WriteLine(boardRenderer.Render(computerBoard, false));
            console.WriteLine($"{Message.GetMessage()} \n");
            Message = UpdateMessage(8);
            console.WriteLine(Message.GetMessage());
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
                Message = UpdateMessage(5);
                return false;
            }

            if (int.Parse(playerInput[0]) <= 0 || int.Parse(playerInput[0]) > 10 || int.Parse(playerInput[1]) <= 0 || int.Parse(playerInput[1]) > 10)
            {
                Message = UpdateMessage(6);
                return false;
            }

            return true;
        }

        private IMessage UpdateMessage(int messageType)
        {
            return MessageFactory.Create(messageType);
        }
    }
}
