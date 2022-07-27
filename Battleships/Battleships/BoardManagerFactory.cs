using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class BoardManagerFactory
    {
        public BoardManager Create(int height, int width)
        {
            var boardManager = new BoardManager(height, width);
            return boardManager.Initialize();
        }
    }
}
