namespace Battleships;

public class InputCheck
{
    readonly Board board;

    public InputCheck(Board board)
    {
        this.board = board;
    }

    public string GetInputResult(Coordinate coordinate) =>
        ResultMessage(OutOfBounds(coordinate) ?? "Valid");

    private string? OutOfBounds(Coordinate coordinate) =>
        coordinate.XPos >= 0 && coordinate.XPos < board.Width &&
        coordinate.YPos >= 0 && coordinate.YPos < board.Height ?
        null : "OutOfBounds";


    private string ResultMessage(string inputFault) =>
        inputFault == "OutOfBounds" ? Messages.OUT_OF_BOUND : string.Empty;
}
