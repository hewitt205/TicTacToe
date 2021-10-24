using System;
using System.Threading;

namespace TicTacToe
{
    class Program
    {
        static char[] spaces = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int chosenSpace;
        static int flag;
        /// <summary>
        /// Draws the Board of the game using just text
        /// </summary>
        static void DrawBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", spaces[0], spaces[1], spaces[2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", spaces[3], spaces[4], spaces[5]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}  ", spaces[6], spaces[7], spaces[8]);
            Console.WriteLine("     |     |     ");
        }
        /// <summary>
        /// Check the game state and win status
        /// </summary>
        /// <returns></returns>
        static int Check()
        {
            //checking horizontal/vertical/diagonal wins
            if (spaces[0] == spaces[1] &&
                spaces[1] == spaces[2] || //row 1
                spaces[3] == spaces[4] &&
                spaces[4] == spaces[5] || //row 2
                spaces[6] == spaces[7] &&
                spaces[7] == spaces[8] ||  //row 3
                spaces[0] == spaces[3] &&
                spaces [3] == spaces[6] || //column 1
                spaces[1] == spaces[4] &&
                spaces[4] == spaces[7] || //column 2
                spaces[2] == spaces[5] &&
                spaces[5] == spaces[8] || //column 3
                spaces[0] == spaces[4] &&
                spaces[4] == spaces[8] || //right diagonal
                spaces[2] == spaces[4] &&
                spaces[4] == spaces[6] //left diagonal
                )
            {
                return 1;
            }
            else if (spaces[0] != '1' &&
                     spaces[1] != '2' &&
                     spaces[2] != '3' &&
                     spaces[3] != '4' &&
                     spaces[4] != '5' &&
                     spaces[5] != '6' &&
                     spaces[6] != '7' &&
                     spaces[7] != '8' &&
                     spaces[8] != '9')
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        static void DrawX(int pos)
        {
            spaces[pos] = 'X';
        }

        static void DrawO(int pos)
        {
            spaces[pos] = 'O';
        }


        //Game Loop here
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Player 1 will be X, player 2 is O" + "\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2's turn.");
                }
                else
                {
                    Console.WriteLine("Player 1's turn.");
                }

                Console.WriteLine("\n");
                DrawBoard();
                chosenSpace = int.Parse(Console.ReadLine()) - 1; //subtract 1 due to indexing at 0 but board count starts at 1

                if (spaces[chosenSpace] != 'X' &&
                    spaces[chosenSpace] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        DrawO(chosenSpace);
                    }
                    else
                    {
                        DrawX(chosenSpace);
                    }
                    player++;
                }
                else
                {
                    Console.WriteLine("This space is taken.");
                    Console.WriteLine("Wait while the board reloads. . .");
                    Thread.Sleep(2000);
                }

                flag = Check();
            } while (flag != 1 && flag != -1);

            Console.Clear();
            DrawBoard();

            if (flag ==1)
            {
                Console.WriteLine("Player {0} has won.", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Game is a tie.");
            }

            Console.ReadLine();
        }
    }
}
