namespace Battleships;

public interface IConsole
{
    void WriteLine(string message);

    void WriteLine(string message, params object[] args);

    void Write(char c);

    void Clear();

    string ReadLine();
}
