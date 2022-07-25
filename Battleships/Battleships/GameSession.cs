using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    internal class GameSession
    {
        GameManager gameManager;

        public GameSession(GameManager gameManager)
        {
            this.gameManager = gameManager;
            gameManager.Initialize();
        }

        public void Play()
        {
            do
            {
                gameManager.RenderGame();
                gameManager.UpdateGame();
            } while (gameManager.GameStatus);

            gameManager.RenderGame();
        }
    }
}
