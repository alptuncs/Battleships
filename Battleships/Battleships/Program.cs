﻿using System;
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

            /* initializng the board and printing it on the console */
            Console.WriteLine("Enter the size of the board");
            Regex r = new Regex(@"^\d+x{1}\d+$");
            string userInput = Console.ReadLine();
            while (!r.IsMatch(userInput))
            {
                Console.WriteLine("Wrong input, please write in the format of (height)x(length) E.g. 4x6");
                userInput = Console.ReadLine();
            }

            int boardHeight = int.Parse(userInput.Substring(0, userInput.IndexOf('x')));
            int boardlength = int.Parse(userInput.Substring(userInput.IndexOf('x') + 1));

            string[][] board = new string[boardHeight][];

            for (int i = 0; i < board.Length; i++)
            {
                string test = "";
                test = string.Concat(Enumerable.Repeat("[] ", boardlength));
                board[i] = test.Split(' ');
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
