﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using System.Media;
using System.Threading;

namespace Gaugan
{
    internal class Program
    {
        class Dice
        {
            public static Random random = new Random();

            public static int Roll()
            {
                return random.Next(1, 7);
            }
        }

        static void Main(string[] args)
        {
            string name;
            int playerMoney;

            do
            {                      //TODO Publish it to GitHUB and record preview :D
                Console.ReadKey(); //TODO delete this line, its only for videoing to have a control on start
                Welcome();
                Console.WriteLine("");
                PressEnter();
                LoadingAnim();
                Console.WriteLine("Please enter your name:");
                name = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(name))
                {
                    LoadingAnim();
                    Console.Clear();
                    SecurityInfo();
                    Console.WriteLine(" We don't have any anonymous folks here. Please share your name.");
                    Console.WriteLine("");
                }
                else
                {
                    Console.Clear();
                    BarEntrence();
                    LoadingAnim();
                    BarStartPlaying();
                    Console.WriteLine($" You feeling lucky tonight, {name}? How 'bout we roll some dice and see where the night takes us?");
                    Console.WriteLine("");
                    PressEnter();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Thread.Sleep(700);
                    Console.Write($"{name}:");
                    Console.ResetColor();
                    PlayerDialog();
                    Console.WriteLine();
                    PressEnter();
                    LoadingAnim();
                    SissyReaction();
                    LoadingAnim();
                    BarStartPlaying();
                    SissyTalk();
                    Console.WriteLine("");
                    PressEnter();
                    Console.Clear();     
                }

            } while (string.IsNullOrEmpty(name)); // Repeat the loop if the name is null or empty

            do
            {
                BarStartPlaying();
                HowMuch();
                Console.WriteLine("");
                Console.WriteLine("Cash in your pocket $USD:");
                string playerMoneyStr = Console.ReadLine(); // Assign value inside the loop

                // Convert string into integer
                if (int.TryParse(playerMoneyStr, out playerMoney) && playerMoney >= 1)
                {
                    LoadingAnim();
                    MePlayerBetting();
                    LoadingAnim();
                    PlayerDialogV2(name);
                    break; // Exit the loop since valid input is provided
                }
                else
                {
                    Console.WriteLine("");
                    Console.Clear();
                    BarStartPlaying();
                    Console.WriteLine(" No time for games, my friend... when the money is in the game.");
                    continue; // Repeat the loop if input is not a valid integer
                }

            } while (true); // Infinite loop; exits only when valid input is provided

