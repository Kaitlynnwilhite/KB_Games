using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB_Games_UI_TicTacToe
{
    public class TTT_UI
    {

        public void Run()
        {
            StartGame();
        }

        private void StartGame()
        {
            bool closeAsk = false;
            bool oneTurn = true;
            Random random = new Random();
            char[,] board;
            while (closeAsk !=true)
            {
                board = new char[3, 3]
                {
                    {' ', ' ', ' ', },
                    {' ', ' ', ' ', },
                    {' ', ' ', ' ', },
                };
                while (!closeAsk)
                {
                    if (oneTurn)
                    {
                        OneTurn();
                        if (CheckThree('X'))
                        {
                            EndGame("You Win.");
                            break;
                        }
                    }
                    else
                    {
                        ComputerTurn();
                        if (CheckThree('O'))
                        {
                            EndGame("You Lose.");
                            break;
                        }
                    }
                    oneTurn = !oneTurn;
                    if (CheckFullBoard())
                    {
                        EndGame("Draw.");
                        break;
                    }
                }
                if (!closeAsk)
                {
                    Console.WriteLine();
                    Console.WriteLine("Play Again, [y] (yes) or [e] (exit)");
                GetInput:
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Y:
                            break;
                        case ConsoleKey.E:
                            break;
                        default: goto GetInput;
                    }
                }
            }
            void OneTurn()
            {
                var (row, column) = (0, 0);
                bool moved = false;
                while (!moved && !closeAsk)
                {
                    Console.Clear();
                    RenderBoard();
                    Console.WriteLine();
                    Console.WriteLine("Choose a valid position and press enter.");
                    Console.SetCursorPosition(column * 6 + 1, row * 4 + 1);
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.UpArrow:
                            row = row <= 0 ? 2 : row - 1;
                            break;
                        case ConsoleKey.DownArrow:
                            row = row >= 2 ? 0 : row + 1;
                            break;
                        case ConsoleKey.LeftArrow:
                            column = column <= 0 ? 2 : column - 1;
                            break;
                        case ConsoleKey.RightArrow:
                            column = column >= 2 ? 0 : column + 1;
                            break;
                        case ConsoleKey.Enter:
                            if (board[row, column] is ' ')
                            {
                                board[row, column] = 'X';
                                moved = true;
                            }
                            break;
                        case ConsoleKey.Escape:
                            Console.Clear();
                            closeAsk = true;
                            break;
                        default:
                            Console.WriteLine("Please enter a valid move...");
                            break;
                    }
                }
            }
            void ComputerTurn()
            {
                var possibleMoves = new List<(int X, int Y)>();
                for (int i = 0; i < 3; i++)
                {
                    for (int z = 0; z < 3; z++)
                    {
                        if (board[i, z] == ' ')
                        {
                            possibleMoves.Add((i, z));
                        }
                    }
                }
                int index = random.Next(0, possibleMoves.Count);
                var (X, Y) = possibleMoves[index];
                board[X, Y] = '0';
            }
            bool CheckThree(char c) =>
                board[0, 0] == c && board[1, 0] == c && board[2, 0] == c ||
                board[0, 1] == c && board[1, 1] == c && board[2, 1] == c ||
                board[0, 2] == c && board[1, 2] == c && board[2, 2] == c ||
                board[0, 0] == c && board[0, 1] == c && board[0, 2] == c ||
                board[1, 0] == c && board[1, 1] == c && board[1, 2] == c ||
                board[2, 0] == c && board[2, 1] == c && board[2, 2] == c ||
                board[0, 0] == c && board[1, 1] == c && board[2, 2] == c ||
                board[2, 0] == c && board[1, 1] == c && board[0, 2] == c;
            bool CheckFullBoard() =>
                board[0, 0] != ' ' && board[1, 0] != ' ' && board[2, 0] != ' ' &&
                board[0, 1] != ' ' && board[1, 1] != ' ' && board[2, 1] != ' ' &&
                board[0, 2] != ' ' && board[1, 2] != ' ' && board[2, 2] != ' ';
            void RenderBoard()
            {
                Console.WriteLine();
                Console.WriteLine($" {board[0, 0]}  ║  {board[0, 1]}  ║  {board[0, 2]}");
                Console.WriteLine("    ║     ║");
                Console.WriteLine(" ═══╬═════╬═══");
                Console.WriteLine("    ║     ║");
                Console.WriteLine($" {board[1, 0]}  ║  {board[1, 1]}  ║  {board[1, 2]}");
                Console.WriteLine("    ║     ║");
                Console.WriteLine(" ═══╬═════╬═══");
                Console.WriteLine("    ║     ║");
                Console.WriteLine($" {board[2, 0]}  ║  {board[2, 1]}  ║  {board[2, 2]}");
            }
            void EndGame(string message)
            {
                Console.Clear();
                RenderBoard();
                Console.WriteLine();
                Console.Write(message);
            }
        }
    }
    
}

