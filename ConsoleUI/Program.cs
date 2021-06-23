using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            PrintGuestsName();
            MultiLineAnimation();
            PrintWinner();

            Console.ReadKey();

        }

        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random rdm = new Random();

        private static string GetUserInput(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            { 
                Console.Write(message);
                input = Console.ReadLine();
            }
            return input;
        }

        private static void GetUserInfo()
        {
            string guestName;
            string otherGuest;
            do
            {
                guestName = GetUserInput("Please enter a guest: ");
                AddGuestsInRaffle(GenerateRandomNumber(), guestName);
                otherGuest = GetUserInput("Do you want to add another name (y/n)? ");
            }
            while (otherGuest == "y");
        }

        private static int GenerateRandomNumber()
        {
            return rdm.Next(min, max);
        }

        private static void AddGuestsInRaffle(int raffleNumber, string guest)
        {
            guests.Add(raffleNumber, guest);
        }

        private static void PrintGuestsName()
        {
            Console.WriteLine();
            foreach (KeyValuePair<int, string> kvp in guests)
            {
                Console.WriteLine("Raffle Number: {0}, Name: {1}", kvp.Key, kvp.Value);
            }
            Console.WriteLine("\nPress any key to start the drawing!");
            Console.ReadKey();
        }

        private static int GetRaffleNumber(Dictionary<int, string> guests)
        {
            int i = rdm.Next(guests.Count);
            return i;
        }

        private static void PrintWinner()
        {
            int winnerNumber = GetRaffleNumber(guests);
            Console.WriteLine($"\nThe winner is: {guests.ElementAt(winnerNumber).Value} with # {guests.ElementAt(winnerNumber).Key}");
        }

        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}
