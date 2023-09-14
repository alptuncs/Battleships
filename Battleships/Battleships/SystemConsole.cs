﻿using System;

namespace Battleships;

public class SystemConsole : IConsole
{
    public void WriteLine(string text, params object[] args) => Console.WriteLine(text, args);

    public void WriteLine(string text) => Console.WriteLine(text);

    public string ReadLine() => Console.ReadLine() ?? "";

    public void Clear() => Console.Clear();

    public void Write(char c) => Console.Write(c);
}
