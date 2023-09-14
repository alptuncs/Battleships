using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Battleships;

public class GameManager
{
    public IConsole GameManagerConsole { get; private set; }
    public Board ComputerBoard { get; private set; }
    public BoardRenderer BoardRenderer { get; private set; }
    public List<Target> Targets { get; private set; }
    public int PlayerLives { get; private set; }
    public int Score { get; private set; }
    public int ConsecutiveHits { get; private set; }
    public string? Message { get; private set; }

    public GameManager(IConsole console, Board computerBoard, BoardRenderer boardRenderer, List<Target> targets)
    {
        GameManagerConsole = console;
        ComputerBoard = computerBoard;
        BoardRenderer = boardRenderer;
        Targets = targets;
        Console.OutputEncoding = Encoding.UTF8;
    }

    public void Initialize()
    {
        Score = 0;
        ConsecutiveHits = 0;
        PlayerLives = 30;
        Message = string.Empty;

        PlaceShips();

    }

    private void PlaceShips()
    {
        foreach (Target target in Targets)
        {
            ComputerBoard.PlaceShip(1, target);
        }
    }

    public void SetPlayerLives(int playerLives)
    {
        PlayerLives = playerLives;
    }

    public void UpdateGame(bool manualUpdate = false, string manualInput = "TakeUserInputForCoordinate")
    {
        string userInput = manualUpdate ? manualInput : TakeInput().ToUpper();

        SetInvalidInputMessage(InvalidInput(userInput));

        Action action = string.IsNullOrEmpty(Message) ?
            () =>
            {
                FireMissile(ComputerBoard, new Coordinate(userInput[0], int.Parse(userInput[2..])));
            }
        : () => { };

        action.Invoke();
    }

    private string TakeInput() =>
        GameManagerConsole.ReadLine();

    private InputResult InvalidInput(string input) =>
        WrongInput(input.ToUpper()) ??
        OutOfBounds(input.ToUpper()) ??
        InputResultFactory.Create("Valid");

    private InputResult? WrongInput(string playerInput) =>
        !Regex.IsMatch(playerInput, @"^^[A-Z]{1},\d{1,2}$") ?
            InputResultFactory.Create("WrongInput") : null;

    private InputResult? OutOfBounds(string playerInput) =>
        int.Parse(playerInput[2..]) <= 0 ||
        int.Parse(playerInput[2..]) > ComputerBoard.Width ||
        playerInput[0] - 'A' > ComputerBoard.Width ||
        playerInput[0] - 'A' < 0 ?
            InputResultFactory.Create("OutOfBounds") : null;

    private void SetInvalidInputMessage(InputResult ınputResult)
    {
        Message = ınputResult.Message != string.Empty ? ınputResult.Message : string.Empty;
    }

    private void FireMissile(Board board, Coordinate coordinate)
    {

        if (board[coordinate].IsHit || !board[coordinate].HasShip)
        {
            Message = board[coordinate].IsHit ? Messages.SAME_COORD : Messages.HIT_MISSED;
            PlayerLives--;
            ConsecutiveHits = 0;
        }
        else
        {
            ConsecutiveHits++;
            Score += 100 * ConsecutiveHits;
            ComputerBoard.RemoveShip(coordinate);
            Message = Messages.HIT_SUCCESS;
        }

        board[coordinate].HitSquare();
    }

    public bool ShouldRun()
    {
        if (PlayerLives == 0)
        {
            Message = Messages.OUT_OF_LIVES;
            return false;
        }
        else if (ComputerBoard.ShipCoordinates.Count == 0)
        {
            Message = Messages.YOU_WON;
            return false;
        }
        else
        {
            Message += "\n\n" + Messages.ENTER_COORDS;

            return true;
        }
    }

    public void RenderGame()
    {
        GameManagerConsole.Clear();
        GameManagerConsole.WriteLine($"Lives: {PlayerLives}    Score: {Score} \n");
        string board = BoardRenderer.Render(ComputerBoard);

        for (int i = 0; i < board.Length; i++)
        {
            if (board[i] == '•')
            {
                GameManagerConsole.Write('*');
            }
            else if (board[i] == '*')
            {

                Console.ForegroundColor = ConsoleColor.Red;
                GameManagerConsole.Write(board[i]);
            }
            else
            {
                GameManagerConsole.Write(board[i]);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        GameManagerConsole.WriteLine("\n" + Message);
    }
}
