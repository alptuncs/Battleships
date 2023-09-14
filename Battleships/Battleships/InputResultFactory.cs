namespace Battleships;

public static class InputResultFactory
{
    public static InputResult Create(string inputFault) =>
        inputFault == "WrongInput" ?
            new InputResult(Messages.WRONG_INPUT) :
            inputFault == "OutOfBounds" ?
                new InputResult(Messages.OUT_OF_BOUND) :
                new InputResult(string.Empty);
}

public class InputResult
{
    public string Message { get; }

    public InputResult(string message)
    {
        Message = message;
    }
}

