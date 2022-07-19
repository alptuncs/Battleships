using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class GameManager
    {
        private IConsole console;
        private BoardManager _playerBoard;
        private BoardManager _computerBoard;
        private BoardRenderer _boardRenderer;

        public GameManager(IConsole console, BoardManager playerBoard, BoardManager computerBoard, BoardRenderer boardRenderer)
        {
            this.console = console;
            _playerBoard = playerBoard;
            _computerBoard = computerBoard;
            _boardRenderer = boardRenderer;
        }

        public void FireMissile(BoardManager board, int i, int j)
        {
            board.HitSquare(i, j);
        }

        public void RenderGame()
        {
            _boardRenderer.Render(_computerBoard);
            console.WriteLine("---------------------------");
            _boardRenderer.Render(_playerBoard);
        }


    }
}
