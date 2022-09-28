using System;
using System.Collections.Generic;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> board = GetNewBoard();
            string currentPlayer = "x";
            while (!IsGameOver(board))
            {
                DisplayBoard(board);

                int choice = GetMoveChoice(currentPlayer);
                MakeMove(board, choice, currentPlayer);

                currentPlayer = GetNextPlayer(currentPlayer);
            }

            DisplayBoard(board);
            Console.WriteLine("Good game. Thanks for playing!");
        }
        // This section gets a new instance of the board with the numbers 1-9 in place.
        // Then it returns a list of 9 strings representing each square.

        static List<string> GetNewBoard()
        {
            List<string> board = new List<string>();

            for (int i = 0; i <9; i++)
            {
                board.Add(i.ToString());
            }

            return board;
        }

        // This section displays the board in a 3x3 grid.
        static void DisplayBoard(List<string> board)
        {
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }

        // This section determines if the game is over because of a win or a tie1.
        // It returns true if the game is over.
        static bool IsGameOver(List<string> board)
        {
            bool isGameOver = false;
            if (IsWinner(board, "x") || IsWinner(board, "o") || IsTie(board))
            {
                isGameOver = true;
            }

            return isGameOver;
        }

        // This section determines if a player has a tic tac toe.

        static bool IsWinner(List<string> board, string player)
        {
            bool isWinner = false;

            if ((board[0] == player && board[1] == player && board[2] == player)
                || (board[3] == player && board[4] == player && board[5] == player)
                || (board[6] == player && board[7] == player && board[8] == player)
                || (board[0] == player && board[3] == player && board[6] == player)
                || (board[1] == player && board[4] == player && board[7] == player)
                || (board[2] == player && board[5] == player && board[8] == player)
                || (board[0] == player && board[4] == player && board[8] == player)
                || (board[2] == player && board[4] == player && board[6] == player)
                )
            {
                isWinner = true;
            }

            return isWinner; 
        }

        static bool IsTie(List<string> board)
        {
            // if there is a digit, then there are still moves to be made.
            bool foundDigit = false;
            
            foreach (string value in board)
            {
                if (char.IsDigit(value[0]))
                {
                    foundDigit = true;
                    break;
                }
            }

            return !foundDigit;
        }

        // This section cycles through the players (from x to o and o to x)

        static string GetNextPlayer(string currentPlayer)
        {
            string nextPlayer = "x";

            if (currentPlayer == "x")
            {
                nextPlayer = "o";
            }

            return nextPlayer;
        }

        // This section gets the 1-based spot number associated with the user's choice.

        static int GetMoveChoice(string currentPlayer)
        {
            Console.Write($"{currentPlayer}'s turn to choose a square (1-9): ");
            string move_string = Console.ReadLine();

            int choice = int.Parse(move_string) + 1;

            return choice;
        }

        // This section places the current players mark on the board at the desired spot.
        // However, it does NOT check to see if the spot is available.

        static void MakeMove(List<string> board, int choice, string currentPlayer)
        {
            // Converts teh 1-=based spot number into a 0-based index.
            int index = choice -1;
            board[index] = currentPlayer;
        }
    }
}