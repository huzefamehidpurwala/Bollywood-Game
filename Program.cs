using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BollywoodGame
{
    internal class Program
    {
        public static string movieName = "7 Sweeney Todd: The Demon Barber of Fleet Street".ToLower();
        public static List<char> displayedChars = new List<char> { 'a', 'e', 'i', 'o', 'u' };
        public static int numOfAttempts = 9;
        public static int oldNumOfAttempts = 9;
        public static ConsoleKeyInfo userInput;

        public static void WinCenter(string str)
        {
            int num = Convert.ToInt32(Console.WindowWidth / 2 - str.Length / 2);
            for (int i = 0; i < num; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(str);
        }

        public static void ColorText(char str, bool check = false)
        {
            ConsoleColor currentforegroundcolor = Console.ForegroundColor;
            if (check)
            {
                Console.ForegroundColor = ConsoleColor.Green; 
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Red;
            }
            Console.Write(str);
            Console.ForegroundColor = currentforegroundcolor;
        }

        public static void printBollywood()
        {
            int num = Convert.ToInt32(Console.WindowWidth / 2 - 25 / 2);
            for (int i = 0; i < num; i++)
            {
                Console.Write(" ");
            }
            Console.Write("------- ");

            foreach (char character in "BOLLYWOOD")
            {
                if (oldNumOfAttempts > numOfAttempts)
                {
                    ColorText(character);
                    oldNumOfAttempts--;
                }
                else
                {
                    Console.Write(character);
                }
            }

            Console.WriteLine(" -------");
            oldNumOfAttempts = 9;
        }

        public static bool repetativeStart()
        {
            Console.Clear();
            string dashString = DashString();
            WinCenter($"------- You have {numOfAttempts} attempts -------\n");
            printBollywood();

            Console.WriteLine();
            WinCenter(dashString + '\n');

            Console.Write("\nGuess character: ");
            if (movieName.Contains(userInput.KeyChar))
            {
                ColorText(userInput.KeyChar, true);
            }
            else
            {
                ColorText(userInput.KeyChar);
            }
            if (dashString == movieName) return true;
            else return false;
        }

        public static string DashString()
        {
            string dashString = null;
            bool dashDisplay = true;
            foreach (char character in movieName)
            {
                for (int i = 0; i < displayedChars.Count; i++)
                {
                    dashDisplay = true;
                    if (character == displayedChars[i] || !Char.IsLetter(character))
                    {
                        dashString += character;
                        dashDisplay = false;
                        break;
                    }
                }
                if (dashDisplay) dashString += '_';
            }

            return dashString;
        }

        public static bool checkPresence(char character)
        {
            foreach (char item in displayedChars)
            {
                if (character == item) return true;
            }
            return false;
        }

        static void Main(/*string[] args*/)
        {
            bool winOrLoose = false;
            while (numOfAttempts > 0)
            {
                //userInput:
                winOrLoose = repetativeStart();
                if (!winOrLoose)
                {
                    userInput = Console.ReadKey(true);

                    if (!Char.IsLetterOrDigit(userInput.KeyChar))
                    {
                        Console.WriteLine("\nYou are disqualified. Input should be Alphabets only!");
                        goto exit;
                    }
                    else if (checkPresence(userInput.KeyChar))
                    {
                        Console.WriteLine("Input character is already present.");
                        continue;
                    }
                    else if (!movieName.Contains(userInput.KeyChar))
                    {
                        numOfAttempts--;
                    }
                    
                    displayedChars.Add(userInput.KeyChar);
                }
                else
                {
                    break;
                }
            }

            if (winOrLoose)
            {
                Console.Clear();
                WinCenter($"You win the game with {numOfAttempts} points.\n");
                WinCenter($"The Movie was '{movieName.ToUpper()}'\n");
            }
            else
            {
                Console.Clear();
                WinCenter($"You Loose the game.\n");
                WinCenter($"The Movie was '{movieName.ToUpper()}'\n");
            }
            
        exit:
            Console.WriteLine("\nApplication Terminated..!!");
            Console.Write("Press any key to continue...");
            Console.ReadKey(true);
        }
    }
}
