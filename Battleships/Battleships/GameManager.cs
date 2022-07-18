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
        private BoardManager playerBoard;
        private BoardManager computerBoard;
        private BoardRenderer boardRenderer;

        public GameManager(IConsole console, BoardManager playerBoard, BoardManager computerBoard, BoardRenderer boardRenderer)
        {
            this.console = console;
            this.playerBoard = playerBoard;
            this.computerBoard = computerBoard;
            this.boardRenderer = boardRenderer;
        }


    }
}