            do
            {
                int barmanResultV1 = Dice.Roll();
                int barmanResultV2 = Dice.Roll();

                int playerResultV1 = Dice.Roll();
                int playerResultV2 = Dice.Roll();

                LoadingAnim();
                //barman rolling
                BarStartPlaying();
                Thread.Sleep(700);
                Console.Write(" First Roll: ");
                Thread.Sleep(1700);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(barmanResultV1);
                Console.ResetColor();
                Thread.Sleep(700);
                Console.Write(", Second Roll: ");
                Thread.Sleep(1700);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(barmanResultV2);
                Console.ResetColor();
                Console.WriteLine("");

                //player rolling
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Thread.Sleep(1700);
                Console.Write($"{name}: ");
                Console.ResetColor();
                Thread.Sleep(700);
                Console.Write("First Roll: ");
                Thread.Sleep(1000);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(playerResultV1);
                Console.ResetColor();
                Thread.Sleep(700);
                Console.Write(", Second Roll: ");
                Thread.Sleep(1700);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(playerResultV2);
                Console.ResetColor();
                Console.WriteLine("");

                int barmanTotalRolled = barmanResultV1 + barmanResultV2;
                int playerTotalRolled = playerResultV1 + playerResultV2;

                int playerTotalMoney = playerMoney * 2;

                DateTime currentTime = DateTime.Now;


                // Convert string into integer
                if (barmanTotalRolled > playerTotalRolled)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("");
                    Console.WriteLine($"Barman rolled: {barmanTotalRolled}");
                    PressEnter();
                    LoadingAnim();
                    BarmanWonSoul();
                    Console.ResetColor();
                    Thread.Sleep(700);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Wake up {name}...");
                    BadGameOver();
                    break; // Exit the loop since valid input is provided
                }
                else if(playerTotalRolled > barmanTotalRolled)
                {
                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(name);
                    Console.WriteLine($" rolled: {playerTotalRolled} , bet ${playerMoney} and won ${playerTotalMoney}!");
                    Console.WriteLine("");
                    PressEnter();
                    LoadingAnim();
                    Console.ResetColor();
                    GreatVictoryPhrase();
                    Thread.Sleep(100);
                    Console.Write(currentTime);
                    Thread.Sleep(1000);
                    GoodGameOver();
                    break; // Exit the loop since valid input is provided
                }
                else if(barmanTotalRolled == playerTotalRolled)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("DRAW!");
                    Thread.Sleep(700);
                    continue; // Repeat the loop if input is not a valid integer
                }

            } while (true); // Infinite loop; exits only when valid input is provided


            //Console.WriteLine($"{name} bets ${playerMoney}");
            //Console.WriteLine($"DZIAŁA MOZNA LECIEC DALEJ {playerMoney} NA KONCIE WARIAT"); // Now 'playerMoney' is accessible outside the loop

            // FUNCTIONS START
            static void LoadingAnim()
            {
                Console.Clear();
                Thread.Sleep(550);
                Console.Write(".");
                Thread.Sleep(550);
                Console.Write(".");
                Thread.Sleep(550);
                Console.Write(".");
                Thread.Sleep(550);
                Console.Clear();
            }
            static void BarEntrence()
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Thread.Sleep(100);
                Console.Write("* ");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("g");
                Thread.Sleep(100);
                Console.Write(" t");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write(" t");
                Thread.Sleep(100);
                Console.Write("h");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write(" b");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write(" *");
                Thread.Sleep(1500);
                Console.Clear();
                Console.ResetColor();
            }
            static void BarStartPlaying()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Thread.Sleep(700);
                Console.Write("B");
                Thread.Sleep(100);
                Console.Write("A");
                Thread.Sleep(100);
                Console.Write("R");
                Thread.Sleep(100);
                Console.Write("M");
                Thread.Sleep(100);
                Console.Write("A");
                Thread.Sleep(100);
                Console.Write("N");
                Thread.Sleep(100);
                Console.Write(":");
                Thread.Sleep(200);
                Console.ResetColor();
            }
            static void SecurityInfo()
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Thread.Sleep(700);
                Console.Write("S");
                Thread.Sleep(100);
                Console.Write("E");
                Thread.Sleep(100);
                Console.Write("C");
                Thread.Sleep(100);
                Console.Write("U");
                Thread.Sleep(100);
                Console.Write("R");
                Thread.Sleep(100);
                Console.Write("I");
                Thread.Sleep(100);
                Console.Write("T");
                Thread.Sleep(100);
                Console.Write("Y");
                Thread.Sleep(100);
                Console.Write(":");
                Thread.Sleep(200);
                Console.ResetColor();
            }
            static void PlayerDialog()
            {
                Thread.Sleep(700);
                Console.Write(" L");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("'"); // Single quote for "Let's"
                Thread.Sleep(100);
                Console.Write("s");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("R");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write("!");
                Console.WriteLine("");
                Thread.Sleep(100);
            }
            static void PressEnter()
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Thread.Sleep(1000);
                Console.WriteLine("(Press Enter to agree)");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }

            static void SissyReaction()
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Thread.Sleep(100);
                Console.Write("* ");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("h");
                Thread.Sleep(100);
                Console.Write("e ");
                Thread.Sleep(100);
                Console.Write("b");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("d");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("r ");
                Thread.Sleep(100);
                Console.Write("s");
                Thread.Sleep(100);
                Console.Write("m");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("d ");
                Thread.Sleep(100);
                Console.Write("s");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("g");
                Thread.Sleep(100);
                Console.Write("h");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write("y ");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("d ");
                Thread.Sleep(100);
                Console.Write("b");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("g");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("n ");
                Thread.Sleep(100);
                Console.Write("s");
                Thread.Sleep(100);
                Console.Write("p");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("k");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("g ");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("n ");
                Thread.Sleep(100);
                Console.Write("a ");
                Thread.Sleep(100);
                Console.Write("m");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write("e ");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("f");
                Thread.Sleep(100);
                Console.Write("f");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("m");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("e ");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("e ");
                Thread.Sleep(100);
                Console.Write("*");
                Thread.Sleep(1500);
                Console.ResetColor();
            }
            static void SissyTalk()
            {
                Thread.Sleep(700);
                Console.Write(" O");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("h");
                Thread.Sleep(100);
                Console.Write(", ");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("w");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("f");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("g");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write("u");
                Thread.Sleep(100);
                Console.Write("c");
                Thread.Sleep(100);
                Console.Write("k");
                Thread.Sleep(100);
                Console.Write("y");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("g");
                Thread.Sleep(100);
                Console.Write("h");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("?");
                Thread.Sleep(100);
                Console.Write(".");
                Thread.Sleep(100);
                Console.Write(".");
                Thread.Sleep(100);
                Console.Write(".");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("R");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("h");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("d");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("c");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write(",");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("d");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("g");
                Thread.Sleep(100);
                Console.Write("!");
                Console.WriteLine("");
            }
            static void Welcome()
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
                Thread.Sleep(700);
                Console.Write(" W");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write("c");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("m");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("h");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("D");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("K");
                Thread.Sleep(100);
                Console.Write("U");
                Thread.Sleep(100);
                Console.Write("'");
                Thread.Sleep(100);
                Console.Write("s");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("D");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("c");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("R");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("G");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("m");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("! ");
                Console.ResetColor();
                Console.WriteLine("");
            }
            static void HowMuch()
            {
                Thread.Sleep(700);
                Console.Write(" H");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("w");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("m");
                Thread.Sleep(100);
                Console.Write("u");
                Thread.Sleep(100);
                Console.Write("c");
                Thread.Sleep(100);
                Console.Write("h");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("m");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("y");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("y");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("u");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("w");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("b");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("?");
                Console.WriteLine("");
                Thread.Sleep(100);
            }
            static void MePlayerBetting()
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Thread.Sleep(700);
                Console.Write("* ");
                Thread.Sleep(700);
                Console.Write("T");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("k");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("g");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("m");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("y");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("u");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("f");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("h");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("p");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("c");
                Thread.Sleep(100);
                Console.Write("k");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("d");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("p");
                Thread.Sleep(100);
                Console.Write("u");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("g");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("h");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("b");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write(" *");
                Thread.Sleep(700);
                Console.ResetColor();
            }
            static void PlayerDialogV2(string name)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Thread.Sleep(700);
                Console.Write($"{name}: ");
                Console.ResetColor();
                Thread.Sleep(700);
                Console.Write("W");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("t ");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("m");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("u");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write(".");
                Thread.Sleep(100);
                Console.Write(".");
                Thread.Sleep(100);
                Console.Write(". ");
                Thread.Sleep(100);
                Console.Write("W");
                Thread.Sleep(100);
                Console.Write("h");
                Thread.Sleep(100);
                Console.Write("y ");
                Thread.Sleep(100);
                Thread.Sleep(100);
                Console.Write("d");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("d ");
                Thread.Sleep(100);
                Console.Write("I ");
                Thread.Sleep(100);
                Console.Write("d");
                Thread.Sleep(100);
                Console.Write("o ");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("? ");
                Thread.Sleep(100);
                Console.Write("I");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("d");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("'"); // Single quote for "don't"
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("v");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("k");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("w");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("h");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write("u");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("s");
                Thread.Sleep(100);
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("y");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write(".");
                Thread.Sleep(100);
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("S");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("m");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("h");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("g");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("s");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("w");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("g");
                Thread.Sleep(100);
                Console.Write(".");
                Thread.Sleep(1500);
                Console.WriteLine("");
                Console.WriteLine("");
                PressEnter();
            }
            static void BarmanWonSoul()
            {
                Thread.Sleep(700);
                Console.Write(" a");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("d");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("w");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write(".");
                Thread.Sleep(100);
                Console.Write(".");
                Thread.Sleep(100);
                Console.Write(".");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("y");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("u");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("s");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("u");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write(".");
                Thread.Sleep(100);
                Console.WriteLine("");
                PressEnter();
            }
            static void GreatVictoryPhrase()
            {
                SecurityInfo();
                Thread.Sleep(100);
                Console.Write(" C");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("g");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("u");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write("a");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("n");
                Thread.Sleep(100);
                Console.Write("s");
                Thread.Sleep(100);
                Console.Write("!");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("y");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("u");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("v");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("c");
                Thread.Sleep(100);
                Console.Write("t");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write("y");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("w");
                Thread.Sleep(100);
                Console.Write("i");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write("l");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("b");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("m");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("m");
                Thread.Sleep(100);
                Console.Write("b");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("d");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("f");
                Thread.Sleep(100);
                Console.Write("o");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("v");
                Thread.Sleep(100);
                Console.Write("e");
                Thread.Sleep(100);
                Console.Write("r");
                Thread.Sleep(100);
                Console.Write(". ");
                Thread.Sleep(100);
            }
            static void GoodGameOver()
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("");
                Thread.Sleep(700);
                Console.Write(" G");
                Thread.Sleep(100);
                Console.Write("A");
                Thread.Sleep(100);
                Console.Write("M");
                Thread.Sleep(100);
                Console.Write("E");
                Thread.Sleep(100);
                Console.Write(" ");
                Thread.Sleep(100);
                Console.Write("O");
                Thread.Sleep(100);
                Console.Write("V");
                Thread.Sleep(100);
                Console.Write("E");
                Thread.Sleep(100);
                Console.Write("R");
                Thread.Sleep(100);
                Console.Write("!");
                Thread.Sleep(900);
                Environment.Exit(0);
                Console.ResetColor();
                Console.ReadKey();
            }
            static void BadGameOver()
            {
                Console.Clear();
                Thread.Sleep(700);
                Console.Write(" T");
                Thread.Sleep(200);
                Console.Write("h");
                Thread.Sleep(200);
                Console.Write("e");
                Thread.Sleep(200);
                Console.Write(" ");
                Thread.Sleep(200);
                Console.Write("M");
                Thread.Sleep(200);
                Console.Write("a");
                Thread.Sleep(200);
                Console.Write("t");
                Thread.Sleep(200);
                Console.Write("r");
                Thread.Sleep(200);
                Console.Write("i");
                Thread.Sleep(200);
                Console.Write("x");
                Thread.Sleep(200);
                Console.Write(" ");
                Thread.Sleep(200);
                Console.Write("h");
                Thread.Sleep(200);
                Console.Write("a");
                Thread.Sleep(200);
                Console.Write("s");
                Thread.Sleep(200);
                Console.Write(" ");
                Thread.Sleep(200);
                Console.Write("y");
                Thread.Sleep(200);
                Console.Write("o");
                Thread.Sleep(200);
                Console.Write("u");
                Thread.Sleep(200);
                Console.Write(" ");
                Thread.Sleep(200);
                Console.Write(".");
                Thread.Sleep(200);
                Console.Write(".");
                Thread.Sleep(200);
                Console.Write(".");
                Thread.Sleep(200);
                Console.Write(" ");
                Thread.Sleep(200);
                Console.Write(".");
                Thread.Sleep(200);
                Console.Write(".");
                Thread.Sleep(200);
                Console.Write(".");
                Thread.Sleep(900);
                Environment.Exit(0);
            }
            // FUNCTIONS END


        }
    }
}
