using System;
using System.Collections;


using System;
using System.Text.RegularExpressions;

namespace DelegateParser
{
    public class ConsoleParser
    {
        public delegate void OnWordDelegate(string word);
        public delegate void OnNumberDelegate(string number);
        public delegate void OnJunkDelegate(string junk);

        public void Run(OnWordDelegate onWord, OnNumberDelegate onNumber, OnJunkDelegate onJunk)
        {
            while (true)
            {
                string input = Console.ReadLine();
                Console.WriteLine("Write from Inside While");
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                if (IsWord(input))
                {
                    onWord?.Invoke(input);
                }
                else if (IsNumber(input))
                {
                    onNumber?.Invoke(input);
                }
                else
                {
                    onJunk?.Invoke(input);
                }
            }
        }

        private bool IsWord(string input)
        {
            return Regex.IsMatch(input, @"^[A-Za-z]+$");
        }

        private bool IsNumber(string input)
        {
            return Regex.IsMatch(input, @"^[0-9]+$");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write Line Testing");
            ConsoleParser parser = new ConsoleParser();
            parser.Run(
                onWord: word => Console.WriteLine("Word: " + word),
                onNumber: number => Console.WriteLine("Number: " + number),
                onJunk: junk => Console.WriteLine("Junk: " + junk)
            );
        }
    }
}
