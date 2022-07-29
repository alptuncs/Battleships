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
                    if (i == 0 && j == 0) BoardGraphicString += "  1  2  3  4  5  6  7  8  9 10".Substring(0, BoardSurface[0].Length * 3) + "\n";

                    if (j == 0) BoardGraphicString += "ABCDEFGHIJ".Substring(i, 1);

                    BoardGraphicString += BoardSurface[i][j];
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
                    else if (boardManager.IsHit(new Coordinate(i, j)) && !boardManager.HasShip(new Coordinate(i, j))) BoardSurface[i][j] = "[•]";
                }
            }

            return InitializeBoardGraphicString();
        }
    }
}
