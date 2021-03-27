using KB_Games_UI_RockPaperScissors;
using KB_Games_UI_TicTacToe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KB_Games_UI_Main
{
    public class MainUI
    {
        public void Run()
        {
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of the option you would like to select:\n" +
                    "1: Play Rock, Paper, Scissors!\n" +
                    "2: Play Tic Tac Toe\n" +
                    "3: Play Third game yet to be determined lol\n" +
                    "4: Exit");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":

                        RockPaperScissors();
                        break;
                    case "2":
                        TicTacToe();
                        break;
                    case "3":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a vaild number between 1 and 4\n" +
                            "" +
                            "Press any key to continue......................");
                        Console.ReadKey();
                        break;
                }

            }
        }
        private void TicTacToe()
        {
            TTT_UI UI = new TTT_UI();
            UI.Run();
            Console.ReadKey();
        }

        private void RockPaperScissors()
        {
            RPS_UI UI = new RPS_UI();
            UI.Run();
        }
    }
}

