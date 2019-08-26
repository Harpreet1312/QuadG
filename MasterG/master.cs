using System;
namespace MasterG
{
    public class master
    {
        public master()
        {
        }

        public void Start()
        {
            //Generate random number between 1 and 6
            string answercode = RandomCode();
            //Console.WriteLine(answercode);

            Console.WriteLine("Enter 4-digit Number");
            string input;
            int maximumTurns = 10;

            //Loop for checking the maximun turns
            while (maximumTurns != 0)
            {
                input = Console.ReadLine();
                maximumTurns -= 1;

                //Check for 4 digit number 
                if (ValidateInput(input))
                {
                    // Check if the entered number is equal to the generated answercode otherwise display signs 
                    CheckCode(input, answercode);
                    DisplaySigns(input, answercode);
                }

                else
                {
                    Console.WriteLine("Enter correct number of digits");
                }
            }
            //Print if the user has lost the game 
            PrintWinOrLoseMessage(false, answercode);
        }

        static void CheckCode(string input, string code)
        {

            if (input == code)
            {
                PrintWinOrLoseMessage(true, code);
            }

        }

        static Random random = new Random();
        static string RandomCode()
        {
            return random.Next(2, 6).ToString() +
            random.Next(2, 6).ToString() +
            random.Next(2, 6).ToString() +
            random.Next(2, 6).ToString();
        }

        static bool ValidateInput(string code)
        {
            int num;
            return code.Length == 4 && int.TryParse(code, out num);
        }
        static void DisplaySigns(string input, string code)
        {
            for (int i = 0; i < input.Length; i++)
                if (input[i] == code[i])
                {

                    Console.Write("+");
                }
                else if (code.Contains(input[i]) && input[i] != code[i])
                {

                    Console.Write("-");
                }
                else
                {
                    Console.Write(" ");
                }
            Console.WriteLine();
        }

        static void PrintWinOrLoseMessage(bool hasWon, string code)
        {
            Console.Clear();
            if (hasWon == true) { Console.WriteLine("You won! The code is {0}.", code); }
            else
            {
                Console.WriteLine("You lost! The correct code is {0}.", code);
            }
            Console.ReadKey(true);

        }

    }
}
