using System.Linq;

namespace Battleships
{
    public class BoardRenderer
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public string? BoardGraphicString { get; private set; }
        public string[][] BoardSurface { get; private set; }

        public BoardRenderer(int height, int width)
        {
            Height = height;
            Width = width;
            BoardSurface = InitializeBoardSurface();
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

        private string[][] InitializeBoardSurface()
        {
            BoardSurface = new string[Height][];

            for (int i = 0; i < BoardSurface.Length; i++)
            {
                BoardSurface[i] = Enumerable.Repeat("[ ]", Width).ToArray();
            }

            return BoardSurface;
        }

        public string Render(BoardManager boardManager)
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (boardManager[i, j].IsHit && boardManager[i, j].HasShip) BoardSurface[i][j] = "[*]";
                    else if (boardManager[i, j].IsHit && !boardManager[i, j].HasShip) BoardSurface[i][j] = "[•]";
                }
            }

            return InitializeBoardGraphicString();
        }
    }
}
