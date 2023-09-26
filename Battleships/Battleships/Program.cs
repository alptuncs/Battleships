﻿using System.Threading;
using System.Threading.Tasks;

namespace Battleships;

internal class Program
{
    static async Task Main(string[] args)
    {
        GameRunner gameSession = new GameRunner(new GameManagerFactory().Create(new AsciiGameUserInterface<IBattleshipGameObjectFactory>(new SystemConsole(), 10, 10, new AsciiBattleShipGameObjectFactory(), new ConsoleGameInputController())));

        await gameSession.Play();
    }
}