using System.Text.RegularExpressions;

namespace Battleships;

public class InputCheck
{
    public Coordinate Coordinate { get; set; }
    public string Message { get; set; }

    public InputCheck(string input, Board board)
    {
        Message = GetInputResult(input, board);
        Coordinate = new Coordinate(input[0], int.Parse(input[2..]));
    }

    public string GetInputResult(string input, Board board) =>
        ResultMessage(WrongInput(input.ToUpper()) ?? OutOfBounds(input.ToUpper(), board) ?? "Valid");

    private string? WrongInput(string playerInput) =>
        !Regex.IsMatch(playerInput, @"^^[A-Z]{1},\d{1,2}$") ?
            "WrongInput" : null;

    private string? OutOfBounds(string playerInput, Board board) =>
        int.Parse(playerInput[2..]) <= 0 ||
        int.Parse(playerInput[2..]) > board.Width ||
        playerInput[0] - 'A' >= board.Width ||
        playerInput[0] - 'A' < 0 ?
            "OutOfBounds" : null;

    private string ResultMessage(string inputFault) =>
        inputFault == "WrongInput" ?
            Messages.WRONG_INPUT :
            inputFault == "OutOfBounds" ?
                Messages.OUT_OF_BOUND :
                string.Empty;
}
