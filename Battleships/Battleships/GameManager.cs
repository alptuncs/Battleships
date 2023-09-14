using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Battleships
{
    public class GameManager
    {
        public IConsole GameManagerConsole { get; private set; }
        public BoardManager ComputerBoard { get; private set; }
        public BoardRenderer BoardRenderer { get; private set; }
        public List<Target> Targets { get; private set; }
        public int PlayerLives { get; private set; }
        public int Score { get; private set; }
        public int ShipValue { get; private set; }
        public int ConsecutiveHits { get; private set; }
        public string? Message { get; private set; }
        public bool GameStatus { get; private set; }

        public GameManager(IConsole console, BoardManager computerBoard, BoardRenderer boardRenderer, List<Target> targets)
        {
            GameManagerConsole = console;
            ComputerBoard = computerBoard;
            BoardRenderer = boardRenderer;
            Targets = targets;
            Console.OutputEncoding = Encoding.UTF8;
        }

        public void Initialize()
        {
            GameStatus = true;
            Score = 0;
            ShipValue = 0;
            ConsecutiveHits = 0;
            PlayerLives = 30;
            Message = "" + "\n\n" + Messages.ENTER_COORDS;

            PlaceShips();

        }

        private void PlaceShips()
        {
            foreach (Target target in Targets)
            {
                ComputerBoard.PlaceShip(1, target);
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

            string[] playerInput;
            char[] playerInputChar;

            if (!manualUpdate)
            {
                string userInput = TakeInput().ToUpper();
                if (!InputCheck(userInput)) return;

                playerInput = userInput.Split(',');
                playerInputChar = playerInput[0].ToCharArray();
            }
            else
            {
                playerInput = manualInput.Split(',');
                playerInputChar = playerInput[0].ToCharArray();
            }

            FireMissile(ComputerBoard, new Coordinate(playerInputChar[0], int.Parse(playerInput[1]) - 1));
            EndTurn();
        }

        private string TakeInput()
        {
            return GameManagerConsole.ReadLine();
        }

        private bool InputCheck(string input)
        {
            Regex rx = new(@"^^[A-J]{1},\d{1,2}$");
            string stringPlayerInput = input.ToUpper();
            string[] playerInput = stringPlayerInput.Split(',');
            char[] playerInputChar = playerInput[0].ToCharArray();

            if (!rx.IsMatch(stringPlayerInput))
            {
                Message = Messages.WRONG_INPUT + "\n\n" + Messages.ENTER_COORDS;
                return false;
            }

            if (int.Parse(playerInput[1]) <= 0 || int.Parse(playerInput[1]) > 10 || playerInputChar[0] > 'J' || playerInputChar[0] < 'A')
            {
                Message = Messages.OUT_OF_BOUND + "\n\n" + Messages.ENTER_COORDS;
                return false;
            }

            return true;
        }

        private void FireMissile(BoardManager board, Coordinate coordinate)
        {

            if (board[coordinate].IsHit || !board[coordinate].HasShip)
            {
                Message = board[coordinate].IsHit ? Messages.SAME_COORD : Messages.HIT_MISSED;
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

            board[coordinate].HitSquare();
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
            GameManagerConsole.Clear();
            GameManagerConsole.WriteLine($"Lives: {PlayerLives}    Score: {Score} \n");
            string board = BoardRenderer.Render(ComputerBoard);

            for (int i = 0; i < board.Length; i++)
            {
                if (board[i] == '•')
                {
                    GameManagerConsole.Write('*');
                }
                else if (board[i] == '*')
                {

                    Console.ForegroundColor = ConsoleColor.Red;
                    GameManagerConsole.Write(board[i]);
                }
                else
                {
                    GameManagerConsole.Write(board[i]);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            GameManagerConsole.WriteLine("\n" + Message);
        }
    }
}
