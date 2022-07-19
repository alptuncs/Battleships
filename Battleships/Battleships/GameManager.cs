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
        List<Target> targets = new List<Target>();
        private int playerLives = 30;
        private int score = 0;
        private int shipValue = 0;
        private int consecutiveHits = 0;
        private string message = "";
        bool gameStatus = true;
        public GameManager(IConsole console, BoardManager playerBoard, BoardManager computerBoard, BoardRenderer boardRenderer)
        {
            this.console = console;
            _playerBoard = playerBoard;
            _computerBoard = computerBoard;
            _boardRenderer = boardRenderer;

            Target amiralGemisi = new Target(4, "east", "amiralGemisi");
            Target kruvazor = new Target(3, "north", "kruvazor");
            Target mayinGemisi = new Target(2, "east", "mayinGemisi");
            Target denizalti = new Target(1, "north", "denizalti");

            targets.Add(amiralGemisi);
            targets.Add(kruvazor);
            targets.Add(mayinGemisi);
            targets.Add(denizalti);

            foreach (Target target in targets)
            {
                computerBoard.RandomPlaceShip(5 - target.Size, target);
                shipValue += target.Size * target.Size * (5 - target.Size);
            }
        }
        public void play()
        {

            do
            {
                RenderGame();
                UpdateGame();
            } while (gameStatus);
            RenderGame();
        }
        private void FireMissile(BoardManager board, int i, int j)
        {
            if (board.IsHit(i, j))
            {
                message = "That coordinate has already been hit";
                playerLives--;
                consecutiveHits = 0;
            }
            else if (!board.HasShip(i, j))
            {
                board.HitSquare(i, j);
                message = "You missed...";
                playerLives--;
                consecutiveHits = 0;

            }
            else if (board.HasShip(i, j))
            {
                board.HitSquare(i, j);
                shipValue -= board.Board[i][j].shipType;
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
                playerInput = stringPlayerInput.Split(',');
                FireMissile(_computerBoard, int.Parse(playerInput[0]) - 1, int.Parse(playerInput[1]) - 1);
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
