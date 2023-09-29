namespace Battleships;

public class BoardFactory
{
    public static Board Create(int height, int width)
    {
        var board = new Board(height, width);
        return board.Initialize();
    }
}
