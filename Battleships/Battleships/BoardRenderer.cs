using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class BoardRenderer
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public string BoardGraphicString { get; private set; }
        public string[][] BoardSurface { get; private set; }

        public BoardRenderer(int height, int width)
        {
            this.Height = height;
            this.Width = width;
            InitializeBoardSurface();
        }

        public string InitializeBoardGraphicString()
        {
            BoardGraphicString = "";

            for (int i = 0; i < BoardSurface.Length; i++)
            {
                for (int j = 0; j < BoardSurface[i].Length; j++)
                {
                    BoardGraphicString += BoardSurface[i][j] + (j < BoardSurface[i].Length - 1 ? " " : "");
                }
                BoardGraphicString += i < BoardSurface.Length - 1 ? "\n" : "";
            }
            InitializeBoardSurface();
            return BoardGraphicString;
        }
        private void InitializeBoardSurface()
        {
            BoardSurface = new string[Height][];

            for (int i = 0; i < BoardSurface.Length; i++)
            {
                BoardSurface[i] = Enumerable.Repeat("[ ]", Width).ToArray();
            }
        }
        public string Render(BoardManager boardManager, bool hide)
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (boardManager.HasShip(new Coordinate(i, j)) && !hide) BoardSurface[i][j] = $"[{boardManager.Board[i, j].shipType}]";

                    if (boardManager.IsHit(new Coordinate(i, j)) && boardManager.HasShip(new Coordinate(i, j))) BoardSurface[i][j] = "[*]";

                    else if (boardManager.IsHit(new Coordinate(i, j)) && !boardManager.HasShip(new Coordinate(i, j))) BoardSurface[i][j] = "[X]";
                }
            }
            return InitializeBoardGraphicString();
        }
    }
}
