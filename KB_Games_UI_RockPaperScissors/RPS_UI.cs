using KB_Games_UI_RockPaperScissors.ENUMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB_Games_UI_RockPaperScissors
{
    public class RPS_UI
    {
        int wins = 0;
        int losses = 0;
        public void Run()
        {
            StartGame();
        }

        private void StartGame()
        {
            System.Threading.Thread.Sleep(250);
            Random random = new Random();
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Rock, Paper< Scissors");
                Console.WriteLine();
            GetInput:
                Console.WriteLine("Choose 'r' (rock), 'p' (paper), 's' (scissors) or 'e' exit:");
                Move playerMove;
                switch (Console.ReadLine().ToLower())
                {
                    case "r":
                        playerMove = Move.Rock;
                        break;
                    case "p":
                        playerMove = Move.Paper;
                        break;
                    case "s":
                        playerMove = Move.Scissors;
                        break;
                    case "e":
                        Console.Clear();
                        return;
                    default: Console.WriteLine("Invalid Input, please try another input..."); goto GetInput;
                }
                Move computerMove = (Move)random.Next(3);
                Console.WriteLine($"Computer chose {computerMove}.");
                Moves(playerMove, computerMove);
                Console.WriteLine($"Score: {wins} wins, {losses} losses");
                Console.WriteLine($"Press any key to continue...");
                Console.ReadKey();
            }
        }

        private void Moves(Move playerMove, Move computerMove)
        {
            if (playerMove == Move.Rock && computerMove == Move.Paper)
            {
                Console.WriteLine($"You lose.");
                losses++;

            }
            else if (playerMove == Move.Paper && computerMove == Move.Scissors)
            {
                Console.WriteLine($"You lose.");
                losses++;
            }
            else if (playerMove == Move.Scissors && computerMove == Move.Rock)
            {
                Console.WriteLine($"You lose.");
                losses++;
            }
            else if (playerMove == Move.Rock && computerMove == Move.Scissors)
            {
                Console.WriteLine("You win!");

            }
            else if (playerMove == Move.Scissors && computerMove == Move.Paper)
            {
                Console.WriteLine("You win!");
            }
            else if (playerMove == Move.Paper && computerMove == Move.Rock)
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("Draw");
            }
        }
    }
}