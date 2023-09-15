using System.Text.RegularExpressions;

namespace Battleships;

public static class InputCheck
{
    public static string GetInputResult(string input, Board board) =>
        ResultMessage(WrongInput(input.ToUpper()) ?? OutOfBounds(input.ToUpper(), board) ?? "Valid");

    private static string? WrongInput(string playerInput) =>
        !Regex.IsMatch(playerInput, @"^^[A-Z]{1},\d{1,2}$") ?
            "WrongInput" : null;

    private static string? OutOfBounds(string playerInput, Board board) =>
        int.Parse(playerInput[2..]) <= 0 ||
        int.Parse(playerInput[2..]) > board.Width ||
        playerInput[0] - 'A' >= board.Width ||
        playerInput[0] - 'A' < 0 ?
            "OutOfBounds" : null;

    private static string ResultMessage(string inputFault) =>
        inputFault == "WrongInput" ?
            Messages.WRONG_INPUT :
            inputFault == "OutOfBounds" ?
                Messages.OUT_OF_BOUND :
                string.Empty;
}
