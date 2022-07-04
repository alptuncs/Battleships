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
            string[][] board = CreateBoard();
            Random rnd = new Random();
            string shipCoordinates = rnd.Next(1, board.Length).ToString() + "," + rnd.Next(1, board[0].Length).ToString();
            PrintBoard(board);
            int lives = (board.Length + board[0].Length) / 2;
            bool succesfulAttempt = false;
            while (lives != 0)
            {

                succesfulAttempt = Attack(ref board, shipCoordinates, ref lives);
                if (succesfulAttempt == true)
                {
                    Console.Clear();
                    Console.WriteLine("You won");
                    break;
                }

            }
            if (lives == 0)
            {
                Console.Clear();
                Console.WriteLine("out of lives");
            }


        }

        static string[][] CreateBoard()
        {
            /* initializng the board and printing it on the console */

            Console.WriteLine("Enter the size of the board");
            /* using regex to enforce the input to be in acceptable format that can be parsed to int */
            Regex r = new Regex(@"^\d+x{1}\d+$");
            string userInput = Console.ReadLine();
            /* Input check */
            while (!r.IsMatch(userInput))
            {
                Console.WriteLine("Wrong input, please write in the format of (height)x(length) E.g. 4x6");
                userInput = Console.ReadLine();
            }
            /* initialize the board height and length based on user input */
            int boardHeight = int.Parse(userInput.Substring(0, userInput.IndexOf('x')));
            int boardlength = int.Parse(userInput.Substring(userInput.IndexOf('x') + 1));

            /* initialize the board with height and length */
            string[][] board = new string[boardHeight][];

            for (int i = 0; i < board.Length; i++)
            {
                string row = "";
                row = string.Concat(Enumerable.Repeat("[ ]*", boardlength));
                board[i] = row.Split('*');
            }
            Console.Clear();
            return board;
        }

        static void PrintBoard(string[][] board)
        {

            /* print the board */
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[i].Length; j++)
                {
                    Console.Write(board[i][j] + " ");
                }
                Console.Write("\n");
            }
        }

        static bool Attack(ref string[][] board, string shipCoordinates, ref int lives)
        {
            Regex y = new Regex(@"\d+,{1}\d+");

            Console.WriteLine("Write the coordinates for the attack");
            string attackCoordinates = Console.ReadLine();

            while (!y.IsMatch(attackCoordinates))
            {
                Console.WriteLine("Wrong input format, please enter the coordinates in the format (x),(y). E.g. 3,4");
                attackCoordinates = Console.ReadLine();
            }

            int yCoordinate = int.Parse(attackCoordinates.Substring(0, attackCoordinates.IndexOf(',')));
            int xCoordinate = int.Parse(attackCoordinates.Substring(attackCoordinates.IndexOf(',') + 1));

            while (yCoordinate > board.Length || xCoordinate > board[0].Length)
            {
                Console.WriteLine("Coordinates can not be outside the board, enter the coordinates according the the board size");
                attackCoordinates = Console.ReadLine();
                yCoordinate = int.Parse(attackCoordinates.Substring(0, attackCoordinates.IndexOf(',')));
                xCoordinate = int.Parse(attackCoordinates.Substring(attackCoordinates.IndexOf(',') + 1));
            }

            Console.Clear();

            if (attackCoordinates == shipCoordinates)
            {
                Console.WriteLine($"                                        lives:{lives}");
                board[xCoordinate - 1][yCoordinate - 1] = "[x]";
                PrintBoard(board);
                return true;
            }
            else
            {
                lives--;
                Console.WriteLine($"                                        lives:{lives}");
                PrintBoard(board);
                Console.WriteLine("Missed...");
                return false;
            }
        }
    }
}
