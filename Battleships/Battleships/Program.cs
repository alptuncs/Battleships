using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Battleships
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameSession gameSession = new GameSession(new GameManagerFactory().Create());

            gameSession.Play();
        }
    }
}
