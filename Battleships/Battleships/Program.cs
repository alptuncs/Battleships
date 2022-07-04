using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /* initializng the board and printing it on the console */

            string[][] board = new string[10][];

            for (int i = 0; i < board.Length; i++)
            {
                board[i] = new string[] { "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]", "[ ]" };
            }

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    Console.Write(board[i][j] + " ");
                }
                Console.Write("\n");
            }

        }
    }
}
