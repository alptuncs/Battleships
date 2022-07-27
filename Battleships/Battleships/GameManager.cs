﻿using System;
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
        }

        public void Initialize()
        {
            foreach (ITarget target in Targets)
            {
                computerBoard.PlaceShip(5 - target.Size, target);
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

            FireMissile(computerBoard, new Coordinate(int.Parse(playerInput[0]) - 1, int.Parse(playerInput[1]) - 1));
            EndTurn();
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
                computerBoard.RemoveShip(coordinate);
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
            else if (computerBoard.ShipCoordinates.Count == 0)
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
            console.Clear();
            console.WriteLine($"Lives: {PlayerLives}    Score: {Score} \n");
            console.WriteLine(boardRenderer.Render(computerBoard, true));
            console.WriteLine(Message);
        }
    }
}
